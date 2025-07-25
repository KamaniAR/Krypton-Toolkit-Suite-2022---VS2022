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
    /// Draws a scrolling button with given orientation.
    /// </summary>
    internal class ViewDrawRibbonScrollButton : ViewLeaf
    {
        #region Instance Fields
        private readonly KryptonRibbon _ribbon;
        private IDisposable? _mementoBack;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewDrawRibbonScrollButton class.
        /// </summary>
        /// <param name="ribbon">Reference to owning ribbon control.</param>
        /// <param name="orientation">Scroller orientation.</param>
        public ViewDrawRibbonScrollButton(KryptonRibbon ribbon,
                                          VisualOrientation orientation)
        {
            _ribbon = ribbon;
            Orientation = orientation;
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $@"ViewDrawRibbonScrollButton:{Id}";

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_mementoBack != null)
                {
                    _mementoBack.Dispose();
                    _mementoBack = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Orientation
        /// <summary>
        /// Gets and sets the visual orientation of the scroller button.
        /// </summary>
        public VisualOrientation Orientation { get; set; }

        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize(ViewLayoutContext context) => Size.Empty;

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // We take on all the available display area
            ClientRectangle = context!.DisplayRectangle;
        }
        #endregion

        #region Paint
        /// <summary>
        /// Perform rendering before child elements are rendered.
        /// </summary>
        /// <param name="context">Rendering context.</param>
        public override void RenderBefore(RenderContext context) 
        {
            if (context.Renderer is null)
            {
                throw new ArgumentNullException(nameof(context.Renderer));
            }

            // Create a border offset down and right for drawing a shadow
            Rectangle shadowRect = ClientRectangle;
            shadowRect.X++;
            shadowRect.Y++;

            // Reduce background to fit inside the border
            Rectangle backRect = ClientRectangle;
            backRect.Inflate(-1, -1);

            // Create border paths
            using GraphicsPath borderPath = CreateBorderPath(ClientRectangle),
                shadowPath = CreateBorderPath(shadowRect);
            // Are we allowed to draw a border?
            if (_ribbon.StateCommon.RibbonScroller.PaletteBorder!.GetBorderDraw(State) == InheritBool.True)
            {
                // Draw the border shadow
                using var aa = new AntiAlias(context.Graphics);
                using var shadowBrush = new SolidBrush(Color.FromArgb(16, Color.Black));
                context.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Are we allowed to draw a background?
            if (_ribbon.StateCommon.RibbonScroller.PaletteBack.GetBackDraw(State) == InheritBool.True)
            {
                _mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, backRect, borderPath,
                    _ribbon.StateCommon.RibbonScroller.PaletteBack,
                    VisualOrientation.Top,State, _mementoBack);
            }

            // Are we allowed to draw the content?
            if (_ribbon.StateCommon.RibbonScroller.PaletteContent!.GetContentDraw(State) == InheritBool.True)
            {
                // Get the text color from palette
                Color textColor = _ribbon.StateCommon.RibbonScroller.PaletteContent.GetContentShortTextColor1(State);

                // Draw the arrow content in center of the background
                DrawArrow(context.Graphics, textColor, backRect);
            }

            // Are we allowed to draw border?
            if (_ribbon.StateCommon.RibbonScroller.PaletteBorder.GetBorderDraw(State) == InheritBool.True)
            {
                // Get the border color from palette
                Color borderColor = _ribbon.StateCommon.RibbonScroller.PaletteBorder.GetBorderColor1(State);

                // Draw the border last to overlap the background
                using var aa = new AntiAlias(context.Graphics);
                using var borderPen = new Pen(borderColor);
                context.Graphics.DrawPath(borderPen, borderPath);
            }
        }
        #endregion

        #region Implementation
        private GraphicsPath CreateBorderPath(Rectangle rect)
        {
            var path = new GraphicsPath();

            switch (Orientation)
            {
                case VisualOrientation.Top:
                    path.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top + 2);
                    path.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
                    path.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 1);
                    path.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
                    break;
                case VisualOrientation.Bottom:
                    path.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom - 3);
                    path.AddLine(rect.Left, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 1);
                    path.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 3, rect.Bottom - 1);
                    path.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 3);
                    path.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 1, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top, rect.Left, rect.Top);
                    break;
                case VisualOrientation.Left:
                    path.AddLine(rect.Right - 1, rect.Top, rect.Left + 2, rect.Top);
                    path.AddLine(rect.Left + 2, rect.Top, rect.Left, rect.Top + 2);
                    path.AddLine(rect.Left, rect.Top + 2, rect.Left, rect.Bottom - 3);
                    path.AddLine(rect.Left, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 1);
                    path.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                    path.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Right - 1, rect.Top);
                    break;
                case VisualOrientation.Right:
                    path.AddLine(rect.Left, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
                    path.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
                    path.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
                    path.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top);
                    break;
            }

            return path;
        }

        private void DrawArrow(Graphics? g, Color textColor, Rectangle rect)
        {
            // Create path that describes the arrow in orientation needed
            using GraphicsPath arrowPath = CreateArrowPath(rect);
            using var arrowBrush = new SolidBrush(textColor);
            g?.FillPath(arrowBrush, arrowPath);
        }

        private GraphicsPath CreateArrowPath(Rectangle rect)
        {
            int x, y;

            // Find the correct starting position, which depends on direction
            if (Orientation is VisualOrientation.Left or VisualOrientation.Right)
            {
                x = rect.Right - ((rect.Width - 4) / 2);
                y = rect.Y + (rect.Height / 2);
            }
            else
            {
                x = rect.X + (rect.Width / 2);
                y = rect.Bottom - ((rect.Height - 3) / 2);
            }

            // Create triangle using a series of lines
            var path = new GraphicsPath();

            switch (Orientation)
            {
                case VisualOrientation.Right:
                    path.AddLine(x, y, x - 4, y - 4);
                    path.AddLine(x - 4, y - 4, x - 4, y + 4);
                    path.AddLine(x - 4, y + 4, x, y);
                    break;
                case VisualOrientation.Left:
                    path.AddLine(x - 4, y, x, y - 4);
                    path.AddLine(x, y - 4, x, y + 4);
                    path.AddLine(x, y + 4, x - 4, y);
                    break;
                case VisualOrientation.Bottom:
                    path.AddLine(x + 3f, y - 3f, x - 2f, y - 3f);
                    path.AddLine(x - 2f, y - 3f, x, y);
                    path.AddLine(x, y, x + 3f, y - 3f);
                    break;
                case VisualOrientation.Top:
                    path.AddLine(x + 3f, y, x - 3f, y);
                    path.AddLine(x - 3f, y, x, y - 4f);
                    path.AddLine(x, y - 4f, x + 3f, y);
                    break;
            }

            return path;
        }
        #endregion
    }
}
