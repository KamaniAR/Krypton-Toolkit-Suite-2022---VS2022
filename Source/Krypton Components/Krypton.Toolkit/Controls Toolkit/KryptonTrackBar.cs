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
    /// Allow user to scroll between a range of values.
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KryptonTrackBar), "ToolboxBitmaps.KryptonTrackBar.bmp")]
    [DefaultEvent(nameof(ValueChanged))]
    [DefaultProperty(nameof(Value))]
    [Designer(typeof(KryptonTrackBarDesigner))]
    [DesignerCategory(@"code")]
    [Description(@"Allow user to scroll between a range of values.")]
    public class KryptonTrackBar : VisualSimpleBase
    {
        #region Instance Fields
        private readonly ViewDrawTrackBar _drawTrackBar;
        private readonly PaletteTrackBarStatesOverride _overrideNormal;
        private readonly PaletteTrackBarPositionStatesOverride _overrideTracking;
        private readonly PaletteTrackBarPositionStatesOverride _overridePressed;
        private bool _autoSize;
        private int _requestedDim;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the value of the Value property changes.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when the value of the Value property changes.")]
        public event EventHandler? ValueChanged;

        /// <summary>
        /// Occurs when either a mouse or keyboard action moves the scroll box.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Occurs when either a mouse or keyboard action moves the scroll box.")]
        public event EventHandler? Scroll;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonTrackBar class.
        /// </summary>
        public KryptonTrackBar()
        {
            // Default values
            _autoSize = true;
            _requestedDim = 0;

            // Create the palette storage
            StateCommon = new PaletteTrackBarRedirect(Redirector, NeedPaintDelegate);
            OverrideFocus = new PaletteTrackBarRedirect(Redirector, NeedPaintDelegate);
            StateDisabled = new PaletteTrackBarStates(StateCommon, NeedPaintDelegate);
            StateNormal = new PaletteTrackBarStates(StateCommon, NeedPaintDelegate);
            StateTracking = new PaletteTrackBarPositionStates(StateCommon, NeedPaintDelegate);
            StatePressed = new PaletteTrackBarPositionStates(StateCommon, NeedPaintDelegate);

            // Create the override handling classes
            _overrideNormal = new PaletteTrackBarStatesOverride(OverrideFocus, StateNormal, PaletteState.FocusOverride);
            _overrideTracking = new PaletteTrackBarPositionStatesOverride(OverrideFocus, StateTracking, PaletteState.FocusOverride);
            _overridePressed = new PaletteTrackBarPositionStatesOverride(OverrideFocus, StatePressed, PaletteState.FocusOverride);

            // Create the view manager instance
            _drawTrackBar = new ViewDrawTrackBar(_overrideNormal, StateDisabled, _overrideTracking, _overridePressed, NeedPaintDelegate)
            {
                IgnoreRender = false, // (DrawBackground is true)
                RightToLeft = RightToLeft
            };
            _drawTrackBar.ValueChanged += OnDrawValueChanged;
            _drawTrackBar.Scroll += OnDrawScroll;
            ViewManager = new ViewManager(this, _drawTrackBar);
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [AllowNull]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// Determines the IME status of the object when selected.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode
        {
            get => base.ImeMode;
            set => base.ImeMode = value;
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(true)]
        public override bool AutoSize
        {
            get => _autoSize;

            set
            {
                if (value != _autoSize)
                {
                    _autoSize = value;

                    if (Orientation == Orientation.Horizontal)
                    {
                        SetStyle(ControlStyles.FixedHeight, _autoSize);
                        SetStyle(ControlStyles.FixedWidth, false);
                    }
                    else
                    {
                        SetStyle(ControlStyles.FixedWidth, _autoSize);
                        SetStyle(ControlStyles.FixedHeight, false);
                    }

                    AdjustSize();
                    OnAutoSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets and sets the auto size mode.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AutoSizeMode AutoSizeMode
        {
            get => base.AutoSizeMode;
            set => base.AutoSizeMode = value;
        }

        /// <summary>
        /// Gets and sets the internal padding space.
        /// </summary>
        [DefaultValue(typeof(Padding), "0,0,0,0")]
        public new Padding Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }

        /// <summary>
        /// Gets and sets the background style.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Background style.")]
        public PaletteBackStyle BackStyle
        {
            get => OverrideFocus.BackStyle;

            set
            {
                if (OverrideFocus.BackStyle != value)
                {
                    OverrideFocus.BackStyle = value;
                    PerformNeedPaint(true);
                }
            }
        }

        private bool ShouldSerializeBackStyle() => BackStyle != PaletteBackStyle.PanelClient;

        private void ResetBackStyle() => BackStyle = PaletteBackStyle.PanelClient;

        /// <summary>
        /// Gets access to the track bar appearance when it has focus.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining track bar appearance when it has focus.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTrackBarRedirect OverrideFocus { get; }

        private bool ShouldSerializeOverrideFocus() => !OverrideFocus.IsDefault;

        /// <summary>
        /// Gets access to the common TrackBar appearance that other states can override.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining common TrackBar appearance that other states can override.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTrackBarRedirect StateCommon { get; }

        private bool ShouldSerializeStateCommon() => !StateCommon.IsDefault;

        /// <summary>
        /// Gets access to the disabled TrackBar appearance.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining disabled TrackBar appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTrackBarStates StateDisabled { get; }

        private bool ShouldSerializeStateDisabled() => !StateDisabled.IsDefault;

        /// <summary>
        /// Gets access to the normal TrackBar appearance.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining normal TrackBar appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTrackBarStates StateNormal { get; }

        private bool ShouldSerializeStateNormal() => !StateNormal.IsDefault;

        /// <summary>
        /// Gets access to the tracking TrackBar appearance.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining tracking TrackBar appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTrackBarPositionStates StateTracking { get; }

        private bool ShouldSerializeStateTracking() => !StateTracking.IsDefault;

        /// <summary>
        /// Gets access to the pressed TrackBar appearance.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining pressed TrackBar appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTrackBarPositionStates StatePressed { get; }

        private bool ShouldSerializeStatePressed() => !StatePressed.IsDefault;

        /// <summary>
        /// Gets and sets if the control displays like a volume control.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Determines if the control display like a volume control.")]
        [DefaultValue(false)]
        public bool VolumeControl
        {
            get => _drawTrackBar.VolumeControl;

            set
            {
                if (value != _drawTrackBar.VolumeControl)
                {
                    _drawTrackBar.VolumeControl = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the size of the track bar elements.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Determines size of the track bar elements.")]
        [DefaultValue(PaletteTrackBarSize.Medium)]
        public PaletteTrackBarSize TrackBarSize
        {
            get => _drawTrackBar.TrackBarSize;

            set
            {
                if (value != _drawTrackBar.TrackBarSize)
                {
                    _drawTrackBar.TrackBarSize = value;
                    AdjustSize();
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating how to display the tick marks on the track bar.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Determines where tick marks are Displayed.")]
        [DefaultValue(TickStyle.BottomRight)]
        [RefreshProperties(RefreshProperties.All)]
        public TickStyle TickStyle
        {
            get => _drawTrackBar.TickStyle;

            set
            {
                if (value != _drawTrackBar.TickStyle)
                {
                    _drawTrackBar.TickStyle = value;
                    AdjustSize();
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value that specifies the delta between ticks drawn on the control.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Determines the frequency of tick marks.")]
        [DefaultValue(1)]
        public int TickFrequency
        {
            get => _drawTrackBar.TickFrequency;

            set
            {
                if (value != _drawTrackBar.TickFrequency)
                {
                    _drawTrackBar.TickFrequency = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the horizontal or vertical orientation of the track bar.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Background style.")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get => _drawTrackBar.Orientation;

            set
            {
                if (value != _drawTrackBar.Orientation)
                {
                    _drawTrackBar.Orientation = value;

                    if (Orientation == Orientation.Horizontal)
                    {
                        SetStyle(ControlStyles.FixedHeight, _autoSize);
                        SetStyle(ControlStyles.FixedWidth, false);
                        Width = Height;
                    }
                    else
                    {
                        SetStyle(ControlStyles.FixedHeight, false);
                        SetStyle(ControlStyles.FixedWidth, _autoSize);
                        Height = Width;
                    }

                    if (IsHandleCreated)
                    {
                        AdjustSize();
                    }

                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets the upper limit of the range this TrackBar is working with.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Upper limit of the trackbar range.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(10)]
        public int Maximum
        {
            get => _drawTrackBar.Maximum;

            set
            {
                if (value != _drawTrackBar.Maximum)
                {
                    _drawTrackBar.Maximum = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets the lower limit of the range this TrackBar is working with.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Lower limit of the trackbar range.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(0)]
        public int Minimum
        {
            get => _drawTrackBar.Minimum;

            set
            {
                if (value != _drawTrackBar.Minimum)
                {
                    _drawTrackBar.Minimum = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Current position of the indicator within the trackbar.")]
        [DefaultValue(0)]
        public int Value
        {
            get => _drawTrackBar.Value;

            set
            {
                if (value != _drawTrackBar.Value)
                {
                    _drawTrackBar.Value = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value added to or subtracted from the Value property when the scroll box is moved a small distance.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Change to apply when a small change occurs.")]
        [DefaultValue(1)]
        public int SmallChange
        {
            get => _drawTrackBar.SmallChange;
            set => _drawTrackBar.SmallChange = value;
        }

        /// <summary>
        /// Gets or sets a value to be added to or subtracted from the Value property when the scroll box is moved a large distance.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Change to apply when a large change occurs.")]
        [DefaultValue(5)]
        public int LargeChange
        {
            get => _drawTrackBar.LargeChange;
            set => _drawTrackBar.LargeChange = value;
        }

        /// <summary>
        /// Sets the minimum and maximum values for a TrackBar.
        /// </summary>
        /// <param name="minValue">The lower limit of the range of the track bar.</param>
        /// <param name="maxValue">The upper limit of the range of the track bar.</param>
        public void SetRange(int minValue, int maxValue)
        {
            if ((Minimum != minValue) || (Maximum != maxValue))
            {
                _drawTrackBar.SetRange(minValue, maxValue);
                PerformNeedPaint(true);
            }
        }

        /// <summary>
        /// Fix the control to a particular palette state.
        /// </summary>
        /// <param name="state">Palette state to fix.</param>
        public virtual void SetFixedState(PaletteState state) => _drawTrackBar.SetFixedState(state);

        /// <summary>
        /// Gets and sets if the control should draw the background.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Draw Background (Default = true);\r\nNote: Does not draw correctly in designer if false.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool DrawBackground
        {
            get => !_drawTrackBar.IgnoreRender;
            set => _drawTrackBar.IgnoreRender = !value;
        }

        private bool ShouldSerializeDrawBackground() => !DrawBackground;

        private void ResetDrawBackground() => DrawBackground = true;

        /// <summary>
        /// Gets and sets if the control is in the ribbon design mode.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public bool InRibbonDesignMode { get; set; }

        #endregion

        #region Protected
        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        protected override Size DefaultSize => new Size(150, 35);

        /// <summary>
        /// Raises the HandleCreated event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AdjustSize();
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        /// <param name="x">The new Left property value of the control.</param>
        /// <param name="y">The new Top property value of the control.</param>
        /// <param name="width">The new Width property value of the control.</param>
        /// <param name="height">The new Height property value of the control.</param>
        /// <param name="specified">A bitwise combination of the BoundsSpecified values.</param>
        protected override void SetBoundsCore(int x, int y,
                                              int width, int height,
                                              BoundsSpecified specified)
        {
            _requestedDim = (Orientation == Orientation.Horizontal) ? height : width;

            if (_autoSize)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    if ((specified & BoundsSpecified.Height) != BoundsSpecified.None)
                    {
                        height = GetPreferredSize(Size.Empty).Height;
                    }
                }
                else if ((specified & BoundsSpecified.Width) != BoundsSpecified.None)
                {
                    width = GetPreferredSize(Size.Empty).Width;
                }
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the Keys values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData) => (keyData & ~Keys.Shift) switch
        {
            Keys.Left or Keys.Right or Keys.Up or Keys.Down or Keys.Home or Keys.End or Keys.PageDown or Keys.PageUp => true,
            _ => base.IsInputKey(keyData)
        };

        /// <summary>
        /// Raises the MouseWheel event.
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            _drawTrackBar.OnMouseWheel(e);
            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        /// <param name="e">An MouseEventArgs that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (CanFocus)
            {
                Focus();
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the GotFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (!_drawTrackBar.TrackPosition.IsFixed)
            {
                // Apply the focus overrides
                _overrideNormal.Apply = true;
                _overrideTracking.Apply = true;
                _overridePressed.Apply = true;

                // Change in focus requires a repaint
                PerformNeedPaint(true);
            }

            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the LostFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            if (!_drawTrackBar.TrackPosition.IsFixed)
            {
                // Apply the focus overrides
                _overrideNormal.Apply = false;
                _overrideTracking.Apply = false;
                _overridePressed.Apply = false;

                // Change in focus requires a repaint
                PerformNeedPaint(false);
            }

            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the EnabledChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            _drawTrackBar.Enabled = Enabled;

            // Change in enabled state requires a layout and repaint
            PerformNeedPaint(true);

            // Let base class fire standard event
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Raises the Padding event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            _drawTrackBar.Padding = Padding;
            AdjustSize();
            PerformNeedPaint(true);
            base.OnPaddingChanged(e);
        }

        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            PerformNeedPaint(true);

            ValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the Scroll event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnScroll(EventArgs e) => Scroll?.Invoke(this, e);

        /// <summary>
        /// Raises the RightToLeftChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            _drawTrackBar.RightToLeft = RightToLeft;
            PerformNeedPaint(true);
            base.OnRightToLeftChanged(e);
        }

        /// <summary>
        /// Process Windows-based messages.
        /// </summary>
        /// <param name="m">A Windows-based message.</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case PI.WM_.NCHITTEST:
                    if (InTransparentDesignMode)
                    {
                        m.Result = (IntPtr)PI.HT.TRANSPARENT;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }

                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Work out if this control needs to paint transparent areas.
        /// </summary>
        /// <returns>True if paint required; otherwise false.</returns>
        protected override bool EvalTransparentPaint() =>
            // If we are not drawing the background then must be transparent
            !DrawBackground;

        #endregion

        #region Internal
        internal bool InTransparentDesignMode => InRibbonDesignMode;

        #endregion

        #region Implementation
        private void AdjustSize()
        {
            if (IsHandleCreated)
            {
                var requestedDim = _requestedDim;
                try
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        Height = _autoSize ? GetPreferredSize(Size.Empty).Height : requestedDim;
                    }
                    else
                    {
                        Width = _autoSize ? GetPreferredSize(Size.Empty).Width : requestedDim;
                    }
                }
                finally
                {
                    _requestedDim = requestedDim;
                }
            }
        }

        private void OnDrawValueChanged(object? sender, EventArgs e) => OnValueChanged(e);

        private void OnDrawScroll(object? sender, EventArgs e) => OnScroll(e);

        #endregion
    }
}
