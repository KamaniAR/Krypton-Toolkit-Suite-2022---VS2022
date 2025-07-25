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
    /// Display check box with text and images with the styling features of the Krypton Toolkit
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KryptonCheckBox), "ToolboxBitmaps.KryptonCheckBox.bmp")]
    [DefaultEvent(nameof(CheckedChanged))]
    [DefaultProperty(nameof(Text))]
    [DefaultBindingProperty(nameof(CheckState))]
    [Designer(typeof(KryptonCheckBoxDesigner))]
    [DesignerCategory(@"code")]
    [Description(@"Allow user to set or clear the associated option.")]
    public class KryptonCheckBox : VisualSimpleBase, IContentValues
    {
        #region Instance Fields
        private LabelStyle _style;
        private VisualOrientation _orientation;
        private readonly CheckBoxController _controller;
        private readonly ViewLayoutDocker _layoutDocker;
        private readonly ViewLayoutCenter _layoutCenter;
        private readonly ViewDrawCheckBox _drawCheckBox;
        private readonly ViewDrawContent _drawContent;
        private readonly PaletteContentInheritRedirect _paletteCommonRedirect;
        private readonly PaletteRedirectCheckBox? _paletteCheckBoxImages;
        private readonly PaletteContentInheritOverride _overrideNormal;
        private KryptonCommand? _command;
        private VisualOrientation _checkPosition;
        private CheckState _checkState;
        private CheckState _wasCheckState;
        private bool _wasEnabled;
        private bool _checked;
        private bool _threeState;
        private bool _useMnemonic;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the control is double clicked with the mouse.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new event EventHandler? DoubleClick;

        /// <summary>
        /// Occurs when the control is mouse double clicked with the mouse.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new event EventHandler? MouseDoubleClick;

        /// <summary>
        /// Occurs when the value of the ImeMode property is changed.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new event EventHandler? ImeModeChanged;

        /// <summary>
        /// Occurs when the value of the Checked property has changed.
        /// </summary>
        [Category(@"Misc")]
        [Description(@"Occurs whenever the Checked property has changed.")]
        public event EventHandler? CheckedChanged;

        /// <summary>
        /// Occurs when the value of the CheckState property has changed.
        /// </summary>
        [Category(@"Misc")]
        [Description(@"Occurs whenever the CheckState property has changed.")]
        public event EventHandler? CheckStateChanged;

        /// <summary>
        /// Occurs when the value of the KryptonCommand property changes.
        /// </summary>
        [Category(@"Property Changed")]
        [Description(@"Occurs when the value of the KryptonCommand property changes.")]
        public event EventHandler? KryptonCommandChanged;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonCheckBox class.
        /// </summary>
        public KryptonCheckBox()
        {
            // Turn off standard click and double click events, we do that manually
            SetStyle(ControlStyles.StandardClick |
                     ControlStyles.StandardDoubleClick, false);

            // Set default properties
            _style = LabelStyle.NormalPanel;
            _orientation = VisualOrientation.Top;
            _checkPosition = VisualOrientation.Left;
            _checked = false;
            _threeState = false;
            _checkState = CheckState.Unchecked;
            _useMnemonic = true;
            AutoCheck = true;

            // Create content storage
            Values = new LabelValues(NeedPaintDelegate);
            Values.TextChanged += OnCheckBoxTextChanged;
            Images = new CheckBoxImages(NeedPaintDelegate);

            // Create palette redirector
            _paletteCommonRedirect = new PaletteContentInheritRedirect(Redirector, PaletteContentStyle.LabelNormalPanel);
            _paletteCheckBoxImages = new PaletteRedirectCheckBox(Redirector, Images);

            // Create the palette provider
            StateCommon = new PaletteContent(_paletteCommonRedirect, NeedPaintDelegate);
            StateDisabled = new PaletteContent(StateCommon, NeedPaintDelegate);
            StateNormal = new PaletteContent(StateCommon, NeedPaintDelegate);
            OverrideFocus = new PaletteContent(_paletteCommonRedirect, NeedPaintDelegate);

            // Override the normal values with the focus, when the control has focus
            _overrideNormal = new PaletteContentInheritOverride(OverrideFocus, StateNormal, PaletteState.FocusOverride, false);

            // Our view contains background and border with content inside
            _drawContent = new ViewDrawContent(_overrideNormal, this, VisualOrientation.Top)
            {
                UseMnemonic = _useMnemonic,

                // Only draw a focus rectangle when focus cues are needed in the top level form
                TestForFocusCues = true
            };

            // Create the check box image drawer and place inside element so it is always centered
            _drawCheckBox = new ViewDrawCheckBox(_paletteCheckBoxImages)
            {
                CheckState = _checkState
            };
            _layoutCenter = new ViewLayoutCenter
            {
                _drawCheckBox
            };

            // Place check box on the left and the label in the remainder
            _layoutDocker = new ViewLayoutDocker
            {
                { _layoutCenter, ViewDockStyle.Left },
                { _drawContent, ViewDockStyle.Fill }
            };

            // Need a controller for handling mouse input
            _controller = new CheckBoxController(_drawCheckBox, _layoutDocker, NeedPaintDelegate);
            _controller.Click += OnControllerClick;
            _controller.Enabled = true;
            _layoutDocker.MouseController = _controller;
            _layoutDocker.KeyController = _controller;

            // Change the layout to match the inital right to left setting and orientation
            UpdateForOrientation();

            // Create the view manager instance
            ViewManager = new ViewManager(this, _layoutDocker);

            // We want to be auto sized by default, but not the property default!
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets and sets the automatic resize of the control to fit contents.
        /// </summary>
        [Browsable(true)]
        [Localizable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(true)]
        public override bool AutoSize
        {
            get => base.AutoSize;
            set => base.AutoSize = value;
        }

        /// <summary>
        /// Gets and sets the mode for when auto sizing.
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(AutoSizeMode.GrowAndShrink)]
        public new AutoSizeMode AutoSizeMode
        {
            get => base.AutoSizeMode;
            set => base.AutoSizeMode = value;
        }

        /// <summary>
        /// Gets and sets the internal padding space.
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }

        /// <summary>
        /// Gets or sets the text associated with this control. 
        /// </summary>
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [AllowNull]
        public override string Text
        {
            get => Values.Text;

            set => Values.Text = value;
        }

        private bool ShouldSerializeText() =>
            // Never serialize, let the label values serialize instead
            false;

        /// <summary>
        /// Resets the Text property to its default value.
        /// </summary>
        public override void ResetText() =>
            // Map onto the text property from the label values
            Values.ResetText();

        /// <summary>
        /// Gets and sets the visual orientation of the control.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Visual orientation of the control.")]
        [DefaultValue(VisualOrientation.Top)]
        public virtual VisualOrientation Orientation
        {
            get => _orientation;

            set
            {
                if (_orientation != value)
                {
                    _orientation = value;

                    // Update the associated visual element that is effected
                    _drawContent.Orientation = value;

                    // Update the layout according to the new orientation value
                    UpdateForOrientation();

                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the position of the check box.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Visual position of the check box.")]
        [DefaultValue(VisualOrientation.Left)]
        [Localizable(true)]
        public virtual VisualOrientation CheckPosition
        {
            get => _checkPosition;

            set
            {
                if (_checkPosition != value)
                {
                    _checkPosition = value;

                    // Update the layout according to the new orientation value
                    UpdateForOrientation();

                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the label style.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Label style.")]
        public LabelStyle LabelStyle
        {
            get => _style;

            set
            {
                if (_style != value)
                {
                    _style = value;
                    SetLabelStyle(_style);
                    PerformNeedPaint(true);
                }
            }
        }

        private void ResetLabelStyle() => LabelStyle = LabelStyle.NormalPanel;

        private bool ShouldSerializeLabelStyle() => LabelStyle != LabelStyle.NormalPanel;

        /// <summary>
        /// Gets access to the label content.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Label values")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LabelValues Values { get; }

        private bool ShouldSerializeValues() => !Values.IsDefault;

        /// <summary>
        /// Gets access to the image value overrides.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Image value overrides.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CheckBoxImages Images { get; }

        private bool ShouldSerializeImages() => !Images.IsDefault;

        /// <summary>
        /// Gets access to the common label appearance that other states can override.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining common label appearance that other states can override.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteContent StateCommon { get; }

        private bool ShouldSerializeStateCommon() => !StateCommon.IsDefault;

        /// <summary>
        /// Gets access to the disabled label appearance entries.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining disabled label appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteContent StateDisabled { get; }

        private bool ShouldSerializeStateDisabled() => !StateDisabled.IsDefault;

        /// <summary>
        /// Gets access to the normal label appearance entries.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining normal label appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteContent StateNormal { get; }

        private bool ShouldSerializeStateNormal() => !StateNormal.IsDefault;

        /// <summary>
        /// Gets access to the label appearance when it has focus.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining label appearance when it has focus.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteContent OverrideFocus { get; }

        private bool ShouldSerializeOverrideFocus() => !OverrideFocus.IsDefault;

        /// <summary>
        /// Gets or sets a value indicating whether an ampersand is included in the text of the control. 
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"When true the first character after an ampersand will be used as a mnemonic.")]
        [DefaultValue(true)]
        public bool UseMnemonic
        {
            get => _useMnemonic;

            set
            {
                if (_useMnemonic != value)
                {
                    _useMnemonic = value;
                    _drawContent.UseMnemonic = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the component is in the checked state.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Indicates if the component is in the checked state.")]
        [DefaultValue(false)]
        [Bindable(true)]
        public bool Checked
        {
            get => _checked;

            set
            {
                if (_checked != value)
                {
                    // Store new values
                    _checked = value;
                    _checkState = _checked ? CheckState.Checked : CheckState.Unchecked;

                    // Generate events
                    OnCheckedChanged(EventArgs.Empty);
                    OnCheckStateChanged(EventArgs.Empty);

                    // Repaint
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the check box is automatically changed state when clicked. 
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Causes the check box to automatically change state when clicked.")]
        [DefaultValue(true)]
        public bool AutoCheck { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the component allows three states instead of two.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Indicates if the component allows three states instead of two.")]
        [DefaultValue(false)]
        public bool ThreeState
        {
            get => _threeState;

            set
            {
                if (_threeState != value)
                {
                    _threeState = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the checked state of the component.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Indicates the checked state of the component.")]
        [DefaultValue(CheckState.Unchecked)]
        [Bindable(true)]
        public CheckState CheckState
        {
            get => _checkState;

            set
            {
                if (_checkState != value)
                {
                    // Store new values
                    _checkState = value;
                    var newChecked = _checkState != CheckState.Unchecked;
                    var checkedChanged = _checked != newChecked;
                    _checked = newChecked;

                    // Generate events
                    if (checkedChanged)
                    {
                        OnCheckedChanged(EventArgs.Empty);
                    }

                    OnCheckStateChanged(EventArgs.Empty);

                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Gets and sets the associated KryptonCommand.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Command associated with the check button.")]
        [DefaultValue(null)]
        public virtual KryptonCommand? KryptonCommand
        {
            get => _command;

            set
            {
                if (_command != value)
                {
                    if (_command != null)
                    {
                        _command.PropertyChanged -= OnCommandPropertyChanged;
                    }
                    else
                    {
                        _wasEnabled = Enabled;
                        _wasCheckState = CheckState;
                    }

                    _command = value;
                    OnKryptonCommandChanged(EventArgs.Empty);

                    if (_command != null)
                    {
                        _command.PropertyChanged += OnCommandPropertyChanged;
                    }
                    else
                    {
                        Enabled = _wasEnabled;
                        CheckState = _wasCheckState;
                    }
                }
            }
        }

        /// <summary>
        /// Fix the control to a particular palette state.
        /// </summary>
        /// <param name="focus">Focus state for display.</param>
        /// <param name="enabled">Enabled state for display.</param>
        /// <param name="tracking">Tracking state for display.</param>
        /// <param name="pressed">Pressed state for display.</param>
        public virtual void SetFixedState(bool focus,
                                          bool enabled,
                                          bool tracking,
                                          bool pressed)
        {
            // Prevent controller from changing drawing state
            _controller.Enabled = false;

            // Request fixed state from the view
            _overrideNormal.Apply = focus;
            _drawContent.FixedState = enabled ? PaletteState.Normal : PaletteState.Disabled;
            _drawCheckBox.Enabled = enabled;
            _drawCheckBox.Tracking = tracking;
            _drawCheckBox.Pressed = pressed;
        }
        #endregion

        #region IContentValues
        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public string GetShortText() => KryptonCommand?.Text ?? Values.GetShortText();

        /// <summary>
        /// Gets the content long text.
        /// </summary>
        /// <returns>String value.</returns>
        public string GetLongText() => KryptonCommand?.ExtraText ?? Values.GetLongText();

        /// <summary>
        /// Gets the content image.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Image value.</returns>
        public Image? GetImage(PaletteState state) => KryptonCommand?.ImageSmall ?? Values.GetImage(state);

        /// <summary>
        /// Gets the image color that should be transparent.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Color value.</returns>
        public Color GetImageTransparentColor(PaletteState state) =>
            KryptonCommand?.ImageTransparentColor ?? Values.GetImageTransparentColor(state);
        #endregion

        #region Protected
        /// <summary>
        /// Raises the DoubleClick event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnDoubleClick(EventArgs e) => DoubleClick?.Invoke(this, e);

        /// <summary>
        /// Raises the MouseDoubleClick event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnMouseDoubleClick(EventArgs e) => MouseDoubleClick?.Invoke(this, e);

        /// <summary>
        /// Raises the ImeModeChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnMouseImeModeChanged(EventArgs e) => ImeModeChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the CheckedChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the CheckStateChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            // Update the checked state that is drawn
            _drawCheckBox.CheckState = _checkState;

            CheckStateChanged?.Invoke(this, e);

            // If there is a command associated then update with new state
            if (KryptonCommand != null)
            {
                KryptonCommand.CheckState = CheckState;
            }
        }

        /// <summary>
        /// Raises the GotFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (!_drawContent.IsFixed)
            {
                // Apply the focus overrides
                _overrideNormal.Apply = true;

                // Change in focus requires a repaint
                PerformNeedPaint(false);
            }

            // Let base class fire standard event
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the KryptonCommandChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnKryptonCommandChanged(EventArgs e)
        {
            KryptonCommandChanged?.Invoke(this, e);

            // Use the values from the new command
            if (KryptonCommand != null)
            {
                Enabled = KryptonCommand.Enabled;
                CheckState = KryptonCommand.CheckState;
            }

            // Redraw to update the text/extratext/image properties
            PerformNeedPaint(true);
        }

        /// <summary>
        /// Handles a change in the property of an attached command.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">A PropertyChangedEventArgs that contains the event data.</param>
        protected virtual void OnCommandPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Enabled):
                    Enabled = KryptonCommand!.Enabled;
                    break;
                case nameof(CheckState):
                    CheckState = KryptonCommand!.CheckState;
                    break;
                case nameof(Text):
                case @"ExtraText":
                case @"ImageSmall":
                case @"ImageTransparentColor":
                    PerformNeedPaint(true);
                    break;
            }
        }

        /// <summary>
        /// Raises the LostFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            if (!_drawContent.IsFixed)
            {
                // Apply the focus overrides
                _overrideNormal.Apply = false;

                // Change in focus requires a repaint
                PerformNeedPaint(false);
            }

            // Let base class fire standard event
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the CheckStateChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            if (AutoCheck)
            {
                // Change state based on the current state
                CheckState = CheckState switch
                {
                    CheckState.Unchecked => CheckState.Checked,
                    CheckState.Checked => ThreeState ? CheckState.Indeterminate : CheckState.Unchecked,
                    CheckState.Indeterminate => CheckState.Unchecked,
                    _ => CheckState
                };
            }

            base.OnClick(e);

            // If we have an attached command then execute it
            KryptonCommand?.PerformExecute();
        }

        /// <summary>
        /// Update the view elements based on the requested label style.
        /// </summary>
        /// <param name="style">New label style.</param>
        protected virtual void SetLabelStyle(LabelStyle style) => _paletteCommonRedirect.Style = CommonHelper.ContentStyleFromLabelStyle(style);

        /// <summary>
        /// Processes a mnemonic character.
        /// </summary>
        /// <param name="charCode">The mnemonic character entered.</param>
        /// <returns>true if the mnemonic was processed; otherwise, false.</returns>
        protected override bool ProcessMnemonic(char charCode)
        {
            // Are we allowed to process mnemonics?
            if (UseMnemonic && AutoCheck && CanProcessMnemonic())
            {
                // Does the button primary text contain the mnemonic?
                if (IsMnemonic(charCode, Values.Text))
                {
                    // If we don't have the focus, then take it
                    if (!ContainsFocus)
                    {
                        Focus();
                    }

                    // Generating a click event will automatically transition the state
                    OnClick(EventArgs.Empty);
                    return true;
                }
            }

            // No match found, let base class do standard processing
            return base.ProcessMnemonic(charCode);
        }

        /// <summary>
        /// Raises the EnabledChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            // Push correct palettes into the view
            if (Enabled)
            {
                _drawContent.SetPalette(_overrideNormal);
            }
            else
            {
                _drawContent.SetPalette(StateDisabled);
            }

            _drawContent.Enabled = Enabled;
            _drawCheckBox.Enabled = Enabled;

            // Need to relayout to reflect the change in state
            MarkLayoutDirty();

            // Let base class fire standard event
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Raises the RightToLeftChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing event data.</param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            // Orientation and right to left are interconnected
            UpdateForOrientation();
            base.OnRightToLeftChanged(e);
        }

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        protected override Size DefaultSize => new Size(90, 25);

        /// <summary>
        /// Work out if this control needs to paint transparent areas.
        /// </summary>
        /// <returns>True if paint required; otherwise false.</returns>
        protected override bool EvalTransparentPaint() =>
            // Always need to draw the background because always transparent
            true;

        #endregion

        #region Implementation
        private void OnCheckBoxTextChanged(object? sender, EventArgs e) => OnTextChanged(EventArgs.Empty);

        private void OnControllerClick(object? sender, EventArgs e) => OnClick(e);

        private void UpdateForOrientation()
        {
            ViewDockStyle dockStyle = CheckPosition switch
            {
                VisualOrientation.Right => Orientation switch
                {
                    VisualOrientation.Bottom => RightToLeft == RightToLeft.Yes ? ViewDockStyle.Right : ViewDockStyle.Left,
                    VisualOrientation.Left => ViewDockStyle.Top,
                    VisualOrientation.Right => ViewDockStyle.Bottom,
                    _ => RightToLeft == RightToLeft.Yes ? ViewDockStyle.Left : ViewDockStyle.Right
                },
                VisualOrientation.Top => Orientation switch
                {
                    VisualOrientation.Bottom => ViewDockStyle.Bottom,
                    VisualOrientation.Left => ViewDockStyle.Left,
                    VisualOrientation.Right => ViewDockStyle.Right,
                    _ => ViewDockStyle.Top
                },
                VisualOrientation.Bottom => Orientation switch
                {
                    VisualOrientation.Bottom => ViewDockStyle.Top,
                    VisualOrientation.Left => ViewDockStyle.Right,
                    VisualOrientation.Right => ViewDockStyle.Left,
                    _ => ViewDockStyle.Bottom
                },
                _ => Orientation switch
                {
                    VisualOrientation.Bottom => RightToLeft == RightToLeft.Yes ? ViewDockStyle.Left : ViewDockStyle.Right,
                    VisualOrientation.Left => ViewDockStyle.Bottom,
                    VisualOrientation.Right => ViewDockStyle.Top,
                    _ => RightToLeft == RightToLeft.Yes ? ViewDockStyle.Right : ViewDockStyle.Left
                }
            };


            // Update docking position of check box to match orientation
            _layoutDocker.SetDock(_layoutCenter, dockStyle);
        }
        #endregion
    }
}
