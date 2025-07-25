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
    /// Extends the ViewComposite by applying a docking style for each child.
    /// </summary>
    public class ViewLayoutDocker : ViewComposite
    {
        #region Instance Fields

        private ViewDockStyleLookup _childDocking;

        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewLayoutDocker class.
        /// </summary>
        public ViewLayoutDocker()
        {
            // Create child to dock style lookup
            _childDocking = new ViewDockStyleLookup();

            // Default state
            FillRectangle = Rectangle.Empty;
            Orientation = VisualOrientation.Top;
            MaxBorderEdges = PaletteDrawBorders.All;
            PreferredSizeAll = false;
            RemoveChildBorders = false;
            IgnoreRightToLeftLayout = false;
            Padding = Padding.Empty;
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewLayoutDocker:{Id} {_childDocking.Count}";

        #endregion

        #region IgnoreRightToLeftLayout
        /// <summary>
        /// Gets and sets if the RightToLeftLayout ability is used.
        /// </summary>
        public bool IgnoreRightToLeftLayout { get; set; }

        #endregion

        #region Orientation
        /// <summary>
        /// Gets and sets the visual orientation.
        /// </summary>
        public VisualOrientation Orientation { get; set; }

        #endregion

        #region Padding
        /// <summary>
        /// Gets and sets the padding around the edges.
        /// </summary>
        public Padding Padding { get; set; }

        #endregion

        #region MaxBorderEdges
        /// <summary>
        /// Gets and sets the maximum edges allowed.
        /// </summary>
        public PaletteDrawBorders MaxBorderEdges { get; set; }

        #endregion

        #region RemoveChildBorders
        /// <summary>
        /// Gets and sets a value indicating if borders for docking edged children should be removed to prevent double borders.
        /// </summary>
        public bool RemoveChildBorders { get; set; }

        #endregion

        #region PreferredSizeAll
        /// <summary>
        /// Gets and sets a value indicating if calculating the preferred size should include visible and invisible children.
        /// </summary>
        public bool PreferredSizeAll { get; set; }

        #endregion

        #region FillRect
        /// <summary>
        /// Gets the fill rectangle left after positioning all children.
        /// </summary>
        public Rectangle FillRectangle { get; private set; }

        #endregion

        #region Dock
        /// <summary>
        /// Gets the dock setting for the provided child instance.
        /// </summary>
        /// <param name="child">Child view element.</param>
        /// <returns>Docking setting.</returns>
        public ViewDockStyle GetDock([DisallowNull] ViewBase child)
        {
            Debug.Assert(child != null);

            // Does this element exist in the lookup?
            if (!_childDocking.ContainsKey(child!))
            {
                // No, so add with a default value
                _childDocking.Add(child!, ViewDockStyle.Top);
            }

            return _childDocking[child!];
        }

        /// <summary>
        /// Sets the dock setting for the provided child instance.
        /// </summary>
        /// <param name="child">Child view element.</param>
        /// <param name="dock">ViewDockStyle setting.</param>
        public void SetDock([DisallowNull] ViewBase child, ViewDockStyle dock)
        {
            Debug.Assert(child != null);

            // If the lookup is not already defined
            if (!_childDocking.ContainsKey(child!))
            {
                // Then just add the value
                _childDocking.Add(child!, dock);
            }
            else
            {
                // Overwrite the existing value
                _childDocking[child!] = dock;
            }
        }
        #endregion

        #region Collection
        /// <summary>
        /// Append a view to the collection.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <param name="dock">DockStyle setting.</param>
        public void Add(ViewBase item, ViewDockStyle dock)
        {
            // Add the child to the view
            Add(item);

            // Set the initial docking for the new element
            SetDock(item, dock);
        }
        #endregion

        #region Tag
        /// <summary>
        /// Gets and sets data with the view.
        /// </summary>
        public object Tag { get; set; }

        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // Create new lookup that only contains entries for current child items
            var newChildDocking = new ViewDockStyleLookup();

            // Remember the original display rectangle provided
            Rectangle originalRect = context!.DisplayRectangle;
            Rectangle displayRect = context.DisplayRectangle;

            // Accumulate the size that must be provided by docking edges and then filler
            var preferredSize = Size.Empty;

            // Track the minimize size needed to satisfy the docking edges only
            var minimumSize = Size.Empty;

            var leftEdges = PaletteDrawBorders.All;
            var rightEdges = PaletteDrawBorders.All;
            var topEdges = PaletteDrawBorders.All;
            var bottomEdges = PaletteDrawBorders.All;
            var fillEdges = PaletteDrawBorders.All;

            // Check for edge docking children
            foreach (ViewBase child in Reverse())
            {
                // Add into the valid child lookup
                ViewDockStyle dockStyle = GetDock(child);
                newChildDocking.Add(child, dockStyle);

                // Only position visible children that are not 'fill'
                if ((child.Visible || PreferredSizeAll) && (GetDock(child) != ViewDockStyle.Fill))
                {
                    // Prevent children from showing adjacent borders that are not needed
                    UpdateChildBorders(child, context, ref leftEdges, ref rightEdges,
                                       ref topEdges, ref bottomEdges, ref fillEdges);

                    // Update with latest calculated display rectangle
                    context.DisplayRectangle = displayRect;

                    // Get the preferred size of the child
                    Size childSize = child.GetPreferredSize(context);

                    // Apply size requests from edge docking children
                    switch (OrientateDock(dockStyle))
                    {
                        case ViewDockStyle.Top:
                            preferredSize.Height += childSize.Height;
                            displayRect.Y += childSize.Height;
                            displayRect.Height -= childSize.Height;

                            if (minimumSize.Width < childSize.Width)
                            {
                                minimumSize.Width = childSize.Width;
                            }
                            break;

                        case ViewDockStyle.Bottom:
                            preferredSize.Height += childSize.Height;
                            displayRect.Height -= childSize.Height;

                            if (minimumSize.Width < childSize.Width)
                            {
                                minimumSize.Width = childSize.Width;
                            }
                            break;

                        case ViewDockStyle.Left:
                            preferredSize.Width += childSize.Width;
                            displayRect.X += childSize.Width;
                            displayRect.Width -= childSize.Width;

                            if (minimumSize.Height < childSize.Height)
                            {
                                minimumSize.Height = childSize.Height;
                            }
                            break;

                        case ViewDockStyle.Right:
                            preferredSize.Width += childSize.Width;
                            displayRect.Width -= childSize.Width;

                            if (minimumSize.Height < childSize.Height)
                            {
                                minimumSize.Height = childSize.Height;
                            }
                            break;
                    }
                }
            }

            // Check for the fill child last
            foreach (ViewBase child in Reverse())
            {
                // Only interested in a visible 'fill' child
                if ((child.Visible || PreferredSizeAll) && (GetDock(child) == ViewDockStyle.Fill))
                {
                    // Prevent children from showing adjacent borders that are not needed
                    UpdateChildBorders(child, context, ref leftEdges, ref rightEdges,
                                       ref topEdges, ref bottomEdges, ref fillEdges);

                    // Update with latest calculated display rectangle
                    context.DisplayRectangle = displayRect;

                    // Get the preferred size of the child
                    Size childSize = child.GetPreferredSize(context);

                    preferredSize.Width += childSize.Width;
                    preferredSize.Height += childSize.Height;

                    // There can only be one filler!
                    break;
                }
            }

            // Use updated lookup
            _childDocking = newChildDocking;

            // Put back the original display rect
            context.DisplayRectangle = originalRect;

            // Enforce the minimum values from the other docking edge sizes
            preferredSize.Width = Math.Max(preferredSize.Width, minimumSize.Width);
            preferredSize.Height = Math.Max(preferredSize.Height, minimumSize.Height);

            // Apply the padding request
            switch (Orientation)
            {
                case VisualOrientation.Top:
                case VisualOrientation.Bottom:
                    preferredSize.Width += Padding.Horizontal;
                    preferredSize.Height += Padding.Vertical;
                    break;

                case VisualOrientation.Left:
                case VisualOrientation.Right:
                    preferredSize.Width += Padding.Vertical;
                    preferredSize.Height += Padding.Horizontal;
                    break;
            }

            // Allow the preferred size to be modified before being used
            return UpdatePreferredSize(preferredSize);
        }

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // We take on all the available display area
            ClientRectangle = context!.DisplayRectangle;

            // Space available for children begins with our space
            Rectangle fillerRect = ClientRectangle;

            // Apply the padding against the rect
            switch (Orientation)
            {
                case VisualOrientation.Top:
                    fillerRect.X += Padding.Left;
                    fillerRect.Y += Padding.Top;
                    fillerRect.Width -= Padding.Horizontal;
                    fillerRect.Height -= Padding.Vertical;
                    break;

                case VisualOrientation.Bottom:
                    fillerRect.X += Padding.Right;
                    fillerRect.Y += Padding.Bottom;
                    fillerRect.Width -= Padding.Horizontal;
                    fillerRect.Height -= Padding.Vertical;
                    break;

                case VisualOrientation.Left:
                    fillerRect.X += Padding.Top;
                    fillerRect.Y += Padding.Right;
                    fillerRect.Width -= Padding.Vertical;
                    fillerRect.Height -= Padding.Horizontal;
                    break;

                case VisualOrientation.Right:
                    fillerRect.X += Padding.Bottom;
                    fillerRect.Y += Padding.Left;
                    fillerRect.Width -= Padding.Vertical;
                    fillerRect.Height -= Padding.Horizontal;
                    break;
            }

            // By default, all the children need to draw all their borders
            var leftEdges = PaletteDrawBorders.All;
            var rightEdges = PaletteDrawBorders.All;
            var topEdges = PaletteDrawBorders.All;
            var bottomEdges = PaletteDrawBorders.All;
            var fillEdges = PaletteDrawBorders.All;

            // Position all except the filler
            foreach (var child in Reverse()
                         .Where(child => child.Visible && (GetDock(child) != ViewDockStyle.Fill))
                     )
            {
                // Prevent children from showing adjacent borders that are not needed
                UpdateChildBorders(child, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);

                // Provide the available space left over
                context.DisplayRectangle = fillerRect;

                // Get the preferred size of the child
                Size childSize = child.GetPreferredSize(context);

                // Position the child inside the available space
                switch (CalculateDock(OrientateDock(GetDock(child)), context.Control!))
                {
                    case ViewDockStyle.Top:
                        context.DisplayRectangle = fillerRect with { Height = childSize.Height };
                        fillerRect.Height -= childSize.Height;
                        fillerRect.Y += childSize.Height;
                        break;

                    case ViewDockStyle.Bottom:
                        context.DisplayRectangle = fillerRect with { Y = fillerRect.Bottom - childSize.Height, Height = childSize.Height };
                        fillerRect.Height -= childSize.Height;
                        break;

                    case ViewDockStyle.Left:
                        context.DisplayRectangle = fillerRect with { Width = childSize.Width };
                        fillerRect.Width -= childSize.Width;
                        fillerRect.X += childSize.Width;
                        break;

                    case ViewDockStyle.Right:
                        context.DisplayRectangle = fillerRect with { X = fillerRect.Right - childSize.Width, Width = childSize.Width };
                        fillerRect.Width -= childSize.Width;
                        break;
                }

                // Layout child in the provided space
                child.Layout(context);
            }

            // Allow the filler rectangle to be modified before being used
            fillerRect = UpdateFillerRect(fillerRect, context.Control!);

            // Position any filler last
            foreach (ViewBase child in Reverse()
                         .Where(child => child.Visible && (GetDock(child) == ViewDockStyle.Fill))
                     )
            {
                // Prevent children from showing adjacent borders that are not needed
                UpdateChildBorders(child, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);

                // Give the filler the remaining space
                context.DisplayRectangle = fillerRect;

                // Layout child in the provided space
                child.Layout(context);
            }

            // Put back the original display value now we have finished
            context.DisplayRectangle = ClientRectangle;

            // Remember the filler size
            FillRectangle = fillerRect;
        }
        #endregion

        #region Protected Virtual
        /// <summary>
        /// Allow the preferred size calculated by GetPreferredSize to be modified before use.
        /// </summary>
        /// <param name="preferredSize">Original preferred size value.</param>
        /// <returns>Modified size.</returns>
        protected virtual Size UpdatePreferredSize(Size preferredSize) => preferredSize;

        /// <summary>
        /// Allow the filler rectangle calculated by Layout to be modified before use.
        /// </summary>
        /// <param name="fillerRect">Original filler rectangle.</param>
        /// <param name="control">Owning control instance.</param>
        /// <returns>Modified rectangle.</returns>
        protected virtual Rectangle UpdateFillerRect(Rectangle fillerRect,
                                                     Control control) =>
            fillerRect;

        #endregion

        #region Implementation
        /// <summary>
        /// Find the actual docking to apply for the specified RightToLeft setting.
        /// </summary>
        /// <param name="ds">Docking style.</param>
        /// <param name="control">Control for which the setting is needed.</param>
        /// <returns>Calculated docking to actual use.</returns>
        protected ViewDockStyle CalculateDock(ViewDockStyle ds, Control control)
        {
            if (IgnoreRightToLeftLayout)
            {
                return ds;
            }
            else
            {
                // Do we need to adjust to reflect right to left layout?
                if (CommonHelper.GetRightToLeftLayout(control) && (control.RightToLeft == RightToLeft.Yes))
                {
                    // Only need to invert the left and right sides
                    ds = ds switch
                    {
                        ViewDockStyle.Left => ViewDockStyle.Right,
                        ViewDockStyle.Right => ViewDockStyle.Left,
                        _ => ds
                    };
                }
            }

            return ds;
        }

        /// <summary>
        /// Update the incoming dock style to reflect our orientation.
        /// </summary>
        /// <param name="style">Incoming dock style.</param>
        /// <returns>Orientation adjusted dock style.</returns>
        protected ViewDockStyle OrientateDock(ViewDockStyle style)
        {
            switch (Orientation)
            {
                case VisualOrientation.Top:
                    // Nothing to do, as top is the standard setting
                    break;
                case VisualOrientation.Left:
                    switch (style)
                    {
                        case ViewDockStyle.Top:
                            return ViewDockStyle.Left;
                        case ViewDockStyle.Left:
                            return ViewDockStyle.Bottom;
                        case ViewDockStyle.Right:
                            return ViewDockStyle.Top;
                        case ViewDockStyle.Bottom:
                            return ViewDockStyle.Right;
                    }
                    break;

                case VisualOrientation.Right:
                    switch (style)
                    {
                        case ViewDockStyle.Top:
                            return ViewDockStyle.Right;
                        case ViewDockStyle.Left:
                            return ViewDockStyle.Top;
                        case ViewDockStyle.Right:
                            return ViewDockStyle.Bottom;
                        case ViewDockStyle.Bottom:
                            return ViewDockStyle.Left;
                    }
                    break;

                case VisualOrientation.Bottom:
                    switch (style)
                    {
                        case ViewDockStyle.Top:
                            return ViewDockStyle.Bottom;
                        case ViewDockStyle.Left:
                            return ViewDockStyle.Right;
                        case ViewDockStyle.Right:
                            return ViewDockStyle.Left;
                        case ViewDockStyle.Bottom:
                            return ViewDockStyle.Top;
                    }
                    break;
                default:
    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(Orientation.ToString());
                    break;
            }

            // No change required
            return style;
        }

        private void UpdateChildBorders(ViewBase child,
                                        ViewLayoutContext context,
                                        ref PaletteDrawBorders leftEdges,
                                        ref PaletteDrawBorders rightEdges,
                                        ref PaletteDrawBorders topEdges,
                                        ref PaletteDrawBorders bottomEdges,
                                        ref PaletteDrawBorders fillEdges)
        {
            // Do we need to calculate if the child should remove any borders?
            if (RemoveChildBorders)
            {
                // Check if the view is a canvas
                var childCanvas = child as ViewDrawCanvas;

                // Docking edge determines calculation
                switch (CalculateDock(GetDock(child), context.Control!))
                {
                    case ViewDockStyle.Fill:
                        if (childCanvas != null)
                        {
                            childCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(fillEdges, childCanvas.Orientation);
                        }
                        else
                        {
                            if (child is ViewLayoutDocker layoutDocker)
                            {
                                foreach (ViewBase layoutChild in layoutDocker)
                                {
                                    childCanvas = layoutChild as ViewDrawCanvas;
                                    if (childCanvas != null)
                                    {
                                        childCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(fillEdges, childCanvas.Orientation);
                                    }
                                }
                            }
                        }
                        break;
                    case ViewDockStyle.Top:
                        if (childCanvas != null)
                        {
                            childCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(topEdges, childCanvas.Orientation);
                        }

                        // Remove top edges from subsequent children
                        leftEdges &= PaletteDrawBorders.BottomLeftRight;
                        rightEdges &= PaletteDrawBorders.BottomLeftRight;
                        topEdges &= PaletteDrawBorders.BottomLeftRight;
                        fillEdges &= PaletteDrawBorders.BottomLeftRight;
                        break;
                    case ViewDockStyle.Bottom:
                        if (childCanvas != null)
                        {
                            childCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(bottomEdges, childCanvas.Orientation);
                        }

                        // Remove bottom edges from subsequent children
                        leftEdges &= PaletteDrawBorders.TopLeftRight;
                        rightEdges &= PaletteDrawBorders.TopLeftRight;
                        bottomEdges &= PaletteDrawBorders.TopLeftRight;
                        fillEdges &= PaletteDrawBorders.TopLeftRight;
                        break;
                    case ViewDockStyle.Left:
                        if (childCanvas != null)
                        {
                            childCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(leftEdges, childCanvas.Orientation);
                        }

                        // Remove left edges from subsequent children
                        topEdges &= PaletteDrawBorders.TopBottomRight;
                        bottomEdges &= PaletteDrawBorders.TopBottomRight;
                        leftEdges &= PaletteDrawBorders.TopBottomRight;
                        fillEdges &= PaletteDrawBorders.TopBottomRight;
                        break;
                    case ViewDockStyle.Right:
                        if (childCanvas != null)
                        {
                            childCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(rightEdges, childCanvas.Orientation);
                        }

                        // Remove right edges from subsequent children
                        topEdges &= PaletteDrawBorders.TopBottomLeft;
                        bottomEdges &= PaletteDrawBorders.TopBottomLeft;
                        rightEdges &= PaletteDrawBorders.TopBottomLeft;
                        fillEdges &= PaletteDrawBorders.TopBottomLeft;
                        break;
                }
            }
        }
        #endregion
    }
}
