﻿#region BSD License
/*
 * 
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, All rights reserved.
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), Giduac & Ahmed Abdelhameed et al. 2017 - 2025. All rights reserved.
 *  
 */
#endregion

namespace Krypton.Ribbon
{
    /// <summary>
    /// Represents a ribbon group triple container.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(KryptonRibbonGroupTriple), "ToolboxBitmaps.KryptonRibbonGroupTriple.bmp")]
    [Designer(typeof(KryptonRibbonGroupTripleDesigner))]
    [DesignerCategory(@"code")]
    [DesignTimeVisible(false)]
    [DefaultProperty(nameof(Visible))]
    public class KryptonRibbonGroupTriple : KryptonRibbonGroupContainer
    {
        #region Instance Fields

        private GroupItemSize _itemSizeMax;
        private GroupItemSize _itemSizeMin;
        private GroupItemSize _itemSizeCurrent;
        private RibbonItemAlignment _itemAlignment;
        private bool _visible;
        #endregion

        #region Events
        /// <summary>
        /// Occurs after the value of a property has changed.
        /// </summary>
        [Category(@"Ribbon")]
        [Description(@"Occurs after the value of a property has changed.")]
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when the design time wants to add a button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddButton;

        /// <summary>
        /// Occurs when the design time wants to add a color button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddColorButton;

        /// <summary>
        /// Occurs when the design time wants to add a checkbox.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddCheckBox;

        /// <summary>
        /// Occurs when the design time wants to add a radio button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddRadioButton;

        /// <summary>
        /// Occurs when the design time wants to add a label.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddLabel;

        /// <summary>
        /// Occurs when the design time wants to add a custom control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddCustomControl;

        /// <summary>
        /// Occurs when the design time wants to add a text box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddTextBox;

        /// <summary>
        /// Occurs when the design time wants to add a masked text box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddMaskedTextBox;

        /// <summary>
        /// Occurs when the design time wants to add a rich text box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddRichTextBox;

        /// <summary>
        /// Occurs when the design time wants to add a combobox.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddComboBox;

        /// <summary>
        /// Occurs when the design time wants to add a numeric up down.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddNumericUpDown;

        /// <summary>
        /// Occurs when the design time wants to add a domain up down.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddDomainUpDown;

        /// <summary>
        /// Occurs when the design time wants to add a date time picker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddDateTimePicker;

        /// <summary>
        /// Occurs when the design time wants to add a track bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddTrackBar;

        /// <summary>
        /// Occurs when the design time wants to add a theme combobox.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event EventHandler? DesignTimeAddThemeComboBox;

        /// <summary>
        /// Occurs when the design time context menu is requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public event MouseEventHandler? DesignTimeContextMenu;
        #endregion

        #region Identity
        /// <summary>
        /// Initialise a new instance of the KryptonRibbonGroupTriple class.
        /// </summary>
        public KryptonRibbonGroupTriple()
        {
            // Default fields
            _visible = true;
            _itemSizeMax = GroupItemSize.Large;
            _itemSizeMin = GroupItemSize.Small;
            _itemSizeCurrent = GroupItemSize.Large;
            _itemAlignment = RibbonItemAlignment.Near;

            // Create collection for holding triple items
            Items = [];
            Items.Clearing += OnRibbonGroupTripleClearing;
            Items.Cleared += OnRibbonGroupTripleCleared;
            Items.Inserted += OnRibbonGroupTripleInserted;
            Items.Removed += OnRibbonGroupTripleRemoved;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of per-item resources
                foreach (var item in Items!)
                {
                    item.Dispose();
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets access to the owning ribbon control.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override KryptonRibbon? Ribbon
        {
            get => base.Ribbon;

            set
            {
                base.Ribbon = value;

                // Forward the reference to all children (just in case the children
                // are added before this object is added to the owner)
                foreach (var item in Items!)
                {
                    item.Ribbon = value;
                }
            }
        }

        /// <summary>
        /// Gets access to the owning ribbon tab.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override KryptonRibbonTab? RibbonTab
        {
            get => base.RibbonTab;

            set
            {
                base.RibbonTab = value;

                // Forward the reference to all children (just in case the children
                // are added before this object is added to the owner)
                foreach (var item in Items!)
                {
                    item.RibbonTab = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets how to align items in the medium and small item sizes.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"How to align items in medium and small item sizes.")]
        [DefaultValue(typeof(RibbonItemAlignment), "Near")]
        public RibbonItemAlignment ItemAlignment
        {
            get => _itemAlignment;

            set
            {
                if (_itemAlignment != value)
                {
                    _itemAlignment = value;
                    OnPropertyChanged(nameof(ItemAlignment));
                }
            }
        }

        /// <summary>
        /// Gets and sets the visible state of the triple group container.
        /// </summary>
        [Bindable(true)]
        [Category(@"Behavior")]
        [Description(@"Determines whether the triple group container is visible or hidden.")]
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
        /// Make the ribbon group visible.
        /// </summary>
        public void Show() => Visible = true;

        /// <summary>
        /// Make the ribbon group hidden.
        /// </summary>
        public void Hide() => Visible = false;

        /// <summary>
        /// Gets and sets the maximum allowed size of the container.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Maximum size of items placed in the triple container.")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(GroupItemSize), "Large")]
        [RefreshProperties(RefreshProperties.All)]
        public GroupItemSize MaximumSize
        {
            get => ItemSizeMaximum;
            set => ItemSizeMaximum = value;
        }

        /// <summary>
        /// Gets and sets the minimum allowed size of the container.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Minimum size of items placed in the triple container.")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(GroupItemSize), "Small")]
        [RefreshProperties(RefreshProperties.All)]
        public GroupItemSize MinimumSize
        {
            get => ItemSizeMinimum;
            set => ItemSizeMinimum = value;
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

                    // Ensure the minimum size is always the same or smaller than the max
                    switch (_itemSizeMax)
                    {
                        case GroupItemSize.Medium:
                            if (_itemSizeMin == GroupItemSize.Large)
                            {
                                _itemSizeMin = GroupItemSize.Medium;
                            }
                            break;
                        case GroupItemSize.Small:
                            _itemSizeMin = GroupItemSize.Small;
                            break;
                    }

                    // Update all contained elements to reflect the same sizing
                    foreach (IRibbonGroupItem item in Items!)
                    {
                        item.ItemSizeMaximum = value;
                    }

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

                    // Ensure the maximum size is always the same or larger than the min
                    switch (_itemSizeMin)
                    {
                        case GroupItemSize.Large:
                            _itemSizeMax = GroupItemSize.Large;
                            break;
                        case GroupItemSize.Medium:
                            if (_itemSizeMax == GroupItemSize.Small)
                            {
                                _itemSizeMax = GroupItemSize.Medium;
                            }
                            break;
                    }

                    // Update all contained elements to reflect the same sizing
                    foreach (IRibbonGroupItem item in Items!)
                    {
                        item.ItemSizeMinimum = value;
                    }

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

                    // Update all contained elements to reflect the same sizing
                    foreach (IRibbonGroupItem item in Items!)
                    {
                        item.ItemSizeCurrent = value;
                    }

                    OnPropertyChanged(nameof(ItemSizeCurrent));
                }
            }
        }

        /// <summary>
        /// Gets access to the Wrapped Controls Tooltips.
        /// </summary>
        public override ToolTipValues ToolTipValues => _toolTipValues;

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
            return new ViewLayoutRibbonGroupTriple(ribbon, this, needPaint);
        }

        /// <summary>
        /// Gets the collection of ribbon group triple items.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Collection of ribbon group triple items.")]
        [MergableProperty(false)]
        [Editor(typeof(KryptonRibbonGroupTripleCollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonRibbonGroupTripleCollection? Items { get; }

        /// <summary>
        /// Gets an array of all the contained components.
        /// </summary>
        /// <returns>Array of child components.</returns>
        public override Component[] GetChildComponents()
        {
            var array = new Component[Items!.Count];
            Items.CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// Internal design time properties.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public ViewBase TripleView { get; set; }

        #endregion

        #region Protected
        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region Internal
        internal void OnDesignTimeAddButton() => DesignTimeAddButton?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddColorButton() => DesignTimeAddColorButton?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddCheckBox() => DesignTimeAddCheckBox?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddRadioButton() => DesignTimeAddRadioButton?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddLabel() => DesignTimeAddLabel?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddCustomControl() => DesignTimeAddCustomControl?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddTextBox() => DesignTimeAddTextBox?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddMaskedTextBox() => DesignTimeAddMaskedTextBox?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddRichTextBox() => DesignTimeAddRichTextBox?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddComboBox() => DesignTimeAddComboBox?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddNumericUpDown() => DesignTimeAddNumericUpDown?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddDomainUpDown() => DesignTimeAddDomainUpDown?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddDateTimePicker() => DesignTimeAddDateTimePicker?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddTrackBar() => DesignTimeAddTrackBar?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeAddThemeComboBox() => DesignTimeAddThemeComboBox?.Invoke(this, EventArgs.Empty);

        internal void OnDesignTimeContextMenu(MouseEventArgs e) => DesignTimeContextMenu?.Invoke(this, e);

        internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Ask the containers to check for command key processing
            foreach (var item in Items!)
            {
                if (item.ProcessCmdKey(ref msg, keyData))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Private
        private void OnRibbonGroupTripleClearing(object? sender, EventArgs e)
        {
            // Remove the back references
            foreach (IRibbonGroupItem item in Items!)
            {
                item.Ribbon = null;
                item.RibbonTab = null;
                item.RibbonContainer = null;
            }
        }

        private void OnRibbonGroupTripleCleared(object? sender, EventArgs e)
        {
            // Only need to update display if this tab is selected
            if ((Ribbon != null)
                && (RibbonTab != null)
                && (Ribbon.SelectedTab == RibbonTab)
                )
            {
                Ribbon.PerformNeedPaint(true);
            }
        }

        private void OnRibbonGroupTripleInserted(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
        {
            // Setup the back references
            e.Item!.Ribbon = Ribbon;
            e.Item.RibbonTab = RibbonTab;
            e.Item.RibbonContainer = this;

            // Force the child item to have same sizing as the whole group
            e.Item.ItemSizeMaximum = ItemSizeMaximum;
            e.Item.ItemSizeMinimum = ItemSizeMinimum;
            e.Item.ItemSizeCurrent = ItemSizeCurrent;

            // Only need to update display if this tab is selected and the group is visible
            if ((Ribbon != null)
                && (RibbonTab != null)
                && (Ribbon.SelectedTab == RibbonTab)
                )
            {
                Ribbon.PerformNeedPaint(true);
            }
        }

        private void OnRibbonGroupTripleRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
        {
            // Remove the back references
            e.Item!.Ribbon = null;
            e.Item.RibbonTab = null;
            e.Item.RibbonContainer = null;

            // Only need to update display if this tab is selected and the group was visible
            if ((Ribbon != null)
                && (RibbonTab != null)
                && (Ribbon.SelectedTab == RibbonTab)
                )
            {
                Ribbon.PerformNeedPaint(true);
            }
        }
        #endregion
    }
}
