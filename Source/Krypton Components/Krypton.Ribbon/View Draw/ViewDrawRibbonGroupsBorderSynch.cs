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
    /// Draws the border around the groups inside the groups area and manages per tab scrollers as well.
    /// </summary>
    internal class ViewDrawRibbonGroupsBorderSynch : ViewDrawRibbonGroupsBorder
    {
        #region Classes
        private class TabToView : Dictionary<KryptonRibbonTab, ViewLayoutRibbonScrollPort>;
        #endregion

        #region Static Fields

        private const int SCROLL_SPEED = 24;

        #endregion

        #region Instance Fields
        private TabToView _tabToView;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewDrawRibbonGroupsBorderSynch class.
        /// </summary>
        /// <param name="ribbon">Reference to owning ribbon control.</param>
        /// <param name="needPaintDelegate">Delegate for notifying paint/layout changes.</param>
        public ViewDrawRibbonGroupsBorderSynch(KryptonRibbon ribbon,
                                               NeedPaintHandler needPaintDelegate)
            : base(ribbon, false, needPaintDelegate) =>
            // Create initial lookup table
            _tabToView = new TabToView();

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $@"ViewDrawRibbonGroupsBorderSynch:{Id}";

        #endregion

        #region ViewGroupFromPoint
        /// <summary>
        /// Gets the view element group that the provided point is inside.
        /// </summary>
        /// <param name="pt">Mouse point.</param>
        /// <returns>Reference if inside a group; otherwise null.</returns>
        public ViewDrawRibbonGroup? ViewGroupFromPoint(Point pt)
        {
            // There can only be groups showing for the currently selected tab
            if (Ribbon.SelectedTab != null && _tabToView.TryGetValue(Ribbon.SelectedTab, out ViewLayoutRibbonScrollPort? viewScrollPort))
            {
                // Get the scroll port for this tab

                // The first child of the scroll port is always the view control
                var viewControl = viewScrollPort[0] as ViewLayoutControl;

                // The first child of the view control is always the ribbon groups
                var viewGroups = viewControl?.ChildView as ViewLayoutRibbonGroups;

                // Ask the view groups to find a matching group
                return viewGroups?.ViewGroupFromPoint(pt);
            }

            return null;
        }
        #endregion

        #region GetGroupKeyTips
        /// <summary>
        /// Gets the array of group level key tips for the selected tab.
        /// </summary>
        /// <param name="tab">Ribbon tab reference.</param>
        /// <returns>Array of KeyTipInfo; otherwise null.</returns>
        public KeyTipInfo[] GetGroupKeyTips(KryptonRibbonTab tab) => _tabToView.ContainsKey(tab)
            ? _tabToView[tab].GetGroupKeyTips()
            : Array.Empty<KeyTipInfo>();

        #endregion

        #region GetFirstFocusItem
        /// <summary>
        /// Gets the first focus item within the currently selected tab.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetFirstFocusItem()
        {
            if ((Ribbon.SelectedTab != null) &&
                _tabToView.ContainsKey(Ribbon.SelectedTab))
            {
                return _tabToView[Ribbon.SelectedTab].GetFirstFocusItem();
            }
            else
            {
                return null!;
            }
        }
        #endregion

        #region GetLastFocusItem
        /// <summary>
        /// Gets the last focus item within the currently selected tab.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetLastFocusItem()
        {
            if ((Ribbon.SelectedTab != null) &&
                _tabToView.ContainsKey(Ribbon.SelectedTab))
            {
                return _tabToView[Ribbon.SelectedTab].GetLastFocusItem();
            }
            else
            {
                return null!;
            }
        }
        #endregion

        #region GetNextFocusItem
        /// <summary>
        /// Gets the next focus item based on the current item as provided.
        /// </summary>
        /// <param name="current">The view that is currently focused.</param>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetNextFocusItem(ViewBase current)
        {
            if ((Ribbon.SelectedTab != null) &&
                _tabToView.ContainsKey(Ribbon.SelectedTab))
            {
                return _tabToView[Ribbon.SelectedTab].GetNextFocusItem(current);
            }
            else
            {
                return null!;
            }
        }
        #endregion

        #region GetPreviousFocusItem
        /// <summary>
        /// Gets the previous focus item based on the current item as provided.
        /// </summary>
        /// <param name="current">The view that is currently focused.</param>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetPreviousFocusItem(ViewBase current)
        {
            if ((Ribbon.SelectedTab != null) &&
                _tabToView.ContainsKey(Ribbon.SelectedTab))
            {
                return _tabToView[Ribbon.SelectedTab].GetPreviousFocusItem(current);
            }
            else
            {
                return null!;
            }
        }
        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize(ViewLayoutContext context)
        {
            // Sync to represent a groups view per tab
            SyncChildrenToRibbonTabs();
            return base.GetPreferredSize(context);
        }

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout(ViewLayoutContext context)
        {
            // Sync to represent a groups view per tab
            SyncChildrenToRibbonTabs();
            base.Layout(context);
        }
        #endregion

        #region Implementation
        private void SyncChildrenToRibbonTabs()
        {
            // Remove all child elements
            Clear();

            // Create a new lookup that reflects any changes in tabs
            var regenerate = new TabToView();

            // Make sure we have a view element to match each tab
            foreach (KryptonRibbonTab tab in Ribbon.RibbonTabs)
            {
                ViewLayoutRibbonScrollPort? view = null;

                // Get the currently cached view for the tab
                if (_tabToView.TryGetValue(tab, out ViewLayoutRibbonScrollPort? value))
                {
                    view = value;
                }

                // If a new tab, create a view for it now
                if (view == null)
                {
                    var groups = new ViewLayoutRibbonGroups(Ribbon, tab, NeedPaintDelegate);
                    view = new ViewLayoutRibbonScrollPort(Ribbon, Orientation.Horizontal, groups, false, SCROLL_SPEED, NeedPaintDelegate)
                    {
                        TransparentBackground = true
                    };
                    groups.NeedPaintDelegate = view.ViewControlPaintDelegate;
                }

                // Make sure only the selected tab is visible
                view.Visible = Ribbon.SelectedTab == tab;

                // Add to the lookup for future reference
                regenerate.Add(tab, view);

                // Remove no longer needed reference
                _tabToView.Remove(tab);
            }

            // Switch to using the lookup with only the current options inside
            TabToView redundant = _tabToView;
            _tabToView = regenerate;

            // Add the view elements in same order as the tab definitions
            foreach (KryptonRibbonTab tab in Ribbon.RibbonTabs)
            {
                Add(_tabToView[tab]);
            }

            // Dispose of all the no longer needed child tabs
            foreach (ViewBase oldChild in redundant.Values)
            {
                oldChild.Dispose();
            }
        }
        #endregion
    }
}
