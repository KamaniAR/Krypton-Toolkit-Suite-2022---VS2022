﻿#region BSD License
/*
 * 
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, (Version 4.5.0.0) All rights reserved.
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), Giduac & Ahmed Abdelhameed et al. 2017 - 2025. All rights reserved.
 *  
 */
#endregion

namespace Krypton.Navigator
{
    /// <summary>
    /// Implements the NavigatorMode.HeaderBarCheckButtonOnly mode.
    /// </summary>
    internal class ViewBuilderHeaderBarCheckButtonOnly : ViewBuilderHeaderBarCheckButtonBase
    {
        #region Instance Fields
        protected ViewLayoutDocker _layoutPanelDocker;
        #endregion

        #region Public
        /// <summary>
        /// Gets a value indicating if the mode is a tab strip style mode.
        /// </summary>
        public override bool IsTabStripMode => true;

        /// <summary>
        /// User has used the keyboard to select the currently selected page.
        /// </summary>
        public override void KeyPressedPageView()
        {
            // If there is a currently selected page
            if (Navigator.SelectedPage != null)
            {
                // Grab the view for the page
                INavCheckItem checkItem = _pageLookup![Navigator.SelectedPage];

                // If the item also has the focus
                if (checkItem.HasFocus)
                {
                    // Then perform the click action for the button
                    checkItem.PerformClick();
                }
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Create the view hierarchy for this view mode.
        /// </summary>
        protected override void CreateCheckItemView()
        {
            // Create the view element that lays out the check buttons
            _layoutBar = new ViewLayoutBar(Navigator.StateCommon!.Bar,
                                           PaletteMetricInt.CheckButtonGap,
                                           Navigator.Bar.ItemSizing,
                                           Navigator.Bar.ItemAlignment,
                                           Navigator.Bar.BarMultiline,
                                           Navigator.Bar.ItemMinimumSize,
                                           Navigator.Bar.ItemMaximumSize,
                                           Navigator.Bar.BarMinimumHeight,
                                           false);

            // Create the scroll spacer that restricts display
            _layoutBarViewport = new ViewLayoutViewport(Navigator.StateCommon.Bar,
                                                        PaletteMetricPadding.BarPaddingInside,
                                                        PaletteMetricInt.CheckButtonGap,
                                                        Navigator.Header.HeaderPositionBar,
                                                        Navigator.Bar.ItemAlignment,
                                                        Navigator.Bar.BarAnimation)
            {
                _layoutBar
            };

            // Create the button bar area docker
            _layoutBarDocker = new ViewLayoutDocker
            {
                { _layoutBarViewport, ViewDockStyle.Fill }
            };

            // Place the bar inside a header style area
            _viewHeadingBar = new ViewDrawDocker(Navigator.StateNormal.HeaderGroup.HeaderBar.Back,
                                                 Navigator.StateNormal.HeaderGroup.HeaderBar.Border,
                                                 Navigator.StateNormal.HeaderGroup.HeaderBar,
                                                 PaletteMetricBool.None,
                                                 PaletteMetricPadding.HeaderGroupPaddingSecondary,
                                                 VisualOrientation.Top)
            {
                { _layoutBarDocker, ViewDockStyle.Fill }
            };

            // Create the docker used to layout contents of main panel and fill with group
            _layoutPanelDocker = new ViewLayoutDocker
            {
                { new ViewLayoutPageHide(Navigator), ViewDockStyle.Fill },
                { _viewHeadingBar, ViewDockStyle.Top }
            };

            // Create the top level panel and put a layout docker inside it
            _drawPanel = new ViewDrawPanel(Navigator.StateNormal.Back)
            {
                _layoutPanelDocker
            };
            _newRoot = _drawPanel;

            // Must call the base class to perform common actions
            base.CreateCheckItemView();
        }

        /// <summary>
        /// Destruct the view hierarchy for this mode.
        /// </summary>
        protected override void DestructCheckItemView()
        {
            // Remove the old root from the canvas
            _layoutPanelDocker.Clear();

            // Must call the base class to perform common actions
            base.CreateCheckItemView();
        }

        /// <summary>
        /// Update the bar orientation.
        /// </summary>
        protected override void UpdateOrientation()
        {
            switch (Navigator.Header.HeaderPositionBar)
            {
                case VisualOrientation.Top:
                    _layoutPanelDocker.SetDock(_viewHeadingBar, ViewDockStyle.Top);
                    _viewHeadingBar.Orientation = VisualOrientation.Top;
                    _layoutBarDocker.Orientation = VisualOrientation.Top;
                    _layoutBarViewport.Orientation = VisualOrientation.Top;
                    break;
                case VisualOrientation.Bottom:
                    _layoutPanelDocker.SetDock(_viewHeadingBar, ViewDockStyle.Bottom);
                    _viewHeadingBar.Orientation = VisualOrientation.Top;
                    _layoutBarDocker.Orientation = VisualOrientation.Top;
                    _layoutBarViewport.Orientation = VisualOrientation.Top;
                    break;
                case VisualOrientation.Left:
                    _layoutPanelDocker.SetDock(_viewHeadingBar, ViewDockStyle.Left);
                    _viewHeadingBar.Orientation = VisualOrientation.Left;
                    _layoutBarDocker.Orientation = VisualOrientation.Right;
                    _layoutBarViewport.Orientation = VisualOrientation.Right;
                    break;
                case VisualOrientation.Right:
                    _layoutPanelDocker.SetDock(_viewHeadingBar, ViewDockStyle.Right);
                    _viewHeadingBar.Orientation = VisualOrientation.Left;
                    _layoutBarDocker.Orientation = VisualOrientation.Right;
                    _layoutBarViewport.Orientation = VisualOrientation.Right;
                    break;
            }

            _layoutBar.Orientation = Navigator.Header.HeaderPositionBar;
            _layoutBarViewport.Orientation = Navigator.Header.HeaderPositionBar;
        }
        #endregion
    }
}
