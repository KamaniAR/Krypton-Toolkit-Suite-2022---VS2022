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

namespace Krypton.Toolkit
{
    /// <summary>
    /// Controller used to manage keyboard and mouse interaction with a check box.
    /// </summary>
    public class CheckBoxController : GlobalId,
                                      IMouseController,
                                      IKeyController
    {
        #region Instance Fields
        private bool _captured;
        private readonly ViewDrawCheckBox _target;
        private readonly ViewBase _top;
        private NeedPaintHandler? _needPaint;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the check box has been selected.
        /// </summary>
        public event EventHandler? Click;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the CheckBoxController class.
        /// </summary>
        /// <param name="target">Target for state changes.</param>
        /// <param name="top">Top element for the check box control.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public CheckBoxController(ViewDrawCheckBox target,
                                  ViewBase top,
                                  NeedPaintHandler needPaint)
        {
            Debug.Assert(target is not null);
            Debug.Assert(top is not null);

            // Remember target for state changes
            // Debug.Assert() causes the null assignment warning.
            // Suppressed by the null forgiving operator
            _target = target!;
            _top = top!;
            NeedPaint = needPaint;
        }
        #endregion

        #region Mouse Notifications
        /// <summary>
        /// Mouse has entered the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        public virtual void MouseEnter(Control c)
        {
            if (Enabled)
            {
                // Mouse is over the target
                _target.Tracking = true;
                PerformNeedPaint();
            }
        }

        /// <summary>
        /// Mouse has moved inside the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="pt">Mouse position relative to control.</param>
        public virtual void MouseMove(Control c, Point pt)
        {
            // When capturing input...
            if (_captured)
            {
                if (Enabled)
                {
                    // Only pressed if mouse still over the view element
                    var pressed = _top.ClientRectangle.Contains(pt);

                    // Only update and paint if we a change has occurred
                    if (_target.Pressed != pressed)
                    {
                        _target.Pressed = pressed;
                        PerformNeedPaint();
                    }
                }
            }
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
            // Only interested in left mouse pressing down
            if (button == MouseButtons.Left)
            {
                // Capturing mouse input
                _captured = true;

                if (Enabled)
                {
                    _target.Pressed = true;
                    PerformNeedPaint();
                }

                // Take the focus if allowed
                if (c.CanFocus)
                {
                    c.Focus();
                }
            }

            return _captured;
        }

        /// <summary>
        /// Mouse button has been released in the view.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="pt">Mouse position relative to control.</param>
        /// <param name="button">Mouse button released.</param>
        public virtual void MouseUp(Control c, Point pt, MouseButtons button)
        {
            // If the mouse is currently captured
            if (_captured)
            {
                // Not capturing mouse input anymore
                _captured = false;

                if (Enabled)
                {
                    // Only interested in left mouse being released
                    if (button == MouseButtons.Left)
                    {
                        // Only if check box is still pressed
                        if (_target is { Pressed: true, Enabled: true })
                        // Can only click if enabled
                        {
                            OnClick(EventArgs.Empty);
                        }
                    }

                    _target.Pressed = false;
                }

                PerformNeedPaint();
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
                if (Enabled)
                {
                    // Mouse is no longer over the target
                    _target.Tracking = false;
                }

                // If leaving the view then cannot be capturing mouse input anymore
                _captured = false;
                PerformNeedPaint();
            }
        }

        /// <summary>
        /// Left mouse button double click.
        /// </summary>
        /// <param name="pt">Mouse position relative to control.</param>
        public virtual void DoubleClick(Point pt)
        {
            // Do nothing
        }

        /// <summary>
        /// Should the left mouse down be ignored when present on a visual form border area.
        /// </summary>
        public virtual bool IgnoreVisualFormLeftButtonDown => false;

        #endregion

        #region Key Notifications

        /// <summary>
        /// Key has been pressed down.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void KeyDown([DisallowNull] Control c, [DisallowNull] KeyEventArgs e)
        {
            Debug.Assert(c != null);
            Debug.Assert(e != null);

            // Validate incoming references
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.KeyCode == Keys.Space)
            {
                // Enter the captured mode and pretend mouse is over area
                if (Enabled)
                {
                    _captured = true;
                    _target.Pressed = true;
                    PerformNeedPaint();
                }
            }
        }

        /// <summary>
        /// Key has been pressed.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        public virtual void KeyPress(Control c, KeyPressEventArgs e)
        {
        }

        /// <summary>
        /// Key has been released.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>True if capturing input; otherwise false.</returns>
        public virtual bool KeyUp([DisallowNull] Control c, [DisallowNull] KeyEventArgs e)
        {
            Debug.Assert(c != null);
            Debug.Assert(e != null);

            // Validate incoming references
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // If the user pressed the escape key
            if (e.KeyCode is Keys.Escape or Keys.Space)
            {
                // If we are capturing mouse input
                if (_captured)
                {
                    // Release the mouse capture
                    c.Capture = false;
                    _captured = false;

                    if (Enabled)
                    {
                        // No longer pressing the check box
                        _target.Pressed = false;
                    }

                    if (e.KeyCode == Keys.Space)
                    {
                        // Can only click if enabled
                        if (_target.Enabled)
                        {
                            OnClick(EventArgs.Empty);
                        }
                    }

                    PerformNeedPaint();
                }
            }

            return _captured;
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets and sets the enabled state of the controller.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets and sets the need paint delegate for notifying paint requests.
        /// </summary>
        public NeedPaintHandler? NeedPaint
        {
            get => _needPaint;

            set
            {
                // Warn if multiple sources want to hook their single delegate
                Debug.Assert(((_needPaint == null) && (value != null)) ||
                             ((_needPaint != null) && (value == null)));

                _needPaint = value;
            }
        }

        /// <summary>
        /// Gets access to the associated target of the controller.
        /// </summary>
        public ViewBase Target => _target;


        /// <summary>
        /// Fires the NeedPaint event.
        /// </summary>
        public void PerformNeedPaint() => OnNeedPaint(false);

        /// <summary>
        /// Fires the NeedPaint event.
        /// </summary>
        /// <param name="needLayout">Does the palette change require a layout.</param>
        public void PerformNeedPaint(bool needLayout) => OnNeedPaint(needLayout);

        #endregion

        #region Protected
        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnClick(EventArgs e) => Click?.Invoke(_target, e);

        /// <summary>
        /// Raises the NeedPaint event.
        /// </summary>
        /// <param name="needLayout">Does the palette change require a layout.</param>
        protected virtual void OnNeedPaint(bool needLayout) => _needPaint?.Invoke(this, new NeedLayoutEventArgs(needLayout));

        #endregion
    }
}
