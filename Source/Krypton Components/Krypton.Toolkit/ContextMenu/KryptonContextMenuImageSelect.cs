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
    /// Provide a context menu image select.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(KryptonContextMenuImageSelect), "ToolboxBitmaps.KryptonContextMenuImageSelect.bmp")]
    [DesignerCategory(@"code")]
    [DesignTimeVisible(false)]
    [DefaultProperty(nameof(ImageList))]
    [DefaultEvent(nameof(SelectedIndexChanged))]
    public class KryptonContextMenuImageSelect : KryptonContextMenuItemBase
    {
        #region Instance Fields
        private Padding _padding;
        private ImageList? _imageList;
        private ButtonStyle _style;
        private bool _autoClose;
        private int _selectedIndex;
        private int _imageIndexStart;
        private int _imageIndexEnd;
        private int _lineItems;
        private int _trackingIndex;
        private int _cacheTrackingIndex;
        private int _eventTrackingIndex;
        private readonly System.Windows.Forms.Timer _trackingEventTimer;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the value of the SelectedIndex property changes.
        /// </summary>
        [Category(@"Property Changed")]
        [Description(@"Occurs when the value of the SelectedIndex property changes.")]
        public event EventHandler? SelectedIndexChanged;

        /// <summary>
        /// Occurs when the user is tracking over a color.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when user is tracking over an image.")]
        public event EventHandler<ImageSelectEventArgs>? TrackingImage;

        /// <summary>
        /// Occurs when the value of the SelectedIndex property changes.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when an image is clicked.")]
        public event EventHandler? Click;

        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonContextMenuImageSelect class.
        /// </summary>
        public KryptonContextMenuImageSelect()
        {
            _autoClose = true;
            _selectedIndex = -1;
            _trackingIndex = -1;
            _imageList = null;
            _imageIndexStart = -1;
            _imageIndexEnd = -1;
            _lineItems = 5;
            _padding = new Padding(2);
            _style = ButtonStyle.LowProfile;

            // Timer used to generate tracking change event
            _trackingEventTimer = new System.Windows.Forms.Timer
            {
                Interval = 120
            };
            _trackingEventTimer.Tick += OnTrackingTick;
        }

        /// <summary>
        /// Returns a description of the instance.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString() => "(ImageSelect)";

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
            return new ViewLayoutMenuItemSelect(this, provider);
        }

        /// <summary>
        /// Gets and sets padding around the image selection area.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Padding used around the image selection area.")]
        [DefaultValue(typeof(Padding), "2,2,2,2")]
        public Padding Padding
        {
            get => _padding;

            set
            {
                if (_padding != value)
                {
                    _padding = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Padding)));
                }
            }
        }

        /// <summary>
        /// Gets and sets if selecting an image automatically closes the context menu.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Indicates if selecting an image automatically closes the context menu.")]
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
        /// Gets access to the collection of images for display and selection.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"The index of the selected image.")]
        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get => _selectedIndex;

            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnSelectedIndexChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets and sets the button style used for each image item.
        /// </summary>
        [KryptonPersist]
        [Category(@"Visuals")]
        [Description(@"Button style used for each image item.")]
        [DefaultValue(ButtonStyle.LowProfile)]
        public ButtonStyle ButtonStyle
        {
            get => _style;

            set
            {
                if (_style != value)
                {
                    _style = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(ButtonStyle)));
                }
            }
        }

        /// <summary>
        /// Gets access to the collection of images for display and selection.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Collection of images for display and selection.")]
        [DefaultValue(null)]
        public ImageList? ImageList
        {
            get => _imageList;

            set
            {
                if (_imageList != value)
                {
                    _imageList = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(ImageList)));
                }
            }
        }

        /// <summary>
        /// Gets and sets the index of first image in the ImageList for display.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Index of first image in the ImageList for display.")]
        [DefaultValue(-1)]
        public int ImageIndexStart
        {
            get => _imageIndexStart;

            set
            {
                if (_imageIndexStart != value)
                {
                    _imageIndexStart = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(ImageIndexStart)));
                }
            }
        }

        /// <summary>
        /// Gets and sets the index of last image in the ImageList for display.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Index of last image in the ImageList for display.")]
        [DefaultValue(-1)]
        public int ImageIndexEnd
        {
            get => _imageIndexEnd;

            set
            {
                if (_imageIndexEnd != value)
                {
                    _imageIndexEnd = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(ImageIndexEnd)));
                }
            }
        }

        /// <summary>
        /// Gets and sets the number of items to place on each display line.
        /// </summary>
        [KryptonPersist]
        [Category(@"Behavior")]
        [Description(@"Number of items to place on each display line.")]
        [DefaultValue(5)]
        public int LineItems
        {
            get => _lineItems;

            set
            {
                if (_lineItems != value)
                {
                    // Ensure a minimum value of 1
                    value = Math.Max(1, value);

                    _lineItems = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(LineItems)));
                }
            }
        }
        #endregion

        #region Protected Virtual
        /// <summary>
        /// Raises the SelectedIndexChanged event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnSelectedIndexChanged(EventArgs e) => SelectedIndexChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the SelectedIndexChanged event.
        /// </summary>
        /// <param name="e">An ImageSelectEventArgs containing the event data.</param>
        protected virtual void OnTrackingImage(ImageSelectEventArgs e)
        {
            _eventTrackingIndex = e.ImageIndex;
            TrackingImage?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        internal virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);
        #endregion

        #region Internal
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden)]
        internal int TrackingIndex
        {
            get => _trackingIndex;

            set
            {
                if (_trackingIndex != value)
                {
                    _trackingIndex = value;

                    // Must stop and then start to restart the length of time passing
                    _cacheTrackingIndex = _trackingIndex;
                    _trackingEventTimer.Stop();
                    _trackingEventTimer.Start();
                }
            }
        }
        #endregion

        #region Implementation
        private void OnTrackingTick(object? sender, EventArgs e)
        {
            // If no change in tracking index over last interval
            if (_trackingIndex == _cacheTrackingIndex)
            {
                // Kill timer and generate the change event
                _trackingEventTimer.Stop();

                // But only generate if actual event would yield a different value
                if (_eventTrackingIndex != _trackingIndex)
                {
                    OnTrackingImage(new ImageSelectEventArgs(_imageList, _trackingIndex));
                }
            }
            else
            {
                // Cache the updated value and wait for next tick before generating event
                _cacheTrackingIndex = _trackingIndex;
            }
        }
        #endregion
    }
}
