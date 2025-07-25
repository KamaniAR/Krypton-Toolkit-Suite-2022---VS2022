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
    internal class ViewRibbonQATOverflowManager : ViewManager
    {
        #region Instance Fields
        private readonly KryptonRibbon _ribbon;
        private ViewBase? _focusView;
        private bool _layingOut;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewRibbonPopupGroupManager class.
        /// </summary>
        /// <param name="ribbon">Reference to original ribbon instance.</param>
        /// <param name="control">Owning control.</param>
        /// <param name="qatContents">View that will handle focus requests.</param>
        /// <param name="root">View for group we are tracking.</param>
        public ViewRibbonQATOverflowManager([DisallowNull] KryptonRibbon ribbon,
                                            Control control,
                                            [DisallowNull] ViewLayoutRibbonQATContents qatContents,
                                            ViewBase root)
            : base(control, root)
        {
            Debug.Assert(ribbon is not null);
            Debug.Assert(qatContents is not null);
            
            _ribbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));
            QATContents = qatContents ?? throw new ArgumentNullException(nameof(qatContents));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
            // Remove focus from current view
            FocusView = null;

            base.Dispose();
        }
        #endregion

        #region QATContents
        /// <summary>
        /// Gets a the view that handles the overflow items.
        /// </summary>
        public ViewLayoutRibbonQATContents? QATContents { get; }

        #endregion

        #region GetPreferredSize
        /// <summary>
        /// Discover the preferred size of the view.
        /// </summary>
        /// <param name="renderer">Renderer provider.</param>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        public override Size GetPreferredSize(IRenderer renderer,
                                              Size proposedSize)
        {
            // Update the calculated values used during layout calls
            _ribbon!.CalculatedValues.Recalculate();

            // Let base class perform standard preferred sizing actions
            return base.GetPreferredSize(renderer, proposedSize);
        }
        #endregion

        #region Layout
        /// <summary>
        /// Perform a layout of the view.
        /// </summary>
        /// <param name="context">View context for layout operation.</param>
        public override void Layout(ViewLayoutContext context)
        {
            // Prevent reentrancy
            if (!_layingOut)
            {
                _layingOut = true;

                // Update the calculated values used during layout calls
                _ribbon!.CalculatedValues.Recalculate();

                // Let base class perform standard layout actions
                base.Layout(context);

                _layingOut = false;
            }
        }
        #endregion

        #region Key
        /// <summary>
        /// Perform key down handling.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        public override void KeyDown(KeyEventArgs e) =>
            // Tell current view of key event
            FocusView?.KeyDown(e);

        /// <summary>
        /// Perform key press handling.
        /// </summary>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        public override void KeyPress(KeyPressEventArgs e) =>
            // Tell current view of key event
            FocusView?.KeyPress(e);

        /// <summary>
        /// Perform key up handling.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        public override void KeyUp(KeyEventArgs e)
        {
            // Tell current view of key event
            if (FocusView != null)
            {
                MouseCaptured = FocusView.KeyUp(e);
            }
        }
        #endregion

        #region FocusView
        /// <summary>
        /// Gets and sets the view that has the focus.
        /// </summary>
        public ViewBase? FocusView
        {
            get => _focusView;

            set
            {
                // Only interested in changes of focus
                if (_focusView != value)
                {
                    // Remove focus from existing view
                    _focusView?.LostFocus(Root.OwningControl!);

                    _focusView = value;

                    // Add focus to the new view
                    _focusView?.GotFocus(Root.OwningControl!);
                }
            }
        }
        #endregion
    }
}
