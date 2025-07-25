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
    /// View element that contains a control that has a view hierarchy of its own.
    /// </summary>
    public class ViewLayoutControl : ViewLeaf
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewLayoutControl class.
        /// </summary>
        /// <param name="rootControl">Top level visual control.</param>
        /// <param name="viewChild">View used to size and position the child control.</param>
        public ViewLayoutControl(VisualControl rootControl,
                                 ViewBase viewChild)
            : this(new ViewControl(rootControl), rootControl, viewChild)
        {
        }

        /// <summary>
        /// Initialize a new instance of the ViewLayoutControl class.
        /// </summary>
        /// <param name="viewControl">View control to use as child.</param>
        /// <param name="rootControl">Top level visual control.</param>
        /// <param name="viewChild">View used to size and position the child control.</param>
        public ViewLayoutControl([DisallowNull] ViewControl viewControl,
                                 [DisallowNull] VisualControl rootControl,
                                 [DisallowNull] ViewBase viewChild)
        {
            Debug.Assert(viewControl != null);
            Debug.Assert(rootControl != null);
            Debug.Assert(viewChild != null);

            // Default values
            LayoutOffset = Point.Empty;

            // Remember the view
            ChildView = viewChild;

            // Ensure the child is hooked into the hierarchy of elements
            ChildView!.Parent = this;

            // Create the view control instance
            ChildControl = viewControl;

            // Back reference hookup
            ChildControl!.ViewLayoutControl = this;

            // Start off invisible until first laid out
            ChildControl.Visible = false;

            // Ensure that all view elements inside here use our control
            OwningControl = ChildControl;

            // Add our new control to the provided parent collection
            CommonHelper.AddControlToParent(rootControl!, ChildControl);
        }

        /// <summary>
        /// Release unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing">Called from Dispose method.</param>
        protected override void Dispose(bool disposing)
        {
            // If called from explicit call to Dispose
            if (disposing)
            {
                if (ChildControl != null)
                {
                    try
                    {
                        ViewControl? vc = ChildControl;
                        ChildControl = null;
                        CommonHelper.RemoveControlFromParent(vc);
                    }
                    catch { }
                }

                if (ChildView != null)
                {
                    ChildView.Dispose();
                    ChildView = null;
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewLayoutControl:{Id} ClientLocation:{ClientLocation}";

        #endregion

        #region Visible
        /// <summary>
        /// Gets and sets the visible state of the element.
        /// </summary>
        public override bool Visible
        {
            get => base.Visible;

            set
            {
                if (base.Visible != value)
                {
                    base.Visible = value;

                    // During disposal the view control will not longer exist
                    if (ChildControl != null)
                    {
                        // Only want the child real control to show when we are
                        ChildControl.Visible = value;
                    }
                }
            }
        }
        #endregion

        #region LayoutOffset
        /// <summary>
        /// Gets and sets the offset to apply the layout of the child view.
        /// </summary>
        public Point LayoutOffset { get; set; }

        #endregion

        #region ChildView
        /// <summary>
        /// Gets access to the child view.
        /// </summary>
        public ViewBase? ChildView { get; private set; }

        #endregion

        #region ChildControl
        /// <summary>
        /// Gets access to the child control.
        /// </summary>
        public ViewControl? ChildControl { get; private set; }

        #endregion

        #region ChildPaintDelegate
        /// <summary>
        /// Gets access to the child controls paint delegate.
        /// </summary>
        public NeedPaintHandler? ChildPaintDelegate => ChildControl?.NeedPaintDelegate;

        #endregion

        #region ChildTransparentBackground
        /// <summary>
        /// Gets and sets if the background is transparent.
        /// </summary>
        public bool ChildTransparentBackground
        {
            get => ChildControl!.TransparentBackground;
            set => ChildControl!.TransparentBackground = value;
        }
        #endregion

        #region InDesignMode
        /// <summary>
        /// Gets and sets a value indicating if the control is in design mode.
        /// </summary>
        public bool InDesignMode
        {
            get => ChildControl!.InDesignMode;
            set => ChildControl!.InDesignMode = value;
        }
        #endregion

        #region MakeParent
        /// <summary>
        /// Reparent the provided control as a child of ourself.
        /// </summary>
        /// <param name="c">Control to reparent.</param>
        public void MakeParent(Control? c)
        {
            // Remove control from current collection
            CommonHelper.RemoveControlFromParent(c!);

            // Add to our child control
            CommonHelper.AddControlToParent(ChildControl!, c!);
        }
        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // Validate incoming reference
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // During disposal the view control will not longer exist
            if (ChildControl != null)
            {
                // Ensure the control has the correct parent
                UpdateParent(context.Control!);

                // Ensure context has the correct control
                using var ccc = new CorrectContextControl(context, ChildControl);
                // Ask the view for its preferred size
                if (ChildView != null)
                {
                    return ChildView.GetPreferredSize(context);
                }
            }

            return Size.Empty;
        }

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // Validate incoming reference
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // During disposal the view control will not longer exist
            if (ChildControl != null)
            {
                // Ensure context has the correct control
                using var ccc = new CorrectContextControl(context, ChildControl);
                // We take on all the available display area
                ClientRectangle = context.DisplayRectangle;

                // Are we allowed to layout child controls?
                if (!context.ViewManager!.DoNotLayoutControls)
                {
                    // Do we have a control to position?
                    if (ChildControl != null)
                    {
                        // Size and position the child control
                        ChildControl.SetBounds(ClientLocation.X, ClientLocation.Y, ClientWidth, ClientHeight);

                        // Ensure the visible/enabled states are up to date
                        ChildControl.Visible = Visible;
                        ChildControl.Enabled = Enabled;

                        // A layout means something might have changed, so better redraw it
                        ChildControl.Invalidate();
                    }
                }

                // Adjust the view location to be at the top left of the child control
                context.DisplayRectangle = new Rectangle(LayoutOffset, ClientSize);

                // Do we have a child view to layout?
                // Layout the child view
                ChildView?.Layout(context);

                // Put back the original display value now we have finished
                context.DisplayRectangle = ClientRectangle;
            }
        }
        #endregion

        #region ViewFromPoint
        /// <summary>
        /// Find the view that contains the specified point.
        /// </summary>
        /// <param name="pt">Point in view coordinates.</param>
        /// <returns>ViewBase if a match is found; otherwise false.</returns>
        public override ViewBase? ViewFromPoint(Point pt)
        {
            // If we contain a child view
            if (ChildView != null)
            {
                // Is the point inside this controls area?
                if (ClientRectangle.Contains(pt))
                {
                    // Convert to contained view coordinates
                    return ChildView.ViewFromPoint(new Point(pt.X - ClientLocation.X,
                                                              pt.Y - ClientLocation.Y));
                }
            }

            return null;
        }
        #endregion

        #region UpdateParent
        private void UpdateParent(Control parentControl)
        {
            // During disposal the view control will no longer exist
            if (ChildControl != null)
            {
                // If the view control is not inside the correct parent
                if (parentControl != ChildControl.Parent)
                {
                    // Ensure the control is not in the display area when first added
                    ChildControl.Location = new Point(-ChildControl.Width, -ChildControl.Height);

                    // Add our control to the provided parent collection
                    CommonHelper.AddControlToParent(parentControl, ChildControl);

                    // Let the actual control hook into correct parent for view manager processing
                    ChildControl.UpdateParent(parentControl);
                }
            }
        }
        #endregion
    }
}
