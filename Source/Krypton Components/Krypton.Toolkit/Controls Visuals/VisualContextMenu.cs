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
    /// Base class for drawing a krypton context menu as a popup control.
    /// </summary>
    public class VisualContextMenu : VisualPopup
    {
        #region Instance Fields
        private readonly KryptonContextMenu? _contextMenu;
        private PaletteBase? _palette;
        private readonly ContextMenuProvider _provider;
        private ViewDrawDocker _drawDocker;
        private readonly ViewLayoutStack _viewColumns;

        #endregion

        #region Identity
        /// <summary>
        ///  Initialize a new instance of the VisualContextMenu class.
        /// </summary>
        /// <param name="provider">Original source of provider details</param>
        /// <param name="items">Enabled state of the context menu.</param>
        /// <param name="keyboardActivated">Was the context menu activate by a keyboard action.</param>
        public VisualContextMenu(IContextMenuProvider provider,
                                 KryptonContextMenuCollection items,
                                 bool keyboardActivated)
            : base(provider.ProviderStateCommon.HasShadow)
        {
            Redirector = provider.ProviderRedirector;

            // Create the view manager instance with root element
            ViewManager = new ViewContextMenuManager(this, new ViewLayoutNull());

            // Set the initial resolved palette to the appropriate setting
            SetPalette(provider.ProviderPalette ?? KryptonManager.GetPaletteForMode(provider.ProviderPaletteMode));

            // Set of context menu columns
            _viewColumns = new ViewLayoutStack(true);

            // Create provider instance
            _provider = new ContextMenuProvider(provider, (ViewContextMenuManager)ViewManager, _viewColumns, NeedPaintDelegate);
            _provider.Closing += OnProviderClosing;
            _provider.Close += OnProviderClose;
            _provider.Dispose += OnProviderClose;

            Construct(items, keyboardActivated);
        }

        /// <summary>
        ///  Initialize a new instance of the VisualContextMenu class.
        /// </summary>
        /// <param name="contextMenu">Originating context menu instance.</param>
        /// <param name="palette">Local palette setting to use initially.</param>
        /// <param name="paletteMode">Palette mode setting to use initially.</param>
        /// <param name="redirector">Redirector used for obtaining palette values.</param>
        /// <param name="redirectorImages">Redirector used for obtaining images.</param>
        /// <param name="items">Collection of context menu items to be displayed.</param>
        /// <param name="enabled">Enabled state of the context menu.</param>
        /// <param name="keyboardActivated">Was the context menu activate by a keyboard action.</param>
        public VisualContextMenu(KryptonContextMenu contextMenu,
                                 PaletteBase? palette,
                                 PaletteMode paletteMode,
                                 PaletteRedirect redirector,
                                 PaletteRedirectContextMenu redirectorImages,
                                 KryptonContextMenuCollection items,
                                 bool enabled,
                                 bool keyboardActivated)
            : base(contextMenu.StateCommon.HasShadow)
        {
            _contextMenu = contextMenu;
            Redirector = redirector;

            // Create the view manager instance with root element
            ViewManager = new ViewContextMenuManager(this, new ViewLayoutNull());

            // Set the initial resolved palette to the appropriate setting
            SetPalette(palette ?? KryptonManager.GetPaletteForMode(paletteMode));

            // Set of context menu columns
            _viewColumns = new ViewLayoutStack(true);

            // Create provider instance
            _provider = new ContextMenuProvider(contextMenu, (ViewContextMenuManager)ViewManager, _viewColumns,
                                                palette!, paletteMode, redirector, redirectorImages,
                                                NeedPaintDelegate, enabled);

            _provider.Closing += OnProviderClosing;
            _provider.Close += OnProviderClose;
            _provider.Dispose += OnProviderClose;

            Construct(items, keyboardActivated);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Must unhook from the palette paint event
                if (_palette != null)
                {
                    _palette.PalettePaint -= OnPaletteNeedPaint;
                    _palette.BasePaletteChanged -= OnBaseChanged;
                    _palette.BaseRendererChanged -= OnBaseChanged;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public
        /// <summary>
        /// Sets the reason for the context menu being closed.
        /// </summary>
        public ToolStripDropDownCloseReason? CloseReason => _provider.ProviderCloseReason;

        /// <summary>
        /// Show the context menu relative to the current mouse location.
        /// </summary>
        public new void Show() =>
            // Without a screen location we just place it at the same location as the mouse.
            Show(MousePosition);

        /// <summary>
        /// Show the context menu relative to the provided screen point.
        /// </summary>
        /// <param name="screenPt">Screen location.</param>
        public void Show(Point screenPt) =>
            // When providing just a point we turn this into a rectangle that happens to
            // have a zero size. We always position relative to a screen rectangle.
            Show(new Rectangle(screenPt, Size.Empty));

        /// <summary>
        /// Show the context menu relative to the provided screen rectangle.
        /// </summary>
        /// <param name="screenRect">Screen rectangle.</param>
        public new void Show(Rectangle screenRect) =>
            // When the relative position is not provided we assume a default 
            // of below and aligned to the left edge of the screen rectangle.
            Show(screenRect, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below);

        /// <summary>
        /// Show the context menu relative to the provided screen rectangle.
        /// </summary>
        /// <param name="screenRect">Screen rectangle.</param>
        /// <param name="horz">Horizontal location relative to screen rectangle.</param>
        /// <param name="vert">Vertical location relative to screen rectangle.</param>
        public void Show(Rectangle screenRect,
                         KryptonContextMenuPositionH horz,
                         KryptonContextMenuPositionV vert) =>
            // Do not bounce, so adjust position so it fits on screen but do not alter the
            // position so that you bounce the menu from the edges as you reach them.
            Show(screenRect, horz, vert, false, true);

        /// <summary>
        /// Show the context menu relative to the provided screen rectangle.
        /// </summary>
        /// <param name="screenRect">Screen rectangle.</param>
        /// <param name="horz">Horizontal location relative to screen rectangle.</param>
        /// <param name="vert">Vertical location relative to screen rectangle.</param>
        /// <param name="bounce">Should the menu bounce around the monitor.</param>
        /// <param name="constrain">Should size and position of menu be constrained by display size.</param>
        public void Show(Rectangle screenRect,
                         KryptonContextMenuPositionH horz,
                         KryptonContextMenuPositionV vert,
                         bool bounce,
                         bool constrain)
        {
            // Find the preferred size of the context menu if it could be any size it likes
            Size preferredSize = CalculatePreferredSize();

            // Get the working area of the monitor that most of the screen rectangle is inside
            Rectangle workingArea = Screen.GetWorkingArea(screenRect);

            if (constrain)
            {
                // Limit size of context menu to the working area
                preferredSize.Width = Math.Min(workingArea.Width, preferredSize.Width);
                preferredSize.Height = Math.Min(workingArea.Height, preferredSize.Height);
            }

            // Find the horizontal position relative to screen rectangle
            var screenPt = Point.Empty;
            screenPt.X = horz switch
            {
                KryptonContextMenuPositionH.After => screenRect.Right,
                KryptonContextMenuPositionH.Before => screenRect.Left - preferredSize.Width,
                KryptonContextMenuPositionH.Left => screenRect.Left,
                KryptonContextMenuPositionH.Right => screenRect.Right - preferredSize.Width,
                _ => screenPt.X
            };

            // Find the vertical position relative to screen rectangle
            screenPt.Y = vert switch
            {
                KryptonContextMenuPositionV.Above => screenRect.Top - preferredSize.Height,
                KryptonContextMenuPositionV.Below => screenRect.Bottom,
                KryptonContextMenuPositionV.Top => screenRect.Top,
                KryptonContextMenuPositionV.Bottom => screenRect.Bottom - preferredSize.Height,
                _ => screenPt.Y
            };

            // Do we check for bouncing off working area edges?
            if (bounce)
            {
                // Are we extending past the right edge...
                if ((screenPt.X + preferredSize.Width) > workingArea.Right)
                {
                    // ...and we tried to position afterwards
                    if (horz is KryptonContextMenuPositionH.After or KryptonContextMenuPositionH.Left)
                    {
                        // Then switch to positioning before
                        horz = KryptonContextMenuPositionH.Before;
                        screenPt.X = screenRect.Left - preferredSize.Width;
                    }
                }

                // Are we extending past the left edge...
                if (screenPt.X < workingArea.X)
                {
                    // ...and we tried to position before
                    if (horz is KryptonContextMenuPositionH.Before or KryptonContextMenuPositionH.Right)
                    {
                        // Then switch to positioning after
                        horz = KryptonContextMenuPositionH.After;
                        screenPt.X = screenRect.Right;
                    }
                }

                // Are we extending past the bottom edge...
                if ((screenPt.Y + preferredSize.Height) > workingArea.Bottom)
                {
                    // ...and we tried to position downwards
                    if (vert is KryptonContextMenuPositionV.Below or KryptonContextMenuPositionV.Top)
                    {
                        // Then switch to positioning upwards
                        vert = KryptonContextMenuPositionV.Bottom;
                        screenPt.Y = screenRect.Bottom - preferredSize.Height;
                    }
                }

                // Are we extending past the top edge...
                if (screenPt.Y < workingArea.Y)
                {
                    // ...and we tried to position upwards
                    if (vert is KryptonContextMenuPositionV.Above or KryptonContextMenuPositionV.Bottom)
                    {
                        // Then switch to positioning downwards
                        vert = KryptonContextMenuPositionV.Top;
                        screenPt.Y = screenRect.Top;
                    }
                }
            }

            if (constrain)
            {
                // Limit location of context menu to the working area
                screenPt.X = Math.Max(screenPt.X, workingArea.X);
                screenPt.Y = Math.Max(screenPt.Y, workingArea.Y);

                if ((screenPt.X + preferredSize.Width) > workingArea.Right)
                {
                    screenPt.X = workingArea.Right - preferredSize.Width;
                }

                if ((screenPt.Y + preferredSize.Height) > workingArea.Bottom)
                {
                    screenPt.Y = workingArea.Bottom - preferredSize.Height;
                }
            }

            // Cache the information used to create this menu
            ShowHorz = horz;
            ShowVert = vert;

            // Call base class method that performs actual sizing and display of control
            base.Show(new Rectangle(screenPt, preferredSize));
        }

        /// <summary>
        /// Show the context menu at the fixed screen rectangle.
        /// </summary>
        /// <param name="screenRect">Screen rectangle.</param>
        /// <param name="horz">Horizontal location relative to screen rectangle.</param>
        /// <param name="vert">Vertical location relative to screen rectangle.</param>
        public void ShowFixed(Rectangle screenRect,
                              KryptonContextMenuPositionH horz,
                              KryptonContextMenuPositionV vert)
        {
            // Cache the information used to create this menu
            ShowHorz = horz;
            ShowVert = vert;

            // Call base class method that performs actual sizing and display of control
            base.Show(screenRect);
        }

        /// <summary>
        /// Gets and sets the horizontal setting used to position the menu.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KryptonContextMenuPositionH ShowHorz
        {
            get => _provider.ProviderShowHorz;
            set => _provider.ProviderShowHorz = value;
        }

        /// <summary>
        /// Gets and sets the vertical setting used to position the menu.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KryptonContextMenuPositionV ShowVert
        {
            get => _provider.ProviderShowVert;
            set => _provider.ProviderShowVert = value;
        }

        /// <summary>
        /// Gets access to the view manager for the context menu.
        /// </summary>
        public ViewContextMenuManager? ViewContextMenuManager => ViewManager as ViewContextMenuManager;

        /// <summary>
        /// Should a mouse down at the provided point cause it to become the current tracking popup.
        /// </summary>
        /// <param name="m">Original message.</param>
        /// <param name="pt">Client coordinates point.</param>
        /// <returns>True to become current; otherwise false.</returns>
        public override bool DoesStackedClientMouseDownBecomeCurrent(Message m, Point pt) =>
            // Ask the manager if the mouse down should make the stacked menu the current one
            ViewContextMenuManager!.DoesStackedClientMouseDownBecomeCurrent(m, pt);

        #endregion

        #region Protected
        /// <summary>
        /// Gets access to the palette redirector.
        /// </summary>
        protected PaletteRedirect Redirector
        {
            [DebuggerStepThrough]
            get;
        }

        /// <summary>
        /// Raises the KeyDown event.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Cannot process a message for a disposed control
            if (!IsDisposed)
            {
                // If the user pressed the escape key
                if (e.KeyData == Keys.Escape)
                {
                    // Using the escape key should give a close reason of keyboard
                    _provider.ProviderCloseReason = ToolStripDropDownCloseReason.Keyboard;
                }
            }

            // Let base class fire events
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the Layout event.
        /// </summary>
        /// <param name="levent">An EventArgs that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            // Let base class calculate fill rectangle
            base.OnLayout(levent);

            // Need a render context for accessing the renderer
            using var context = new RenderContext(this, null, ClientRectangle, Renderer);
            using var gh = new GraphicsHint(context.Graphics,
                _provider.ProviderStateCommon.ControlOuter.Border.GetBorderGraphicsHint(PaletteState.Normal));
            // Grab a path that is the outside edge of the border
            Rectangle borderRect = ClientRectangle;
            GraphicsPath borderPath1 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _provider.ProviderStateCommon.ControlOuter.Border, VisualOrientation.Top, PaletteState.Normal);
            borderRect.Inflate(-1, -1);
            GraphicsPath borderPath2 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _provider.ProviderStateCommon.ControlOuter.Border, VisualOrientation.Top, PaletteState.Normal);
            borderRect.Inflate(-1, -1);
            GraphicsPath borderPath3 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _provider.ProviderStateCommon.ControlOuter.Border, VisualOrientation.Top, PaletteState.Normal);

            // Update the region of the popup to be the border path
            Region = new Region(borderPath1);

            // Inform the shadow to use the same paths for drawing the shadow
            DefineShadowPaths(borderPath1, borderPath2, borderPath3);
        }

        /// <summary>
        /// Processes a notification from palette of a paint and optional layout required.
        /// </summary>
        /// <param name="sender">Source of notification.</param>
        /// <param name="e">An NeedLayoutEventArgs containing event data.</param>
        protected virtual void OnPaletteNeedPaint(object? sender, NeedLayoutEventArgs e) =>
            // Need to recalculate anything relying on the palette
            OnNeedPaint(sender, e);

        #endregion

        #region Implementation
        private void Construct(KryptonContextMenuCollection items,
                               bool keyboardActivated)
        {
            // Ask the top level collection to generate the child view elements
            items.GenerateView(_provider, this, _viewColumns, true, true, NeedPaintDelegate);

            // Create the control panel canvas
            var mainBackground = new ViewDrawCanvas(_provider.ProviderStateCommon.ControlInner.Back,
                _provider.ProviderStateCommon.ControlInner.Border, VisualOrientation.Top)
            {
                _viewColumns
            };

            var layoutDocker = new ViewLayoutDocker();
            Padding outerPadding = _provider.ProviderRedirector.GetMetricPadding(null, PaletteState.Normal, PaletteMetricPadding.ContextMenuItemOuter);
            layoutDocker.Add(new ViewLayoutSeparator(outerPadding.Top), ViewDockStyle.Top);
            layoutDocker.Add(new ViewLayoutSeparator(outerPadding.Bottom), ViewDockStyle.Bottom);
            layoutDocker.Add(new ViewLayoutSeparator(outerPadding.Left), ViewDockStyle.Left);
            layoutDocker.Add(new ViewLayoutSeparator(outerPadding.Right), ViewDockStyle.Right);
            layoutDocker.Add(mainBackground, ViewDockStyle.Fill);

            // Create the docking element that gives us a border and background
            _drawDocker = new ViewDrawDocker(_provider.ProviderStateCommon.ControlOuter.Back, _provider.ProviderStateCommon.ControlOuter.Border, null)
            {
                { layoutDocker, ViewDockStyle.Fill }
            };
            _drawDocker.KeyController = new ContextMenuController(ViewManager as ViewContextMenuManager);
            ViewManager!.Root = _drawDocker;

            // With keyboard activate we select the first valid item
            if (keyboardActivated)
            {
                ((ViewContextMenuManager)ViewManager).KeyDown();
            }
        }

        private Size CalculatePreferredSize()
        {
            // Prevent calculation of layout from performing a recursive layout
            SuspendLayout();

            try
            {
                // Find the preferred size which fits exactly the calculated contents size
                using var context = new ViewLayoutContext(this, Renderer);
                return ViewManager!.Root.GetPreferredSize(context);
            }
            finally
            {
                // Must always have matching suspend/resume
                ResumeLayout();
            }
        }

        private void SetPalette(PaletteBase palette)
        {
            if (palette != _palette)
            {
                // Unhook from current palette events
                if (_palette is not null)
                {
                    _palette.PalettePaint -= OnPaletteNeedPaint;
                    _palette.BasePaletteChanged -= OnBaseChanged;
                    _palette.BaseRendererChanged -= OnBaseChanged;
                }

                // Remember the new palette
                _palette = palette;

                // Update redirector to use palette as source for obtaining values
                Redirector.Target = _palette;

                // Get the renderer associated with the palette
                Renderer = _palette.GetRenderer();

                // Hook to new palette events
                if (_palette != null)
                {
                    _palette.PalettePaint += OnPaletteNeedPaint;
                    _palette.BasePaletteChanged += OnBaseChanged;
                    _palette.BaseRendererChanged += OnBaseChanged;
                }
            }
        }

        private void OnBaseChanged(object? sender, EventArgs e) =>
            // Change in base renderer or base palette require we fetch the latest renderer
            Renderer = _palette!.GetRenderer();

        private void OnProviderClosing(object? sender, CancelEventArgs e) => _contextMenu?.OnClosing(e);

        private void OnProviderClose(object? sender, CloseReasonEventArgs e) => _contextMenu?.Close(e.CloseReason);

        private void OnProviderClose(object? sender, EventArgs e)
        {
            // Unhook from event source
            var provider = sender as ContextMenuProvider;
            _provider.Dispose -= OnProviderClose;

            // Kill this pop-up window
            Dispose();
        }
        #endregion
    }
}
