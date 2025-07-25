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
    /// Extend the visual container control base class with the ISupportInitializeNotification interface.
    /// </summary>
    [ToolboxItem(false)]
    [DesignerCategory(@"code")]
    public abstract class VisualContainerControl : VisualContainerControlBase,
                                                   ISupportInitializeNotification
    {
        #region Events
        /// <summary>
        /// Occurs when the control is initialized.
        /// </summary>
        [Category(@"Behavior")]
        [Description(@"Occurs when the control has been fully initialized.")]
        public event EventHandler? Initialized;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the VisualContainerControl class.
        /// </summary>
        protected VisualContainerControl()
        {
        }
        #endregion

        #region Public
        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public virtual void BeginInit()
        {
            // Remember that fact we are inside a BeginInit/EndInit pair
            IsInitializing = true;

            // No need to layout the view during initialization
            SuspendLayout();
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public virtual void EndInit()
        {
            // We are now initialized
            IsInitialized = true;

            // We are no longer initializing
            IsInitializing = false;

            // Need to recalculate anything relying on the palette
            DirtyPaletteCounter++;

            // We always need a paint and layout
            OnNeedPaint(this, new NeedLayoutEventArgs(true));

            // Should layout once initialization is complete
            ResumeLayout(true);

            // Raise event to show control is now initialized
            OnInitialized(EventArgs.Empty);
        }

        /// <summary>
        /// Gets a value indicating if the control is initialized.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInitialized
        {
            [DebuggerStepThrough]
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating if the control is initialized.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInitializing
        {
            [DebuggerStepThrough]
            get;
            private set;
        }

        #endregion

        #region Protected Virtual
        // ReSharper disable VirtualMemberNeverOverridden.Global
        /// <summary>
        /// Raises the Initialized event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnInitialized(EventArgs e) => Initialized?.Invoke(this, EventArgs.Empty);
        // ReSharper restore VirtualMemberNeverOverridden.Global
        #endregion
    }
}
