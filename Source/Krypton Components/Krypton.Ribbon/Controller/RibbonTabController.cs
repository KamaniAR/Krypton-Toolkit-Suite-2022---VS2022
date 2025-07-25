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
    /// Process mouse events for a ribbon tab.
    /// </summary>
    internal class RibbonTabController : GlobalId,
                                         IMouseController,
                                         ISourceController,
                                         IKeyController,
                                         IRibbonKeyTipTarget
    {
        #region Instance Fields
        private readonly KryptonRibbon _ribbon;
        private bool _mouseOver;
        private bool _rightButtonDown;
        private readonly ViewDrawRibbonTab _target;
        private NeedPaintHandler? _needPaint;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the mouse is used to left click the target.
        /// </summary>
        public event MouseEventHandler? Click;

        /// <summary>
        /// Occurs when the mouse is used to right click the target.
        /// </summary>
        public event MouseEventHandler? ContextClick;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the RibbonTabController class.
        /// </summary>
        /// <param name="ribbon">Reference to owning control.</param>
        /// <param name="target">Target for state changes.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public RibbonTabController([DisallowNull] KryptonRibbon? ribbon,
                                   [DisallowNull] ViewDrawRibbonTab? target,
                                   [DisallowNull] NeedPaintHandler? needPaint)
        {
            Debug.Assert(ribbon is not null);
            Debug.Assert(target is not null);

            // Remember incoming references
            _ribbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));
            _target = target ?? throw new ArgumentNullException(nameof(target));

            // Store the provided paint notification delegate
            NeedPaint = needPaint ?? throw new ArgumentNullException(nameof(needPaint));
        }
        #endregion

        #region Mouse Notifications
        /// <summary>
        /// Mouse has entered the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        public virtual void MouseEnter(Control c)
        {
            if (Active)
            {
                // Mouse is over the target
                _mouseOver = true;

                // Update the visual state
                UpdateTargetState(c);
            }
        }

        /// <summary>
        /// Mouse has moved inside the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="pt">Mouse position relative to control.</param>
        public virtual void MouseMove(Control c, Point pt)
        {
        }

        /// <summary>
        /// Mouse button has been pressed in the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="pt">Mouse position relative to control.</param>
        /// <param name="button">Mouse button pressed down.</param>
        /// <returns>True if capturing input; otherwise false.</returns>
        public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
        {
            if (Active)
            {
                switch (button)
                {
                    // Only interested in left mouse pressing down
                    case MouseButtons.Left:
                        {
                            // Can only click if enabled
                            if (_target.Enabled)
                            {
                                // Generate a click event
                                OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
                            }

                            // Update the visual state
                            UpdateTargetState(c);
                            break;
                        }
                    case MouseButtons.Right:
                        // Remember the user has pressed the right mouse button down
                        _rightButtonDown = true;
                        break;
                }
            }

            return false;
        }

        /// <summary>
        /// Mouse button has been released in the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="pt">Mouse position relative to control.</param>
        /// <param name="button">Mouse button released.</param>
        public virtual void MouseUp(Control c, Point pt, MouseButtons button)
        {
            // If user is releasing the right mouse button
            if (button == MouseButtons.Right)
            {
                // And it was pressed over the tab
                if (_rightButtonDown)
                {
                    _rightButtonDown = false;

                    // Raises event so a context menu for the ribbon can be shown
                    OnContextClick(new MouseEventArgs(MouseButtons.Right, 1, pt.X, pt.Y, 0));
                }
            }
        }

        /// <summary>
        /// Mouse has left the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="next">Reference to view that is next to have the mouse.</param>
        public virtual void MouseLeave(Control c, ViewBase? next)
        {
            // Only if mouse is leaving all the children monitored by controller.
            if (!_target.ContainsRecurse(next))
            {
                // Mouse is no longer over the target
                _mouseOver = false;

                // Update the visual state
                UpdateTargetState(c);
            }
        }

        /// <summary>
        /// Left mouse button double click.
        /// </summary>
        /// <param name="pt">Mouse position relative to control.</param>
        public virtual void DoubleClick(Point pt)
        {
            // Ignore double click at design time
            if (_ribbon is { InDesignMode: false, AllowMinimizedChange: true })
            {
                // Toggle the minimized mode of ribbon control
                _ribbon.MinimizedMode = !_ribbon.MinimizedMode;
            }
        }

        /// <summary>
        /// Should the left mouse down be ignored when present on a visual form border area.
        /// </summary>
        public virtual bool IgnoreVisualFormLeftButtonDown => false;

        #endregion

        #region Focus Notifications
        /// <summary>
        /// Source control has got the focus.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        public virtual void GotFocus(Control c)
        {
            _target.HasFocus = true;

            // Redraw to show the change in visual state
            OnNeedPaint(false, _target.ClientRectangle);
        }

        /// <summary>
        /// Source control has lost the focus.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        public virtual void LostFocus([DisallowNull] Control c)
        {
            _target.HasFocus = false;

            // Redraw to show the change in visual state
            OnNeedPaint(false, _target.ClientRectangle);
        }
        #endregion

        #region Key Notifications
        /// <summary>
        /// Key has been pressed down.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        public void KeyDown(Control c, KeyEventArgs e)
        {
            ViewBase? newView = null;
            Keys keyData = e.KeyData;

            if (_ribbon.TabsArea is null)
            {
                throw new NullReferenceException(GlobalStaticValues.PropertyCannotBeNull(nameof(_ribbon.TabsArea)));
            }

            // When there is no selected tab then tab and shift+tab become right and left
            if (_ribbon.SelectedTab == null)
            {
                if (keyData == Keys.Tab)
                {
                    keyData = Keys.Right;
                }

                if (keyData == (Keys.Tab | Keys.Shift))
                {
                    keyData = Keys.Left;
                }
            }

            switch (keyData)
            {
                case Keys.Right:
                    // Get the next visible tab page
                    newView = (_target.ViewLayoutRibbonTabs.GetViewForNextRibbonTab(_target.RibbonTab!)
                               ?? (ViewBase)_ribbon.TabsArea.ButtonSpecManager?.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far)!)
                              ?? _ribbon.TabsArea.ButtonSpecManager?.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);

                    // Move across to any far defined buttons

                    // Move across to any inherit defined buttons

                    // Rotate around to application button
                    if (newView == null)
                    {
                        if (_ribbon.TabsArea.LayoutAppButton.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppButton.AppButton;
                        }
                        else if (_ribbon.TabsArea.LayoutAppTab.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppTab.AppTab;
                        }
                    }
                    break;
                case Keys.Left:
                    // Get the previous visible tab page
                    newView = (_target.ViewLayoutRibbonTabs.GetViewForPreviousRibbonTab(_target.RibbonTab!)
                               ?? (ViewBase)_ribbon.TabsArea.ButtonSpecManager?.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near)!)
                              ?? _ribbon.GetLastQATView();

                    // Move across to any near defined buttons

                    // Get the last qat button

                    // Rotate around to application button
                    if (newView == null)
                    {
                        if (_ribbon.TabsArea.LayoutAppButton.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppButton.AppButton;
                        }
                        else if (_ribbon.TabsArea.LayoutAppTab.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppTab.AppTab;
                        }
                    }
                    break;
                case Keys.Tab | Keys.Shift:
                    // Move across to any near defined buttons
                    newView = _ribbon.TabsArea.ButtonSpecManager?.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near)
                              ?? _ribbon.GetLastQATView();

                    // Get the last qat button

                    // Rotate around to application button
                    if (newView == null)
                    {
                        if (_ribbon.TabsArea.LayoutAppButton.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppButton.AppButton;
                        }
                        else if (_ribbon.TabsArea.LayoutAppTab.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppTab.AppTab;
                        }
                    }
                    break;
                case Keys.Down:
                    // Get the first focus item for the currently selected page
                    newView = _ribbon.GroupsArea.ViewGroups.GetFirstFocusItem();
                    break;
                case Keys.Tab:
                    // Get the first focus item for the currently selected page
                    newView = (_ribbon.GroupsArea.ViewGroups.GetFirstFocusItem()
                               ?? _ribbon.TabsArea.ButtonSpecManager?.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near))
                              ?? _ribbon.GetLastQATView();

                    // Move across to any near defined buttons

                    // Get the last qat button

                    // Rotate around to application button
                    if (newView == null)
                    {
                        if (_ribbon.TabsArea.LayoutAppButton.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppButton.AppButton;
                        }
                        else if (_ribbon.TabsArea.LayoutAppTab.Visible)
                        {
                            newView = _ribbon.TabsArea.LayoutAppTab.AppTab;
                        }
                    }
                    break;
                case Keys.Enter:
                case Keys.Space:
                    // When minimize, pressing enter will select the tab and pop it up
                    if (_ribbon.RealMinimizedMode
                        && (_ribbon.SelectedTab != _target.RibbonTab)
                        )
                    {
                        // Select the tab will automatically create a popup for it
                        _ribbon.SelectedTab = _target.RibbonTab;

                        // Get access to the popup for the group
                        if (VisualPopupManager.Singleton.CurrentPopup is VisualPopupMinimized popupMinimized)
                        {
                            popupMinimized.SetFirstFocusItem();
                        }
                    }
                    break;
            }

            // If we have a new view to focus and it is not ourself...
            if ((newView != null) && (newView != _target))
            {
                // If the new view is a tab then select that tab
                if (!_ribbon.RealMinimizedMode && (newView is ViewDrawRibbonTab tab))
                {
                    _ribbon.SelectedTab = tab.RibbonTab;
                }

                // Finally we switch focus to new view
                _ribbon.FocusView = newView;
            }
        }

        /// <summary>
        /// Key has been pressed.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        public void KeyPress(Control c, KeyPressEventArgs e)
        {
        }

        /// <summary>
        /// Key has been released.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        /// <returns>True if capturing input; otherwise false.</returns>
        public bool KeyUp(Control c, KeyEventArgs e) => false;

        #endregion

        #region KeyTipSelect
        /// <summary>
        /// Perform actual selection of the item.
        /// </summary>
        /// <param name="ribbon">Reference to owning ribbon instance.</param>
        public void KeyTipSelect(KryptonRibbon ribbon)
        {
            // If we are not selected then make us so
            if (_ribbon.SelectedTab != _target.RibbonTab)
            {
                _ribbon.SelectedTab = _target.RibbonTab;
            }

            // Switch focus to this view
            _ribbon.FocusView = _target;

            // Update key tips with those appropriate for this tab
            KeyTipMode mode = _ribbon.RealMinimizedMode ? KeyTipMode.PopupMinimized : KeyTipMode.SelectedGroups;
            _ribbon.KeyTipMode = mode;
            _ribbon.SetKeyTips(_ribbon.GenerateKeyTipsForSelectedTab(), mode);
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets and sets the need paint delegate for notifying paint requests.
        /// </summary>
        public NeedPaintHandler NeedPaint
        {
            get => _needPaint!;

            set
            {
                // Warn if multiple sources want to hook their single delegate
                Debug.Assert(((_needPaint == null) && (value != null))
                             || ((_needPaint != null) && (value == null))
                             );

                _needPaint = value;
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Set the correct visual state of the target.
        /// </summary>
        /// <param name="c">Owning control.</param>
        protected void UpdateTargetState(Control c)
        {
            if (c == null || c.IsDisposed)
            {
                UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
            }
            else
            {
                UpdateTargetState(c.PointToClient(Control.MousePosition));
            }
        }

        /// <summary>
        /// Set the correct visual state of the target.
        /// </summary>
        /// <param name="pt">Mouse point.</param>
        protected void UpdateTargetState(Point pt)
        {
            // By default, the button is in the normal state
            PaletteState newState;

            // If the button is disabled then show as disabled
            if (!_target.Enabled)
            {
                newState = PaletteState.Disabled;
            }
            else
            {
                if (_target.Checked)
                {
                    newState = _mouseOver ? PaletteState.CheckedTracking : PaletteState.CheckedNormal;
                }
                else
                {
                    newState = _mouseOver ? PaletteState.Tracking : PaletteState.Normal;
                }
            }

            // If state has changed
            if (_target.ElementState != newState)
            {
                // Update target to reflect new state
                _target.ElementState = newState;

                // Redraw to show the change in visual state
                OnNeedPaint(false, _target.ClientRectangle);
            }
        }

        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="e">A MouseEventArgs containing the event data.</param>
        protected virtual void OnClick(MouseEventArgs e) => Click?.Invoke(_target, e);

        /// <summary>
        /// Raises the ContextClick event.
        /// </summary>
        /// <param name="e">A MouseEventArgs containing the event data.</param>
        protected virtual void OnContextClick(MouseEventArgs e) => ContextClick?.Invoke(_target, e);

        /// <summary>
        /// Raises the NeedPaint event.
        /// </summary>
        /// <param name="needLayout">Does the palette change require a layout.</param>
        /// <param name="invalidRect">Rectangle to invalidate.</param>
        protected virtual void OnNeedPaint(bool needLayout,
                                           Rectangle invalidRect)
        {
            if (_needPaint != null)
            {
                // Redraw the entire with the ribbon for the button location
                invalidRect = new Rectangle(0, invalidRect.Y - 3, _ribbon.Width, invalidRect.Height + 3);
                _needPaint(this, new NeedLayoutEventArgs(needLayout, invalidRect));
            }
        }
        #endregion

        #region Implementation
        private bool Active
        {
            get
            {
                if (_ribbon == null)
                {
                    return false;
                }
                else
                {
                    if (_ribbon.InDesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        Form? topForm = _ribbon.FindForm();
                        return (CommonHelper.ActiveFloatingWindow != null) ||
                               ((topForm != null) &&
                                (topForm.ContainsFocus ||
                                ((topForm.Parent != null) && topForm is { Visible: true, Enabled: true })));
                    }
                }
            }
        }
        #endregion
    }
}
