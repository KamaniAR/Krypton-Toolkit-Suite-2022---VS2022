﻿#region BSD License
/*
 * 
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, All rights reserved.
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), Giduac & Ahmed Abdelhameed et al. 2017 - 2025. All rights reserved.
 *  
 *  Modified: Monday 12th April, 2021 @ 18:00 GMT
 *
 */
#endregion

namespace Krypton.Ribbon
{
    /// <summary>
    /// Extends the ViewComposite by creating and laying out elements to represent ribbon group lines.
    /// </summary>
    internal class ViewLayoutRibbonGroupLines : ViewComposite,
                                                IRibbonViewGroupContainerView
    {
        #region Static Definitions

        private const int DEFAULT_GAP = 2;

        #endregion

        #region Type Definitions
        private class ItemToView : Dictionary<IRibbonGroupItem, ViewBase>;
        private class ViewToItem : Dictionary<ViewBase, IRibbonGroupItem>;
        private class ViewToGap : Dictionary<ViewBase, int>;
        private class SizeList : List<Size>;
        private class ViewList : List<ViewBase>;
        #endregion

        #region Instance Fields
        private readonly KryptonRibbon _ribbon;
        private readonly KryptonRibbonGroupLines _ribbonLines;
        private ViewDrawRibbonDesignGroupLines _viewAddItem;
        private readonly NeedPaintHandler? _needPaint;
        private GroupItemSize _currentSize;
        private ItemToView _itemToView;
        private ViewToItem _viewToItem;
        private readonly ViewToGap _viewToLargeGap;
        private readonly ViewToGap _viewToMediumGap;
        private readonly ViewToGap _viewToSmallGap;
        private ViewToGap _viewToGap;
        private readonly SizeList _sizeLargeList;
        private readonly SizeList _sizeMediumList;
        private readonly SizeList _sizeSmallList;
        private SizeList _sizeList;
        private readonly ViewList _viewLargeList;
        private readonly ViewList _viewMediumList;
        private readonly ViewList _viewSmallList;
        private ViewList _viewList;
        private int _split1Large;
        private int _split1Medium;
        private int _split1Small;
        private int _split2Small;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewLayoutRibbonGroupLines class.
        /// </summary>
        /// <param name="ribbon">Owning ribbon control instance.</param>
        /// <param name="ribbonLines">Reference to lines definition.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public ViewLayoutRibbonGroupLines([DisallowNull] KryptonRibbon? ribbon,
                                          [DisallowNull] KryptonRibbonGroupLines? ribbonLines,
                                          [DisallowNull] NeedPaintHandler? needPaint)
        {
            Debug.Assert(ribbon is not null);
            Debug.Assert(ribbonLines is not null);
            Debug.Assert(needPaint is not null);

            // Cache references
            _ribbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));
            _ribbonLines = ribbonLines ?? throw new ArgumentNullException(nameof(ribbonLines));
            _needPaint = needPaint ?? throw new ArgumentNullException(nameof(needPaint));

            // Associate the component with this view element for design time selection
            Component = _ribbonLines;

            // Use hashtable to store relationships
            _itemToView = new ItemToView();
            _viewToItem = new ViewToItem();
            _sizeLargeList = [];
            _sizeMediumList = [];
            _sizeSmallList = [];
            _viewLargeList = [];
            _viewMediumList = [];
            _viewSmallList = [];
            _viewToLargeGap = new ViewToGap();
            _viewToMediumGap = new ViewToGap();
            _viewToSmallGap = new ViewToGap();

            // Get the initial size used for sizing and positioning
            ApplySize(ribbonLines.ItemSizeCurrent);

            // Hook into changes in the ribbon triple definition
            _ribbonLines.PropertyChanged += OnLinesPropertyChanged;
            _ribbonLines.LinesView = this;

            // At design time we want to track the mouse and show feedback
            if (_ribbon.InDesignMode)
            {
                var controller = new ViewHightlightController(this, needPaint);
                controller.ContextClick += OnContextClick;
                MouseController = controller;
            }
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewLayoutRibbonGroupLines:{Id}";

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Must unhook to prevent memory leaks
                _ribbonLines.PropertyChanged -= OnLinesPropertyChanged;
            }

            base.Dispose(disposing);
        }
        #endregion

        #region CurrentSize
        /// <summary>
        /// Let other views discover our current size.
        /// </summary>
        public GroupItemSize CurrentSize
        {
            get => _currentSize;

            set
            {
                _currentSize = value;

                if (_viewAddItem != null)
                {
                    _viewAddItem.CurrentSize = value;
                }
            }
        }
        #endregion

        #region GetFirstFocusItem
        /// <summary>
        /// Gets the first focus item from the container.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetFirstFocusItem()
        {
            ViewBase? view = null;

            // Scan all the children, which must be containers
            foreach (ViewBase child in this)
            {
                // Only interested in visible children!
                if (child.Visible)
                {
                    // Cast to correct type
                    // Is this a container item
                    if (child is IRibbonViewGroupContainerView container)
                    {

                        // If it can provide a view, then use it
                        view = container.GetFirstFocusItem();
                        if (view != null)
                        {
                            break;
                        }
                    }
                    else if (child is IRibbonViewGroupItemView item) // Cast to correct type
                    {

                        // If it can provide a view, then use it
                        view = item.GetFirstFocusItem();
                        if (view != null)
                        {
                            break;
                        }
                    }
                }
            }

            return view!;
        }
        #endregion

        #region GetLastFocusItem
        /// <summary>
        /// Gets the last focus item from the container.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetLastFocusItem()
        {
            ViewBase? view = null;

            // Scan all the children, which must be containers
            foreach (ViewBase child in Reverse())
            {
                // Only interested in visible children!
                if (child.Visible)
                {
                    // Cast to correct type
                    // Is this a container item
                    if (child is IRibbonViewGroupContainerView container)
                    {

                        // If it can provide a view, then use it
                        view = container.GetLastFocusItem();
                        if (view != null)
                        {
                            break;
                        }
                    }
                    else if (child is IRibbonViewGroupItemView item) // Cast to correct type
                    {

                        // If it can provide a view, then use it
                        view = item.GetLastFocusItem();
                        if (view != null)
                        {
                            break;
                        }
                    }
                }
            }

            return view!;
        }
        #endregion

        #region GetNextFocusItem
        /// <summary>
        /// Gets the next focus item based on the current item as provided.
        /// </summary>
        /// <param name="current">The view that is currently focused.</param>
        /// <param name="matched">Has the current focus item been matched yet.</param>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
        {
            ViewBase? view = null;

            // Scan all the children, which must be containers
            foreach (ViewBase child in this)
            {
                // Only interested in visible children!
                if (child.Visible)
                {
                    // Cast to correct type
                    // Is this a container item
                    if (child is IRibbonViewGroupContainerView container)
                    {
                        // Already matched means we need the next item we come across,
                        // otherwise we continue with the attempt to find next
                        view = matched
                            ? container.GetFirstFocusItem()
                            : container.GetNextFocusItem(current, ref matched);

                        if (view != null)
                        {
                            break;
                        }
                    }
                    else if (child is IRibbonViewGroupItemView item) // Cast to correct type
                    {
                        // Already matched means we need the next item we come across,
                        // otherwise we continue with the attempt to find next
                        view = matched ? item.GetFirstFocusItem() : item.GetNextFocusItem(current, ref matched);

                        if (view != null)
                        {
                            break;
                        }
                    }
                }
            }

            return view!;
        }
        #endregion

        #region GetPreviousFocusItem
        /// <summary>
        /// Gets the previous focus item based on the current item as provided.
        /// </summary>
        /// <param name="current">The view that is currently focused.</param>
        /// <param name="matched">Has the current focus item been matched yet.</param>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
        {
            ViewBase? view = null;

            // Scan all the children, which must be containers
            foreach (ViewBase child in Reverse())
            {
                // Only interested in visible children!
                if (child.Visible)
                {
                    // Cast to correct type
                    // Is this a container item
                    if (child is IRibbonViewGroupContainerView container)
                    {
                        // Already matched means we need the next item we come across,
                        // otherwise we continue with the attempt to find previous
                        view = matched
                            ? container.GetLastFocusItem()
                            : container.GetPreviousFocusItem(current, ref matched);

                        if (view != null)
                        {
                            break;
                        }
                    }
                    else if (child is IRibbonViewGroupItemView item) // Cast to correct type
                    {
                        // Already matched means we need the next item we come across,
                        // otherwise we continue with the attempt to find previous
                        view = matched ? item.GetLastFocusItem() : item.GetPreviousFocusItem(current, ref matched);

                        if (view != null)
                        {
                            break;
                        }
                    }
                }
            }

            return view!;
        }
        #endregion

        #region GetGroupKeyTips
        /// <summary>
        /// Gets the array of group level key tips.
        /// </summary>
        /// <param name="keyTipList">List to add new entries into.</param>
        public void GetGroupKeyTips(KeyTipInfoList keyTipList)
        {
            var visibleIndex = 0;
            var lineHint = _currentSize == GroupItemSize.Small ? 1 : 4;

            // Scan all the children, which must be containers or items
            foreach (ViewBase child in this)
            {
                // Only interested in visible children!
                if (child.Visible)
                {
                    switch (child)
                    {
                        // Is this a container item
                        case IRibbonViewGroupContainerView container:
                            container.GetGroupKeyTips(keyTipList);
                            break;
                        case IRibbonViewGroupItemView item:
                            item.GetGroupKeyTips(keyTipList, lineHint);

                            // Depending on size we check to adjust the lint hint
                            switch (_currentSize)
                            {
                                case GroupItemSize.Large:
                                    if (visibleIndex == _split1Large)
                                    {
                                        lineHint = 5;
                                    }
                                    break;
                                case GroupItemSize.Medium:
                                    if (visibleIndex == _split1Medium)
                                    {
                                        lineHint = 5;
                                    }
                                    break;
                                case GroupItemSize.Small:
                                    if (visibleIndex == _split1Small)
                                    {
                                        lineHint = 2;
                                    }
                                    else if (visibleIndex == _split2Small)
                                    {
                                        lineHint = 3;
                                    }
                                    break;
                            }

                            break;
                    }

                    // Track number of visible items, as the split indexes are based on 
                    // visible items and not on the total number of child view items
                    visibleIndex++;
                }
            }
        }
        #endregion

        #region Layout
        /// <summary>
        /// Gets an array of the allowed possible sizes of the container.
        /// </summary>
        /// <param name="context">Context used to calculate the sizes.</param>
        /// <returns>Array of size values.</returns>
        public ItemSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
        {
            // Sync child elements to the current group items
            SyncChildrenToRibbonGroupItems();

            // Create a list of results
            var results = new List<ItemSizeWidth>();

            // Are we allowed to be in the large size?
            if (_ribbonLines.ItemSizeMaximum == GroupItemSize.Large)
            {
                ApplySize(GroupItemSize.Large);
                results.Add(new ItemSizeWidth(GroupItemSize.Large, GetPreferredSize(context).Width));
            }

            // Are we allowed to be in the medium size?
            if (((int)_ribbonLines.ItemSizeMaximum >= (int)GroupItemSize.Medium) &&
                ((int)_ribbonLines.ItemSizeMinimum <= (int)GroupItemSize.Medium))
            {
                ApplySize(GroupItemSize.Medium);
                var mediumWidth = new ItemSizeWidth(GroupItemSize.Medium, GetPreferredSize(context).Width);

                if (_ribbon.InDesignHelperMode)
                {
                    // Only add if we are the first calculation, as in design mode we
                    // always provide a single possible size which is the largest item
                    if (results.Count == 0)
                    {
                        results.Add(mediumWidth);
                    }
                }
                else
                {
                    // Only add the medium size if there is no other entry or we are
                    // smaller than the existing size and so represent a useful shrinkage
                    if ((results.Count == 0) || (results[0].Width > mediumWidth.Width))
                    {
                        results.Add(mediumWidth);
                    }
                }
            }

            // Are we allowed to be in the small size?
            if (_ribbonLines.ItemSizeMinimum == GroupItemSize.Small)
            {
                ApplySize(GroupItemSize.Small);
                var smallWidth = new ItemSizeWidth(GroupItemSize.Small, GetPreferredSize(context).Width);

                if (_ribbon.InDesignHelperMode)
                {
                    // Only add if we are the first calculation, as in design mode we
                    // always provide a single possible size which is the largest item
                    if (results.Count == 0)
                    {
                        results.Add(smallWidth);
                    }
                }
                else
                {
                    // Only add the small size if there is no other entry or we are
                    // smaller than the existing size and so represent a useful shrinkage
                    if ((results.Count == 0) || (results[results.Count - 1].Width > smallWidth.Width))
                    {
                        results.Add(smallWidth);
                    }
                }
            }

            // Ensure original value is put back
            ResetSize();

            return results.ToArray();
        }

        /// <summary>
        /// Update the group with the provided sizing solution.
        /// </summary>
        /// <param name="size">Value for the container.</param>
        public void SetSolutionSize(ItemSizeWidth size)
        {
            // Update the container definition, which itself will then
            // update all the child items inside the container for us
            _ribbonLines.ItemSizeCurrent = size.GroupItemSize;
            ApplySize(size.GroupItemSize);
        }

        /// <summary>
        /// Reset the container back to its requested size.
        /// </summary>
        public void ResetSolutionSize()
        {
            // Restore the container back to the defined size
            _ribbonLines.ItemSizeCurrent = _ribbonLines.ItemSizeMaximum;
            ApplySize(_ribbonLines.ItemSizeCurrent);
        }

        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize(ViewLayoutContext context)
        {
            // Sync child elements to the current group items
            SyncChildrenToRibbonGroupItems();

            // Clear down the cache of item sizes
            _sizeList.Clear();
            _viewList.Clear();
            _viewToGap.Clear();

            var totalWidth = 0;
            ViewBase? previousChild = null;

            // Find the size of each individual visible child item
            for (var i = 0; i < Count; i++)
            {
                ViewBase? child = this[i];

                // Only interested in visible items
                if (child!.Visible)
                {
                    // Inform cluster if it is immediately after another cluster (and so potentially needs a separator)
                    // Are we positioning a cluster?
                    if (child is ViewLayoutRibbonGroupCluster clusterChild)
                    {
                        clusterChild.StartSeparator = (previousChild != null) && previousChild is not ViewLayoutRibbonGroupCluster;
                        clusterChild.EndSeparator = true;
                    }

                    // Can we calculate the spacing gap between the previous and this item
                    if (previousChild != null)
                    {
                        if (_viewToItem.ContainsKey(child) &&
                            _viewToItem.TryGetValue(previousChild, out IRibbonGroupItem? previousItem))
                        {
                            // Cast to correct type
                            IRibbonGroupItem childItem = _viewToItem[child];

                            // Find the requested gap between them
                            _viewToGap.Add(child, childItem.ItemGap(previousItem));
                        }
                        else
                        {
                            // Default the gap
                            _viewToGap.Add(child, DEFAULT_GAP);
                        }
                    }

                    // Get requested size of the child
                    Size childSize = child.GetPreferredSize(context);

                    // Add to list of visible child sizes
                    _sizeList.Add(childSize);
                    _viewList.Add(child);

                    // Cache total visible width for later
                    totalWidth += childSize.Width;

                    // This is now the previous child
                    previousChild = child;
                }
            }

            // Find the item size specific preferred calculation
            switch (_currentSize)
            {
                case GroupItemSize.Large:
                    return LargeMediumPreferredSize(totalWidth, ref _split1Large);
                case GroupItemSize.Medium:
                    return LargeMediumPreferredSize(totalWidth, ref _split1Medium);
                case GroupItemSize.Small:
                    return SmallPreferredSize(totalWidth);
                default:
    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(_currentSize.ToString());
                    return Size.Empty;
            }
        }

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // Store the provided client area
            ClientRectangle = context!.DisplayRectangle;

            // Are there any children to layout?
            if (Count > 0)
            {
                // Perform item size specific layout
                switch (_currentSize)
                {
                    case GroupItemSize.Large:
                        LargeMediumLayout(context, ref _split1Large);
                        break;

                    case GroupItemSize.Medium:
                        LargeMediumLayout(context, ref _split1Medium);
                        break;

                    case GroupItemSize.Small:
                        SmallLayout(context);
                        break;

                    default:
    // Should never happen!
                        Debug.Assert(false);
                        DebugTools.NotImplemented(_currentSize.ToString());
                        break;
                }
            }

            // Update the display rectangle we allocated for use by parent
            context.DisplayRectangle = ClientRectangle;
        }
        #endregion

        #region Paint
        /// <summary>
        /// Perform rendering before child elements are rendered.
        /// </summary>
        /// <param name="context">Rendering context.</param>
        public override void RenderBefore(RenderContext context)
        {
            // At design time we draw the selection flap
            if (_ribbon.InDesignHelperMode)
            {
                DesignTimeDraw.DrawFlapArea(_ribbon, context, ClientRectangle, State);
            }

            // Let base class draw contained items
            base.RenderBefore(context);
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the NeedPaint event.
        /// </summary>
        /// <param name="needLayout">Does the palette change require a layout.</param>
        protected virtual void OnNeedPaint(bool needLayout)
        {
            if (_needPaint != null)
            {
                _needPaint(this, new NeedLayoutEventArgs(needLayout));

                if (needLayout)
                {
                    _ribbon.PerformLayout();
                }
            }
        }
        #endregion

        #region Implementation
        private void ApplySize(GroupItemSize size)
        {
            CurrentSize = size;
            var itemSize = GroupItemSize.Medium;

            switch (size)
            {
                case GroupItemSize.Large:
                    _sizeList = _sizeLargeList;
                    _viewList = _viewLargeList;
                    _viewToGap = _viewToLargeGap;
                    itemSize = GroupItemSize.Medium;
                    break;

                case GroupItemSize.Medium:
                    _sizeList = _sizeMediumList;
                    _viewList = _viewMediumList;
                    _viewToGap = _viewToMediumGap;
                    itemSize = GroupItemSize.Small;
                    break;

                case GroupItemSize.Small:
                    _sizeList = _sizeSmallList;
                    _viewList = _viewSmallList;
                    _viewToGap = _viewToSmallGap;
                    itemSize = GroupItemSize.Small;
                    break;

                default:
    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(size.ToString());
                    break;
            }

            foreach (ViewBase item in this)
            {
                if (item is IRibbonViewGroupItemView viewItem)
                {
                    viewItem.SetGroupItemSize(itemSize);
                }
            }
        }

        private void ResetSize()
        {
            foreach (ViewBase item in this)
            {
                if (item is IRibbonViewGroupItemView viewItem)
                {
                    viewItem.ResetGroupItemSize();
                }
            }

            CurrentSize = _ribbonLines.ItemSizeCurrent;
        }

        private void SyncChildrenToRibbonGroupItems()
        {
            // Remove all child elements
            Clear();

            var regenItemToView = new ItemToView();
            var regenViewToItem = new ViewToItem();

            // Add a view element for each group item
            foreach (IRibbonGroupItem item in _ribbonLines.Items!)
            {
                ViewBase? itemView;

                // Do we already have a view for this item definition
                if (_itemToView.ContainsKey(item))
                {
                    itemView = _itemToView[item];

                    // Remove from lookup to prevent it being deleted
                    _itemToView.Remove(item);
                }
                else
                {
                    // Ask the item definition to return an appropriate view
                    itemView = item.CreateView(_ribbon, _needPaint!);
                }

                // Update the visible state of the item
                itemView.Visible = _ribbon.InDesignHelperMode || item.Visible;

                // We need to keep this association
                regenItemToView.Add(item, itemView);
                regenViewToItem.Add(itemView, item);

                Add(itemView);
            }

            // When in design time help mode
            if (_ribbon.InDesignHelperMode)
            {
                // Create the design time 'Add Tab' first time it is needed
                _viewAddItem ??= new ViewDrawRibbonDesignGroupLines(_ribbon,
                        _ribbonLines,
                        _currentSize,
                        _needPaint!);

                // Always add at end of the list of items
                Add(_viewAddItem);
            }

            // Dispose of all the items no longer needed
            foreach (var view in _itemToView.Values)
            {
                view.Dispose();
            }

            // Use the latest hashtable
            _itemToView = regenItemToView;
            _viewToItem = regenViewToItem;
        }

        private Size LargeMediumPreferredSize(int totalWidth, ref int split1)
        {
            var preferredSize = Size.Empty;

            // Default to not splitting anywhere
            split1 = int.MaxValue;

            var bestTop = 0;
            var bestBottom = 0;

            // Only worth finding the best split position if more than 1 item is present
            if (_sizeList.Count > 1)
            {
                var bestDelta = int.MaxValue;
                var afterWidth = totalWidth;
                var beforeWidth = 0;

                // Test splitting into two lines after each item in turn
                for (var i = 0; i <= (_sizeList.Count - 2); i++)
                {
                    // Get size of this item
                    Size itemSize = _sizeList[i];

                    // Move the item width across the split
                    beforeWidth += itemSize.Width;
                    afterWidth -= itemSize.Width;

                    // What is the delta between them both?
                    var delta = Math.Abs(beforeWidth - afterWidth);

                    // We remember the best delta encountered
                    if (delta < bestDelta)
                    {
                        // This split is now the best found
                        split1 = i;
                        bestDelta = delta;
                        bestTop = beforeWidth;
                        bestBottom = afterWidth;
                    }
                }

                // Add the spacing gaps before relevant items
                if ((split1 >= 0) && (split1 < _sizeList.Count))
                {
                    bestTop += GetItemSpacingGap(0, split1);
                    bestBottom += GetItemSpacingGap(split1 + 1, _sizeList.Count - 1);
                }

                preferredSize.Width = Math.Max(bestTop, bestBottom);
            }
            else
            {
                // No split to make, so just the total width of all items
                preferredSize.Width = totalWidth;
            }

            // Our height is always the same as a triple, the entire content height
            preferredSize.Height = _ribbon.CalculatedValues.GroupTripleHeight;

            // At design time we add space for the selection flap
            if (_ribbon.InDesignHelperMode)
            {
                preferredSize.Width += DesignTimeDraw.FlapWidth + DesignTimeDraw.SepWidth;
            }

            return preferredSize;
        }

        private Size SmallPreferredSize(int totalWidth)
        {
            var preferredSize = Size.Empty;

            // Default to not splitting anywhere
            _split1Small = int.MaxValue;
            _split2Small = int.MaxValue;

            switch (_sizeList.Count)
            {
                case 1:
                    // No split to make, so just the total width of all items
                    preferredSize.Width = totalWidth;
                    break;
                case 2:
                    // Split after the first time
                    _split1Small = 0;

                    // Total width is the largest width of the two items
                    preferredSize.Width = Math.Max(_sizeList[0].Width, _sizeList[1].Width);
                    break;
                case 3:
                    // Split after the first and second time
                    _split1Small = 0;
                    _split2Small = 1;

                    // Total width is the largest width of the three items
                    preferredSize.Width = Math.Max(_sizeList[0].Width, Math.Max(_sizeList[1].Width, _sizeList[2].Width));
                    break;
                default:
                    {
                        var bestDelta = int.MaxValue;
                        var bestTop = 0;
                        var bestMiddle = 0;
                        var bestBottom = 0;
                        var afterFirstWidth = totalWidth;
                        var beforeFirstWidth = 0;

                        // Test all combinations of the first split
                        for (var i = 0; i < (_sizeList.Count - 2); i++)
                        {
                            // Get size of this item
                            Size itemFirstSize = _sizeList[i];

                            // Move the item width across the split
                            beforeFirstWidth += itemFirstSize.Width;
                            afterFirstWidth -= itemFirstSize.Width;

                            // Remainder of space is needed for testing the second split
                            var afterSecondWidth = afterFirstWidth;
                            var beforeSecondWidth = 0;

                            // Check all combinations of the second split for this first split
                            for (var j = i + 1; j < (_sizeList.Count - 1); j++)
                            {
                                // Get size of this item
                                Size itemSecondSize = _sizeList[j];

                                // Move the item width across the split
                                beforeSecondWidth += itemSecondSize.Width;
                                afterSecondWidth -= itemSecondSize.Width;

                                // Find shortest and longest lines and then delta between them
                                var shortest = Math.Min(beforeFirstWidth, Math.Min(beforeSecondWidth, afterSecondWidth));
                                var longest = Math.Max(beforeFirstWidth, Math.Max(beforeSecondWidth, afterSecondWidth));
                                var delta = Math.Abs(longest - shortest);

                                // We remember the best delta encountered
                                if (delta < bestDelta)
                                {
                                    // This split is now the best found
                                    _split1Small = i;
                                    _split2Small = j;
                                    bestDelta = delta;
                                    bestTop = beforeFirstWidth;
                                    bestMiddle = beforeSecondWidth;
                                    bestBottom = afterSecondWidth;
                                }
                            }
                        }

                        // Add the spacing gaps before relevant items
                        if ((_split1Small >= 0)
                            && (_split1Small < _sizeList.Count)
                            && (_split2Small >= 0)
                            && (_split2Small < _sizeList.Count)
                            )
                        {
                            bestTop += GetItemSpacingGap(0, _split1Small);
                            bestMiddle += GetItemSpacingGap(_split1Small + 1, _split2Small);
                            bestBottom += GetItemSpacingGap(_split2Small + 1, _sizeList.Count - 1);
                        }

                        preferredSize.Width = Math.Max(bestTop, Math.Max(bestMiddle, bestBottom));
                    }
                    break;
            }

            // Our height is always the same as a triple, the entire content height
            preferredSize.Height = _ribbon.CalculatedValues.GroupTripleHeight;

            // At design time we add space for the selection flap
            if (_ribbon.InDesignHelperMode)
            {
                preferredSize.Width += DesignTimeDraw.FlapWidth + DesignTimeDraw.SepWidth;
            }

            return preferredSize;
        }

        private void LargeMediumLayout(ViewLayoutContext context, ref int split1)
        {
            var x = ClientLocation.X;
            var y = ClientLocation.Y + _ribbon.CalculatedValues.GroupLineGapHeight;

            // At design time we reserve space at the left side for the selection flap
            if (_ribbon.InDesignHelperMode)
            {
                x += DesignTimeDraw.FlapWidth;
            }

            ViewBase? previousChild = null;

            // Position the visible items in turn
            for (int i = 0, visibleIndex = 0; i < Count; i++)
            {
                ViewBase? child = this[i];

                // We only position visible items
                if (child!.Visible)
                {
                    // Are we positioning a cluster?
                    if (child is ViewLayoutRibbonGroupCluster clusterChild1)
                    {
                        // Inform cluster if it is immediately after another cluster (and so potentially needs a separator)
                        clusterChild1.StartSeparator = (previousChild != null) && previousChild is not ViewLayoutRibbonGroupCluster;
                        clusterChild1.EndSeparator = false;
                    }

                    if (previousChild is ViewLayoutRibbonGroupCluster clusterChild)
                    {
                        // Inform cluster if it is before another item and so needs an end separator
                        clusterChild.EndSeparator = true;

                        // Need to layout the item again with the new setting
                        context.DisplayRectangle = new Rectangle(clusterChild.ClientLocation.X, clusterChild.ClientLocation.Y, clusterChild.ClientWidth, clusterChild.ClientHeight);
                        clusterChild.Layout(context);
                    }

                    // If not the first item on the line, then get the pixel gap between them
                    if ((previousChild != null) && _viewToGap.TryGetValue(child, out var value))
                    {
                        x += value;
                    }

                    // Get the size of the child item
                    Size childSize = _sizeList[visibleIndex];

                    // Define display rectangle for the group
                    context.DisplayRectangle = new Rectangle(x, y, childSize.Width, childSize.Height);

                    // Position the element
                    this[i]?.Layout(context);

                    // Do we need to split after this item
                    if (split1 == visibleIndex)
                    {
                        // Move back to start of line and downwards to next line
                        x = ClientLocation.X;

                        // At design time we reserve space at the left side for the selection flap
                        if (_ribbon.InDesignHelperMode)
                        {
                            x += DesignTimeDraw.FlapWidth;
                        }

                        y += _ribbon.CalculatedValues.GroupLineHeight +
                             _ribbon.CalculatedValues.GroupLineGapHeight;

                        // As last item on the line, there is no previous item on next line
                        previousChild = null;
                    }
                    else
                    {
                        // Move across to next position
                        x += childSize.Width;

                        // We have become the previous child
                        previousChild = child;
                    }

                    // Not all child items are visible, so track separately
                    visibleIndex++;
                }
            }
        }

        private void SmallLayout(ViewLayoutContext context)
        {
            var x = ClientLocation.X;
            var y = ClientLocation.Y;

            // At design time we reserve space at the left side for the selection flap
            if (_ribbon.InDesignHelperMode)
            {
                x += DesignTimeDraw.FlapWidth;
            }

            ViewBase? previousChild = null;

            // Position the visible items in turn
            for (int i = 0, visibleIndex = 0; i < Count; i++)
            {
                ViewBase? child = this[i];

                // We only position visible items
                if (child!.Visible)
                {
                    // Are we positioning a cluster?
                    if (child is ViewLayoutRibbonGroupCluster clusterChild1)
                    {
                        // Inform cluster if it is immediately after another item and so needs a start separator
                        clusterChild1.StartSeparator = (previousChild != null) && previousChild is not ViewLayoutRibbonGroupCluster;
                        clusterChild1.EndSeparator = false;
                    }

                    if (previousChild is ViewLayoutRibbonGroupCluster clusterChild)
                    {
                        // Inform cluster if it is before another item and so needs an end separator
                        clusterChild.EndSeparator = true;

                        // Need to layout the item again with the new setting
                        context.DisplayRectangle = new Rectangle(previousChild.ClientLocation.X, previousChild.ClientLocation.Y, previousChild.ClientWidth, previousChild.ClientHeight);
                        previousChild.Layout(context);
                    }

                    // If not the first item on the line, then get the pixel gap between them
                    if ((previousChild != null) && _viewToGap.TryGetValue(child, out var value))
                    {
                        x += value;
                    }

                    // Get the size of the child item
                    Size childSize = _sizeList[visibleIndex];

                    // Define display rectangle for the group
                    context.DisplayRectangle = new Rectangle(x, y, childSize.Width, childSize.Height);

                    // Position the element
                    this[i]?.Layout(context);

                    // Do we need to split after this item
                    if ((_split1Small == visibleIndex) || (_split2Small == visibleIndex))
                    {
                        // Move back to start of line and downwards to next line
                        x = ClientLocation.X;

                        // At design time we reserve space at the left side for the selection flap
                        if (_ribbon.InDesignHelperMode)
                        {
                            x += DesignTimeDraw.FlapWidth;
                        }

                        y += _ribbon.CalculatedValues.GroupLineHeight;

                        // As last item on the line, there is no previous item on next line
                        previousChild = null;
                    }
                    else
                    {
                        // Move across to next position
                        x += childSize.Width;

                        // We have become the previous child
                        previousChild = child;
                    }

                    // Not all child items are visible, so track separately
                    visibleIndex++;
                }
            }
        }

        private int GetItemSpacingGap(int start, int end)
        {
            var gapTotal = 0;

            // Only interested in gaps after the first item
            for (var i = start + 1; i <= end; i++)
            {
                gapTotal += _viewToGap[_viewList[i]];
            }

            return gapTotal;
        }

        private void OnLinesPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            var updateLayout = false;

            switch (e.PropertyName)
            {
                case nameof(Visible):
                    updateLayout = true;
                    break;
                case "ItemSizeMinimum":
                case "ItemSizeMaximum":
                case "ItemSizeCurrent":
                    // Update with the latest sizing value
                    ApplySize(_ribbonLines.ItemSizeCurrent);
                    updateLayout = true;
                    break;
            }

            if (updateLayout)
            {
                // If we are on the currently selected tab then...
                if ((_ribbonLines.RibbonTab != null) &&
                    (_ribbon.SelectedTab == _ribbonLines.RibbonTab))
                {
                    // ...layout so the visible change is made
                    OnNeedPaint(true);
                }
            }
        }

        private void OnContextClick(object? sender, MouseEventArgs e)
        {
            if (_ribbon.InDesignMode)
            {
                _ribbonLines.OnDesignTimeContextMenu(e);
            }
        }
        #endregion
    }
}
