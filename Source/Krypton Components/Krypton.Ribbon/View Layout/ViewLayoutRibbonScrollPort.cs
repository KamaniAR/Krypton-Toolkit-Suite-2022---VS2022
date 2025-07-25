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
    /// Sizes and positions a provided view but provides scrolling if too big for area.
    /// </summary>
    internal class ViewLayoutRibbonScrollPort : ViewComposite
    {
        #region Type Definintions
        public class RibbonViewControl : ViewControl
        {
            #region Instance Fields
            private readonly KryptonRibbon _ribbon;
            private readonly Button? _hiddenFocusTarget;
            #endregion

            #region Identity
            /// <summary>
            /// Initialize a new instance of the ViewControl class.
            /// </summary>
            /// <param name="ribbon">Top level ribbon control.</param>
            public RibbonViewControl([DisallowNull] KryptonRibbon? ribbon)
                : base(ribbon)
            {
                Debug.Assert(ribbon is not null);
                
                _ribbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));

                // Create and add a hidden button to act as the focus target
                _hiddenFocusTarget = new Button
                {
                    TabStop = false
                };
                _hiddenFocusTarget.Location = new Point(-_hiddenFocusTarget.Width, -_hiddenFocusTarget.Height);
                CommonHelper.AddControlToParent(this, _hiddenFocusTarget);
            }
            #endregion

            #region Public
            /// <summary>
            /// Hide focus by giving it to the hidden control.
            /// </summary>
            public void HideFocus() => _hiddenFocusTarget!.Focus();
            #endregion

            #region Protected

            /// <summary>
            /// Processes a dialog key.
            /// </summary>
            /// <param name="keyData">One of the Keys values that represents the key to process.</param>
            /// <returns>True is handled; otherwise false.</returns>
            protected override bool ProcessDialogKey(Keys keyData)
            {
                // Grab the controlling control that is a parent
                Control? c = _ribbon.GetControllerControl(this);

                // Grab the view manager handling the focus view
                ViewBase? focusView = null;
                switch (c)
                {
                    case VisualPopupGroup popGroup:
                    {
                        var manager = popGroup.GetViewManager() as ViewRibbonPopupGroupManager;
                        focusView = manager?.FocusView;
                        break;
                    }
                    case VisualPopupMinimized minimized:
                    {
                        var manager = minimized.GetViewManager() as ViewRibbonMinimizedManager;
                        focusView = manager?.FocusView;
                        break;
                    }
                }

                // When in keyboard mode...
                if (focusView != null)
                {
                    // We pass movements keys onto the view
                    switch (keyData)
                    {
                        case Keys.Tab | Keys.Shift:
                        case Keys.Tab:
                        case Keys.Left:
                        case Keys.Right:
                        case Keys.Up:
                        case Keys.Down:
                        case Keys.Space:
                        case Keys.Enter:
                            _ribbon.KillKeyboardKeyTips();
                            focusView.KeyDown(new KeyEventArgs(keyData));
                            return true;
                    }
                }

                return base.ProcessDialogKey(keyData);
            }
            #endregion
        }
        #endregion

        #region Static Fields

        private const int SCROLL_GAP = 8;

        #endregion

        #region Instance Fields
        private readonly KryptonRibbon _ribbon;
        private readonly NeedPaintHandler _needPaintDelegate;
        private Orientation _orientation;
        private readonly ViewBase _viewFiller;
        private readonly ViewLayoutRibbonScroller _nearScroller;
        private readonly ViewLayoutRibbonScroller _farScroller;
        private readonly ViewLayoutRibbonTabs? _ribbonTabs;
        private readonly RibbonViewControl _viewControlContent;
        private Rectangle _viewClipRect;
        private int _scrollOffset;
        private readonly int _scrollSpeed;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the background needs painting.
        /// </summary>
        public event PaintEventHandler? PaintBackground;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewLayoutRibbonScrollPort class.
        /// </summary>
        /// <param name="ribbon">Reference to owning ribbon control.</param>
        /// <param name="orientation">Viewport orientation.</param>
        /// <param name="viewFiller">View to size and position.</param>
        /// <param name="insetForTabs">Should scoller be inset for use in tabs area.</param>
        /// <param name="scrollSpeed">Scrolling speed.</param>
        /// <param name="needPaintDelegate">Delegate for notifying paint/layout requests.</param>
        public ViewLayoutRibbonScrollPort([DisallowNull] KryptonRibbon? ribbon,
                                          Orientation orientation,
                                          [DisallowNull] ViewBase? viewFiller,
                                          bool insetForTabs,
                                          int scrollSpeed,
                                          [DisallowNull] NeedPaintHandler? needPaintDelegate)
        {
            Debug.Assert(ribbon != null);
            Debug.Assert(viewFiller != null);
            Debug.Assert(needPaintDelegate != null);

            // Remember initial settings
            _ribbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));
            _orientation = orientation;
            _viewFiller = viewFiller ?? throw new ArgumentNullException(nameof(viewFiller));
            _needPaintDelegate = needPaintDelegate ?? throw new ArgumentNullException(nameof(needPaintDelegate));
            _scrollSpeed = scrollSpeed;
            _ribbonTabs = viewFiller as ViewLayoutRibbonTabs;

            // Default to left hand scroll position
            _scrollOffset = 0;

            // Place the child view inside an actual control, so that the contents of the 
            // filler are clipped to the control size. This is needed if the child view
            // contains controls and need clipping inside this area and so prevent them
            // from drawing over the end scrollers.
            _viewControlContent = new RibbonViewControl(ribbon!);
            _viewControlContent.PaintBackground += OnViewControlPaintBackground;
            ViewLayoutControl = new ViewLayoutControl(_viewControlContent, ribbon!, _viewFiller!);

            // Removed because of this
            // https://github.com/Krypton-Suite/Standard-Toolkit/issues/372
            // And the statement below does not make sense, and it didn;t do what it states !
            //// For ribbon tabs we want to monitor and intercept the WM_NCHITTEST so that the remainder of the 
            //// tabs area acts like the application title bar and can be used to manipulate the application
            //if (_ribbonTabs != null)
            //{
            //    ViewLayoutControl.ChildControl.WndProcHitTest += OnChildWndProcHitTest;
            //}

            // Create the two scrollers used when not enough space for filler
            _nearScroller = new ViewLayoutRibbonScroller(ribbon!, NearOrientation, insetForTabs, needPaintDelegate!);
            _farScroller = new ViewLayoutRibbonScroller(ribbon!, FarOrientation, insetForTabs, needPaintDelegate!);

            // Hook into scroller events
            _nearScroller.Click += OnNearClick;
            _farScroller.Click += OnFarClick;

            // Add elements in correct order
            Add(ViewLayoutControl);
            Add(_nearScroller);
            Add(_farScroller);
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewLayoutRibbonScrollPort:{Id}";

        #endregion

        #region NeedPaintHandler
        /// <summary>
        /// Gets access to the paint delegate to redraw the owning control.
        /// </summary>
        public NeedPaintHandler ViewControlPaintDelegate => ViewLayoutControl.ChildPaintDelegate!;

        #endregion

        #region TransparentBackground
        /// <summary>
        /// Gets and sets if the background is transparent.
        /// </summary>
        public bool TransparentBackground
        {
            get => ViewLayoutControl.ChildTransparentBackground;
            set => ViewLayoutControl.ChildTransparentBackground = value;
        }
        #endregion

        #region ViewLayoutControl
        /// <summary>
        /// Gets access to the actual control instance.
        /// </summary>
        public ViewLayoutControl ViewLayoutControl { get; }

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

                    // Only want the child real control to show when we are
                    ViewLayoutControl.Visible = value;
                }
            }
        }
        #endregion

        #region Enabled
        /// <summary>
        /// Gets and sets the enabled state of the element.
        /// </summary>
        public override bool Enabled
        {
            get => base.Enabled;

            set
            {
                if (base.Enabled != value)
                {
                    base.Enabled = value;

                    // Only want the child real control to be enabled when we are
                    ViewLayoutControl.Enabled = value;
                }
            }
        }
        #endregion

        #region Orientation
        /// <summary>
        /// Gets and sets the orientation of the scroller viewport.
        /// </summary>
        public Orientation Orientation
        {
            get => _orientation;

            set
            {
                _orientation = value;
                _nearScroller.Orientation = NearOrientation;
                _farScroller.Orientation = FarOrientation;
            }
        }
        #endregion

        #region GetGroupKeyTips
        /// <summary>
        /// Gets the array of group level key tips.
        /// </summary>
        /// <returns>Array of KeyTipInfo; otherwise null.</returns>
        public KeyTipInfo[] GetGroupKeyTips()
        {

            // If we contain a groups layout
            if (_viewFiller is ViewLayoutRibbonGroups groups)
            {
                var keyTips = new KeyTipInfoList();

                // Grab the list of key tips for all groups
                keyTips.AddRange(groups.GetGroupKeyTips());

                // Remove all those that do not intercept the view rectangle
                foreach (KeyTipInfo tip in keyTips)
                {
                    if (!_viewClipRect.Contains(tip.ClientRect))
                    {
                        tip.Visible = false;
                    }
                }

                return keyTips.ToArray();
            }
            else
            {
                return Array.Empty<KeyTipInfo>();
            }
        }
        #endregion

        #region GetFirstFocusItem
        /// <summary>
        /// Gets the first focus item within the scroll port.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetFirstFocusItem()
        {
            ViewBase? view = null;

            // If we contain a groups layout
            if (_viewFiller is ViewLayoutRibbonGroups groups)
            {
                // Ask the groups for the first focus item
                view = groups.GetFirstFocusItem();

                // Make sure client area of view is visible
                if (view != null)
                {
                    ScrollIntoView(view.ClientRectangle, true);
                }
            }

            return view!;
        }
        #endregion

        #region GetFirstFocusItem
        /// <summary>
        /// Gets the last focus item within the scroll port.
        /// </summary>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetLastFocusItem()
        {
            ViewBase? view = null;

            // If we contain a groups layout
            if (_viewFiller is ViewLayoutRibbonGroups groups)
            {
                // Ask the groups for the first focus item
                view = groups.GetLastFocusItem();

                // Make sure client area of view is visible
                if (view != null)
                {
                    ScrollIntoView(view.ClientRectangle, true);
                }
            }

            return view!;
        }
        #endregion

        #region GetNextFocusItem
        /// <summary>
        /// Gets the next focus item based on the current item as provided.
        /// </summary>
        /// <param name="current">The view that is currently focused.</param>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetNextFocusItem(ViewBase current)
        {
            ViewBase? view = null;

            // If we contain a groups layout
            if (_viewFiller is ViewLayoutRibbonGroups groups)
            {
                // Ask the groups for the next focus item
                view = groups.GetNextFocusItem(current);

                // Make sure client area of view is visible
                if (view != null)
                {
                    ScrollIntoView(view.ClientRectangle, true);
                }
            }

            return view!;
        }
        #endregion

        #region GetPreviousFocusItem
        /// <summary>
        /// Gets the previous focus item based on the current item as provided.
        /// </summary>
        /// <param name="current">The view that is currently focused.</param>
        /// <returns>ViewBase of item; otherwise false.</returns>
        public ViewBase GetPreviousFocusItem(ViewBase current)
        {
            ViewBase? view = null;

            // If we contain a groups layout
            if (_viewFiller is ViewLayoutRibbonGroups groups)
            {
                // Ask the groups for the previous focus item
                view = groups.GetPreviousFocusItem(current);

                // Make sure client area of view is visible
                if (view != null)
                {
                    ScrollIntoView(view.ClientRectangle, true);
                }
            }

            return view!;
        }
        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize(ViewLayoutContext context) =>
            // We always want to be the size needed to show the filler completely
            ViewLayoutControl.GetPreferredSize(context);

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // Out enabled state is the same as that of the ribbon itself
            Enabled = _ribbon.Enabled;

            // We take on all the available display area
            ClientRectangle = context!.DisplayRectangle;

            Rectangle layoutRect = ClientRectangle;
            var controlRect = new Rectangle(Point.Empty, ClientSize);

            // Reset the view control layout offset to be zero again
            ViewLayoutControl.LayoutOffset = Point.Empty;

            // Ask the view control the size it would like to be, this is the requested filler
            // size of the control. If it wants more than we can give then scroll buttons are
            // needed, otherwise we can give it the requested size and any extra available.
            _ribbon.GetViewManager()!.DoNotLayoutControls = true;
            ViewLayoutControl.GetPreferredSize(context);

            // Ensure context has the correct control
            if (ViewLayoutControl.ChildControl is { IsDisposed: false })
            {
                using var ccc = new CorrectContextControl(context, ViewLayoutControl.ChildControl);
                _viewFiller.Layout(context);
            }

            _ribbon.GetViewManager()!.DoNotLayoutControls = false;
            Size fillerSize = _viewFiller.ClientSize;

            // Limit check the scroll offset
            _scrollOffset = Math.Max(_scrollOffset, 0);

            // Did it fit fully into our space?
            if (((Orientation == Orientation.Horizontal) && (fillerSize.Width <= ClientWidth)) ||
                ((Orientation == Orientation.Vertical) && (fillerSize.Height <= ClientHeight)))
            {
                // Filler rectangle is used for clipping
                _viewClipRect = controlRect;

                // Default back to left hand scroll position
                _scrollOffset = 0;

                // Then make the scrollers invisible and nothing more to do
                _nearScroller.Visible = false;
                _farScroller.Visible = false;

                // We need to layout again but this time we do layout the actual children
                ViewLayoutControl.Layout(context);
            }
            else
            {
                // We only need the near scroller if we are not at the left scroll position
                if (_scrollOffset > 0)
                {
                    _nearScroller.Visible = true;

                    // Find size requirements of the near scroller
                    Size nearSize = _nearScroller.GetPreferredSize(context);

                    // Find layout position of the near scroller
                    if (Orientation == Orientation.Horizontal)
                    {
                        context.DisplayRectangle = layoutRect with { Width = nearSize.Width };
                        layoutRect.Width -= nearSize.Width;
                        layoutRect.X += nearSize.Width;
                        controlRect.Width -= nearSize.Width;
                        controlRect.X += nearSize.Width;
                    }
                    else
                    {
                        context.DisplayRectangle = layoutRect with { Height = nearSize.Height };
                        layoutRect.Height -= nearSize.Height;
                        layoutRect.Y += nearSize.Height;
                        controlRect.Height -= nearSize.Height;
                        controlRect.Y += nearSize.Height;
                    }

                    _nearScroller.Layout(context);
                }
                else
                {
                    _nearScroller.Visible = false;
                }

                // Work out the maximum scroll offset needed to show all of the filler
                var maxOffset = Orientation == Orientation.Horizontal
                    ? fillerSize.Width - layoutRect.Width
                    : fillerSize.Height - layoutRect.Height;

                // We only need the far scroller if we are not at the right scroll position
                if (_scrollOffset < maxOffset)
                {
                    _farScroller.Visible = true;

                    // Find size requirements of the near scroller
                    Size farSize = _nearScroller.GetPreferredSize(context);

                    // Find layout position of the far scroller
                    if (Orientation == Orientation.Horizontal)
                    {
                        context.DisplayRectangle = layoutRect with { X = layoutRect.Right - farSize.Width, Width = farSize.Width };
                        layoutRect.Width -= farSize.Width;
                        controlRect.Width -= farSize.Width;
                    }
                    else
                    {
                        context.DisplayRectangle = layoutRect with { Y = layoutRect.Bottom - farSize.Height, Height = farSize.Height };
                        layoutRect.Height -= farSize.Height;
                        controlRect.Height -= farSize.Height;
                    }

                    _farScroller.Layout(context);
                }
                else
                {
                    _farScroller.Visible = false;
                }

                // Calculate the maximum offset again with all scrollers positioned
                if (Orientation == Orientation.Horizontal)
                {
                    maxOffset = fillerSize.Width - layoutRect.Width;
                }
                else
                {
                    maxOffset = fillerSize.Height - layoutRect.Height;
                }

                // Limit check the current offset
                _scrollOffset = Math.Min(_scrollOffset, maxOffset);

                // Filler rectangle is used for clipping
                _viewClipRect = controlRect;

                // Apply the offset to the display of the view filler
                ViewLayoutControl.LayoutOffset = Orientation == Orientation.Horizontal
                    ? new Point(-_scrollOffset, 0)
                    : new Point(0, -_scrollOffset);

                // Position the filler in the remaining space
                context.DisplayRectangle = layoutRect;
                ViewLayoutControl.GetPreferredSize(context);
                ViewLayoutControl.Layout(context);
            }

            // Put back the original display value now we have finished
            context.DisplayRectangle = ClientRectangle;

            // If we are the scroller for the tab headers
            if (_ribbon.InKeyboardMode 
                && (_viewFiller is ViewLayoutRibbonTabs layoutTabs)
                )
            {
                // If we have a selected tab, then ensure it is visible
                if (_ribbon.SelectedTab != null)
                {
                    // Cast to correct type
                    ViewBase viewTab = layoutTabs.GetViewForRibbonTab(_ribbon.SelectedTab)!;

                    // If a scroll change is required to bring it into view
                    if (ScrollIntoView(viewTab.ClientRectangle, false))
                    {
                        // Call ourself again to take change into account
                        Layout(context);
                    }
                }
            }
        }
        #endregion

        #region Paint
        /// <summary>
        /// Perform a render of the elements.
        /// </summary>
        /// <param name="context">Rendering context.</param>
        public override void Render([DisallowNull] RenderContext context)
        {
            Debug.Assert(context != null);

            // Ask each child to render in turn
            foreach (ViewBase child in this)
            {
                // Only render visible children
                if (child.Visible)
                {
                    // We need to clip the filler to ensure it does not draw outside its client area
                    if (child == _viewFiller)
                    {
                        // New clipping region is at most our own client size
                        using var combineRegion = new Region(_viewClipRect);
                        // Remember the current clipping region
                        Region clipRegion = context?.Graphics.Clip.Clone()!;

                        // Reduce clipping region down by the existing clipping region
                        combineRegion.Intersect(clipRegion);

                        // Use new region that restricts drawing to our client size only
                        context!.Graphics.Clip = combineRegion;

                        child.Render(context);

                        // Put clipping region back to original setting
                        context.Graphics.Clip = clipRegion;
                    }
                    else
                    {
                        child.Render(context!);
                    }
                }
            }
        }
        #endregion

        #region Implementation
        // Removed because of this
        // https://github.com/Krypton-Suite/Standard-Toolkit/issues/372
        //private void OnChildWndProcHitTest(object sender, ViewControlHitTestArgs e)
        //{
        //    if (_ribbonTabs?.GetViewForSpare != null)
        //    {
        //        if (_ribbonTabs.GetViewForSpare.ClientRectangle.Contains(e.Point))
        //        {
        //            e.Cancel = false;
        //            e.Result = (IntPtr)PI.HT.TRANSPARENT;
        //        }
        //    }
        //}

        private bool ScrollIntoView(Rectangle rect, bool paint)
        {
            // If the item does not fully it into the clipping (visible rect)
            if ((rect.Right > _viewClipRect.Right) ||
                (rect.Left < _viewClipRect.Left))
            {
                // If off the right hand side of the area
                if (rect.Right > _viewClipRect.Right)
                {
                    _scrollOffset += rect.Right - _viewClipRect.Right + (SCROLL_GAP * 2);
                }

                // If off the left hand side of the area
                if (rect.Left < _viewClipRect.Left)
                {
                    _scrollOffset -= _viewClipRect.Left - rect.Left + SCROLL_GAP;
                }

                // Request a layout with new scroll settings
                if (paint)
                {
                    _needPaintDelegate(this, new NeedLayoutEventArgs(true));
                }

                // A change was made to the scroll offset
                return true;
            }

            return false;
        }

        private VisualOrientation NearOrientation
        {
            get
            {
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        return VisualOrientation.Left;

                    case Orientation.Vertical:
                        return VisualOrientation.Top;

                    default:
    // Should never happen!
                        Debug.Assert(false);
                        DebugTools.NotImplemented(Orientation.ToString());
                        return VisualOrientation.Left;
                }
            }
        }

        private VisualOrientation FarOrientation
        {
            get
            {
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        return VisualOrientation.Right;

                    case Orientation.Vertical:
                        return VisualOrientation.Bottom;

                    default:
    // Should never happen!
                        Debug.Assert(false);
                        DebugTools.NotImplemented(Orientation.ToString());
                        return VisualOrientation.Right;
                }
            }
        }

        private void OnNearClick(object? sender, EventArgs e)
        {
            // Scroll left/up
            _scrollOffset -= _scrollSpeed;

            // Request a layout with new scroll settings
            _needPaintDelegate(this, new NeedLayoutEventArgs(true));
        }

        private void OnFarClick(object? sender, EventArgs e)
        {
            // Scroll down/right
            _scrollOffset += _scrollSpeed;

            // Request a layout with new scroll settings
            _needPaintDelegate(this, new NeedLayoutEventArgs(true));
        }

        private void OnViewControlPaintBackground(object? sender, PaintEventArgs e) => PaintBackground?.Invoke(sender, e);
        #endregion
    }
}
