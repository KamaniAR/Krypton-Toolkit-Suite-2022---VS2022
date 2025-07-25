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
    /// Represents a ribbon group color button.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(KryptonRibbonGroupColorButton), "ToolboxBitmaps.KryptonRibbonGroupColorButton.bmp")]
    [Designer(typeof(KryptonRibbonGroupColorButtonDesigner))]
    [DesignerCategory(@"code")]
    [DesignTimeVisible(false)]
    [DefaultEvent(nameof(SelectedColorChanged))]
    [DefaultProperty(nameof(SelectedColor))]
    public class KryptonRibbonGroupColorButton : KryptonRibbonGroupItem
    {
        #region Static Fields
        private static readonly Image? _defaultButtonImageSmall = GenericImageResources.ButtonColorImageSmall;
        private static readonly Image? _defaultButtonImageLarge = GenericImageResources.ButtonColorImageLarge;
        #endregion

        #region Instance Fields
        private bool _enabled;
        private bool _visible;
        private bool _checked;
        private bool _autoRecentColors;
        private bool _visibleThemes;
        private bool _visibleStandard;
        private bool _visibleRecent;
        private bool _visibleNoColor;
        private bool _visibleMoreColors;
        private Rectangle _selectedRectSmall;
        private Rectangle _selectedRectLarge;
        private Color _selectedColor;
        private Color _emptyBorderColor;
        private Image? _imageSmall;
        private Image? _imageLarge;
        private string _textLine1;
        private string _textLine2;
        private string _keyTip;
        private GroupButtonType _buttonType;
        private EventHandler? _kcmFinishDelegate;
        private GroupItemSize _itemSizeMax;
        private GroupItemSize _itemSizeMin;
        private GroupItemSize _itemSizeCurrent;
        private ColorScheme _schemeThemes;
        private ColorScheme _schemeStandard;
        private KryptonCommand? _command;
        private int _maxRecentColors;
        private readonly List<Color> _recentColors;

        // Context menu items
        private readonly KryptonContextMenu? _kryptonContextMenu;
        private readonly KryptonContextMenuSeparator _separatorTheme;
        private readonly KryptonContextMenuSeparator _separatorStandard;
        private readonly KryptonContextMenuSeparator _separatorRecent;
        private readonly KryptonContextMenuHeading _headingTheme;
        private readonly KryptonContextMenuHeading _headingStandard;
        private readonly KryptonContextMenuHeading _headingRecent;
        private readonly KryptonContextMenuColorColumns _colorsTheme;
        private readonly KryptonContextMenuColorColumns _colorsStandard;
        private readonly KryptonContextMenuColorColumns _colorsRecent;
        private readonly KryptonContextMenuSeparator _separatorNoColor;
        private readonly KryptonContextMenuItems _itemsNoColor;
        private readonly KryptonContextMenuItem _itemNoColor;
        private readonly KryptonContextMenuSeparator _separatorMoreColors;
        private readonly KryptonContextMenuItems _itemsMoreColors;
        private readonly KryptonContextMenuItem _itemMoreColors;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the color button is clicked.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs when the color button is clicked.")]
        public event EventHandler? Click;

        /// <summary>
        /// Occurs when the drop-down color button type is pressed.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs when the drop-down color button type is pressed.")]
        public event EventHandler<ContextMenuArgs>? DropDown;

        /// <summary>
        /// Occurs when the SelectedColor property changes value.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs when the SelectedColor property changes value.")]
        public event EventHandler<ColorEventArgs>? SelectedColorChanged;

        /// <summary>
        /// Occurs when the user is tracking over a color.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs when user is tracking over a color.")]
        public event EventHandler<ColorEventArgs>? TrackingColor;

        /// <summary>
        /// Occurs when the user selects the more colors option.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs when user selects the more colors option.")]
        public event CancelEventHandler? MoreColors;

        /// <summary>
        /// Occurs after the value of a property has changed.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs after the value of a property has changed.")]
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when the design time context menu is requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event MouseEventHandler? DesignTimeContextMenu;
        #endregion

        #region Identity
        /// <summary>
        /// Initialise a new instance of the KryptonRibbonGroupColorButton class.
        /// </summary>
        public KryptonRibbonGroupColorButton()
        {
            // Default fields
            _enabled = true;
            _visible = true;
            _checked = false;
            _visibleThemes = true;
            _visibleStandard = true;
            _visibleRecent = true;
            _visibleNoColor = true;
            _visibleMoreColors = true;
            _autoRecentColors = true;
            ShortcutKeys = Keys.None;
            _imageSmall = _defaultButtonImageSmall;
            _imageLarge = _defaultButtonImageLarge;
            _textLine1 = nameof(Color);
            _textLine2 = string.Empty;
            _keyTip = "B";
            _selectedColor = Color.Red;
            _emptyBorderColor = Color.DarkGray;
            _selectedRectSmall = new Rectangle(0, 12, 16, 4);
            _selectedRectLarge = new Rectangle(2, 26, 28, 4);
            _schemeThemes = ColorScheme.OfficeThemes;
            _schemeStandard = ColorScheme.OfficeStandard;
            _buttonType = GroupButtonType.Split;
            _itemSizeMax = GroupItemSize.Large;
            _itemSizeMin = GroupItemSize.Small;
            _itemSizeCurrent = GroupItemSize.Large;
            _maxRecentColors = 10;
            _recentColors = [];

            // Create the context menu items
            _kryptonContextMenu = new KryptonContextMenu();
            _separatorTheme = new KryptonContextMenuSeparator();
            _headingTheme = new KryptonContextMenuHeading("Theme Colors");
            _colorsTheme = new KryptonContextMenuColorColumns(ColorScheme.OfficeThemes);
            _separatorStandard = new KryptonContextMenuSeparator();
            _headingStandard = new KryptonContextMenuHeading("Standard Colors");
            _colorsStandard = new KryptonContextMenuColorColumns(ColorScheme.OfficeStandard);
            _separatorRecent = new KryptonContextMenuSeparator();
            _headingRecent = new KryptonContextMenuHeading("Recent Colors");
            _colorsRecent = new KryptonContextMenuColorColumns(ColorScheme.None);
            _separatorNoColor = new KryptonContextMenuSeparator();
            _itemNoColor = new KryptonContextMenuItem("&No Color", GenericImageResources.ButtonNoColor, OnClickNoColor);
            _itemsNoColor = new KryptonContextMenuItems();
            _itemsNoColor.Items.Add(_itemNoColor);
            _separatorMoreColors = new KryptonContextMenuSeparator();
            _itemMoreColors = new KryptonContextMenuItem("&More Colors...", OnClickMoreColors);
            _itemsMoreColors = new KryptonContextMenuItems();
            _itemsMoreColors.Items.Add(_itemMoreColors);
            _kryptonContextMenu.Items.AddRange([
                _separatorTheme, _headingTheme, _colorsTheme,
                                                                                  _separatorStandard, _headingStandard, _colorsStandard,
                                                                                  _separatorRecent, _headingRecent, _colorsRecent,
                                                                                  _separatorNoColor, _itemsNoColor,
                                                                                  _separatorMoreColors, _itemsMoreColors
            ]);
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets and sets the selected color.
        /// </summary>
        [Bindable(true)]
        [Category(@"Appearance")]
        [Description(@"Selected color.")]
        [DefaultValue(typeof(Color), "Red")]
        public Color SelectedColor
        {
            get => _selectedColor;

            set
            {
                if (value != _selectedColor)
                {
                    _selectedColor = value;
                    UpdateRecentColors(_selectedColor);
                    OnSelectedColorChanged(_selectedColor);
                    OnPropertyChanged(nameof(SelectedColor));
                }
            }
        }

        /// <summary>
        /// Gets and sets the selected color block when selected color is empty.
        /// </summary>
        [Bindable(true)]
        [Category(@"Appearance")]
        [Description(@"Border color of selected block when selected color is empty.")]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color EmptyBorderColor
        {
            get => _emptyBorderColor;

            set
            {
                if (value != _emptyBorderColor)
                {
                    _emptyBorderColor = value;
                    OnPropertyChanged(nameof(EmptyBorderColor));
                }
            }
        }

        /// <summary>
        /// Gets and sets the selected color drawing rectangle when small.
        /// </summary>
        [Bindable(true)]
        [Category(@"Appearance")]
        [Description(@"Selected color drawing rectangle when small.")]
        [DefaultValue(typeof(Rectangle), "0,12,16,4")]
        public Rectangle SelectedRectSmall
        {
            get => _selectedRectSmall;

            set
            {
                _selectedRectSmall = value;
                OnPropertyChanged(nameof(SelectedRectSmall));
            }
        }

        /// <summary>
        /// Gets and sets the selected color drawing rectangle when large.
        /// </summary>
        [Bindable(true)]
        [Category(@"Appearance")]
        [Description(@"Selected color drawing rectangle when large.")]
        [DefaultValue(typeof(Rectangle), "2, 26, 28, 4")]
        public Rectangle SelectedRectLarge
        {
            get => _selectedRectLarge;

            set
            {
                _selectedRectLarge = value;
                OnPropertyChanged(nameof(SelectedRectLarge));
            }
        }

        /// <summary>
        /// Gets and sets the small color button image.
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [Category(@"Appearance")]
        [Description(@"Small color button image.")]
        [RefreshProperties(RefreshProperties.All)]
        public Image? ImageSmall
        {
            get => _imageSmall;

            set
            {
                if (_imageSmall != value)
                {
                    _imageSmall = value;
                    OnPropertyChanged(nameof(ImageSmall));
                }
            }
        }

        private bool ShouldSerializeImageSmall() => ImageSmall != _defaultButtonImageSmall;

        /// <summary>
        /// Gets and sets the large color button image.
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [Category(@"Appearance")]
        [Description(@"Large color button image.")]
        [RefreshProperties(RefreshProperties.All)]
        public Image? ImageLarge
        {
            get => _imageLarge;

            set
            {
                if (_imageLarge != value)
                {
                    _imageLarge = value;
                    OnPropertyChanged(nameof(ImageLarge));
                }
            }
        }

        private bool ShouldSerializeImageLarge() => ImageLarge != _defaultButtonImageLarge;

        /// <summary>
        /// Gets and sets the display text line 1 for color  button.
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [Category(@"Appearance")]
        [Description(@"Color button display text line 1.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(nameof(Color))]
        public string TextLine1
        {
            get => _textLine1;

            set
            {
                if (value != _textLine1)
                {
                    _textLine1 = value;
                    OnPropertyChanged(nameof(TextLine1));
                }
            }
        }

        /// <summary>
        /// Gets and sets the display text line 2 for the color button.
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [Category(@"Appearance")]
        [Description(@"Color button display text line 2.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue("")]
        public string TextLine2
        {
            get => _textLine2;

            set
            {
                if (value != _textLine2)
                {
                    _textLine2 = value;
                    OnPropertyChanged(nameof(TextLine2));
                }
            }
        }

        /// <summary>
        /// Gets and sets the key tip for the ribbon group color button.
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [Category(@"Appearance")]
        [Description(@"Ribbon group color button key tip.")]
        [DefaultValue("B")]
        public string KeyTip
        {
            get => _keyTip;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = @"B";
                }

                _keyTip = value.ToUpper();
            }
        }

        /// <summary>
        /// Gets and sets the maximum number of recent colors to store and display.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Determine the maximum number of recent colors to store and display.")]
        [DefaultValue(10)]
        public int MaxRecentColors
        {
            get => _maxRecentColors;

            set
            {
                if (value != _maxRecentColors)
                {
                    _maxRecentColors = value;
                    OnPropertyChanged(nameof(MaxRecentColors));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the themes color set.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Determine the visible state of the themes color set.")]
        [DefaultValue(true)]
        public bool VisibleThemes
        {
            get => _visibleThemes;

            set
            {
                if (value != _visibleThemes)
                {
                    _visibleThemes = value;
                    OnPropertyChanged(nameof(VisibleThemes));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the standard color set.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Determine the visible state of the standard color set.")]
        [DefaultValue(true)]
        public bool VisibleStandard
        {
            get => _visibleStandard;

            set
            {
                if (value != _visibleStandard)
                {
                    _visibleStandard = value;
                    OnPropertyChanged(nameof(VisibleStandard));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the recent color set.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Determine the visible state of the recent color set.")]
        [DefaultValue(true)]
        public bool VisibleRecent
        {
            get => _visibleRecent;

            set
            {
                if (value != _visibleRecent)
                {
                    _visibleRecent = value;
                    OnPropertyChanged(nameof(VisibleRecent));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the no color menu item.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Determine if the 'No Color' menu item is used.")]
        [DefaultValue(true)]
        public bool VisibleNoColor
        {
            get => _visibleNoColor;

            set
            {
                if (value != _visibleNoColor)
                {
                    _visibleNoColor = value;
                    OnPropertyChanged(nameof(VisibleNoColor));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the more colors menu item.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Determine if the 'More Colors...' menu item is used.")]
        [DefaultValue(true)]
        public bool VisibleMoreColors
        {
            get => _visibleMoreColors;

            set
            {
                if (value != _visibleMoreColors)
                {
                    _visibleMoreColors = value;
                    OnPropertyChanged(nameof(VisibleMoreColors));
                }
            }
        }

        /// <summary>
        /// Gets and sets if the recent colors should be automatically updated.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Should recent colors be automatically updated.")]
        [DefaultValue(true)]
        public bool AutoRecentColors
        {
            get => _autoRecentColors;

            set
            {
                if (value != _autoRecentColors)
                {
                    _autoRecentColors = value;
                    OnPropertyChanged(nameof(AutoRecentColors));
                }
            }
        }

        /// <summary>
        /// Gets and sets the color scheme for the themes color set.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Color scheme to use for the themes color set.")]
        [DefaultValue(typeof(ColorScheme), "OfficeThemes")]
        public ColorScheme SchemeThemes
        {
            get => _schemeThemes;

            set
            {
                if (value != _schemeThemes)
                {
                    _schemeThemes = value;
                    OnPropertyChanged(nameof(SchemeThemes));
                }
            }
        }

        /// <summary>
        /// Gets and sets the color scheme for the standard color set.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Color scheme to use for the standard color set.")]
        [DefaultValue(typeof(ColorScheme), "OfficeStandard")]
        public ColorScheme SchemeStandard
        {
            get => _schemeStandard;

            set
            {
                if (value != _schemeStandard)
                {
                    _schemeStandard = value;
                    OnPropertyChanged(nameof(SchemeStandard));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the color button.
        /// </summary>
        [Bindable(true)]
        [Category(@"Behavior")]
        [Description(@"Determines whether the color button is visible or hidden.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool Visible
        {
            get => _visible;

            set
            {
                if (value != _visible)
                {
                    _visible = value;
                    OnPropertyChanged(nameof(Visible));
                }
            }
        }

        /// <summary>
        /// Make the ribbon color button visible.
        /// </summary>
        public void Show() => Visible = true;

        /// <summary>
        /// Make the ribbon color button hidden.
        /// </summary>
        public void Hide() => Visible = false;

        /// <summary>
        /// Gets and sets the enabled state of the color button.
        /// </summary>
        [Bindable(true)]
        [Category(@"Behavior")]
        [Description(@"Determines whether the group color button is enabled.")]
        [DefaultValue(true)]
        public bool Enabled
        {
            get => _enabled;

            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    OnPropertyChanged(nameof(Enabled));
                }
            }
        }

        /// <summary>
        /// Gets and sets the checked state of the group button.
        /// </summary>
        [Bindable(true)]
        [Category(@"Behavior")]
        [Description(@"Determines whether the group color button is checked.")]
        [DefaultValue(false)]
        public bool Checked
        {
            get => _checked;

            set
            {
                if (value != _checked)
                {
                    _checked = value;
                    OnPropertyChanged(nameof(Checked));
                }
            }
        }

        /// <summary>
        /// Gets and sets the operation of the group color button.
        /// </summary>
        [Bindable(true)]
        [Category(@"Behavior")]
        [Description(@"Determines how the group color button operation.")]
        [DefaultValue(typeof(GroupButtonType), "Split")]
        public GroupButtonType ButtonType
        {
            get => _buttonType;

            set
            {
                if (value != _buttonType)
                {
                    _buttonType = value;
                    OnPropertyChanged(nameof(ButtonType));
                }
            }
        }

        /// <summary>
        /// Gets and sets the shortcut key combination.
        /// </summary>
        [Localizable(true)]
        [Category(@"Behavior")]
        [Description(@"Shortcut key combination to fire click event of the color button.")]
        public Keys ShortcutKeys { get; set; }

        private bool ShouldSerializeShortcutKeys() => ShortcutKeys != Keys.None;

        /// <summary>
        /// Resets the ShortcutKeys property to its default value.
        /// </summary>
        public void ResetShortcutKeys() => ShortcutKeys = Keys.None;

        /// <summary>
        /// Gets access to the Wrapped Controls Tooltips.
        /// </summary>
        public override ToolTipValues ToolTipValues => _toolTipValues;

        /// <summary>
        /// Gets and sets the set of recent colors.
        /// </summary>
        [Category(@"Appearance")]
        [Description(@"Collection of recent colors.")]
        [AllowNull]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color[] RecentColors
        {
            get => _recentColors.ToArray();

            set
            {
                ClearRecentColors();

                // You cannot add an empty collection
                if (value != null)
                {
                    _recentColors.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Clear the recent colors setting.
        /// </summary>
        public void ClearRecentColors() => _recentColors.Clear();

        /// <summary>
        /// Gets and sets the associated KryptonCommand.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Command associated with the color button.")]
        [DefaultValue(null)]
        public KryptonCommand? KryptonCommand
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

                    _command = value;
                    OnPropertyChanged(nameof(KryptonCommand));

                    if (_command != null)
                    {
                        _command.PropertyChanged += OnCommandPropertyChanged;
                    }
                }
            }
        }

        /// <summary>
        /// Gets and sets the maximum allowed size of the item.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override GroupItemSize ItemSizeMaximum
        {
            get => _itemSizeMax;

            set
            {
                if (_itemSizeMax != value)
                {
                    _itemSizeMax = value;
                    OnPropertyChanged(nameof(ItemSizeMaximum));
                }
            }
        }

        /// <summary>
        /// Gets and sets the minimum allowed size of the item.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override GroupItemSize ItemSizeMinimum
        {
            get => _itemSizeMin;

            set
            {
                if (_itemSizeMin != value)
                {
                    _itemSizeMin = value;
                    OnPropertyChanged(nameof(ItemSizeMinimum));
                }
            }
        }

        /// <summary>
        /// Gets and sets the current item size.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override GroupItemSize ItemSizeCurrent
        {
            get => _itemSizeCurrent;

            set
            {
                if (_itemSizeCurrent != value)
                {
                    _itemSizeCurrent = value;
                    OnPropertyChanged(nameof(ItemSizeCurrent));
                }
            }
        }

        /// <summary>
        /// Creates an appropriate view element for this item.
        /// </summary>
        /// <param name="ribbon">Reference to the owning ribbon control.</param>
        /// <param name="needPaint">Delegate for notifying changes in display.</param>
        /// <returns>ViewBase derived instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ViewBase CreateView(KryptonRibbon ribbon,
                                            NeedPaintHandler needPaint)
        {
            _toolTipValues.NeedPaint = needPaint;
            return new ViewDrawRibbonGroupColorButton(ribbon, this, needPaint);
        }

        /// <summary>
        /// Generates a Click event for a button.
        /// </summary>
        public void PerformClick() => PerformClick(null);

        /// <summary>
        /// Generates a Click event for a button.
        /// </summary>
        /// <param name="finishDelegate">Delegate fired during event processing.</param>
        public void PerformClick(EventHandler? finishDelegate) => OnClick(finishDelegate);

        /// <summary>
        /// Generates a DropDown event for a button.
        /// </summary>
        public void PerformDropDown() => PerformDropDown(null);

        /// <summary>
        /// Generates a DropDown event for a button.
        /// </summary>
        /// <param name="finishDelegate">Delegate fired during event processing.</param>
        public void PerformDropDown(EventHandler? finishDelegate) => OnDropDown(finishDelegate);

        /// <summary>
        /// Internal design time properties.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public ViewBase? ColorButtonView { get; set; }

        #endregion

        #region Protected
        /// <summary>
        /// Handles a change in the property of an attached command.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">A PropertyChangedEventArgs that contains the event data.</param>
        protected virtual void OnCommandPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(TextLine1):
                    OnPropertyChanged(nameof(TextLine1));
                    break;
                case "ExtraText":
                    OnPropertyChanged(nameof(TextLine2));
                    break;
                case nameof(ImageSmall):
                    OnPropertyChanged(nameof(ImageSmall));
                    break;
                case nameof(ImageLarge):
                    OnPropertyChanged(nameof(ImageLarge));
                    break;
                case nameof(Enabled):
                    OnPropertyChanged(nameof(Enabled));
                    break;
                case nameof(Checked):
                    OnPropertyChanged(nameof(Checked));
                    break;
            }
        }

        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="finishDelegate">Delegate fired during event processing.</param>
        protected virtual void OnClick(EventHandler? finishDelegate)
        {
            var fireDelegate = true;

            if (!Ribbon!.InDesignMode)
            {
                // Events only occur when enabled
                if (Enabled)
                {
                    // A check button should always toggle state
                    if (ButtonType == GroupButtonType.Check)
                    {
                        // Push back the change to the attached command
                        if (KryptonCommand != null)
                        {
                            KryptonCommand.Checked = !KryptonCommand.Checked;
                        }
                        else
                        {
                            Checked = !Checked;
                        }
                    }

                    // In showing a popup we fire the delegate before the click so that the
                    // minimized popup is removed out of the way before the event is handled
                    // because if the event shows a dialog then it would appear behind the popup
                    if (VisualPopupManager.Singleton.CurrentPopup != null)
                    {
                        // Do we need to fire a delegate stating the click processing has finished?
                        if (fireDelegate)
                        {
                            finishDelegate?.Invoke(this, EventArgs.Empty);
                        }

                        fireDelegate = false;
                    }

                    // Generate actual click event
                    Click?.Invoke(this, EventArgs.Empty);

                    // Clicking the button should execute the associated command
                    KryptonCommand?.PerformExecute();
                }
            }

            // Do we need to fire a delegate stating the click processing has finished?
            if (fireDelegate)
            {
                finishDelegate?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raises the DropDown event.
        /// </summary>
        /// <param name="finishDelegate">Delegate fired during event processing.</param>
        protected virtual void OnDropDown(EventHandler? finishDelegate)
        {
            var fireDelegate = true;

            if (!Ribbon!.InDesignMode)
            {
                // Events only occur when enabled
                if (Enabled)
                {
                    if (ButtonType is GroupButtonType.DropDown or GroupButtonType.Split)
                    {
                        if (_kryptonContextMenu != null)
                        {
                            UpdateContextMenu();

                            var contextArgs = new ContextMenuArgs(_kryptonContextMenu);

                            // Generate an event giving a chance for the krypton context menu strip to 
                            // be shown to be provided/modified or the action even to be cancelled
                            DropDown?.Invoke(this, contextArgs);

                            // If user did not cancel and there is still a krypton context menu strip to show
                            if (contextArgs is { Cancel: false, KryptonContextMenu: not null })
                            {
                                var screenRect = Rectangle.Empty;

                                // Convert the view for the button into screen coordinates
                                if ((Ribbon != null) && (ColorButtonView != null))
                                {
                                    screenRect = Ribbon.ViewRectangleToScreen(ColorButtonView);
                                }

                                if (CommonHelper.ValidKryptonContextMenu(contextArgs.KryptonContextMenu))
                                {
                                    // Cache the finish delegate to call when the menu is closed
                                    _kcmFinishDelegate = finishDelegate;

                                    // Decide which separators are needed
                                    DecideOnVisible(_separatorTheme, _colorsTheme);
                                    DecideOnVisible(_separatorStandard, _colorsStandard);
                                    DecideOnVisible(_separatorRecent, _colorsRecent);
                                    DecideOnVisible(_separatorNoColor, _itemsNoColor);
                                    DecideOnVisible(_separatorMoreColors, _itemsMoreColors);

                                    // Monitor relevant events inside the context menu
                                    HookContextMenuEvents(_kryptonContextMenu.Items, true);

                                    // Show at location we were provided, but need to convert to screen coordinates
                                    contextArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
                                    if (contextArgs.KryptonContextMenu.Show(this, new Point(screenRect.X, screenRect.Bottom + 1)))
                                    {
                                        fireDelegate = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Do we need to fire a delegate stating the click processing has finished?
            if (fireDelegate)
            {
                finishDelegate?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raises the SelectedColorChanged event.
        /// </summary>
        /// <param name="selectedColor">New selected color.</param>
        protected virtual void OnSelectedColorChanged(Color selectedColor) => SelectedColorChanged?.Invoke(this, new ColorEventArgs(selectedColor));

        /// <summary>
        /// Raises the TrackingColor event.
        /// </summary>
        /// <param name="e">An ColorEventArgs that contains the event data.</param>
        protected virtual void OnTrackingColor(ColorEventArgs e) => TrackingColor?.Invoke(this, e);

        /// <summary>
        /// Raises the MoreColors event.
        /// </summary>
        /// <param name="e">An CancelEventArgs that contains the event data.</param>
        protected virtual void OnMoreColors(CancelEventArgs e) => MoreColors?.Invoke(this, e);

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region Internal
        internal void OnDesignTimeContextMenu(MouseEventArgs e) => DesignTimeContextMenu?.Invoke(this, e);

        internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Only interested in key processing if this button definition 
            // is enabled and itself and all parents are also visible
            if (Enabled && ChainVisible)
            {
                // Do we have a shortcut definition for ourself?
                if (ShortcutKeys != Keys.None)
                {
                    // Does it match the incoming key combination?
                    if (ShortcutKeys == keyData)
                    {
                        // Button type determines what event to fire
                        switch (ButtonType)
                        {
                            case GroupButtonType.Push:
                            case GroupButtonType.Check:
                                PerformClick();
                                return true;

                            case GroupButtonType.DropDown:
                            case GroupButtonType.Split:
                                PerformDropDown();
                                return true;

                            default:
    // Should never happen!
                                Debug.Assert(false);
                                DebugTools.NotImplemented(ButtonType.ToString());
                                break;
                        }

                        return true;
                    }
                }

                // Check the types that have a relevant context menu strip
                if (ButtonType is GroupButtonType.DropDown or GroupButtonType.Split)
                {
                    if (_kryptonContextMenu != null)
                    {
                        if (_kryptonContextMenu.ProcessShortcut(keyData))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        #endregion

        #region Implementation
        private void HookContextMenuEvents(KryptonContextMenuCollection collection, bool hook)
        {
            // Search for items of interest
            foreach (var item in collection)
            {
                // Hook into color events
                if (item is KryptonContextMenuColorColumns columns)
                {
                    columns.SelectedColor = _selectedColor;

                    if (hook)
                    {
                        columns.TrackingColor += OnColumnsTrackingColor;
                        columns.SelectedColorChanged += OnColumnsSelectedColorChanged;
                    }
                    else
                    {
                        columns.TrackingColor -= OnColumnsTrackingColor;
                        columns.SelectedColorChanged -= OnColumnsSelectedColorChanged;
                    }
                }
            }
        }

        private void UpdateRecentColors(Color color)
        {
            // Do we need to update the recent colors collection?
            if (AutoRecentColors)
            {
                // We do not add to recent colors if it is inside another color columns 
                foreach (var item in _kryptonContextMenu?.Items!)
                {
                    // Only interested in the non-recent colors color columns
                    if ((item != _colorsRecent) && (item is KryptonContextMenuColorColumns colors))
                    {
                        // Cast to correct type

                        // We do not change the theme or standard entries if they are not to be used
                        if (((item == _colorsTheme) && !VisibleThemes) ||
                            ((item == _colorsStandard) && !VisibleStandard))
                        {
                            continue;
                        }

                        // If matching color found, do not add to recent colors
                        if (colors.ContainsColor(color))
                        {
                            return;
                        }
                    }
                }

                // If this color valid and so possible to become a recent color
                if ((color != Color.Empty) && !color.Equals(Color.Empty))
                {
                    var found = false;
                    foreach (var recentColor in _recentColors)
                    {
                        if (recentColor.Equals(color))
                        {
                            found = true;
                            break;
                        }
                    }

                    // If the color is not already part of the recent colors
                    if (!found)
                    {
                        // Add to start of the list
                        _recentColors.Insert(0, color);

                        // Enforce the maximum number of recent colors
                        if (_recentColors.Count > MaxRecentColors)
                        {
                            _recentColors.RemoveRange(MaxRecentColors, _recentColors.Count - MaxRecentColors);
                        }
                    }
                }
            }
        }

        private void UpdateContextMenu()
        {
            // Update visible state based of properties
            _separatorTheme.Visible = _headingTheme.Visible = _colorsTheme.Visible = _visibleThemes;
            _separatorStandard.Visible = _headingStandard.Visible = _colorsStandard.Visible = _visibleStandard;
            _separatorRecent.Visible = _headingRecent.Visible = _colorsRecent.Visible = _visibleRecent && (_recentColors.Count > 0);
            _itemsNoColor.Visible = _visibleNoColor;
            _itemsMoreColors.Visible = _visibleMoreColors;

            // Define the display strings
            _headingTheme.Text = KryptonManager.Strings.RibbonStrings.ThemeColors;
            _headingStandard.Text = KryptonManager.Strings.RibbonStrings.StandardColors;
            _headingRecent.Text = KryptonManager.Strings.RibbonStrings.RecentColors;
            _itemNoColor.Text = KryptonManager.Strings.RibbonStrings.NoColor;
            _itemMoreColors.Text = KryptonManager.Strings.RibbonStrings.MoreColors;

            // Define the colors used in the first two color schemes
            _colorsTheme.ColorScheme = SchemeThemes;
            _colorsStandard.ColorScheme = SchemeStandard;

            // Define the recent colors
            if (_recentColors.Count == 0)
            {
                _colorsRecent.SetCustomColors(null);
            }
            else
            {
                // Create an array of color arrays
                var colors = new Color[_recentColors.Count][];

                // Each column is just a single color
                for (var i = 0; i < _recentColors.Count; i++)
                {
                    colors[i] = [_recentColors[i]];
                }

                _colorsRecent.SetCustomColors(colors);
            }

            // Should the no color entry be checked?
            _itemNoColor.Checked = _selectedColor.Equals(Color.Empty);
        }

        private void DecideOnVisible(KryptonContextMenuItemBase visible, KryptonContextMenuItemBase target)
        {
            var previous = false;

            // Only search if the target itself is visible
            if (target.Visible)
            {
                // Check all items before the target
                foreach (var item in _kryptonContextMenu?.Items!)
                {
                    // Finish when we reach the target
                    if (item == target)
                    {
                        break;
                    }

                    // We do not consider existing separators
                    if (!(item is KryptonContextMenuSeparator or KryptonContextMenuHeading))
                    {
                        // If the previous item is visible, then make the parameter visible
                        if (item.Visible)
                        {
                            previous = true;
                            break;
                        }
                    }
                }
            }
            visible.Visible = previous;
        }

        private void OnColumnsTrackingColor(object? sender, ColorEventArgs e) => OnTrackingColor(new ColorEventArgs(e.Color));

        private void OnColumnsSelectedColorChanged(object? sender, ColorEventArgs e) => SelectedColor = e.Color;

        private void OnClickNoColor(object? sender, EventArgs e) => SelectedColor = Color.Empty;

        private void OnClickMoreColors(object? sender, EventArgs e)
        {
            // Give user a chance to cancel showing the standard more colors dialog
            var cea = new CancelEventArgs();
            OnMoreColors(cea);

            // If not instructed to cancel then...
            if (!cea.Cancel)
            {
                // Use a standard color dialog for the selection of custom colors
                var cd = new KryptonColorDialog
                {
                    Color = SelectedColor,
                    FullOpen = true
                };

                // Only if user selected a value do we want to use it
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    SelectedColor = cd.Color;
                }
            }
        }

        private void OnKryptonContextMenuClosed(object? sender, EventArgs e)
        {
            var kcm = sender as KryptonContextMenu;
            kcm!.Closed -= OnKryptonContextMenuClosed;

            // Fire any associated finish delegate
            if (_kcmFinishDelegate != null)
            {
                _kcmFinishDelegate(this, e);
                _kcmFinishDelegate = null;
            }

            // Unhook from item events
            HookContextMenuEvents(_kryptonContextMenu?.Items!, false);
        }
        #endregion
    }
}
