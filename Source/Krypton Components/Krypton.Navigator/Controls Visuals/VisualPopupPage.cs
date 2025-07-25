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

// ReSharper disable RedundantNullableFlowAttribute

namespace Krypton.Navigator
{
    internal class VisualPopupPage : VisualPopup
    {
        #region Static Fields
        private static readonly MethodInfo? _containerSelect;
        #endregion

        #region Instance Fields
        private readonly KryptonNavigator _navigator;
        private readonly KryptonPage? _page;
        #endregion

        #region Identity
        static VisualPopupPage() =>
            // Cache access to the internal 'Select' method of the ContainerControl
            _containerSelect = typeof(ContainerControl).GetMethod("Select",
                BindingFlags.Instance |
                BindingFlags.NonPublic);

        /// <summary>
        /// Initialize a new instance of the VisualPopupPage class.
        /// </summary>
        /// <param name="navigator">Reference to owning navigator control.</param>
        /// <param name="page">Reference to page for display.</param>
        /// <param name="renderer">Drawing renderer.</param>
        public VisualPopupPage([DisallowNull] KryptonNavigator navigator,
                               [DisallowNull] KryptonPage page,
                               IRenderer renderer)
            : base(renderer, true)
        {
            Debug.Assert(navigator != null);
            Debug.Assert(page != null);

            // Remember references needed later
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            _page = page ?? throw new ArgumentNullException(nameof(page));

            // Always var the layout that positions the actual page
            var layoutPage = new ViewLayoutPopupPage(_navigator, _page!);

            // Create the internal panel used for containing content
            if (_navigator.StateNormal?.HeaderGroup != null)
            {
                var drawGroup = new ViewDrawCanvas(_navigator.StateNormal.HeaderGroup.Back,
                    _navigator.StateNormal.HeaderGroup.Border, VisualOrientation.Top)
                {

                    // Add the layout inside the draw group
                    layoutPage
                };

                // Do we need to add a border area around the page group
                if (_navigator.PopupPages.Border > 0)
                {
                    // Grab the actual border values
                    var border = _navigator.PopupPages.Border;

                    // Put the page group inside a layout that has separators 
                    // to pad out the sizing to the border size we need
                    var layoutDocker = new ViewLayoutDocker
                    {
                        { drawGroup, ViewDockStyle.Fill },
                        { new ViewLayoutSeparator(border), ViewDockStyle.Top },
                        { new ViewLayoutSeparator(border), ViewDockStyle.Bottom },
                        { new ViewLayoutSeparator(border), ViewDockStyle.Left },
                        { new ViewLayoutSeparator(border), ViewDockStyle.Right }
                    };

                    // Create a new top level group that contains the layout
                    drawGroup = new ViewDrawCanvas(_navigator.StateNormal.Back,
                        _navigator.StateNormal.HeaderGroup.Border,
                        VisualOrientation.Top)
                    {
                        layoutDocker
                    };
                }

                ViewManager = new ViewManager(this, drawGroup);
            }

            // Borrow the child panel that contains all the pages from 
            // the navigator and add it inside as a child of ourself
            _navigator.BorrowChildPanel();
            if (_navigator.ChildPanel != null)
            {
                Controls.Add(_navigator.ChildPanel);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (_navigator is { IsChildPanelBorrowed: true, ChildPanel: not null })
            {
                // Remove the child panel from ourself and return it 
                // back to the navigator that it was borrowed from
                Controls.Remove(_navigator.ChildPanel);

                // Move the panel back to a minus position so it does not show
                // until it is laid out again by the owning navigator instance
                _navigator.ChildPanel.Location = new Point(-_navigator.ChildPanel.Width,
                                                           -_navigator.ChildPanel.Height);

                _navigator.ReturnChildPanel();
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the Layout event.
        /// </summary>
        /// <param name="levent">An EventArgs that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            // Let base class calculate fill rectangle
            base.OnLayout(levent);

            // Need a render context for accessing the renderer
            using var context = new RenderContext(this, null, ClientRectangle, Renderer);
            // Grab a path that is the outside edge of the border
            Rectangle borderRect = ClientRectangle;
            if (_navigator.StateNormal?.HeaderGroup != null)
            {
                using var gh = new GraphicsHint(context.Graphics,
                    _navigator.StateNormal.HeaderGroup.Border.GetBorderGraphicsHint(PaletteState.Normal));
                GraphicsPath borderPath1 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _navigator.StateNormal.HeaderGroup.Border, VisualOrientation.Top, PaletteState.Normal);
                borderRect.Inflate(-1, -1);
                GraphicsPath borderPath2 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _navigator.StateNormal.HeaderGroup.Border, VisualOrientation.Top, PaletteState.Normal);
                borderRect.Inflate(-1, -1);
                GraphicsPath borderPath3 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _navigator.StateNormal.HeaderGroup.Border, VisualOrientation.Top, PaletteState.Normal);

                // Update the region of the popup to be the border path
                Region = new Region(borderPath1);

                // Inform the shadow to use the same paths for drawing the shadow
                DefineShadowPaths(borderPath1, borderPath2, borderPath3);
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Show the group popup relative to the parent group instance.
        /// </summary>
        /// <param name="parentScreenRect">Screen rectangle of the parent.</param>
        public void ShowCalculatingSize(Rectangle parentScreenRect)
        {
            // Get the size the popup would like to be
            if (ViewManager != null)
            {
                Size popupSize = ViewManager.GetPreferredSize(Renderer, Size.Empty);

                // Get the resolved position for the popup page
                var position = _navigator.ResolvePopupPagePosition();

                // Find the size and position relative to the parent screen rect
                switch (position)
                {
                    case PopupPagePosition.AboveNear:
                        parentScreenRect = new Rectangle(parentScreenRect.Left, parentScreenRect.Top - _navigator.PopupPages.Gap - popupSize.Height, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.AboveMatch:
                        parentScreenRect = new Rectangle(parentScreenRect.Left, parentScreenRect.Top - _navigator.PopupPages.Gap - popupSize.Height, parentScreenRect.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.AboveFar:
                        parentScreenRect = new Rectangle(parentScreenRect.Right - popupSize.Width, parentScreenRect.Top - _navigator.PopupPages.Gap - popupSize.Height, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.BelowNear:
                        parentScreenRect = new Rectangle(parentScreenRect.Left, parentScreenRect.Bottom + _navigator.PopupPages.Gap, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.BelowMatch:
                        parentScreenRect = new Rectangle(parentScreenRect.Left, parentScreenRect.Bottom + _navigator.PopupPages.Gap, parentScreenRect.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.BelowFar:
                        parentScreenRect = new Rectangle(parentScreenRect.Right - popupSize.Width, parentScreenRect.Bottom + _navigator.PopupPages.Gap, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.FarBottom:
                        parentScreenRect = new Rectangle(parentScreenRect.Right + _navigator.PopupPages.Gap, parentScreenRect.Bottom - popupSize.Height, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.FarMatch:
                        parentScreenRect = new Rectangle(parentScreenRect.Right + _navigator.PopupPages.Gap, parentScreenRect.Top, popupSize.Width, parentScreenRect.Height);
                        break;
                    case PopupPagePosition.FarTop:
                        parentScreenRect = new Rectangle(parentScreenRect.Right + _navigator.PopupPages.Gap, parentScreenRect.Top, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.NearBottom:
                        parentScreenRect = new Rectangle(parentScreenRect.Left - _navigator.PopupPages.Gap - popupSize.Width, parentScreenRect.Bottom - popupSize.Height, popupSize.Width, popupSize.Height);
                        break;
                    case PopupPagePosition.NearMatch:
                        parentScreenRect = new Rectangle(parentScreenRect.Left - _navigator.PopupPages.Gap - popupSize.Width, parentScreenRect.Top, popupSize.Width, parentScreenRect.Height);
                        break;
                    case PopupPagePosition.NearTop:
                        parentScreenRect = new Rectangle(parentScreenRect.Left - _navigator.PopupPages.Gap - popupSize.Width, parentScreenRect.Top, popupSize.Width, popupSize.Height);
                        break;
                }
            }

            if (_page != null)
            {
                var e = new PopupPageEventArgs(_page, _navigator.Pages.IndexOf(_page), parentScreenRect);

                // Use event to allow the popup to be cancelled or the position altered
                _navigator.OnDisplayPopupPage(e);

                // Do we need to kill ourself
                if (!e.Cancel)
                {
                    Show(e.ScreenRect);
                }
                else
                {
                    Dispose();
                }
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the KeyDown event.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Cannot process a message for a disposed control
            if (!IsDisposed)
            {
                // If the user pressed tab or shift tab
                if (e.KeyData is Keys.Tab or (Keys.Tab | Keys.Shift))
                {
                    // If we do not currently contain the focus
                    if (_page is { ContainsFocus: false })
                    {
                        // Select the appropriate control on the page
                        TabToNextControl(null, (e.KeyData == Keys.Tab));

                        // Finished, do not call base class
                        return;
                    }
                }
            }

            // Let base class fire events
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Selects the next available control and makes it active.
        /// </summary>
        /// <param name="forward">true to cycle forward; otherwise false.</param>
        /// <returns>true if a control selected; otherwise false.</returns>
        protected override bool ProcessTabKey(bool forward)
        {
            // Find the control in our hierarchy that has the focus
            Control? focus = GetControlWithFocus(this);

            // If nothing has the focus then we cannot perform processing
            return focus == null || TabToNextControl(focus, forward);
        }
        #endregion

        #region Implementation
        private Control? GetControlWithFocus(Control control)
        {
            // Does the provided control have the focus?
            if (control.Focused)
            {
                return control;
            }
            else
            {
                // Check each child hierarchy in turn
                foreach (Control child in control.Controls)
                {
                    if (child.ContainsFocus)
                    {
                        return GetControlWithFocus(child);
                    }
                }

                return null;
            }
        }

        private bool TabToNextControl(Control? focus,
                                      bool forward)
        {
            // Start searching from the current focus control
            Control? next = focus;

            // If only allow focus on a control within the page instance, so
            // setting to null will force the GetNextControl to get the first
            // child control of the page.
            if (_page != null && !_page.Contains(next))
            {
                next = null;
            }

            // Have we wrapped around the end yet?
            var wrapped = false;

            do
            {
                // Find the next control in sequence
                if (_page != null)
                {
                    next = _page.GetNextControl(next!, forward);

                    // If no more controls found, then finished
                    if (next == null)
                    {
                        // If already wrapped around end of list then must be finished
                        if (wrapped)
                        {
                            return false;
                        }

                        // Keep going from the start
                        wrapped = true;
                    }
                    else
                    {
                        // Can only selected controls that are inside ourself as a container
                        if (_page.Contains(next))
                        {
                            // If the next control is allowed to become selected 
                            // and allowed to be selected because of a tab action
                            if (next is { CanSelect: true, TabStop: true })
                            {
                                // Is the next control a container control?
                                if (next is ContainerControl)
                                {
                                    // If the source control of the next/previous is inside the container
                                    // then we do not want to stop at the container itself as that would 
                                    // just put the focus straight back into the container. So keep going.
                                    if (!next.Contains(focus))
                                    {
                                        // We need to call the protected select method in order to have 
                                        // it perform an internal select of the first/last ordered item
                                        if (_containerSelect != null)
                                        {
                                            _containerSelect.Invoke(next, new object[] { true, forward });
                                        }
                                        return true;
                                    }
                                }
                                else
                                {
                                    // Select the actual control
                                    if (!_page.ContainsFocus)
                                    {
                                        next.Focus();
                                    }
                                    else
                                    {
                                        next.Select();
                                    }

                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            while (next != focus);

            // We always override processing of this method
            return true;
        }
        #endregion
    }
}
