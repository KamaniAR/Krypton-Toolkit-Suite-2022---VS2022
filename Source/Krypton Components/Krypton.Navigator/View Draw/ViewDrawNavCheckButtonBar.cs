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
    /// Navigator view element for drawing a bar check button for a krypton page.
    /// </summary>
    internal class ViewDrawNavCheckButtonBar : ViewDrawNavCheckButtonBase,
                                               INavCheckItem
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewDrawNavCheckButtonBar class.
        /// </summary>
        /// <param name="navigator">Owning navigator instance.</param>
        /// <param name="page">Page this check button represents.</param>
        /// <param name="orientation">Orientation for the check button.</param>
        public ViewDrawNavCheckButtonBar(KryptonNavigator navigator,
                                         KryptonPage? page,
                                         VisualOrientation orientation)
            : base(navigator, page!, orientation)
        {
        }

        /// <summary>
        /// Initialize a new instance of the ViewDrawNavCheckButtonBar class.
        /// </summary>
        /// <param name="navigator">Owning navigator instance.</param>
        /// <param name="page">Page this check button represents.</param>
        /// <param name="orientation">Orientation for the check button.</param>
        /// <param name="stateDisabled">Source for disabled state values.</param>
        /// <param name="stateNormal">Source for normal state values.</param>
        /// <param name="stateTracking">Source for tracking state values.</param>
        /// <param name="statePressed">Source for pressed state values.</param>
        /// <param name="stateSelected">Source for selected state values.</param>
        /// <param name="stateFocused">Source for focused state values.</param>
        public ViewDrawNavCheckButtonBar(KryptonNavigator navigator,
                                         KryptonPage? page,
                                         VisualOrientation orientation,
                                         IPaletteTriple stateDisabled,
                                         IPaletteTriple stateNormal,
                                         IPaletteTriple stateTracking,
                                         IPaletteTriple statePressed,
                                         IPaletteTriple stateSelected,
                                         IPaletteTriple stateFocused)
            : base(navigator, page, orientation, stateDisabled,
                   stateNormal, stateTracking, statePressed,
                   stateSelected, stateFocused)
        {
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewDrawNavCheckButtonBar:{Id}";

        #endregion

        #region View
        /// <summary>
        /// Gets the view associated with the check item.
        /// </summary>
        public ViewBase View => this;

        #endregion

        #region IContentValues
        /// <summary>
        /// Gets the content image.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Image value.</returns>
        public override Image? GetImage(PaletteState state) => Page?.GetImageMapping(Navigator.Bar.BarMapImage);

        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public override string GetShortText() => Page?.GetTextMapping(Navigator.Bar.BarMapText)!;

        /// <summary>
        /// Gets the content long text.
        /// </summary>
        /// <returns>String value.</returns>
        public override string GetLongText() => Page?.GetTextMapping(Navigator.Bar.BarMapExtraText)!;

        #endregion

        #region OnClick
        /// <summary>
        /// Processes the Click event from the button. 
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnClick(object? sender, EventArgs e)
        {
            base.OnClick(sender, e);

            // If the page is actually now selected
            if (Navigator.SelectedPage == Page)
            {
                // If in a tabs only mode then show the popup for the page
                switch (Navigator.NavigatorMode)
                {
                    case NavigatorMode.BarCheckButtonGroupOnly:
                    case NavigatorMode.BarCheckButtonOnly:
                    case NavigatorMode.BarTabOnly:
                    case NavigatorMode.HeaderBarCheckButtonOnly:
                        // Show popup for this page
                        Navigator.ShowPopupPage(Page!, this, null);
                        break;
                }
            }
        }
        #endregion
    }
}
