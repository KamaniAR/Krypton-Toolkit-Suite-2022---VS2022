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
    /// Extends the ViewComposite by creating and laying out elements to represent ribbon group content.
    /// </summary>
    internal class ViewLayoutRibbonGroupContent : ViewComposite,
                                                  IRibbonViewGroupSize
    {
        #region Type Definitions
        private class ContainerToView : Dictionary<IRibbonGroupContainer, ViewBase>;
        #endregion

        #region Static Fields

        private const int EMPTY_WIDTH = 48;
        private static readonly Padding _padding = new Padding(1, 0, 1, 1);
        #endregion

        #region Instance Fields
        private readonly KryptonRibbon _ribbon;
        private readonly KryptonRibbonGroup _ribbonGroup;
        private ViewDrawRibbonDesignGroupContainer _viewAddContainer;
        private readonly NeedPaintHandler _needPaint;
        private ContainerToView _containerToView;
        private List<ItemSizeWidth[]> _listWidths;
        private int[]? _containerWidths;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewLayoutRibbonGroupContent class.
        /// </summary>
        /// <param name="ribbon">Owning ribbon control instance.</param>
        /// <param name="ribbonGroup">The ribbon group this layout is used to display.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public ViewLayoutRibbonGroupContent([DisallowNull] KryptonRibbon? ribbon,
                                            [DisallowNull] KryptonRibbonGroup? ribbonGroup,
                                            [DisallowNull] NeedPaintHandler? needPaint)
        {
            Debug.Assert(ribbon is not null);
            Debug.Assert(ribbonGroup is not null);
            Debug.Assert(needPaint is not null);

            // Cache references
            _ribbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));
            _ribbonGroup = ribbonGroup ?? throw new ArgumentNullException(nameof(ribbonGroup));
            _needPaint = needPaint ?? throw new ArgumentNullException(nameof(needPaint));

            // Use hashtable to store relationships
            _containerToView = new ContainerToView();
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewLayoutRibbonGroupContent:{Id}";

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }
        #endregion

        #region DialogView
        /// <summary>
        /// Gets and sets the dialog view reference.
        /// </summary>
        public ViewLayoutRibbonGroupButton DialogView { get; set; }

        #endregion

        #region GetGroupKeyTips
        /// <summary>
        /// Gets the array of group level key tips.
        /// </summary>
        /// <param name="keyTipList">List to add new entries into.</param>
        public void GetGroupKeyTips(KeyTipInfoList keyTipList)
        {
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

                        // Ask the container to add key tips for its contents
                        container.GetGroupKeyTips(keyTipList);
                    }
                }
            }
        }
        #endregion

        #region GetFirstFocusItem
        /// <summary>
        /// Gets the first focus item from the group content.
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
                }
            }

            // If still nothing, then we can go to the dialog box
            if ((view == null) && _ribbonGroup.Visible)
            {
                view = DialogView.GetFocusView();
            }

            return view!;
        }
        #endregion

        #region GetLastFocusItem
        /// <summary>
        /// Gets the last focus item from the group.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetLastFocusItem()
        {
            ViewBase? view = null;

            if (_ribbonGroup.Visible)
            {
                // The dialog box launcher is the last item (if present)
                view = DialogView.GetFocusView();

                if (view == null)
                {
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

            // If still nothing...
            if (view == null)
            {
                // If matched then try using the dialog box launcher
                if (matched)
                {
                    if (_ribbonGroup.Visible)
                    {
                        view = DialogView.GetFocusView();
                    }
                }
                else
                {
                    matched = DialogView.GetFocusView() == current;
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

            // If matched then try using the dialog box launcher
            if (matched)
            {
                if (_ribbonGroup.Visible)
                {
                    view = DialogView.GetFocusView();
                }
            }
            else
            {
                matched = DialogView.GetFocusView() == current;
            }

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

        #region Layout
        /// <summary>
        /// Get an array of available widths for the group with associated sizing values.
        /// </summary>
        /// <param name="context">Context used to calculate the sizes.</param>
        /// <returns>Array of size values.</returns>
        public GroupSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
        {
            // Sync child elements to the current group items
            SyncChildrenToRibbonGroupItems();

            // Get the permutations available for each child container
            _listWidths = [];

            // Scan all child containers
            var pixelGaps = 0;
            var maxEntries = 0;
            for (var i = 0; i < Count; i++)
            {
                if (this[i]!.Visible 
                    && (this[i] is IRibbonViewGroupContainerView container)
                    )
                {
                    // Find list of possible sizes for this container
                    var widths = container.GetPossibleSizes(context);

                    // Track how many extra pixels are needed for inter container gaps
                    if (_listWidths.Count > 0)
                    {
                        pixelGaps++;
                    }

                    // Add into list of all container values
                    _listWidths.Add(widths);

                    // Track the longest list found
                    maxEntries = Math.Max(maxEntries, widths.Length);
                }
            }

            // Create list for holding resultant permutations
            var retSizes = new List<GroupSizeWidth>();

            // Create array of indexes into each of the containers and set to zero
            var indexes = new int[_listWidths.Count];

            // Cycle around and around the indexes to create permutations
            var cycleMax = _listWidths.Count - 1;
            var cycleCurrent = cycleMax;

            // Decide if we need to break out the process and generate a new perm
            bool breakOut;
            var tags = true;

            do
            {
                // Generate permutation from current set of indexes
                var permTotalWidth = pixelGaps;
                new List<int>().Clear();

                // Per-permutation values
                var permSize = new List<ItemSizeWidth>();
                permSize.Clear();

                // Generate permutation by taking cell values
                for (var k = _listWidths.Count - 1; k >= 0; k--)
                {
                    // Find width and size of the entry
                    ItemSizeWidth size = _listWidths[k][indexes[k]];
                    
                    // Track the total width of this permutation
                    permTotalWidth += size.Width;
                    new List<int>().Insert(0, size.Width);
                    permSize.Insert(0, size);
                }

                // Only add this as a new permutation if the first entry added or if a smaller 
                // size than the last entry. Permutations should be getting progressively smaller
                if ((retSizes.Count == 0) || (retSizes[retSizes.Count - 1].Width != permTotalWidth))
                {
                    retSizes.Add(new GroupSizeWidth(permTotalWidth, permSize.ToArray()));
                }

                // Do a full cycle looking for a tagged entry to consume
                breakOut = false;

                // Do we need to process tags?
                if (tags)
                {
                    for (var i = 0; i <= cycleMax; i++)
                    {
                        // Is this column not at the end of the options?
                        if (_listWidths[cycleCurrent].Length > (indexes[cycleCurrent] + 1))
                        {
                            // Does the entry have a tag value?
                            if (_listWidths[cycleCurrent][indexes[cycleCurrent]].Tag >= 0)
                            {
                                // Advance this column one onwards
                                indexes[cycleCurrent]++;

                                // Break out to generate this permutation
                                breakOut = true;
                            }
                        }

                        // Move cycle around one place
                        cycleCurrent--;
                        if (cycleCurrent < 0)
                        {
                            cycleCurrent = cycleMax;
                        }

                        if (breakOut)
                        {
                            break;
                        }
                    }

                    // If no tag based permutation found then turn off processing tags
                    if (!breakOut)
                    {
                        tags = false;
                    }
                }

                // If no perm found yet...
                if (!breakOut)
                {
                    for (var i = 0; i <= cycleMax; i++)
                    {
                        // Is this column not at the end of the options?
                        if (_listWidths[cycleCurrent].Length > (indexes[cycleCurrent] + 1))
                        {
                            // Advance this column one onwards
                            indexes[cycleCurrent]++;

                            // Break out to generate this permutation
                            breakOut = true;
                        }

                        // Move cycle around one place
                        cycleCurrent--;
                        if (cycleCurrent < 0)
                        {
                            cycleCurrent = cycleMax;
                        }

                        if (breakOut)
                        {
                            break;
                        }
                    }
                }
            }
            while (breakOut);

            // If we have produced nothing then we add a single 
            // entry which is the minimum width of a group
            if (retSizes.Count == 0)
            {
                retSizes.Add(new GroupSizeWidth(EMPTY_WIDTH, Array.Empty<ItemSizeWidth>()));
            }

            // If adding the extra design time entry
            if (_ribbon.InDesignHelperMode)
            {
                // Get the requested width of the add view
                var viewAddWidth = _viewAddContainer.GetPreferredSize(context).Width;

                // Add it onto each permutation
                foreach (GroupSizeWidth retSize in retSizes)
                {
                    retSize.Width += viewAddWidth;
                }
            }

            return retSizes.ToArray();
        }

        /// <summary>
        /// Update the group with the provided sizing solution.
        /// </summary>
        /// <param name="size">Solution size.</param>
        public void SetSolutionSize(ItemSizeWidth[]? size)
        {
            // Do we need to restore each container to its default size?
            if ((size == null) || (size.Length == 0))
            {
                // Look for visible child containers
                for (var i = 0; i < Count; i++)
                {
                    if (this[i]!.Visible 
                        && (this[i] is IRibbonViewGroupContainerView container)
                        )
                    {
                        container.ResetSolutionSize();
                    }
                }

                _containerWidths = null;
            }
            else
            {
                // Create new cache of the actual container widths to use
                _containerWidths = new int[size.Length];

                // Look for visible child containers
                for (int i = 0, j = 0; i < Count; i++)
                {
                    if (this[i]!.Visible 
                        && (this[i] is IRibbonViewGroupContainerView container)
                        )
                    {
                        // Get the width returned for this container
                        _containerWidths[j] = size[j].Width;

                        // Push the solution size into the actual container
                        container.SetSolutionSize(size[j++]);
                    }
                }
            }
        }

        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize(ViewLayoutContext context)
        {
            // Sync child elements to the current group items
            SyncChildrenToRibbonGroupItems();

            var preferredSize = Size.Empty;

            // Find total width and maximum height across all child elements
            for (int i = 0, j = 0; i < Count; i++)
            {
                ViewBase? child = this[i];

                // Only interested in visible items
                if (child!.Visible)
                {
                    Size childSize;

                    if ((_containerWidths != null) && (child is IRibbonViewGroupContainerView))
                    {
                        childSize = new Size(_containerWidths[j++], _ribbon.CalculatedValues.GroupTripleHeight);
                    }
                    else
                    {
                        childSize = child.GetPreferredSize(context);
                    }

                    // Only need extra processing for children that have some width
                    if (childSize.Width > 0)
                    {
                        // If not the first item positioned
                        if (preferredSize.Width > 0)
                        {
                            // Add on a single pixel spacing gap
                            preferredSize.Width++;
                        }

                        // Always add on to the width
                        preferredSize.Width += childSize.Width;

                        // Find maximum height encountered
                        preferredSize.Height = Math.Max(preferredSize.Height, childSize.Height);
                    }
                }
            }

            // Add on the constant additional padding
            return CommonHelper.ApplyPadding(Orientation.Horizontal, preferredSize, _padding);
        }

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // We take on all the available display area and then remove our constant padding
            ClientRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, context!.DisplayRectangle, _padding);

            var x = ClientLocation.X;

            // Are there any children to layout?
            if (Count > 0)
            {
                var y = ClientLocation.Y;
                var height = ClientHeight;

                // Position each item from left to right taking up entire height
                for (int i = 0, j = 0; i < Count; i++)
                {
                    ViewBase? child = this[i];

                    // We only position visible items
                    if (child!.Visible)
                    {
                        Size childSize;

                        if ((_containerWidths != null) && (child is IRibbonViewGroupContainerView))
                        {
                            childSize = new Size(_containerWidths[j++], _ribbon.CalculatedValues.GroupTripleHeight);
                        }
                        else
                        {
                            childSize = child.GetPreferredSize(context);
                        }

                        // Only interested in items with some width
                        if (childSize.Width > 0)
                        {
                            // Define display rectangle for the group
                            context.DisplayRectangle = new Rectangle(x, y, childSize.Width, height);

                            // Position the element
                            this[i]!.Layout(context);

                            // Move across to next position (add 1 extra as the spacing gap)
                            x += childSize.Width + 1;
                        }
                    }
                }
            }

            // Update the display rectangle we allocated for use by parent
            context.DisplayRectangle = ClientRectangle;
        }
        #endregion

        #region Implementation
        private void SyncChildrenToRibbonGroupItems()
        {
            // Remove all child elements
            Clear();

            var regenerate = new ContainerToView();

            // Add a view element for each group item
            foreach (KryptonRibbonGroupContainer container in _ribbonGroup.Items)
            {
                // Do we already have a view for this container definition
                ViewBase containerView = _containerToView.TryGetValue(container, out ViewBase? value)
                    ? value
                    : container.CreateView(_ribbon, _needPaint);

                // Update the visible state of the item
                containerView.Visible = container.Visible || _ribbon.InDesignHelperMode;
                
                // We need to keep this association
                regenerate.Add(container, containerView);

                Add(containerView);
            }

            // When in design time help mode
            if (_ribbon.InDesignHelperMode)
            {
                // Create the design time 'Add Container' first time it is needed
                _viewAddContainer ??= new ViewDrawRibbonDesignGroupContainer(_ribbon, _ribbonGroup, _needPaint);

                // Always add at end of the list of tabs
                Add(_viewAddContainer);
            }

            // Use the latest hashtable
            _containerToView = regenerate;
        }
        #endregion
    }
}
