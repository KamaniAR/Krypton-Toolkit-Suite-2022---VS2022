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
    /// Manage the items that can be added to a top level context menu collection.
    /// </summary>
    [Editor(typeof(KryptonContextMenuCollectionEditor), typeof(UITypeEditor))]
    public class KryptonContextMenuCollection : TypedRestrictCollection<KryptonContextMenuItemBase>
    {
        #region Static Fields
        private static readonly Type[] _types = [
            typeof(KryptonContextMenuItems),
            typeof(KryptonContextMenuItem),
            typeof(KryptonContextMenuSeparator),
            typeof(KryptonContextMenuHeading),
            typeof(KryptonContextMenuLinkLabel),
            typeof(KryptonContextMenuCheckBox),
            typeof(KryptonContextMenuCheckButton),
            typeof(KryptonContextMenuRadioButton),
            typeof(KryptonContextMenuColorColumns),
            typeof(KryptonContextMenuMonthCalendar),
            typeof(KryptonContextMenuImageSelect)
        ];
        #endregion

        #region Restrict
        /// <summary>
        /// Gets an array of types that the collection is restricted to contain.
        /// </summary>
        public override Type[] RestrictTypes => _types;

        #endregion

        #region ProcessShortcut
        /// <summary>
        /// Test for the provided shortcut and perform relevant action if a match is found.
        /// </summary>
        /// <param name="keyData">Key data to check against shortcut definitions.</param>
        /// <returns>True if shortcut was handled, otherwise false.</returns>
        public bool ProcessShortcut(Keys keyData) =>
            // Ask each individual item if it has a shortcut to be processed
            this.Any(item => item.ProcessShortcut(keyData));
        #endregion

        #region Internal

        /// <summary>
        /// Create view elements appropriate for the collection items.
        /// </summary>
        /// <param name="provider">Context menu information provider.</param>
        /// <param name="parent">Parent object.</param>
        /// <param name="columns">Collection of columns to create view inside.</param>
        /// <param name="standardStyle">Should the standard style be applied.</param>
        /// <param name="imageColumn">Should the image column be applied.</param>
        /// <param name="needPaint"></param>
        public void GenerateView(IContextMenuProvider provider,
                                 object parent,
                                 ViewLayoutStack columns,
                                 bool standardStyle,
                                 bool imageColumn,
                                 NeedPaintHandler? needPaint)
        {
            // Create the initial column
            ViewLayoutStack column = AddColumn(columns);

            // Process each item in the collection in turn
            foreach (KryptonContextMenuItemBase item in this.Where(static item => item.Visible))
            {
                item.ToolTipValues.NeedPaint = needPaint;
                // Special handling of separator items
                if (item is KryptonContextMenuSeparator separator)
                {
                    // Cast to correct type

                    // If vertical break....
                    if (!separator.Horizontal)
                    {
                        // Add separator as next column view element
                        provider.ProviderViewColumns.Add(separator.GenerateView(provider, this, columns, standardStyle, imageColumn));

                        // Start new column for subsequent child items
                        column = AddColumn(columns);
                    }
                    else
                    {
                        // Add separator view into the current column
                        column.Add(separator.GenerateView(provider, this, columns, standardStyle, imageColumn));
                    }
                }
                else
                {
                    // All other items we just ask them for the view to add
                    column.Add(item.GenerateView(provider, this, columns, standardStyle, imageColumn));
                }
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the Inserted event.
        /// </summary>
        /// <param name="e">A TypedCollectionEventArgs instance containing event data.</param>
        protected override void OnInserted(TypedCollectionEventArgs<KryptonContextMenuItemBase> e)
        {
            base.OnInserted(e);

            // We monitor changes to the checked state of radio buttons
            if (e.Item is KryptonContextMenuRadioButton radioButton)
            {
                radioButton.CheckedChanged += OnRadioButtonCheckedChanged;
            }
        }

        /// <summary>
        /// Raises the Removing event.
        /// </summary>
        /// <param name="e">A TypedCollectionEventArgs instance containing event data.</param>
        protected override void OnRemoving(TypedCollectionEventArgs<KryptonContextMenuItemBase> e)
        {
            // Must unhook from the change event to prevent memory leak
            if (e.Item is KryptonContextMenuRadioButton radioButton)
            {
                radioButton.CheckedChanged -= OnRadioButtonCheckedChanged;
            }

            base.OnRemoving(e);
        }
        #endregion

        #region Private
        private void OnRadioButtonCheckedChanged(object? sender, EventArgs e)
        {
            // Only interested if the button has become checked
            if (sender is KryptonContextMenuRadioButton { Checked: true } radioButton)
            {
                // Find the position of this element in the collection
                var index = IndexOf(radioButton);

                // Scan upwards for other radio button instances
                UncheckRadioButtons(index - 1, 0, -1);

                // Scan downwards for other radio button instances
                UncheckRadioButtons(index + 1, Count - 1, 1);
            }
        }

        private void UncheckRadioButtons(int start, int end, int change)
        {
            // Check that the start index is valid
            if ((start >= 0) && (start < Count))
            {
                do
                {
                    // Exit as soon as a non-radio button is encountered
                    if (this[start] is not KryptonContextMenuRadioButton radioButton)
                    {
                        break;
                    }

                    // Set the radio button to unchecked
                    if (radioButton.Checked)
                    {
                        radioButton.Checked = false;
                    }

                    // Keep going until we reach the end item
                    if (start == end)
                    {
                        break;
                    }

                    // Moved to next index
                    start += change;

                } while (true);
            }
        }

        private ViewLayoutStack AddColumn(ViewLayoutStack columns)
        {
            var column = new ViewLayoutStack(false);
            columns.Add(column);
            return column;
        }
        #endregion
    }

    /// <summary>
    /// Manage the items that can be added to a standard menu item collection.
    /// </summary>
    public class KryptonContextMenuItemCollection : TypedRestrictCollection<KryptonContextMenuItemBase>
    {
        #region Static Fields
        private static readonly Type[] _types = 
        [
            typeof(KryptonContextMenuItems),
            typeof(KryptonContextMenuItem),
            typeof(KryptonContextMenuSeparator),
            typeof(KryptonContextMenuHeading),
            typeof(KryptonContextMenuLinkLabel),
            typeof(KryptonContextMenuCheckBox),
            typeof(KryptonContextMenuCheckButton),
            typeof(KryptonContextMenuRadioButton),
            typeof(KryptonContextMenuColorColumns),
            typeof(KryptonContextMenuMonthCalendar),
            typeof(KryptonContextMenuImageSelect)
        ];
        #endregion

        #region Restrict
        /// <summary>
        /// Gets an array of types that the collection is restricted to contain.
        /// </summary>
        public override Type[] RestrictTypes => _types;

        #endregion

        #region ProcessShortcut
        /// <summary>
        /// Test for the provided shortcut and perform relevant action if a match is found.
        /// </summary>
        /// <param name="keyData">Key data to check against shortcut definitions.</param>
        /// <returns>True if shortcut was handled, otherwise false.</returns>
        public bool ProcessShortcut(Keys keyData) =>
            // Ask each individual item if it has a shortcut to be processed
            this.Any(item => item.ProcessShortcut(keyData));
        #endregion

        #region Internal
        internal void GenerateView(IContextMenuProvider provider,
                                   KryptonContextMenuItems items,
                                   object parent,
                                   ViewLayoutStack columns,
                                   bool standardStyle,
                                   bool imageColumn)
        {
            // Create the initial column
            ViewBase column = AddColumn(provider, items, columns, standardStyle, imageColumn);

            // Process each item in the collection in turn
            foreach (KryptonContextMenuItemBase item in this.Where(static item => item.Visible))
            {
                // Special handling of separator items
                if (item is KryptonContextMenuSeparator separator)
                {
                    // Cast to correct type

                    // If vertical break....
                    if (!separator.Horizontal)
                    {
                        // Add separator as next column view element
                        columns.Add(separator.GenerateView(provider, this, columns, standardStyle, imageColumn));

                        // Start new column for subsequent child items
                        column = AddColumn(provider, items, columns, standardStyle, imageColumn);
                    }
                    else
                    {
                        // Add separator view into the current column
                        column.Add(separator.GenerateView(provider, this, columns, standardStyle, imageColumn));
                    }
                }
                else
                {
                    // All other items we just ask them for the view to add
                    column.Add(item.GenerateView(provider, this, columns, standardStyle, imageColumn));
                }
            }
        }
        #endregion

        #region Private
        private ViewBase AddColumn(IContextMenuProvider provider,
                                   KryptonContextMenuItems items,
                                   ViewLayoutStack columns,
                                   bool standardStyle,
                                   bool imageColumn)
        {
            // Create a pile specific to organising menu items
            var menuItemPile = new ViewLayoutMenuItemsPile(provider, items, standardStyle, imageColumn);

            // The pile is the root item for the new column
            columns.Add(menuItemPile);

            // Child items are placed inside the column stack
            return menuItemPile.ItemStack;
        }
        #endregion
    }
}
