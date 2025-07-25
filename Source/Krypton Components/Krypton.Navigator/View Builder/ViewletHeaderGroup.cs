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

namespace Krypton.Navigator
{
    /// <summary>
    /// Provides HeaderGroup functionality.
    /// </summary>
    internal class ViewletHeaderGroup
    {
        #region Instance Fields

        private ViewDrawDocker _viewGroup;
        private ViewDrawDocker _viewHeadingPrimary;
        private ViewDrawContent _viewContentPrimary;
        private ViewDrawDocker _viewHeadingSecondary;
        private ViewDrawContent _viewContentSecondary;
        private ButtonSpecManagerDraw? _buttonManager;  // Can be null in the designer
        private readonly NeedPaintHandler _needPaintDelegate;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewletHeaderGroup class.
        /// </summary>
        /// <param name="navigator">Reference to navigator instance.</param>
        /// <param name="redirector">Palette redirector.</param>
        /// <param name="needPaintDelegate">Delegate for notifying paint requests.</param>
        public ViewletHeaderGroup([DisallowNull] KryptonNavigator navigator,
                                  [DisallowNull] PaletteRedirect redirector,
                                  [DisallowNull] NeedPaintHandler needPaintDelegate)
        {
            Debug.Assert(navigator != null);
            Debug.Assert(redirector != null);
            Debug.Assert(needPaintDelegate != null);

            // Remember references
            Navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            Redirector = redirector ?? throw new ArgumentNullException(nameof(redirector));
            _needPaintDelegate = needPaintDelegate ?? throw new ArgumentNullException(nameof(needPaintDelegate));
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets access to the navigator reference.
        /// </summary>
        public KryptonNavigator Navigator { get; }

        /// <summary>
        /// Gets access to the palette redirector reference.
        /// </summary>
        public PaletteRedirect Redirector { get; }

        /// <summary>
        /// Construct the view appropriate for this builder.
        /// </summary>
        /// <param name="filler">View element to fill in the header group.</param>
        /// <returns>The root of the header group hierarchy.</returns>
        public ViewDrawDocker Construct(ViewBase filler)
        {
            CreateHeaderGroupView(filler);
            CreateButtonSpecManager();
            CreateDragDrop();

            return _viewGroup;
        }

        /// <summary>
        /// Perform actions required after the create of hierarchy is completed
        /// </summary>
        public void PostCreate()
        {
            UpdateHeaders();
            UpdateStatePalettes();

            // Force buttons to be recreated in the headers
            _buttonManager?.RecreateButtons();
        }

        /// <summary>
        /// Destruct and cleanup the view hierarchy of the header group.
        /// </summary>
        public void Destruct()
        {
            if (_buttonManager != null)
            {
                // Remove paint delegate so we can be garbage collected
                _buttonManager.NeedPaint = null;

                // Cleanup the button manager events and processing
                _buttonManager.Destruct();
            }

            // Remove the old root from the canvas
            _viewGroup.Dispose();
            _viewGroup.Clear();
        }

        /// <summary>
        /// Gets the ButtonSpec associated with the provided view element.
        /// </summary>
        /// <param name="element">Element to search against.</param>
        /// <returns>Reference to ButtonSpec; otherwise null.</returns>
        public ButtonSpec? ButtonSpecFromView(ViewBase element) =>
            // Ask the button manager for the button spec for this element
            _buttonManager?.ButtonSpecFromView(element);

        /// <summary>
        /// Recreate the buttons to reflect a change in selected page.
        /// </summary>
        public void UpdateButtons() =>
            // Ensure buttons are recreated to reflect different page
            _buttonManager?.RecreateButtons();

        /// <summary>
        /// Ensure the correct state palettes are being used.
        /// </summary>
        public void UpdateStatePalettes()
        {
            // If whole navigator is disabled then all of view is disabled
            var enabled = Navigator.Enabled;

            // If there is no selected page
            if (Navigator.SelectedPage == null)
            {
                // Then use the states defined in the navigator itself
                SetPalettes(Navigator.Enabled
                    ? Navigator.StateNormal.HeaderGroup
                    : Navigator.StateDisabled.HeaderGroup);
            }
            else
            {
                // Use states defined in the selected page
                if (Navigator.SelectedPage.Enabled)
                {
                    SetPalettes(Navigator.SelectedPage.StateNormal.HeaderGroup);
                }
                else
                {
                    SetPalettes(Navigator.SelectedPage.StateDisabled.HeaderGroup);

                    // If page is disabled then all of view should look disabled
                    enabled = false;
                }
            }

            // Update enabled appearance of view
            SetEnabled(enabled);
        }

        /// <summary>
        /// Gets the screen coordinates for showing a context action menu.
        /// </summary>
        /// <returns>Point in screen coordinates.</returns>
        public Point GetContextShowPoint()
        {
            // Get the display rectangle of the context button
            Rectangle rect = _buttonManager!.GetButtonRectangle(Navigator.Button.ContextButton);

            // We want the context menu to show just below the button
            var pt = new Point(rect.Left, rect.Bottom + 3);

            // Convert from control coordinates to screen coordinates
            return Navigator.PointToScreen(pt);
        }

        /// <summary>
        /// Is the provided over a part of the view that wants the mouse.
        /// </summary>
        /// <param name="pt">Mouse point.</param>
        /// <returns>True if the view wants the mouse position; otherwise false.</returns>
        public bool DesignerGetHitTest(Point pt) =>
            // Check if any of the buttons want the point
            _buttonManager?.DesignerGetHitTest(pt) ?? false;

        /// <summary>
        /// Get the appropriate action for the header group next action.
        /// </summary>
        /// <param name="action">Requested action.</param>
        /// <returns>Updated requested action.</returns>
        public DirectionButtonAction NextActionEnabled(DirectionButtonAction action)
        {
            // Our mode appropriate action is always to select a page
            if (action == DirectionButtonAction.ModeAppropriateAction)
            {
                action = DirectionButtonAction.SelectPage;
            }

            return action;
        }

        /// <summary>
        /// Get the appropriate action for the header group previous action.
        /// </summary>
        /// <param name="action">Requested action.</param>
        /// <returns>Updated requested action.</returns>
        public DirectionButtonAction PreviousActionEnabled(DirectionButtonAction action)
        {
            // Our mode appropriate action is always to select a page
            if (action == DirectionButtonAction.ModeAppropriateAction)
            {
                action = DirectionButtonAction.SelectPage;
            }

            return action;
        }

        /// <summary>
        /// Process the change in a property that might effect the viewlet.
        /// </summary>
        /// <param name="e">Property changed details.</param>
        public virtual void ViewBuilderPropertyChanged(PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case @"HeaderStylePrimary":
                    SetHeaderStyle(_viewHeadingPrimary, Navigator.StateCommon!.HeaderGroup.HeaderPrimary, Navigator.Header.HeaderStylePrimary);
                    UpdateStatePalettes();
                    Navigator.PerformNeedPaint(true);
                    break;
                case @"HeaderStyleSecondary":
                    SetHeaderStyle(_viewHeadingSecondary, Navigator.StateCommon!.HeaderGroup.HeaderSecondary, Navigator.Header.HeaderStyleSecondary);
                    UpdateStatePalettes();
                    Navigator.PerformNeedPaint(true);
                    break;
                case @"HeaderPositionPrimary":
                    SetHeaderPosition(_viewHeadingPrimary, _viewContentPrimary, Navigator.Header.HeaderPositionPrimary);
                    _buttonManager?.RecreateButtons();
                    Navigator.PerformNeedPaint(true);
                    break;
                case @"HeaderPositionSecondary":
                    SetHeaderPosition(_viewHeadingSecondary, _viewContentSecondary, Navigator.Header.HeaderPositionSecondary);
                    _buttonManager?.RecreateButtons();
                    Navigator.PerformNeedPaint(true);
                    break;
                case @"HeaderVisiblePrimary":
                    _viewHeadingPrimary.Visible = Navigator.Header.HeaderVisiblePrimary;
                    Navigator.PerformNeedPaint(true);
                    break;
                case @"HeaderVisibleSecondary":
                    _viewHeadingSecondary.Visible = GetHeaderSecondaryVisible();
                    Navigator.PerformNeedPaint(true);
                    break;
                case @"PreviousButtonDisplay":
                case @"PreviousButtonAction":
                case @"NextButtonDisplay":
                case @"NextButtonAction":
                case @"ContextButtonDisplay":
                case @"CloseButtonDisplay":
                case nameof(ButtonDisplayLogic):
                    _buttonManager?.RecreateButtons();
                    break;
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Gets the visible state of the secondary header.
        /// </summary>
        /// <returns>Boolean value.</returns>
        protected virtual bool GetHeaderSecondaryVisible() => Navigator.Header.HeaderVisibleSecondary;

        /// <summary>
        /// Gets the source of the primary header values.
        /// </summary>
        /// <returns></returns>
        protected virtual IContentValues GetPrimaryValues() => Navigator.Header.HeaderValuesPrimary;

        /// <summary>
        /// Gets the source of the secondary header values.
        /// </summary>
        /// <returns></returns>
        protected virtual IContentValues GetSecondaryValues() => Navigator.Header.HeaderValuesSecondary;

        #endregion

        #region Implementation
        private void CreateHeaderGroupView(ViewBase filler)
        {
            // Create the top level group view
            _viewGroup = new ViewDrawDocker(Navigator.StateNormal.HeaderGroup.Back,
                                            Navigator.StateNormal.HeaderGroup.Border,
                                            Navigator.StateNormal.HeaderGroup,
                                            PaletteMetricBool.HeaderGroupOverlay);

            // Create the two headers and header content
            _viewContentPrimary = new ViewDrawContent(Navigator.StateNormal.HeaderGroup.HeaderPrimary.Content,
                                                      GetPrimaryValues(),
                                                      VisualOrientation.Top);

            _viewHeadingPrimary = new ViewDrawDocker(Navigator.StateNormal.HeaderGroup.HeaderPrimary.Back,
                                                     Navigator.StateNormal.HeaderGroup.HeaderPrimary.Border,
                                                     Navigator.StateNormal.HeaderGroup.HeaderPrimary,
                                                     PaletteMetricBool.None,
                                                     PaletteMetricPadding.HeaderGroupPaddingPrimary,
                                                     VisualOrientation.Top);

            _viewContentSecondary = new ViewDrawContent(Navigator.StateNormal.HeaderGroup.HeaderSecondary.Content,
                                                        GetSecondaryValues(),
                                                        VisualOrientation.Top);

            _viewHeadingSecondary = new ViewDrawDocker(Navigator.StateNormal.HeaderGroup.HeaderSecondary.Back,
                                                       Navigator.StateNormal.HeaderGroup.HeaderSecondary.Border,
                                                       Navigator.StateNormal.HeaderGroup.HeaderSecondary,
                                                       PaletteMetricBool.None,
                                                       PaletteMetricPadding.HeaderGroupPaddingSecondary,
                                                       VisualOrientation.Top);

            // Place the the content as fillers in the headers
            _viewHeadingPrimary.Add(_viewContentPrimary, ViewDockStyle.Fill);
            _viewHeadingSecondary.Add(_viewContentSecondary, ViewDockStyle.Fill);

            // Place the headers and page holding area into the group
            _viewGroup.Add(_viewHeadingSecondary, ViewDockStyle.Bottom);
            _viewGroup.Add(_viewHeadingPrimary, ViewDockStyle.Top);
            _viewGroup.Add(filler, ViewDockStyle.Fill);

            // Prevent adjacent headers from having two borders
            _viewGroup.RemoveChildBorders = true;

            // Set initial visible state of headers
            _viewHeadingPrimary.Visible = Navigator.Header.HeaderVisiblePrimary;
            _viewHeadingSecondary.Visible = GetHeaderSecondaryVisible();
        }

        private void CreateDragDrop()
        {
            // Create and attach the drag controller to the header view
            var controller = new DragViewController(_viewHeadingPrimary);
            _viewHeadingPrimary.MouseController = controller;
            _viewHeadingPrimary.KeyController = controller;
            _viewHeadingPrimary.SourceController = controller;

            // Hook into the dragging events for forwarding to the navigator
            controller.DragStart += OnDragStart;
            controller.DragMove += OnDragMove;
            controller.DragEnd += OnDragEnd;
            controller.DragQuit += OnDragQuit;
            controller.LeftMouseDown += OnLeftMouseDown;
            controller.RightMouseDown += OnRightMouseDown;
            controller.LeftDoubleClick += OnLeftDoubleClick;
        }

        private void CreateButtonSpecManager() =>
            // Create button specification collection manager
            _buttonManager = new ButtonSpecManagerDraw(Navigator, Redirector, Navigator.Button.ButtonSpecs, Navigator.FixedSpecs,
                                                       new[] { _viewHeadingPrimary, _viewHeadingSecondary },
                                                       new IPaletteMetric[] { Navigator.StateCommon!.HeaderGroup.HeaderPrimary, Navigator.StateCommon.HeaderGroup.HeaderSecondary },
                                                       new[] { PaletteMetricInt.HeaderButtonEdgeInsetPrimary, PaletteMetricInt.HeaderButtonEdgeInsetSecondary },
                                                       new[] { PaletteMetricPadding.HeaderButtonPaddingPrimary, PaletteMetricPadding.HeaderButtonPaddingSecondary },
                                                       Navigator.CreateToolStripRenderer,
                                                       _needPaintDelegate)
            {

                // Hook up the tooltip manager so that tooltips can be generated
                ToolTipManager = Navigator.ToolTipManager
            };

        private void UpdateHeaders()
        {
            SetHeaderStyle(_viewHeadingPrimary, Navigator.StateCommon!.HeaderGroup.HeaderPrimary, Navigator.Header.HeaderStylePrimary);
            SetHeaderStyle(_viewHeadingSecondary, Navigator.StateCommon.HeaderGroup.HeaderSecondary, Navigator.Header.HeaderStyleSecondary);
            SetHeaderPosition(_viewHeadingPrimary, _viewContentPrimary, Navigator.Header.HeaderPositionPrimary);
            SetHeaderPosition(_viewHeadingSecondary, _viewContentSecondary, Navigator.Header.HeaderPositionSecondary);
        }

        private void SetHeaderStyle(ViewDrawDocker drawDocker,
                                    PaletteTripleMetricRedirect palette,
                                    HeaderStyle style)
        {
            palette.SetStyles(style);

            switch (style)
            {
                case HeaderStyle.Primary:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetPrimary,
                                                    PaletteMetricPadding.HeaderButtonPaddingPrimary);
                    break;

                case HeaderStyle.Secondary:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetSecondary,
                                                    PaletteMetricPadding.HeaderButtonPaddingSecondary);
                    break;

                case HeaderStyle.DockActive:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetDockActive,
                                                    PaletteMetricPadding.HeaderButtonPaddingDockActive);
                    break;

                case HeaderStyle.DockInactive:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetDockInactive,
                                                    PaletteMetricPadding.HeaderButtonPaddingDockInactive);
                    break;

                case HeaderStyle.Form:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetForm,
                                                    PaletteMetricPadding.HeaderButtonPaddingForm);
                    break;

                case HeaderStyle.Calendar:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetCalendar,
                                                    PaletteMetricPadding.HeaderButtonPaddingCalendar);
                    break;

                case HeaderStyle.Custom1:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetCustom1,
                                                    PaletteMetricPadding.HeaderButtonPaddingCustom1);
                    break;

                case HeaderStyle.Custom2:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                                                    PaletteMetricInt.HeaderButtonEdgeInsetCustom2,
                                                    PaletteMetricPadding.HeaderButtonPaddingCustom2);
                    break;

                case HeaderStyle.Custom3:
                    _buttonManager?.SetDockerMetrics(drawDocker, palette,
                        PaletteMetricInt.HeaderButtonEdgeInsetCustom3,
                        PaletteMetricPadding.HeaderButtonPaddingCustom3);
                    break;

                default:
    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }
        }

        private void SetHeaderPosition(ViewDrawCanvas canvas,
                                       ViewDrawContent content,
                                       VisualOrientation position)
        {
            switch (position)
            {
                case VisualOrientation.Top:
                    _viewGroup.SetDock(canvas, ViewDockStyle.Top);
                    canvas.Orientation = VisualOrientation.Top;
                    content.Orientation = VisualOrientation.Top;
                    break;
                case VisualOrientation.Bottom:
                    _viewGroup.SetDock(canvas, ViewDockStyle.Bottom);
                    canvas.Orientation = VisualOrientation.Top;
                    content.Orientation = VisualOrientation.Top;
                    break;
                case VisualOrientation.Left:
                    _viewGroup.SetDock(canvas, ViewDockStyle.Left);
                    canvas.Orientation = VisualOrientation.Left;
                    content.Orientation = VisualOrientation.Left;
                    break;
                case VisualOrientation.Right:
                    _viewGroup.SetDock(canvas, ViewDockStyle.Right);
                    canvas.Orientation = VisualOrientation.Right;
                    content.Orientation = VisualOrientation.Right;
                    break;
            }
        }

        private void SetPalettes(PaletteHeaderGroup palette)
        {
            _viewGroup.SetPalettes(palette.Back, palette.Border, palette);

            _viewHeadingPrimary.SetPalettes(palette.HeaderPrimary.Back, palette.HeaderPrimary.Border, palette.HeaderPrimary);
            _viewHeadingSecondary.SetPalettes(palette.HeaderSecondary.Back, palette.HeaderSecondary.Border, palette.HeaderSecondary);

            _buttonManager?.SetDockerMetrics(_viewHeadingPrimary, palette.HeaderPrimary);
            _buttonManager?.SetDockerMetrics(_viewHeadingSecondary, palette.HeaderSecondary);

            _viewContentPrimary.SetPalette(palette.HeaderPrimary.Content);
            _viewContentSecondary.SetPalette(palette.HeaderSecondary.Content);
        }

        private void SetEnabled(bool enabled)
        {
            _viewGroup.Enabled = enabled;
            _viewHeadingPrimary.Enabled = enabled;
            _viewHeadingSecondary.Enabled = enabled;
            _viewContentPrimary.Enabled = enabled;
            _viewContentSecondary.Enabled = enabled;
            _buttonManager?.RecreateButtons();
        }

        private void OnDragStart(object? sender, DragStartEventCancelArgs e) => Navigator.InternalDragStart(e, null);

        private void OnDragMove(object? sender, PointEventArgs e) => Navigator.InternalDragMove(e);

        private void OnDragEnd(object? sender, PointEventArgs e) => Navigator.InternalDragEnd(e);

        private void OnDragQuit(object? sender, EventArgs e) => Navigator.InternalDragQuit();

        private void OnLeftMouseDown(object? sender, EventArgs e) => Navigator.OnPrimaryHeaderLeftClicked(e);

        private void OnRightMouseDown(object? sender, EventArgs e) => Navigator.OnPrimaryHeaderRightClicked(e);

        private void OnLeftDoubleClick(object? sender, EventArgs e) => Navigator.OnPrimaryHeaderDoubleClicked(e);
        #endregion
    }
}
