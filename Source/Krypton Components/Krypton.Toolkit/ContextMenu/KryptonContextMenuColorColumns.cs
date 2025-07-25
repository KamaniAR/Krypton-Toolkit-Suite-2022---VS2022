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
    /// Provide a set of color columns for the context menu.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(KryptonContextMenuColorColumns), "ToolboxBitmaps.KryptonContextMenuColorColumns.bmp")]
    [DesignerCategory(@"code")]
    [DesignTimeVisible(false)]
    [DefaultProperty(nameof(ColorScheme))]
    [DefaultEvent(nameof(SelectedColorChanged))]
    public class KryptonContextMenuColorColumns : KryptonContextMenuItemBase
    {
        #region Static Fields

        private static readonly Color[][] _noneScheme = Array.Empty<Color[]>();

        private static readonly Color[][] _mono2Scheme =
        [
            [Color.White],
            [Color.Black]
        ];

        private static readonly Color[][] _mono8Scheme =
        [
            [Color.White],
            [Color.Silver],
            [Color.FromArgb(160, 160, 160)],
            [Color.Gray],
            [Color.FromArgb( 96,  96,  96)],
            [Color.FromArgb( 64,  64,  64)],
            [Color.FromArgb( 32,  32,  32)],
            [Color.Black]
        ];

        private static readonly Color[][] _basic16Scheme =
        [
            [Color.White,   Color.Black],
            [Color.Silver,  Color.Gray],
            [Color.Red,     Color.Maroon],
            [Color.Yellow,  Color.Olive],
            [Color.Lime,    Color.Green],
            [Color.Cyan,    Color.Teal],
            [Color.Blue,    Color.Navy],
            [Color.Fuchsia, Color.Purple]
        ]; 

        private static readonly Color[][] _officeStandardScheme =
        [
            [Color.FromArgb(192,   0,   0)],
            [Color.Red],
            [Color.FromArgb(255, 192,   0)],
            [Color.Yellow],
            [Color.FromArgb(146, 208,  80)],
            [Color.FromArgb(  0, 176,  80)],
            [Color.FromArgb(  0, 176, 240)],
            [Color.FromArgb(  0, 112, 192)],
            [Color.FromArgb(  0,  32,  96)],
            [Color.FromArgb(112,  48, 160)]
        ];
    
        private static readonly Color[][] _officeThemeScheme =
        [
            [Color.White,                   Color.FromArgb(242, 242, 242), Color.FromArgb(216, 216, 216), Color.FromArgb(191, 191, 191), Color.FromArgb(165, 165, 165), Color.Gray
            ],
            [Color.Black,                   Color.FromArgb(127, 127, 127), Color.FromArgb( 89,  89,  89), Color.FromArgb( 63,  63,  63), Color.FromArgb( 38,  38,  38), Color.FromArgb( 12,  12,  12)
            ],
            [Color.FromArgb(238, 236, 225), Color.FromArgb(221, 217, 195), Color.FromArgb(196, 189, 151), Color.FromArgb(147, 137,  83), Color.FromArgb( 73,  68,  41), Color.FromArgb( 29,  27,  16)
            ],
            [Color.FromArgb( 31,  73, 125), Color.FromArgb(198, 217, 240), Color.FromArgb(141, 179, 226), Color.FromArgb( 84, 141, 212), Color.FromArgb( 23,  54,  93), Color.FromArgb( 15,  36,  62)
            ],
            [Color.FromArgb( 79, 129, 189), Color.FromArgb(219, 229, 241), Color.FromArgb(184, 204, 228), Color.FromArgb(149, 179, 215), Color.FromArgb( 54,  96, 146), Color.FromArgb( 36,  64,  97)
            ],
            [Color.FromArgb(192,  80,  77), Color.FromArgb(242, 220, 219), Color.FromArgb(229, 185, 183), Color.FromArgb(217, 150, 148), Color.FromArgb(149,  55,  52), Color.FromArgb( 99,  36,  35)
            ],
            [Color.FromArgb(155, 187,  89), Color.FromArgb(235, 241, 221), Color.FromArgb(215, 227, 188), Color.FromArgb(195, 214, 155), Color.FromArgb(118, 146,  60), Color.FromArgb( 79,  97,  40)
            ],
            [Color.FromArgb(128, 100, 162), Color.FromArgb(229, 224, 236), Color.FromArgb(204, 193, 217), Color.FromArgb(178, 162, 199), Color.FromArgb( 95,  73, 122), Color.FromArgb( 63,  49,  81)
            ],
            [Color.FromArgb( 75, 172, 198), Color.FromArgb(219, 238, 243), Color.FromArgb(183, 221, 232), Color.FromArgb(146, 205, 220), Color.FromArgb( 49, 133, 155), Color.FromArgb( 32,  88, 103)
            ],
            [Color.FromArgb(247, 150,  70), Color.FromArgb(253, 234, 218), Color.FromArgb(251, 213, 181), Color.FromArgb(250, 192, 143), Color.FromArgb(227, 108,   9), Color.FromArgb(151,  72,   6)
            ]
        ];
        #endregion

        #region Instance Fields
        private ColorScheme _colorScheme;
        private Color _selectedColor;
        private Size _blockSize;
        private bool _autoClose;
        private bool _groupNonFirstRows;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the SelectedColor property changes value.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when the SelectedColor property changes value.")]
        public event EventHandler<ColorEventArgs>? SelectedColorChanged;

        /// <summary>
        /// Occurs when the user is tracking over a color.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when user is tracking over a color.")]
        public event EventHandler<ColorEventArgs>? TrackingColor;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonContextMenuColorColumns class.
        /// </summary>
        public KryptonContextMenuColorColumns()
            : this(ColorScheme.OfficeThemes)
        {
        }

        /// <summary>
        /// Initialize a new instance of the KryptonContextMenuColorColumns class.
        /// </summary>
        /// <param name="scheme">Required color scheme of colors.</param>
        public KryptonContextMenuColorColumns(ColorScheme scheme)
        {
            // Default fields
            _autoClose = true;
            _selectedColor = GlobalStaticValues.EMPTY_COLOR;
            _groupNonFirstRows = true;
            _blockSize = new Size(13, 13);
            SetColorScheme(scheme);
        }

        /// <summary>
        /// Returns a description of the instance.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString() => "(Color Columns)";

        #endregion

        #region Public
        /// <summary>
        /// Returns the number of child menu items.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int ItemChildCount => 0;

        /// <summary>
        /// Returns the indexed child menu item.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override KryptonContextMenuItemBase? this[int index] => null;

        /// <summary>
        /// Test for the provided shortcut and perform relevant action if a match is found.
        /// </summary>
        /// <param name="keyData">Key data to check against shortcut definitions.</param>
        /// <returns>True if shortcut was handled, otherwise false.</returns>
        public override bool ProcessShortcut(Keys keyData) => false;

        /// <summary>
        /// Returns a view appropriate for this item based on the object it is inside.
        /// </summary>
        /// <param name="provider">Provider of context menu information.</param>
        /// <param name="parent">Owning object reference.</param>
        /// <param name="columns">Containing columns.</param>
        /// <param name="standardStyle">Draw items with standard or alternate style.</param>
        /// <param name="imageColumn">Draw an image background for the item images.</param>
        /// <returns>ViewBase that is the root of the view hierarchy being added.</returns>
        public override ViewBase GenerateView(IContextMenuProvider provider,
                                              object parent,
                                              ViewLayoutStack columns,
                                              bool standardStyle,
                                              bool imageColumn)
        {
            SetProvider(provider);
            return new ViewDrawMenuColorColumns(provider, this);
        }

        /// <summary>
        /// Gets and sets if clicking a color entry automatically closes the context menu.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Indicates if clicking a color entry automatically closes the context menu.")]
        [DefaultValue(true)]
        public bool AutoClose
        {
            get => _autoClose;

            set 
            {
                if (_autoClose != value)
                {
                    _autoClose = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(AutoClose)));
                }
            }
        }

        /// <summary>
        /// Gets and sets the required color scheme.
        /// </summary>
        [KryptonPersist]
        [Category(@"Appearance")]
        [Description(@"Defines the set of colors to use for display.")]
        [DefaultValue(ColorScheme.OfficeThemes)]
        public ColorScheme ColorScheme
        {
            get => _colorScheme;

            set
            {
                if (_colorScheme != value)
                {
                    SetColorScheme(value);
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(ColorScheme)));
                }
            }
        }

        /// <summary>
        /// Gets and sets the user selected color.
        /// </summary>
        [KryptonPersist]
        [Category(@"Appearance")]
        [Description(@"Color that has been selected by the user.")]
        [DefaultValue(typeof(Color), "Empty")]
        public Color SelectedColor
        {
            get => _selectedColor;

            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    OnSelectedColorChanged(new ColorEventArgs(_selectedColor));
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedColor)));
                }
            }
        }

        /// <summary>
        /// Gets and sets the size of each color block.
        /// </summary>
        [KryptonPersist]
        [Category(@"Appearance")]
        [Description(@"Size of each color block.")]
        [DefaultValue(typeof(Size), "13,13")]
        public Size BlockSize
        {
            get => _blockSize;

            set 
            {
                if (_blockSize != value)
                {
                    _blockSize = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(BlockSize)));
                }
            }
        }

        /// <summary>
        /// Gets and sets if all but the first row should be group together.
        /// </summary>
        [KryptonPersist]
        [Category(@"Appearance")]
        [Description(@"Should all but the first row be grouped together.")]
        [DefaultValue(true)]
        public bool GroupNonFirstRows
        {
            get => _groupNonFirstRows;

            set 
            {
                if (_groupNonFirstRows != value)
                {
                    _groupNonFirstRows = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(GroupNonFirstRows)));
                }
            }
        }

        /// <summary>
        /// Define a custom set of colors for display.
        /// </summary>
        /// <param name="colors">An array of color arrays, each of which must be the same length.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCustomColors(Color[]?[]? colors)
        {
            // Cannot accept an empty argument
            if ((colors == null) || (colors.Length == 0))
            {
                colors = _noneScheme;
            }

            var rows = -1;
            for (var i = 0; i < colors.Length; i++)
            {
                // Each element must contain a valid reference
                if (colors[i] == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(colors), @"Child array cannot be null.");
                }
                else
                {
                    // Cache length of first child array
                    if (i == 0)
                    {
                        rows = colors[i]!.Length;
                    }
                    else
                    {
                        // All other child arrays must be the same length
                        if (colors[i]!.Length != rows)
                        {
                            throw new ArgumentOutOfRangeException(nameof(colors), @"Each child color array must be the same length.");
                        }
                    }
                }
            }

            Colors = colors!;
        }

        /// <summary>
        /// Does the provided color exist in the definition.
        /// </summary>
        /// <param name="color">Color to find.</param>
        /// <returns>True if found; otherwise false.</returns>
        public bool ContainsColor([DisallowNull] Color color)
        {
            if ((Colors != null) && (color != null))
            {
                return Colors.Any(column => column.Contains(color));
            }

            return false;
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the SelectedColorChanged event.
        /// </summary>
        /// <param name="e">An ColorEventArgs that contains the event data.</param>
        protected virtual void OnSelectedColorChanged(ColorEventArgs e) => SelectedColorChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the TrackingColor event.
        /// </summary>
        /// <param name="e">An ColorEventArgs that contains the event data.</param>
        protected internal virtual void OnTrackingColor(ColorEventArgs e) => TrackingColor?.Invoke(this, e);

        #endregion

        #region Internal
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Color[][] Colors { get; private set; }

        #endregion

        #region Implementation
        private void SetColorScheme(ColorScheme scheme)
        {
            _colorScheme = scheme;

            Colors = scheme switch
            {
                ColorScheme.None => _noneScheme,
                ColorScheme.Mono2 => _mono2Scheme,
                ColorScheme.Mono8 => _mono8Scheme,
                ColorScheme.Basic16 => _basic16Scheme,
                ColorScheme.OfficeStandard => _officeStandardScheme,
                ColorScheme.OfficeThemes => _officeThemeScheme,
                _ => Colors
            };
        }
        #endregion
    }
}
