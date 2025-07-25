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

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBeProtected.Global

// ReSharper disable EventNeverSubscribedTo.Global
// ReSharper disable RedundantNullableFlowAttribute
namespace Krypton.Docking
{
    /// <summary>
    /// Manages a hierarchy of docking elements to provide docking windows functionality.
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KryptonDockingManager), "ToolboxBitmaps.KryptonDockingManager.bmp")]
    [DefaultEvent(nameof(PageCloseRequest))]
    [DefaultProperty(nameof(Strings))]
    [DesignerCategory("code")]
    [Description("Docking management component.")]
    public class KryptonDockingManager : DockingElementOpenCollection
    {
        #region Events
        /// <summary>
        /// Occurs when the user requests a page be closed.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when the user requests a page be closed.")]
        public event EventHandler<CloseRequestEventArgs>? PageCloseRequest;

        /// <summary>
        /// Occurs when the user requests a page become docked.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when the user requests a page become docked.")]
        public event EventHandler<CancelUniqueNameEventArgs>? PageDockedRequest;

        /// <summary>
        /// Occurs when the user requests a page become auto hidden.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when the user requests a page become auto hidden.")]
        public event EventHandler<CancelUniqueNameEventArgs>? PageAutoHiddenRequest;

        /// <summary>
        /// Occurs when the user requests a page become floating.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when the user requests a page become floating.")]
        public event EventHandler<CancelUniqueNameEventArgs>? PageFloatingRequest;

        /// <summary>
        /// Occurs when the user requests a page become workspace tabbed.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when the user requests a page become workspace tabbed.")]
        public event EventHandler<CancelUniqueNameEventArgs>? PageWorkspaceRequest;

        /// <summary>
        /// Occurs when the user requests a page become navigator tabbed.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when the user requests a page become navigator tabbed.")]
        public event EventHandler<CancelUniqueNameEventArgs>? PageNavigatorRequest;

        /// <summary>
        /// Occurs when a docking context menu is about to be shown for a page.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when a docking context menu is about to be shown for a page.")]
        public event EventHandler<ContextPageEventArgs>? ShowPageContextMenu;

        /// <summary>
        /// Occurs when a dockable workspace context menu is about to be shown for a page.
        /// </summary>
        [Category("User Request")]
        [Description("Occurs when a dockable workspace context menu is about to be shown for a page.")]
        public event EventHandler<ContextPageEventArgs>? ShowWorkspacePageContextMenu;

        /// <summary>
        /// Occurs when global docking configuration information is saving.
        /// </summary>
        [Category("Persistence")]
        [Description("Occurs when globaldocking configuration information is saving.")]
        public event EventHandler<DockGlobalSavingEventArgs>? GlobalSaving;

        /// <summary>
        /// Occurs when global docking configuration information is loading.
        /// </summary>
        [Category("Persistence")]
        [Description("Occurs when global docking configuration information is loading.")]
        public event EventHandler<DockGlobalLoadingEventArgs>? GlobalLoading;

        /// <summary>
        /// Occurs when page docking configuration information is saving.
        /// </summary>
        [Category("Persistence")]
        [Description("Occurs when page docking configuration information is saving.")]
        public event EventHandler<DockPageSavingEventArgs>? PageSaving;

        /// <summary>
        /// Occurs when page docking configuration information is loading.
        /// </summary>
        [Category("Persistence")]
        [Description("Occurs when page docking configuration information is loading.")]
        public event EventHandler<DockPageLoadingEventArgs>? PageLoading;

        /// <summary>
        /// Occurs when docking configuration information is loaded and existing pages have become orphaned because they are not used in the incoming configuration.
        /// </summary>
        [Category("Persistence")]
        [Description("Occurs when docking configuration information is loaded and existing pages have become orphaned because they are not used in the incoming configuration.")]
        public event EventHandler<PagesEventArgs>? OrphanedPages;

        /// <summary>
        /// Occurs when docking configuration information is loading and a page needs creating to match incoming unique name.
        /// </summary>
        [Category("Persistence")]
        [Description("Occurs when docking configuration information is loading and a page needs creating to match incoming unique name.")]
        public event EventHandler<RecreateLoadingPageEventArgs>? RecreateLoadingPage;

        /// <summary>
        /// Occurs when a separator is used to resize an auto hidden dockspace.
        /// </summary>
        [Category("Control Resizing")]
        [Description("Occurs when a separator is used to resize an auto hidden dockspace.")]
        public event EventHandler<AutoHiddenSeparatorResizeEventArgs>? AutoHiddenSeparatorResize;

        /// <summary>
        /// Occurs when a separator is used to resize a docked dockspace.
        /// </summary>
        [Category("Control Resizing")]
        [Description("Occurs when a separator is used to resize a docked dockspace.")]
        public event EventHandler<DockspaceSeparatorResizeEventArgs>? DockspaceSeparatorResize;

        /// <summary>
        /// Occurs when a new auto hidden group is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new auto hidden group is being added.")]
        public event EventHandler<AutoHiddenGroupEventArgs>? AutoHiddenGroupAdding;

        /// <summary>
        /// Occurs when an existing auto hidden group is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing auto hidden group is being removed.")]
        public event EventHandler<AutoHiddenGroupEventArgs>? AutoHiddenGroupRemoved;

        /// <summary>
        /// Occurs when a new panel for hosting auto hidden groups is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new panel for hosting auto hidden groups is being added.")]
        public event EventHandler<AutoHiddenGroupPanelEventArgs>? AutoHiddenGroupPanelAdding;

        /// <summary>
        /// Occurs when an existing panel for hosting auto hidden groups is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing panel for hosting auto hidden groups is being removed.")]
        public event EventHandler<AutoHiddenGroupPanelEventArgs>? AutoHiddenGroupPanelRemoved;

        /// <summary>
        /// Occurs when a new dockable workspace control is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new dockable workspace control is being addd.")]
        public event EventHandler<DockableWorkspaceEventArgs>? DockableWorkspaceAdded;

        /// <summary>
        /// Occurs when an existing dockable workspace control is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing dockable workspace control is being removed.")]
        public event EventHandler<DockableWorkspaceEventArgs>? DockableWorkspaceRemoved;

        /// <summary>
        /// Occurs when a new dockable navigator control is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new dockable navigator control is being addd.")]
        public event EventHandler<DockableNavigatorEventArgs>? DockableNavigatorAdded;

        /// <summary>
        /// Occurs when an existing dockable navigator control is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing dockable navigator control is being removed.")]
        public event EventHandler<DockableNavigatorEventArgs>? DockableNavigatorRemoved;

        /// <summary>
        /// Occurs when a new dockable workspace control cell is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new dockable workspace control cell is being added.")]
        public event EventHandler<DockableWorkspaceCellEventArgs>? DockableWorkspaceCellAdding;

        /// <summary>
        /// Occurs when an existing dockable workspace control cell is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing dockable workspace control cell is being removed.")]
        public event EventHandler<DockableWorkspaceCellEventArgs>? DockableWorkspaceCellRemoved;

        /// <summary>
        /// Occurs when a new dockspace control is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new dockspace control is being added.")]
        public event EventHandler<DockspaceEventArgs>? DockspaceAdding;

        /// <summary>
        /// Occurs when an existing dockspace control is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing dockspace control is being removed.")]
        public event EventHandler<DockspaceEventArgs>? DockspaceRemoved;

        /// <summary>
        /// Occurs when a new dockspace control cell is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new dockspace control cell is being added.")]
        public event EventHandler<DockspaceCellEventArgs>? DockspaceCellAdding;

        /// <summary>
        /// Occurs when an existing dockspace control cell is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing dockspace control cell is being removed.")]
        public event EventHandler<DockspaceCellEventArgs>? DockspaceCellRemoved;

        /// <summary>
        /// Occurs when a new dockspace separator control is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new dockspace separator control is being added.")]
        public event EventHandler<DockspaceSeparatorEventArgs>? DockspaceSeparatorAdding;

        /// <summary>
        /// Occurs when an existing dockspace separator control is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing dockspace separator control is being removed.")]
        public event EventHandler<DockspaceSeparatorEventArgs>? DockspaceSeparatorRemoved;

        /// <summary>
        /// Occurs when a new floatspace control is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new floatspace control is being added.")]
        public event EventHandler<FloatspaceEventArgs>? FloatspaceAdding;

        /// <summary>
        /// Occurs when an existing floatspace control is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing floatspace control is being removed.")]
        public event EventHandler<FloatspaceEventArgs>? FloatspaceRemoved;

        /// <summary>
        /// Occurs when a new floatspace control cell is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new floatspace control cell is being added.")]
        public event EventHandler<FloatspaceCellEventArgs>? FloatspaceCellAdding;

        /// <summary>
        /// Occurs when an existing floatspace control cell is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing floatspace control cell is being removed.")]
        public event EventHandler<FloatspaceCellEventArgs>? FloatspaceCellRemoved;

        /// <summary>
        /// Occurs when a new floating window is being added.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when a new floating window is being added.")]
        public event EventHandler<FloatingWindowEventArgs>? FloatingWindowAdding;

        /// <summary>
        /// Occurs when an existing floating window is being removed.
        /// </summary>
        [Category("Control Adding/Removed")]
        [Description("Occurs when an existing floating window is being removed.")]
        public event EventHandler<FloatingWindowEventArgs>? FloatingWindowRemoved;

        /// <summary>
        /// Occurs when an auto hidden page showing state changes.
        /// </summary>
        [Category("State Changed")]
        [Description("Occurs when an auto hidden page showing state changes.")]
        public event EventHandler<AutoHiddenShowingStateEventArgs>? AutoHiddenShowingStateChanged;

        /// <summary>
        /// Occurs when a drag drop operation has ended with success.
        /// </summary>
        [Category(@"Docking")]
        [Description("Occurs when a drag drop operation has ended with success.")]
        public event EventHandler? DoDragDropEnd;

        /// <summary>
        /// Occurs when a drag drop operation has been quit.
        /// </summary>
        [Category(@"Docking")]
        [Description("Occurs when a drag drop operation has been quit.")]
        public event EventHandler? DoDragDropQuit;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonDockingManager class.
        /// </summary>
        public KryptonDockingManager()
            : this(nameof(DockingManager))
        {
        }

        /// <summary>
        /// Initialize a new instance of the KryptonDockingManager class.
        /// </summary>
        /// <param name="name">Initial name of the element.</param>
        public KryptonDockingManager(string name)
            : base(name)
        {
            InitializeManager();
        }
        #endregion    

        #region Public
        /// <summary>
        /// Manage auto hidden/docked capabilities for provided control.
        /// </summary>
        /// <param name="c">Reference to control instance.</param>
        /// <returns>KryptonDockingControl instance created.</returns>
        public KryptonDockingControl ManageControl(Control c) => ManageControl(nameof(Control), c);

        /// <summary>
        /// Manage auto hidden/docked capabilities for provided control.
        /// </summary>
        /// <param name="c">Reference to control instance.</param>
        /// <param name="navigator">Reference to docking navigator that is inside the control.</param>
        /// <returns>KryptonDockingControl instance created.</returns>
        public KryptonDockingControl ManageControl(Control c, KryptonDockingNavigator navigator) => ManageControl(nameof(Control), c, navigator);

        /// <summary>
        /// Manage auto hidden/docked capabilities for provided control.
        /// </summary>
        /// <param name="c">Reference to control instance.</param>
        /// <param name="workspace">Reference to docking workspace that is inside the control.</param>
        /// <returns>KryptonDockingControl instance created.</returns>
        public KryptonDockingControl ManageControl(Control c, KryptonDockingWorkspace workspace) => ManageControl(nameof(Control), c, workspace);

        /// <summary>
        /// Manage auto hidden/docked capabilities for provided control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="c">Reference to control instance.</param>
        /// <returns>KryptonDockingControl instance created.</returns>
        public KryptonDockingControl ManageControl(string name, Control c)
        {
            var dockingControl = new KryptonDockingControl(name, c);
            Add(dockingControl);
            return dockingControl;
        }

        /// <summary>
        /// Manage auto hidden/docked capabilities for provided control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="c">Reference to control instance.</param>
        /// <param name="navigator">Reference to docking navigator that is inside the control.</param>
        /// <returns>KryptonDockingControl instance created.</returns>
        public KryptonDockingControl ManageControl(string name, Control c, KryptonDockingNavigator navigator)
        {
            var dockingControl = new KryptonDockingControl(name, c, navigator);
            Add(dockingControl);
            return dockingControl;
        }

        /// <summary>
        /// Manage auto hidden/docked capabilities for provided control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="c">Reference to control instance.</param>
        /// <param name="workspace">Reference to docking workspace that is inside the control.</param>
        /// <returns>KryptonDockingControl instance created.</returns>
        public KryptonDockingControl ManageControl(string name, Control c, KryptonDockingWorkspace workspace)
        {
            var dockingControl = new KryptonDockingControl(name, c, workspace);
            Add(dockingControl);
            return dockingControl;
        }

        /// <summary>
        /// Manage floating windows capability for provided form.
        /// </summary>
        /// <param name="f">Reference to form.</param>
        /// <returns>KryptonDockingFloating instance created.</returns>
        public KryptonDockingFloating ManageFloating(Form f) => ManageFloating(@"Floating", f);

        /// <summary>
        /// Manage floating windows capability for provided form.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="f">Reference to form.</param>
        /// <returns>KryptonDockingFloating instance created.</returns>
        public KryptonDockingFloating ManageFloating(string name, Form f)
        {
            var dockingFloating = new KryptonDockingFloating(name, f);
            Add(dockingFloating);
            return dockingFloating;
        }

        /// <summary>
        /// Manage docking capability for provided dockable workspace control.
        /// </summary>
        /// <param name="w">Reference to dockable workspace.</param>
        /// <returns>KryptonDockingWorkspace instance created.</returns>
        public KryptonDockingWorkspace ManageWorkspace(KryptonDockableWorkspace w) => ManageWorkspace(nameof(Workspace), @"Filler", w);

        /// <summary>
        /// Manage docking capability for provided dockable workspace control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="w">Reference to dockable workspace.</param>
        /// <returns>KryptonDockingWorkspace instance created.</returns>
        public KryptonDockingWorkspace ManageWorkspace(string name, KryptonDockableWorkspace w) => ManageWorkspace(name, @"Filler", w);

        /// <summary>
        /// Manage docking capability for provided dockable workspace control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="storeName">Store name for docking element.</param>
        /// <param name="w">Reference to dockable workspace.</param>
        /// <returns>KryptonDockingWorkspace instance created.</returns>
        public KryptonDockingWorkspace ManageWorkspace(string name, string storeName, KryptonDockableWorkspace w)
        {
            var dockingWorkspace = new KryptonDockingWorkspace(name, storeName, w);
            Add(dockingWorkspace);
            return dockingWorkspace;
        }

        /// <summary>
        /// Manage docking capability for provided dockable navigator control.
        /// </summary>
        /// <param name="n">Reference to dockable navigator.</param>
        /// <returns>KryptonDockingNavigator instance created.</returns>
        public KryptonDockingNavigator ManageNavigator(KryptonDockableNavigator n) => ManageNavigator(nameof(Navigator), @"Filler", n);

        /// <summary>
        /// Manage docking capability for provided dockable navigator control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="n">Reference to dockable navigator.</param>
        /// <returns>KryptonDockingNavigator instance created.</returns>
        public KryptonDockingNavigator ManageNavigator(string name, KryptonDockableNavigator n) => ManageNavigator(name, @"Filler", n);

        /// <summary>
        /// Manage docking capability for provided dockable navigator control.
        /// </summary>
        /// <param name="name">Name for new docking element.</param>
        /// <param name="storeName">Store name for docking element.</param>
        /// <param name="n">Reference to dockable navigator.</param>
        /// <returns>KryptonDockingNavigator instance created.</returns>
        public KryptonDockingNavigator ManageNavigator(string name, string storeName, KryptonDockableNavigator n)
        {
            var dockingNavigator = new KryptonDockingNavigator(name, storeName, n);
            Add(dockingNavigator);
            return dockingNavigator;
        }

        /// <summary>
        /// Gets access to the set of display strings required of the docking hierarchy display elements.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DockingManagerStrings Strings { get; private set; }

        /// <summary>
        /// Resolve the provided path.
        /// </summary>
        /// <param name="path">Comma separated list of names to resolve.</param>
        /// <returns>IDockingElement reference if path was resolved with success; otherwise null.</returns>
        public override IDockingElement? ResolvePath([DisallowNull] string path)
        {
            // Cannot resolve a null reference
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            // Path names cannot be zero length
            if (path.Length == 0)
            {
                throw new ArgumentException(@"Needs Comma separated list of names to resolve.", nameof(path));
            }

            // Give each child a chance to resolve the entire path
            return this.Select(child => child.ResolvePath(path)).FirstOrDefault(static ret => ret != null);
        }

        /// <summary>
        /// Show all display elements of the provided page.
        /// </summary>
        /// <param name="page">Reference to page that should be shown.</param>
        public void ShowPage([DisallowNull] KryptonPage page)
        {
            // Cannot show a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            ShowPages(new[] { page.UniqueName });
        }

        /// <summary>
        /// Show all display elements of the provided page.
        /// </summary>
        /// <param name="uniqueName">Unique name of the page that should be shown.</param>
        public void ShowPage([DisallowNull] string uniqueName)
        {
            // Cannot show a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            ShowPages(new[] { uniqueName });
        }

        /// <summary>
        /// Show all display elements of the provided pages.
        /// </summary>
        /// <param name="pages">Array of references to pages that should be shown.</param>
        public void ShowPages([DisallowNull] KryptonPage[] pages)
        {
            // Cannot show a null reference
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            if (pages.Length > 0)
            {
                var uniqueNames = new string[pages.Length];
                for (var i = 0; i < uniqueNames.Length; i++)
                {
                    // Cannot show a null page reference
                    if (pages[i] == null)
                    {
                        throw new ArgumentException(@"pages array contains a null page reference", nameof(pages));
                    }

                    uniqueNames[i] = pages[i].UniqueName;
                }

                ShowPages(uniqueNames);
            }
        }

        /// <summary>
        /// Show all display elements of the provided pages.
        /// </summary>
        /// <param name="uniqueNames">Array of unique names of the pages that should be shown.</param>
        public void ShowPages([DisallowNull] string[] uniqueNames)
        {
            // Cannot show a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            if (uniqueNames.Length > 0)
            {
                // Cannot show a null or zero length unique name
                foreach (var uniqueName in uniqueNames)
                {
                    if (uniqueName == null)
                    {
                        throw new ArgumentNullException(nameof(uniqueNames), @"uniqueNames array contains a null string reference");
                    }

                    if (uniqueName.Length == 0)
                    {
                        throw new ArgumentException(@"uniqueNames array contains a zero length string", nameof(uniqueNames));
                    }
                }

                using var update = new DockingMultiUpdate(this);
                PropogateAction(DockingPropogateAction.ShowPages, uniqueNames);
            }
        }

        /// <summary>
        /// Show all display elements of all pages.
        /// </summary>
        public void ShowAllPages()
        {
            using var update = new DockingMultiUpdate(this);
            PropogateAction(DockingPropogateAction.ShowAllPages, null as string[]);
        }

        /// <summary>
        /// Hide all display elements of the provided page.
        /// </summary>
        /// <param name="page">Reference to page that should be hidden.</param>
        public void HidePage([DisallowNull] KryptonPage page)
        {
            // Cannot hide a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            HidePages(new[] { page.UniqueName });
        }

        /// <summary>
        /// Hide all display elements of the provided page.
        /// </summary>
        /// <param name="uniqueName">Unique name of the page that should be hidden.</param>
        public void HidePage([DisallowNull] string uniqueName)
        {
            // Cannot hide a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            if (uniqueName.Length > 0)
            {
                HidePages(new[] { uniqueName });
            }
        }

        /// <summary>
        /// Hide all display elements of the provided pages.
        /// </summary>
        /// <param name="pages">Array of references to pages that should be hidden.</param>
        public void HidePages([DisallowNull] KryptonPage[] pages)
        {
            // Cannot hide a null reference
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            if (pages.Length > 0)
            {
                // Cannot hide a null page reference
                var uniqueNames = new string[pages.Length];
                for (var i = 0; i < uniqueNames.Length; i++)
                {
                    // Cannot show a null page reference
                    if (pages[i] == null)
                    {
                        throw new ArgumentException(@"pages array contains a null page reference", nameof(pages));
                    }

                    uniqueNames[i] = pages[i].UniqueName;
                }

                HidePages(uniqueNames);
            }
        }

        /// <summary>
        /// Hide all display elements of the provided pages.
        /// </summary>
        /// <param name="uniqueNames">Array of unique names of the pages that should be hidden.</param>
        public void HidePages([DisallowNull] string[] uniqueNames)
        {
            // Cannot hide a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            if (uniqueNames.Length > 0)
            {
                // Cannot hide a null or zero length unique name
                foreach (var uniqueName in uniqueNames)
                {
                    if (uniqueName == null)
                    {
                        throw new ArgumentNullException(nameof(uniqueNames), @"uniqueNames array contains a null string reference");
                    }

                    if (uniqueName.Length == 0)
                    {
                        throw new ArgumentException(@"uniqueNames array contains a zero length string", nameof(uniqueNames));
                    }
                }

                using var update = new DockingMultiUpdate(this);
                PropogateAction(DockingPropogateAction.HidePages, uniqueNames);
            }
        }

        /// <summary>
        /// Hide all display elements of all pages.
        /// </summary>
        public void HideAllPages()
        {
            using var update = new DockingMultiUpdate(this);
            PropogateAction(DockingPropogateAction.HideAllPages, null as string[]);
        }

        /// <summary>
        /// Determines if the provided page is present and showing.
        /// </summary>
        /// <param name="page">Reference to page.</param>
        /// <returns>True if the page is present and showing; otherwise false.</returns>
        public bool IsPageShowing([DisallowNull] KryptonPage page)
        {
            // Cannot search for a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            return IsPageShowing(page.UniqueName);
        }

        /// <summary>
        /// Determines if the provided page is present and showing.
        /// </summary>
        /// <param name="uniqueName">Unique name of page..</param>
        /// <returns>True if the page is present and showing; otherwise false.</returns>
        public bool IsPageShowing([DisallowNull] string uniqueName)
        {
            // Cannot search for a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Search docking hierarchy for the requested information
            var contained = PropogateBoolState(DockingPropogateBoolState.IsPageShowing, uniqueName);

            // Page contained and showing only if we get a definite True returned
            return (contained.HasValue && contained.Value);
        }

        /// <summary>
        /// Remove the referenced page.
        /// </summary>
        /// <param name="page">Reference to page that should be removed.</param>
        /// <param name="disposePage">Should the page be disposed when removed.</param>
        public void RemovePage([DisallowNull] KryptonPage page, bool disposePage)
        {
            // Cannot remove a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            RemovePages(new[] { page.UniqueName }, disposePage);
        }

        /// <summary>
        /// Remove the named page.
        /// </summary>
        /// <param name="uniqueName">Unique name of the page that should be removed.</param>
        /// <param name="disposePage">Should the page be disposed when removed.</param>
        public void RemovePage([DisallowNull] string uniqueName, bool disposePage)
        {
            // Cannot remove a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            RemovePages(new[] { uniqueName }, disposePage);
        }

        /// <summary>
        /// Remove the referenced pages.
        /// </summary>
        /// <param name="pages">Array of references to pages that should be removed.</param>
        /// <param name="disposePage">Should the page be disposed when removed.</param>
        public void RemovePages([DisallowNull] KryptonPage[] pages, bool disposePage)
        {
            // Cannot remove a null reference
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            if (pages.Length > 0)
            {
                // Cannot remove a null page reference
                var uniqueNames = new string[pages.Length];
                for (var i = 0; i < uniqueNames.Length; i++)
                {
                    // Cannot show a null page reference
                    if (pages[i] == null)
                    {
                        throw new ArgumentException(@"pages array contains a null page reference", nameof(pages));
                    }

                    uniqueNames[i] = pages[i].UniqueName;
                }

                RemovePages(uniqueNames, disposePage);
            }
        }

        /// <summary>
        /// Remove the named pages.
        /// </summary>
        /// <param name="uniqueNames">Array of unique names of the pages that should be removed.</param>
        /// <param name="disposePage">Should the page be disposed when removed.</param>
        public void RemovePages([DisallowNull] string[] uniqueNames, bool disposePage)
        {
            // Cannot remove a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            if (uniqueNames.Length > 0)
            {
                // Cannot remove a null or zero length unique name
                foreach (var uniqueName in uniqueNames)
                {
                    if (uniqueName == null)
                    {
                        throw new ArgumentNullException(nameof(uniqueNames), @"uniqueNames array contains a null string reference");
                    }

                    if (uniqueName.Length == 0)
                    {
                        throw new ArgumentException(@"uniqueNames array contains a zero length string", nameof(uniqueNames));
                    }
                }

                // Remove page details from all parts of the hierarchy
                using var update = new DockingMultiUpdate(this);
                PropogateAction(disposePage ? DockingPropogateAction.RemoveAndDisposePages : DockingPropogateAction.RemovePages, uniqueNames);
            }
        }

        /// <summary>
        /// Remove all pages.
        /// </summary>
        /// <param name="disposePage">Should the page be disposed when removed.</param>
        public void RemoveAllPages(bool disposePage)
        {
            // Remove all details about all pages from all parts of the hierarchy
            using var update = new DockingMultiUpdate(this);
            PropogateAction(disposePage ? DockingPropogateAction.RemoveAndDisposeAllPages : DockingPropogateAction.RemoveAllPages, null as string[]);
        }

        /// <summary>
        /// Determines if the provided page is present in the docking hierarchy.
        /// </summary>
        /// <param name="page">Reference to page that should be found.</param>
        /// <returns>True if the page is present; otherwise false.</returns>
        public bool ContainsPage([DisallowNull] KryptonPage page)
        {
            // Cannot find a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            return ContainsPage(page.UniqueName);
        }

        /// <summary>
        /// Determines if the provided page is present in the docking hierarchy.
        /// </summary>
        /// <param name="uniqueName">Unique name of page that should be found.</param>
        /// <returns>True if the page is present; otherwise false.</returns>
        public bool ContainsPage([DisallowNull] string uniqueName)
        {
            // Cannot find a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Search docking hierarchy for the requested information
            var contained = PropogateBoolState(DockingPropogateBoolState.ContainsPage, uniqueName);

            // Page contained only if we get a definite True returned
            return (contained.HasValue && contained.Value);
        }

        /// <summary>
        /// Find the page reference that has the requested unique name.
        /// </summary>
        /// <param name="uniqueName">Unique name of page that should be found.</param>
        /// <returns>Reference to page if the named page exists in the docking hierarchy; otherwise false.</returns>
        public KryptonPage? PageForUniqueName([DisallowNull] string uniqueName)
        {
            // Cannot find a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Search docking hierarchy for the requested page
            return PropogatePageState(DockingPropogatePageState.PageForUniqueName, uniqueName);
        }

        /// <summary>
        /// Replace named page with a store placeholder so it can be restored at a later time.
        /// </summary>
        /// <param name="page">Reference to page that should be replaced.</param>
        public void StorePage([DisallowNull] KryptonPage page)
        {
            // Cannot replace a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            StorePages(new[] { page.UniqueName });
        }

        /// <summary>
        /// Replace page with a store placeholder so it can be restored at a later time.
        /// </summary>
        /// <param name="uniqueName">Unique name of the page that should be replaced.</param>
        public void StorePage([DisallowNull] string uniqueName)
        {
            // Cannot replace a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            StorePages(new[] { uniqueName });
        }

        /// <summary>
        /// Replace named pages with store placeholders so they can be restored at a later time.
        /// </summary>
        /// <param name="pages">Array of references to pages that should be replaced.</param>
        public void StorePages([DisallowNull] KryptonPage[] pages)
        {
            // Cannot replace a null reference
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            if (pages.Length > 0)
            {
                // Cannot replace a null page reference
                var uniqueNames = new string[pages.Length];
                for (var i = 0; i < uniqueNames.Length; i++)
                {
                    // Cannot show a null page reference
                    if (pages[i] == null)
                    {
                        throw new ArgumentException(@"pages array contains a null page reference", nameof(pages));
                    }

                    uniqueNames[i] = pages[i].UniqueName;
                }

                StorePages(uniqueNames);
            }
        }

        /// <summary>
        /// Replace pages with store placeholders so they can be restored at a later time.
        /// </summary>
        /// <param name="uniqueNames">Array of unique names of the pages that should be replaced.</param>
        public void StorePages([DisallowNull] string[] uniqueNames)
        {
            // Cannot replace a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            if (uniqueNames.Length > 0)
            {
                // Cannot replace a null or zero length unique name
                foreach (var uniqueName in uniqueNames)
                {
                    if (uniqueName == null)
                    {
                        throw new ArgumentNullException(nameof(uniqueNames), @"uniqueNames array contains a null string reference");
                    }

                    if (uniqueName.Length == 0)
                    {
                        throw new ArgumentException(@"uniqueNames array contains a zero length string", nameof(uniqueNames));
                    }
                }

                using var update = new DockingMultiUpdate(this);
                PropogateAction(DockingPropogateAction.StorePages, uniqueNames);
            }
        }

        /// <summary>
        /// Replace all pages with store placeholders so they can be restored at a later time.
        /// </summary>
        public void StoreAllPages()
        {
            using var update = new DockingMultiUpdate(this);
            PropogateAction(DockingPropogateAction.StoreAllPages, null as string[]);
        }

        /// <summary>
        /// Clear away any store pages for the provided pages.
        /// </summary>
        /// <param name="pages">Array of references to pages that should be shown.</param>
        public void ClearStoredPages([DisallowNull] KryptonPage[] pages)
        {
            // Cannot show a null reference
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            if (pages.Length > 0)
            {
                var uniqueNames = new string[pages.Length];
                for (var i = 0; i < uniqueNames.Length; i++)
                {
                    // Cannot show a null page reference
                    if (pages[i] == null)
                    {
                        throw new ArgumentException(@"pages array contains a null page reference", nameof(pages));
                    }

                    uniqueNames[i] = pages[i].UniqueName;
                }

                ClearStoredPages(uniqueNames);
            }
        }

        /// <summary>
        /// Clear away any store pages for the provided unique named pages.
        /// </summary>
        /// <param name="uniqueNames">Array of unique names of the pages that should have store pages removed.</param>
        public void ClearStoredPages([DisallowNull] string[] uniqueNames)
        {
            // Cannot clear a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            // Cannot clear an empty array
            if (uniqueNames.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(uniqueNames), @"array cannot be empty");
            }

            // Cannot clear a null or zero length unique name
            foreach (var uniqueName in uniqueNames)
            {
                if (uniqueName == null)
                {
                    throw new ArgumentNullException(nameof(uniqueNames), @"uniqueNames array contains a null string reference");
                }

                if (uniqueName.Length == 0)
                {
                    throw new ArgumentException(@"uniqueNames array contains a zero length string", nameof(uniqueNames));
                }
            }

            using var update = new DockingMultiUpdate(this);
            PropogateAction(DockingPropogateAction.ClearStoredPages, uniqueNames);
        }

        /// <summary>
        /// Cleat away all store pages.
        /// </summary>
        public void ClearAllStoredPages()
        {
            using var update = new DockingMultiUpdate(this);
            PropogateAction(DockingPropogateAction.ClearAllStoredPages, null as string[]);
        }

        /// <summary>
        /// Find the docking location of the provided page.
        /// </summary>
        /// <param name="page">Reference to page.</param>
        /// <returns>Enumeration value indicating docking location.</returns>
        public DockingLocation FindPageLocation([DisallowNull] KryptonPage? page)
        {
            // Cannot find a null reference
            return page == null
                ? throw new ArgumentNullException(nameof(page))
                : FindPageLocation(page.UniqueName);
        }

        /// <summary>
        /// Find the docking location of the named page.
        /// </summary>
        /// <param name="uniqueName">Unique name of the page.</param>
        /// <returns>Enumeration value indicating docking location.</returns>
        public override DockingLocation FindPageLocation([DisallowNull] string uniqueName)
        {
            // Cannot replace a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Search docking hierarchy for the requested page location
            return base.FindPageLocation(uniqueName);
        }

        /// <summary>
        /// Find the docking element that contains the provided page.
        /// </summary>
        /// <param name="page">Reference to page.</param>
        /// <returns>IDockingElement reference if page is found; otherwise null.</returns>
        public IDockingElement? FindPageElement([DisallowNull] KryptonPage page)
        {
            // Cannot find a null reference
            return page == null
                ? throw new ArgumentNullException(nameof(page))
                : FindPageElement(page.UniqueName);
        }

        /// <summary>
        /// Find the docking element that contains the named page.
        /// </summary>
        /// <param name="uniqueName">Unique name of the page.</param>
        /// <returns>IDockingElement reference if page is found; otherwise null.</returns>
        public override IDockingElement? FindPageElement([DisallowNull] string uniqueName)
        {
            // Cannot replace a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Search docking hierarchy for the docking element containing the page
            return base.FindPageElement(uniqueName);
        }

        /// <summary>
        /// Find the docking element that contains the location specific store page for the named page.
        /// </summary>
        /// <param name="location">Location to be searched.</param>
        /// <param name="page">Reference to page.</param>
        /// <returns>IDockingElement reference if store page is found; otherwise null.</returns>
        public IDockingElement? FindStorePageElement(DockingLocation location, [DisallowNull] KryptonPage page)
        {
            // Cannot find a null reference
            return page == null
                ? throw new ArgumentNullException(nameof(page))
                : FindStorePageElement(location, page.UniqueName);
        }

        /// <summary>
        /// Find the docking element that contains the location specific store page for the named page.
        /// </summary>
        /// <param name="location">Location to be searched.</param>
        /// <param name="uniqueName">Unique name of the page to be found.</param>
        /// <returns>IDockingElement reference if store page is found; otherwise null.</returns>
        public override IDockingElement? FindStorePageElement(DockingLocation location, [DisallowNull] string uniqueName)
        {
            // Cannot replace a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            return base.FindStorePageElement(location, uniqueName);
        }

        /// <summary>
        /// Find a floating docking element by searching the hierarchy.
        /// </summary>
        /// <param name="uniqueName">Named page for which a suitable floating element is required.</param>
        /// <returns>KryptonDockingFloating reference if found; otherwise false.</returns>
        public override KryptonDockingFloating? FindDockingFloating(string uniqueName)
        {
            // First preference is to find an existing store page inside a floating element
            if (FindStorePageElement(DockingLocation.Floating, uniqueName) is KryptonDockingFloating floating)
            {
                return floating;
            }

            // Failed, so use default processing
            return base.FindDockingFloating(uniqueName);
        }

        /// <summary>
        /// Find a edge docked element by searching the hierarchy.
        /// </summary>
        /// <param name="uniqueName">Named page for which a suitable docking edge element is required.</param>
        /// <returns>KryptonDockingEdgeDocked reference if found; otherwise false.</returns>
        public override KryptonDockingEdgeDocked? FindDockingEdgeDocked(string uniqueName)
        {
            // Try and find as an existing page inside the hierarchy
            var element = FindPageElement(uniqueName) as DockingElement;

            switch (element)
            {
                // If exists as a dockspace page...
                // Find the edge the dockspace is against and return the matching docked edge
                case KryptonDockingDockspace when element.GetParentType(typeof(KryptonDockingEdgeDocked)) is KryptonDockingEdgeDocked edge:
                    return edge;
                // If exists as a auto hidden group page...
                case KryptonDockingAutoHiddenGroup:
                    {
                        if (element.GetParentType(typeof(KryptonDockingEdgeAutoHidden)) is KryptonDockingEdgeAutoHidden edge)
                        {
                            // Finally we grab the auto hidden edge that is expected to be a sibling of the docked edge
                            if (edge[@"Docked"] is KryptonDockingEdgeDocked edgeDocked)
                            {
                                return edgeDocked;
                            }
                        }

                        break;
                    }
            }

            // First preference is to find an existing store page inside a dockspace element
            if (FindStorePageElement(DockingLocation.Docked, uniqueName) is KryptonDockingDockspace dockspace)
            {
                // Find the docked edge that the dockspace is inside
                if (dockspace.GetParentType(typeof(KryptonDockingEdgeDocked)) is KryptonDockingEdgeDocked edgeDocked)
                {
                    return edgeDocked;
                }
            }

            // Second preference is to find an existing store page inside a auto hidden group element
            if (FindStorePageElement(DockingLocation.AutoHidden, uniqueName) is KryptonDockingAutoHiddenGroup group)
            {
                // Navigate upwards to find the edge that this group is inside
                if (group.GetParentType(typeof(KryptonDockingEdge)) is KryptonDockingEdge edge)
                {
                    // Finally we grab the docked edge that is expected to be a sibling of the auto hidden edge
                    if (edge[@"Docked"] is KryptonDockingEdgeDocked edgeDocked)
                    {
                        return edgeDocked;
                    }
                }
            }

            // Failed, so use default processing
            return base.FindDockingEdgeDocked(uniqueName);
        }

        /// <summary>
        /// Find a edge auto hidden element by searching the hierarchy.
        /// </summary>
        /// <param name="uniqueName">Named page for which a suitable auto hidden edge element is required.</param>
        /// <returns>KryptonDockingEdgeAutoHidden reference if found; otherwise false.</returns>
        public override KryptonDockingEdgeAutoHidden? FindDockingEdgeAutoHidden(string uniqueName)
        {
            // Try and find as an existing page inside the hierarchy
            var element = FindPageElement(uniqueName) as DockingElement;

            switch (element)
            {
                // If exists as a dockspace page...
                case KryptonDockingDockspace:
                    {
                        if (element.GetParentType(typeof(KryptonDockingEdge)) is KryptonDockingEdge edge)
                        {
                            // Finally we grab the auto hidden edge that is expected to be a sibling of the docked edge
                            if (edge[@"AutoHidden"] is KryptonDockingEdgeAutoHidden edgeAutoHidden)
                            {
                                return edgeAutoHidden;
                            }
                        }

                        break;
                    }
                // If exists as a auto hidden group page...
                // Find the edge the dockspace is against and return the matching auto hidden edge
                case KryptonDockingAutoHiddenGroup when element.GetParentType(typeof(KryptonDockingEdgeAutoHidden)) is KryptonDockingEdgeAutoHidden edge:
                    return edge;
            }

            // Second preference is to find an existing store page inside an auto hidden group element
            if (FindStorePageElement(DockingLocation.AutoHidden, uniqueName) is KryptonDockingAutoHiddenGroup group)
            {
                // Find the auto hidden edge that the group is inside
                if (group.GetParentType(typeof(KryptonDockingEdgeAutoHidden)) is KryptonDockingEdgeAutoHidden edgeAutoHidden)
                {
                    return edgeAutoHidden;
                }
            }

            // Third preference is to find an existing store page inside a docked element
            if (FindStorePageElement(DockingLocation.Docked, uniqueName) is KryptonDockingDockspace dockspace)
            {
                // Navigate upwards to find the edge that this dockspace is inside
                if (dockspace.GetParentType(typeof(KryptonDockingEdge)) is KryptonDockingEdge edge)
                {
                    // Finally we grab the auto hidden edge that is expected to be a sibling of the docked edge
                    if (edge[@"AutoHidden"] is KryptonDockingEdgeAutoHidden edgeAutoHidden)
                    {
                        return edgeAutoHidden;
                    }
                }
            }

            // Failed, so use default processing
            return base.FindDockingEdgeAutoHidden(uniqueName);
        }

        /// <summary>
        /// Find a workspace element by searching the hierarchy.
        /// </summary>
        /// <param name="uniqueName">Named page for which a suitable workspace element is required.</param>
        /// <returns>KryptonDockingWorkspace reference if found; otherwise false.</returns>
        public override KryptonDockingWorkspace? FindDockingWorkspace(string uniqueName)
        {
            // First preference is to find an existing store page inside a workspace element
            if (FindStorePageElement(DockingLocation.Workspace, uniqueName) is KryptonDockingWorkspace workspace)
            {
                return workspace;
            }

            // Failed, so use default processing
            return base.FindDockingWorkspace(uniqueName);
        }

        /// <summary>
        /// Gets and sets the default request action to use for a close.
        /// </summary>
        [DefaultValue(typeof(DockingCloseRequest), "HidePage")]
        public DockingCloseRequest DefaultCloseRequest { get; set; }

        /// <summary>
        /// Perform the close request for a set of named pages.
        /// </summary>
        /// <param name="uniqueNames">Array of unique names that need action performed.</param>
        public virtual void CloseRequest([DisallowNull] IReadOnlyList<string> uniqueNames)
        {
            // Cannot action a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            // Cannot action an empty array
            if (uniqueNames.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(uniqueNames), @"array cannot be empty");
            }

            // Cannot action a null or zero length unique name
            foreach (var uniqueName in uniqueNames)
            {
                if (uniqueName == null)
                {
                    throw new ArgumentNullException(nameof(uniqueNames), @"uniqueNames array contains a null string reference");
                }

                if (uniqueName.Length == 0)
                {
                    throw new ArgumentException(@"uniqueNames array contains a zero length string", nameof(uniqueNames));
                }
            }

            using var update = new DockingMultiUpdate(this);
            foreach (var uniqueName in uniqueNames)
            {
                // Raise event that allows the action to be defined by handlers
                var e = new CloseRequestEventArgs(uniqueName, DefaultCloseRequest);
                OnPageCloseRequest(e);

                switch (e.CloseRequest)
                {
                    case DockingCloseRequest.None:
                        // Nothing to do!
                        break;

                    case DockingCloseRequest.RemovePage:
                    case DockingCloseRequest.RemovePageAndDispose:
                        PropogateAction(e.CloseRequest == DockingCloseRequest.RemovePageAndDispose ?
                                DockingPropogateAction.RemoveAndDisposePages :
                                DockingPropogateAction.RemovePages,
                            new[] { uniqueName });
                        break;

                    case DockingCloseRequest.HidePage:
                        PropogateAction(DockingPropogateAction.HidePages, new[] { uniqueName });
                        break;
                }
            }
        }

        /// <summary>
        /// Make the named page auto hidden.
        /// </summary>
        /// <param name="uniqueName">Unique name of page to become auto hidden.</param>
        public virtual void MakeAutoHiddenRequest([DisallowNull] string uniqueName)
        {
            // Cannot process a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // If the named page exists and is not already auto hidden
            if (ContainsPage(uniqueName) && (FindPageLocation(uniqueName) != DockingLocation.AutoHidden))
            {
                // If we can find an auto hidden edge element appropriate for the named page
                KryptonDockingEdgeAutoHidden? autoHidden = FindDockingEdgeAutoHidden(uniqueName);
                if (autoHidden != null)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        // Ensure all docking controls have been laid out before the change is processed
                        Application.DoEvents();

                        var args = new CancelUniqueNameEventArgs(uniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowAutoHidden));
                        OnPageAutoHiddenRequest(args);

                        if (args.Cancel)
                        {
                            return;
                        }

                        using var update = new DockingMultiUpdate(this);
                        // Convert the page to a placeholder so it can be returned to the same location
                        PropogateAction(DockingPropogateAction.StorePages, new[] { uniqueName });

                        // Is there a auto hidden group with a restore page for the named page?
                        if (autoHidden.FindStorePageElement(DockingLocation.AutoHidden, uniqueName) is KryptonDockingAutoHiddenGroup restoreElement)
                        {
                            // Find the target index of the restore page
                            KryptonAutoHiddenGroup control = restoreElement.AutoHiddenGroupControl;
                            var pageIndex = control.Pages.IndexOf(control.Pages[uniqueName]!);

                            // Insert the page at the same index as the restore page
                            control.Pages.Insert(pageIndex, new KryptonAutoHiddenProxyPage(page));
                        }
                        else
                        {
                            // No existing store page so add as a new group
                            restoreElement = autoHidden.AppendAutoHiddenGroup();
                            restoreElement.Append(new[] { page });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Make the named page docked.
        /// </summary>
        /// <param name="uniqueName">Unique name of page to become docked.</param>
        public virtual void MakeDockedRequest([DisallowNull] string uniqueName)
        {
            // Cannot process a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // If the named page exists and is not already docked
            if (ContainsPage(uniqueName) && (FindPageLocation(uniqueName) != DockingLocation.Docked))
            {
                // If we can find a docking edge element appropriate for the named page
                KryptonDockingEdgeDocked? docked = FindDockingEdgeDocked(uniqueName);
                if (docked != null)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        // Ensure all docking controls have been laid out before the change is processed
                        Application.DoEvents();

                        var args = new CancelUniqueNameEventArgs(uniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowDocked));
                        OnPageDockedRequest(args);

                        if (args.Cancel)
                        {
                            return;
                        }

                        using var update = new DockingMultiUpdate(this);
                        // Convert the page to a placeholder so it can be returned to the same location
                        PropogateAction(DockingPropogateAction.StorePages, new[] { uniqueName });

                        // Is there a dockspace with a restore page for the named page?
                        if (docked.FindStorePageElement(DockingLocation.Docked, uniqueName) is KryptonDockingDockspace restoreElement)
                        {
                            // Find the target cell and the index of the restore page
                            KryptonWorkspaceCell? cell = restoreElement.CellForPage(uniqueName);
                            if (cell != null)
                            {
                                var pageIndex = cell.Pages.IndexOf(cell.Pages[uniqueName]!);

                                // Insert the page at the same index as the restore page
                                restoreElement.CellInsert(cell, pageIndex, new[] { page });
                                restoreElement.SelectPage(uniqueName);
                                restoreElement.DockspaceControl.Select();
                            }
                        }
                        else
                        {

                            // No existing store page so add as a new dockspace
                            KryptonDockingDockspace dockspaceElement = docked.AppendDockspace();
                            dockspaceElement.Append(new[] { page });
                            dockspaceElement.SelectPage(page.UniqueName);
                            dockspaceElement.DockspaceControl.Select();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Make the named page floating.
        /// </summary>
        /// <param name="uniqueName">Unique name of page to become floating.</param>
        public virtual void MakeFloatingRequest([DisallowNull] string uniqueName)
        {
            // Cannot process a null reference
            if (string.IsNullOrWhiteSpace(uniqueName))
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // If the named page exists and is not already floating
            if (ContainsPage(uniqueName)
                && (FindPageLocation(uniqueName) != DockingLocation.Floating)
                )
            {
                // If we can find a floating element appropriate for the named page
                KryptonDockingFloating? floating = FindDockingFloating(uniqueName);
                if (floating != null)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        // Ensure all docking controls have been laid out before the change is processed
                        Application.DoEvents();

                        var args = new CancelUniqueNameEventArgs(uniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowFloating));
                        OnPageFloatingRequest(args);

                        if (args.Cancel)
                        {
                            return;
                        }

                        using var update = new DockingMultiUpdate(this);
                        // Convert the page to a placeholder so it can be returned to the same location
                        PropogateAction(DockingPropogateAction.StorePages, new[] { uniqueName });

                        // Is there a floating window with a restore page for the named page?
                        KryptonDockingFloatingWindow? restoreElement = floating.FloatingWindowForStorePage(uniqueName);
                        if (restoreElement != null)
                        {
                            // Find the target cell and the index of the restore page
                            KryptonWorkspaceCell? cell = restoreElement.CellForPage(uniqueName);
                            if (cell != null)
                            {
                                var pageIndex = cell.Pages.IndexOf(cell.Pages[uniqueName]!);

                                // Insert the page at the same index as the restore page
                                restoreElement.FloatspaceElement.CellInsert(cell, pageIndex, new[] { page });
                                restoreElement.SelectPage(uniqueName);
                                restoreElement.FloatingWindow.Select();
                            }
                        }
                        else
                        {
                            // No floating window found to restore into, so create a new window
                            KryptonDockingFloatingWindow floatingElement = floating.AddFloatingWindow();
                            floatingElement.FloatspaceElement.Append(new[] { page });
                            floatingElement.SelectPage(uniqueName);
                            floatingElement.FloatingWindow.Show();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Make the named page workspace tabbed.
        /// </summary>
        /// <param name="uniqueName">Unique name of page to become workspace tabbed.</param>
        public virtual void MakeWorkspaceRequest([DisallowNull] string uniqueName)
        {
            // Cannot process a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // If the named page exists and is not already workspace tabbed
            if (ContainsPage(uniqueName)
                && (FindPageLocation(uniqueName) != DockingLocation.Workspace)
                )
            {
                // If we can find a workspace element appropriate for the named page
                KryptonDockingWorkspace? workspaceElement = FindDockingWorkspace(uniqueName);
                if (workspaceElement != null)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        // Ensure all docking controls have been laid out before the change is processed
                        Application.DoEvents();

                        var args = new CancelUniqueNameEventArgs(uniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowWorkspace));
                        OnPageWorkspaceRequest(args);

                        if (args.Cancel)
                        {
                            return;
                        }

                        using var update = new DockingMultiUpdate(this);
                        // Convert the page to a placeholder so it can be returned to the same location
                        PropogateAction(DockingPropogateAction.StorePages, new[] { uniqueName });

                        // Find the target cell, if there is one, that contains a store page
                        KryptonWorkspaceCell? cell = workspaceElement.CellForPage(uniqueName);

                        if (cell != null)
                        {
                            // Insert the page at the same index as the restore page
                            var pageIndex = cell.Pages.IndexOf(cell.Pages[uniqueName]!);
                            workspaceElement.CellInsert(cell, pageIndex, new[] { page });
                            workspaceElement.SelectPage(uniqueName);
                            workspaceElement.DockableWorkspaceControl?.Select();
                        }
                        else
                        {
                            // No existing store page so just append to the workspace
                            workspaceElement.Append(new[] { page });
                            workspaceElement.SelectPage(uniqueName);
                            workspaceElement.DockableWorkspaceControl?.Select();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Make the named page navigator tabbed.
        /// </summary>
        /// <param name="uniqueName">Unique name of page to become navigator tabbed.</param>
        public virtual void MakeNavigatorRequest([DisallowNull] string uniqueName)
        {
            // Cannot process a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // If the named page exists and is not already navigator tabbed
            if (ContainsPage(uniqueName)
                && (FindPageLocation(uniqueName) != DockingLocation.Navigator)
                )
            {
                // If we can find a navigator element appropriate for the named page
                KryptonDockingNavigator? navigatorElement = FindDockingNavigator(uniqueName);
                if (navigatorElement != null)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        // Ensure all docking controls have been laid out before the change is processed
                        Application.DoEvents();

                        var args = new CancelUniqueNameEventArgs(uniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowNavigator));
                        OnPageNavigatorRequest(args);

                        if (args.Cancel)
                        {
                            return;
                        }

                        using var update = new DockingMultiUpdate(this);
                        // Convert the page to a placeholder so it can be returned to the same location
                        PropogateAction(DockingPropogateAction.StorePages, new[] { uniqueName });

                        // If we can find an existing page in the target navigator with the name we are inserting
                        KryptonDockableNavigator navigatorControl = navigatorElement.DockableNavigatorControl;
                        KryptonPage? insertPage = navigatorControl.Pages[uniqueName];
                        if (insertPage != null)
                        {
                            var pageIndex = navigatorControl.Pages.IndexOf(insertPage);

                            if (pageIndex >= 0)
                            {
                                // Insert the page at the same index as the restore page
                                navigatorControl.Pages.Insert(pageIndex, page);
                                navigatorElement.SelectPage(uniqueName);
                                navigatorControl.Select();
                            }
                            else
                            {
                                // Append at end of current page collection
                                navigatorControl.Pages.Add(page);
                                navigatorElement.SelectPage(uniqueName);
                                navigatorControl.Select();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Populate a context menu appropriate for a non-dockable workspace provided page.
        /// </summary>
        /// <param name="page">Reference to page.</param>
        /// <param name="kcm">Reference to context menu.</param>
        /// <returns>True if the context menu should be displayed; otherwise false.</returns>
        public virtual bool ShowPageContextMenuRequest([DisallowNull] KryptonPage? page, [DisallowNull] KryptonContextMenu kcm)
        {
            // Cannot action a null reference
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            if (kcm == null)
            {
                throw new ArgumentNullException(nameof(kcm));
            }

            // By default, there is nothing to display
            var retDisplay = false;

            // If the page is not located in the hierarchy then there are no options we can provide
            DockingLocation location = FindPageLocation(page);
            if (location != DockingLocation.None)
            {
                // Reset the context menu with an items collection
                var options = new KryptonContextMenuItems();
                kcm.Items.Clear();
                kcm.Items.Add(options);

                // Can only make floating if we can find a floating element to target the action against
                if (FindDockingFloating(page.UniqueName) != null)
                {
                    // Add an option for floating the page
                    var floatingItem = new KryptonContextMenuItem(Strings.TextFloat)
                    {
                        Tag = page.UniqueName
                    };
                    floatingItem.Click += OnDropDownFloatingClicked;
                    floatingItem.Enabled = ((location != DockingLocation.Floating) && (page.AreFlagsSet(KryptonPageFlags.DockingAllowFloating)));
                    options.Items.Add(floatingItem);
                    retDisplay = true;
                }

                // Can only make docked if we can find a docked edge to target the action against
                if (FindDockingEdgeDocked(page.UniqueName) != null)
                {
                    // Add an option for docked the page
                    var dockedItem = new KryptonContextMenuItem(Strings.TextDock)
                    {
                        Tag = page.UniqueName
                    };
                    dockedItem.Click += OnDropDownDockedClicked;
                    dockedItem.Enabled = ((location != DockingLocation.Docked) && (page.AreFlagsSet(KryptonPageFlags.DockingAllowDocked)));
                    options.Items.Add(dockedItem);
                    retDisplay = true;
                }

                // Can only make tabbed document if we can find a workspace to target the action against
                if (FindDockingWorkspace(page.UniqueName) != null)
                {
                    // Add an option for docked the page
                    var workspaceItem = new KryptonContextMenuItem(Strings.TextTabbedDocument)
                    {
                        Tag = page.UniqueName
                    };
                    workspaceItem.Click += OnDropDownWorkspaceClicked;
                    workspaceItem.Enabled = ((location != DockingLocation.Workspace) && (page.AreFlagsSet(KryptonPageFlags.DockingAllowWorkspace)));
                    options.Items.Add(workspaceItem);
                    retDisplay = true;
                }
                else
                {
                    // No workspace so look for a navigator instead
                    if (FindDockingNavigator(page.UniqueName) != null)
                    {
                        // Add an option for docked the page
                        var workspaceItem = new KryptonContextMenuItem(Strings.TextTabbedDocument)
                        {
                            Tag = page.UniqueName
                        };
                        workspaceItem.Click += OnDropDownNavigatorClicked;
                        workspaceItem.Enabled = ((location != DockingLocation.Navigator) && (page.AreFlagsSet(KryptonPageFlags.DockingAllowNavigator)));
                        options.Items.Add(workspaceItem);
                        retDisplay = true;
                    }
                }

                // Can only make auto hidden if we can find a auto hidden edge to target the action against
                if (FindDockingEdgeAutoHidden(page.UniqueName) != null)
                {
                    // Add an option for docked the page
                    var autoHiddenItem = new KryptonContextMenuItem(Strings.TextAutoHide)
                    {
                        Tag = page.UniqueName
                    };
                    autoHiddenItem.Click += OnDropDownAutoHiddenClicked;
                    autoHiddenItem.Enabled = ((location != DockingLocation.AutoHidden) && (page.AreFlagsSet(KryptonPageFlags.DockingAllowAutoHidden)));
                    options.Items.Add(autoHiddenItem);
                    retDisplay = true;
                }

                // Can only add the close menu option if we are allowed to close the page
                if (page.AreFlagsSet(KryptonPageFlags.DockingAllowClose))
                {
                    // Add an option for closing the page
                    var closeItem = new KryptonContextMenuItem(Strings.TextClose)
                    {
                        Tag = page.UniqueName
                    };
                    closeItem.Click += OnDropDownCloseClicked;
                    options.Items.Add(closeItem);
                    retDisplay = true;
                }
            }

            // Let events customize the context menu
            var args = new ContextPageEventArgs(page, kcm, !retDisplay);
            OnShowPageContextMenu(args);
            return !args.Cancel;
        }

        /// <summary>
        /// Perform a switch from docked cell to auto hidden group for the visible pages inside the cell.
        /// </summary>
        /// <param name="uniqueName">Unique name of page inside docked cell that needs switching.</param>
        /// <returns>KryptonDockingAutoHiddenGroup reference on success; otherwise null.</returns>
        public virtual KryptonDockingAutoHiddenGroup? SwitchDockedCellToAutoHiddenGroupRequest([DisallowNull] string uniqueName)
        {
            // Cannot switch a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Does the provided unique name exist and is in the required 'docked' state
            if (FindPageLocation(uniqueName) == DockingLocation.Docked)
            {
                // Grab the dockspace element that we expect to contain the target unique name 
                if (ExpectPageElement(uniqueName, typeof(KryptonDockingDockspace)) is KryptonDockingDockspace dockspace)
                {
                    // Does the dockspace currently have the focus?
                    var hadFocus = dockspace.DockspaceControl.ContainsFocus;

                    // Find the sibling auto hidden edge so we can add a new auto hidden group to it later on
                    KryptonDockingEdgeAutoHidden? edgeAutoHidden = dockspace.EdgeAutoHiddenElement;
                    if (edgeAutoHidden != null)
                    {
                        // Grab the set of visible pages in the same cell as the target unique name
                        var visiblePages = dockspace.CellVisiblePages(uniqueName);
                        if (visiblePages.Length > 0)
                        {
                            // Use events to determine which pages in the cell should be switched
                            var switchUniqueNames = new List<string>();
                            var switchPages = new List<KryptonPage>();
                            foreach (KryptonPage page in visiblePages)
                            {
                                var args = new CancelUniqueNameEventArgs(page.UniqueName,
                                    !page.AreFlagsSet(KryptonPageFlags.DockingAllowAutoHidden));
                                OnPageAutoHiddenRequest(args);

                                if (!args.Cancel)
                                {
                                    switchUniqueNames.Add(page.UniqueName);
                                    switchPages.Add(page);
                                }
                            }

                            // Any pages that actually need to be switched?
                            if (switchPages.Count > 0)
                            {
                                using var update = new DockingMultiUpdate(this);
                                // Convert the pages to placeholders so they can be returned to the same location
                                var uniqueNames = switchUniqueNames.ToArray();
                                dockspace.PropogateAction(DockingPropogateAction.StorePages, uniqueNames);

                                // Create a new auto hidden group and add the switch pages into it
                                KryptonDockingAutoHiddenGroup hiddenGroup = edgeAutoHidden.AppendAutoHiddenGroup();
                                hiddenGroup.Append(switchPages.ToArray());

                                // If we had the focus at the start of the process and the dockspace no longer has it...
                                if (hadFocus && !dockspace.DockspaceControl.ContainsFocus)
                                {
                                    // ...and focus has not moved to another part of the form...
                                    Form? topForm = dockspace.DockspaceControl.FindForm();
                                    if (topForm is { ContainsFocus: false })
                                    {
                                        // ...then shift focus to the auto hidden group placeholder, to ensure the form still has the 
                                        // focus and so hovering the mouse over the auto hidden tabs will correctly get them to slide out
                                        if (hiddenGroup.GetParentType(typeof(KryptonDockingEdgeAutoHidden)) is KryptonDockingEdgeAutoHidden)
                                        {
                                            topForm.Focus();
                                        }
                                    }
                                }
                                dockspace.DockspaceControl.UpdateVisible(false);

                                return hiddenGroup;
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Perform a switch from docked pages to floating window for the named pages.
        /// </summary>
        /// <param name="uniqueNames">Unique name of pages inside a docked cell that needs switching.</param>
        /// <returns>KryptonDockingFloatingWindow reference on success; otherwise null.</returns>
        public virtual KryptonDockingFloatingWindow? SwitchDockedToFloatingWindowRequest([DisallowNull] IReadOnlyList<string> uniqueNames)
        {
            // Cannot action a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            // Cannot action an empty array
            if (uniqueNames.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(uniqueNames), @"array cannot be empty");
            }

            // Cannot action a null or zero length unique name
            foreach (var uniqueName in uniqueNames)
            {
                if (uniqueName == null)
                {
                    throw new ArgumentNullException(nameof(uniqueNames), @"array contains a null string reference");
                }

                if (uniqueName.Length == 0)
                {
                    throw new ArgumentException(@"array contains a zero length string", nameof(uniqueNames));
                }
            }

            // Use events to determine which pages should be switched
            var switchUniqueNames = new List<string>();
            var switchPages = new List<KryptonPage>();
            string? selectedPage = null;
            foreach (var uniqueName in uniqueNames)
            {
                // Does the provided unique name exist and is in the required 'docked' state
                if (FindPageLocation(uniqueName) == DockingLocation.Docked)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        var args = new CancelUniqueNameEventArgs(page.UniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowFloating));
                        OnPageFloatingRequest(args);

                        if (!args.Cancel)
                        {
                            switchUniqueNames.Add(page.UniqueName);
                            switchPages.Add(page);

                            // Navigate to the cell that holds the page
                            if (FindPageElement(page) is KryptonDockingDockspace dockspace)
                            {
                                KryptonWorkspaceCell? cell = dockspace.CellForPage(uniqueName);
                                if (cell != null)
                                {
                                    // Remember the page that is active
                                    if (cell.SelectedPage == page)
                                    {
                                        selectedPage = page.UniqueName;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Still any pages to be switched?
            if (switchUniqueNames.Any())
            {
                // Find a floating element that is the target for the switching
                KryptonDockingFloating? floating = FindDockingFloating(selectedPage ?? switchUniqueNames[0]);
                if (floating != null)
                {
                    using var update = new DockingMultiUpdate(this);
                    // Convert the pages to placeholders so they can be returned to the same location
                    PropogateAction(DockingPropogateAction.StorePages, switchUniqueNames.ToArray());

                    foreach (var switchUniqueName in switchUniqueNames)
                    {
                        // Is there a floating window with a restore page for this unique name?
                        KryptonDockingFloatingWindow? restoreElement = floating.FloatingWindowForStorePage(switchUniqueName);
                        if (restoreElement != null)
                        {
                            // Find the target cell and the index of the restore page
                            KryptonWorkspaceCell? cell = restoreElement.CellForPage(switchUniqueName);
                            if (cell != null)
                            {
                                var pageIndex = cell.Pages.IndexOf(cell.Pages[switchUniqueName]!);

                                // Insert the set of pages at the same index as the restore page
                                restoreElement.FloatspaceElement.CellInsert(cell, pageIndex, switchPages.ToArray());
                            }

                            // Make sure the same page is selected as was selected in the docked source
                            if (selectedPage != null)
                            {
                                restoreElement.SelectPage(selectedPage);
                            }

                            return restoreElement;
                        }
                    }

                    // No floating window found to restore into, so create a new window
                    KryptonDockingFloatingWindow floatingElement = floating.AddFloatingWindow();
                    floatingElement.FloatspaceElement.Append(switchPages.ToArray());

                    // Make sure the same page is selected as was selected in the docked source
                    if (selectedPage != null)
                    {
                        floatingElement.SelectPage(selectedPage);
                    }

                    floatingElement.FloatingWindow.Show();
                    return floatingElement;
                }
            }

            return null;
        }

        /// <summary>
        /// Perform a switch from floating to docked for the named pages.
        /// </summary>
        /// <param name="uniqueNames">Unique name of floating pages that need switching.</param>
        /// <returns>KryptonDockingDockspace reference if a new dockspace needed to be created; otherwise false.</returns>
        public virtual KryptonDockingDockspace? SwitchFloatingToDockedRequest([DisallowNull] string[] uniqueNames)
        {
            // Cannot action a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            // Cannot action an empty array
            if (uniqueNames.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(uniqueNames), @"array cannot be empty");
            }

            // Cannot action a null or zero length unique name
            foreach (var uniqueName in uniqueNames)
            {
                if (uniqueName == null)
                {
                    throw new ArgumentNullException(nameof(uniqueNames), @"array contains a null string reference");
                }

                if (uniqueName.Length == 0)
                {
                    throw new ArgumentException(@"array contains a zero length string", nameof(uniqueNames));
                }
            }

            // Use events to determine which pages should be switched
            var switchUniqueNames = new List<string>();
            var switchPages = new List<KryptonPage>();
            string? selectedPage = null;
            foreach (var uniqueName in uniqueNames)
            {
                // Does the provided unique name exist and is in the required 'floating' state
                if (FindPageLocation(uniqueName) == DockingLocation.Floating)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        var args = new CancelUniqueNameEventArgs(page.UniqueName,
                            !page.AreFlagsSet(KryptonPageFlags.DockingAllowDocked));
                        OnPageDockedRequest(args);

                        if (!args.Cancel)
                        {
                            switchUniqueNames.Add(page.UniqueName);
                            switchPages.Add(page);

                            // Navigate to the cell that holds the page
                            if (FindPageElement(page) is KryptonDockingFloatspace floatspace)
                            {
                                KryptonWorkspaceCell? cell = floatspace.CellForPage(uniqueName);
                                if (cell != null)
                                {
                                    // Remember the page that is active
                                    if (cell.SelectedPage == page)
                                    {
                                        selectedPage = page.UniqueName;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Still any pages to be switched?
            if (switchUniqueNames.Any())
            {
                using var update = new DockingMultiUpdate(this);
                // Convert the pages to placeholders so they can be returned to the same location
                PropogateAction(DockingPropogateAction.StorePages, switchUniqueNames.ToArray());

                // Try and restore each page, but make a note of those that failed to be restore
                //List<string> defaultUniqueNames = new List<string>();
                var defaultPages = new List<KryptonPage>();
                KryptonPage? defaultSelectedPage = null;
                for (var i = 0; i < switchUniqueNames.Count; i++)
                {
                    // Find any dockspace that contains a restore page for this named page
                    var switchUniqueName = switchUniqueNames[i];
                    if (DockingManager?.FindStorePageElement(DockingLocation.Docked, switchUniqueName) is KryptonDockingDockspace restoreElement)
                    {
                        // Find the target cell and the index of the restore page
                        KryptonWorkspaceCell? cell = restoreElement.CellForPage(switchUniqueName);
                        if (cell != null)
                        {
                            var pageIndex = cell.Pages.IndexOf(cell.Pages[switchUniqueName]!);

                            // Insert the set of pages at the same index as the restore page
                            restoreElement.CellInsert(cell, pageIndex, switchPages[i]);
                        }

                        // Make sure the same page is selected as was selected in the floating source
                        if (switchUniqueName == selectedPage)
                        {
                            restoreElement.SelectPage(selectedPage);
                            restoreElement.DockspaceControl.UpdateVisible(true);
                        }
                    }
                    else
                    {
                        //defaultUniqueNames.Add(switchUniqueName);
                        defaultPages.Add(switchPages[i]);

                        // Note the default page that should become selected
                        if (switchUniqueName == selectedPage)
                        {
                            defaultSelectedPage = switchPages[i];
                        }
                    }
                }

                // Any pages that need default positioning because they could not be restored?
                if (defaultPages.Any())
                {
                    // Cannot switch to docked unless we can find a docked element as the target
                    KryptonDockingEdgeDocked? edgeDocked = FindDockingEdgeDocked(defaultSelectedPage != null ? defaultSelectedPage.UniqueName : defaultPages[0].UniqueName);
                    if (edgeDocked != null)
                    {
                        KryptonDockingDockspace dockspace = edgeDocked.AppendDockspace();
                        dockspace.Append(defaultPages.ToArray());

                        // Make sure the same page is selected as was selected in the floating source
                        if (defaultSelectedPage != null)
                        {
                            dockspace.SelectPage(defaultSelectedPage.UniqueName);
                            dockspace.DockspaceControl.UpdateVisible(true);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Perform a switch from floating to new floating window for the named pages.
        /// </summary>
        /// <param name="uniqueNames">Unique name of floating pages that need switching.</param>
        /// <returns>KryptonDockingFloatingWindow reference on success; otherwise false.</returns>
        public virtual KryptonDockingFloatingWindow? SwitchFloatingToFloatingWindowRequest([DisallowNull] IReadOnlyList<string> uniqueNames)
        {
            // Cannot action a null reference
            if (uniqueNames == null)
            {
                throw new ArgumentNullException(nameof(uniqueNames));
            }

            // Cannot action an empty array
            if (uniqueNames.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(uniqueNames), @"array cannot be empty");
            }

            // Cannot action a null or zero length unique name
            foreach (var uniqueName in uniqueNames)
            {
                if (uniqueName == null)
                {
                    throw new ArgumentNullException(nameof(uniqueNames), @"array contains a null string reference");
                }

                if (uniqueName.Length == 0)
                {
                    throw new ArgumentException(@"array contains a zero length string", nameof(uniqueNames));
                }
            }

            // Use events to determine which pages should be switched
            var switchUniqueNames = new List<string>();
            var switchPages = new List<KryptonPage>();
            string? selectedPage = null;
            foreach (var uniqueName in uniqueNames)
            {
                // Does the provided unique name exist and is in the required 'floating' state
                if (FindPageLocation(uniqueName) == DockingLocation.Floating)
                {
                    KryptonPage? page = PageForUniqueName(uniqueName);
                    if (page != null)
                    {
                        switchUniqueNames.Add(uniqueName);
                        switchPages.Add(page);

                        // Navigate to the cell that holds the page
                        if (FindPageElement(page) is KryptonDockingFloatspace floatspace)
                        {
                            KryptonWorkspaceCell? cell = floatspace.CellForPage(uniqueName);
                            if (cell != null)
                            {
                                // Remember the page that is active
                                if (cell.SelectedPage == page)
                                {
                                    selectedPage = page.UniqueName;
                                }
                            }
                        }
                    }
                }
            }

            // Still any pages to be switched?
            if (switchUniqueNames.Any())
            {
                // Find a floating element that is the target for the switching
                KryptonDockingFloating? floating = FindDockingFloating(selectedPage ?? switchUniqueNames[0]);
                if (floating != null)
                {
                    using var update = new DockingMultiUpdate(this);
                    // Grab the current element that contains one of the pages being moved
                    var currentElement = FindPageElement(switchPages[0]) as KryptonDockingFloatspace;

                    // Remove the pages from the existing floating window
                    PropogateAction(DockingPropogateAction.RemovePages, switchUniqueNames.ToArray());

                    // Create a new floating window and add the specified set of pages
                    KryptonDockingFloatingWindow floatingElement = floating.AddFloatingWindow();
                    floatingElement.FloatspaceElement.Append(switchPages.ToArray());

                    // Make sure any selected page is selected in the new floating window
                    if (selectedPage != null)
                    {
                        floatingElement.SelectPage(selectedPage);
                    }

                    // Position the new floating window close to the existing one
                    if (currentElement != null)
                    {
                        floatingElement.FloatingWindow.Location =
                            currentElement.FloatspaceControl.PointToScreen(Point.Empty);
                    }
                    floatingElement.FloatingWindow.Show();

                    return floatingElement;
                }
            }

            return null;
        }

        /// <summary>
        /// Perform a switch from auto hidden group to docked cell for the visible pages inside the group.
        /// </summary>
        /// <param name="uniqueName">Unique name of page inside auto hidden group that needs switching.</param>
        /// <returns>KryptonDockingDockspace reference if a new dockspace needed to be created; otherwise false.</returns>
        public virtual KryptonDockingDockspace? SwitchAutoHiddenGroupToDockedCellRequest([DisallowNull] string uniqueName)
        {
            // Cannot switch a null reference
            if (uniqueName == null)
            {
                throw new ArgumentNullException(nameof(uniqueName));
            }

            // Unique names cannot be zero length
            if (uniqueName.Length == 0)
            {
                throw new ArgumentException(@"uniqueName cannot be zero length", nameof(uniqueName));
            }

            // Does the provided unique name exist and is in the required 'auto-hidden' state
            if (FindPageLocation(uniqueName) == DockingLocation.AutoHidden)
            {
                // Grab the auto hidden group docking element that we expect to contain the target unique name 
                var autoHiddenGroup = (KryptonDockingAutoHiddenGroup)ExpectPageElement(uniqueName, typeof(KryptonDockingAutoHiddenGroup));
                // Find the sibling docked edge so we can add/restore pages
                KryptonDockingEdgeDocked? edgeDocked = autoHiddenGroup.EdgeDockedElement;
                if (edgeDocked != null)
                {
                    // Grab the set of visible pages in the auto hidden group
                    var visiblePages = autoHiddenGroup.VisiblePages();
                    if (visiblePages.Length > 0)
                    {
                        // Use events to determine which pages in the cell should be switched
                        var switchUniqueNames = new List<string>();
                        var switchPages = new List<KryptonPage>();
                        foreach (KryptonPage page in visiblePages)
                        {
                            var args = new CancelUniqueNameEventArgs(page.UniqueName,
                                !page.AreFlagsSet(KryptonPageFlags.DockingAllowDocked));
                            OnPageDockedRequest(args);

                            if (!args.Cancel)
                            {
                                switchUniqueNames.Add(page.UniqueName);
                                switchPages.Add(page);
                            }
                        }

                        // Any pages that actually need to be switched?
                        if (switchPages.Any())
                        {
                            using var update = new DockingMultiUpdate(this);
                            // Remove the pages from the auto hidden group
                            var uniqueNames = switchUniqueNames.ToArray();
                            PropogateAction(DockingPropogateAction.RemovePages, uniqueNames);

                            // Attempt to restore each page back to original location on the same edge
                            var defaultPages = new List<KryptonPage>();
                            KryptonPage? defaultSelectedPage = null;
                            for (var i = 0; i < switchPages.Count; i++)
                            {
                                // If we find a store page then we can simply restore straight back to that position
                                var canRestore = edgeDocked.PropogateBoolState(DockingPropogateBoolState.ContainsStorePage, uniqueNames[i]);
                                if (canRestore.HasValue && canRestore.Value)
                                {
                                    // Restore page back into a dockspace
                                    edgeDocked.PropogateAction(DockingPropogateAction.RestorePages, new[] { switchPages[i] });

                                    // Should this page become the selected and focused page?
                                    if (uniqueName == uniqueNames[i])
                                    {
                                        // If this restored page was the selected page in the auto hidden group, make it selected in the dockspace
                                        if (edgeDocked.FindPageElement(uniqueNames[i]) is KryptonDockingDockspace restoreElement)
                                        {
                                            restoreElement.SelectPage(uniqueNames[i]);
                                            restoreElement.DockspaceControl.UpdateVisible(true);
                                        }
                                    }
                                }
                                else
                                {
                                    defaultPages.Add(switchPages[i]);

                                    // Note the default page that should become selected
                                    if (uniqueName == uniqueNames[i])
                                    {
                                        defaultSelectedPage = switchPages[i];
                                    }
                                }
                            }

                            // Remove any existing placeholders in all the docked edges
                            RemoveControlStorePages(edgeDocked, uniqueNames, false, true);

                            // Do we have some pages that still need adding?
                            if (defaultPages.Any())
                            {
                                // Place them all inside a new dockspace
                                KryptonDockingDockspace newDockspace = edgeDocked.AppendDockspace();
                                newDockspace.Append(defaultPages.ToArray());

                                // Make sure the same page is selected as was selected in the auto hidden group
                                if (defaultSelectedPage != null)
                                {
                                    newDockspace.SelectPage(defaultSelectedPage.UniqueName);
                                    newDockspace.DockspaceControl.UpdateVisible(true);
                                }

                                return newDockspace;
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Add set of pages docked against a specified edge of the specified control.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingControl.</param>
        /// <param name="edge">Target edge within the KryptonDockingControl.</param>
        /// <param name="pages">Array of pages to be added as docked.</param>
        /// <param name="stackPages">Extra arrays of pages to be added in a stacked manner.</param>
        /// <returns>KryptonDockingDockspace reference.</returns>
        public virtual KryptonDockingDockspace AddDockspace(string path,
                                                            DockingEdge edge,
                                                            [DisallowNull] KryptonPage[] pages,
                                                            params KryptonPage[][] stackPages)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking control element
            if (ResolvePath(path) is not KryptonDockingControl dockControl)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingControl", nameof(path));
            }

            // Find the requested target edge
            if (dockControl[edge.ToString()] is not KryptonDockingEdge edgeElement)
            {
                throw new ArgumentException(@"KryptonDockingControl does not have the requested edge.", nameof(edge));
            }

            // Find the docked edge
            if (edgeElement[@"Docked"] is not KryptonDockingEdgeDocked edgeDocked)
            {
                throw new ArgumentException(@"KryptonDockingControl edge does not have a docked element.", nameof(edge));
            }

            using var update = new DockingMultiUpdate(this);
            // Create a new dockspace and add the provided array of pages
            var dockspace = edgeDocked.AppendDockspace();
            dockspace.Append(pages);
            //switch (dockspace.DockspaceControl.Dock)
            //{
            //    case DockStyle.Left:
            //    case DockStyle.Right:
            //        if (orientation == Orientation.Horizontal)
            //        {
            //            controls.Add(dockspace);
            //        }

            //        break;
            //    case DockStyle.Top:
            //    case DockStyle.Bottom:
            //        if (orientation == Orientation.Vertical)
            //        {
            //            controls.Add(dockspace);
            //        }

            //        break;
            //}
            //dockspace.DockspaceControl.MinimumSize = new Size(dockspace.DockspaceControl.MinimumSize.Width+40,
            //    dockspace.DockspaceControl.MinimumSize.Height+40);
            // If we have extra pages then we need to add a stack of tabbed cells
            if (stackPages is { Length: > 0 })
            {
                // For each array of pages...
                foreach (var pageArray in stackPages)
                {
                    if (pageArray is { Length: > 0 })
                    {
                        // We need a new cell with all the pages from the array
                        var cell = new KryptonWorkspaceCell();
                        cell.Pages.AddRange(pageArray);

                        // Add into the root collection so the cells appear in a stack
                        dockspace.DockspaceControl.Root.Children?.Add(cell);
                    }
                }

                // Set the correct direction for the stacking of cells at the root
                switch (edge)
                {
                    case DockingEdge.Left:
                    case DockingEdge.Right:
                        dockspace.DockspaceControl.Root.Orientation = Orientation.Vertical;
                        break;
                    case DockingEdge.Top:
                    case DockingEdge.Bottom:
                        dockspace.DockspaceControl.Root.Orientation = Orientation.Horizontal;
                        break;
                }
            }

            return dockspace;
        }

        /// <summary>
        /// Add set of pages as a new auto hidden group to the specified edge of the specified control.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingControl.</param>
        /// <param name="edge">Target edge within the KryptonDockingControl.</param>
        /// <param name="pages">Array of pages to be added as an auto hidden group.</param>
        /// <param name="extraPages">Extra arrays of pages to be added as extra groups.</param>
        /// <returns>KryptonDockingAutoHiddenGroup reference.</returns>
        public virtual KryptonDockingAutoHiddenGroup AddAutoHiddenGroup(string path,
                                                                        DockingEdge edge,
                                                                        [DisallowNull] KryptonPage[] pages,
                                                                        params KryptonPage[][] extraPages)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking control element
            if (ResolvePath(path) is not KryptonDockingControl control)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingControl", nameof(path));
            }

            // Find the requested target edge
            if (control[edge.ToString()] is not KryptonDockingEdge edgeElement)
            {
                throw new ArgumentException(@"KryptonDockingControl does not have the requested edge.", nameof(edge));
            }

            // Find the auto hidden edge
            if (edgeElement[@"AutoHidden"] is not KryptonDockingEdgeAutoHidden edgeAutoHidden)
            {
                throw new ArgumentException(@"KryptonDockingControl edge does not have an auto hidden element.", nameof(edge));
            }

            using var update = new DockingMultiUpdate(this);
            // Create a new auto hidden group and add the provided array of pages
            KryptonDockingAutoHiddenGroup autoHiddenGroup = edgeAutoHidden.AppendAutoHiddenGroup();
            autoHiddenGroup.Append(pages);

            // If we have extra pages then we need to add extra auto hidden groups
            if (extraPages is { Length: > 0 })
            {
                // For each array of pages...
                foreach (var pageArray in extraPages)
                {
                    if (pageArray is { Length: > 0 })
                    {
                        // Create a new auto hidden group and add the provided array of pages
                        KryptonDockingAutoHiddenGroup extraAutoHiddenGroup = edgeAutoHidden.AppendAutoHiddenGroup();
                        extraAutoHiddenGroup.Append(pageArray);
                    }
                }
            }

            return autoHiddenGroup;
        }

        /// <summary>
        /// Add set of pages as a new floating window.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingFloating.</param>
        /// <param name="pages">Array of pages to be added as an auto hidden group.</param>
        /// <returns>KryptonDockingFloatingWindow reference.</returns>
        public virtual KryptonDockingFloatingWindow AddFloatingWindow(string path, KryptonPage[] pages) => AddFloatingWindow(path, pages, Point.Empty, Size.Empty);

        /// <summary>
        /// Add set of pages as a new floating window.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingFloating.</param>
        /// <param name="pages">Array of pages to be added as an auto hidden group.</param>
        /// <param name="clientSize">Initial client size of the floating window.</param>
        /// <returns>KryptonDockingFloatingWindow reference.</returns>
        public virtual KryptonDockingFloatingWindow AddFloatingWindow(string path,
                                                                      KryptonPage[] pages,
                                                                      Size clientSize) =>
            AddFloatingWindow(path, pages, Point.Empty, clientSize);

        /// <summary>
        /// Add set of pages as a new floating window.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingFloating.</param>
        /// <param name="pages">Array of pages to be added as an auto hidden group.</param>
        /// <param name="location">Initial screen location of the floating window.</param>
        /// <returns>KryptonDockingFloatingWindow reference.</returns>
        public virtual KryptonDockingFloatingWindow AddFloatingWindow(string path,
                                                                      KryptonPage[] pages,
                                                                      Point location) =>
            AddFloatingWindow(path, pages, location, Size.Empty);

        /// <summary>
        /// Add set of pages as a new floating window.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingFloating.</param>
        /// <param name="pages">Array of pages to be added as an auto hidden group.</param>
        /// <param name="location">Initial screen location of the floating window.</param>
        /// <param name="clientSize">Initial client size of the floating window.</param>
        /// <returns>KryptonDockingFloatingWindow reference.</returns>
        public virtual KryptonDockingFloatingWindow AddFloatingWindow(string path,
            [DisallowNull] KryptonPage[] pages,
                                                                      Point location,
                                                                      Size clientSize)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking floating element
            if (ResolvePath(path) is not KryptonDockingFloating floating)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingFloating", nameof(path));
            }

            // Create a new floating window and add the provided array of pages
            KryptonDockingFloatingWindow floatingWindow = floating.AddFloatingWindow();
            floatingWindow.FloatspaceElement.Append(pages);

            // Do we have a location to apply?
            if (!location.IsEmpty)
            {
                floatingWindow.FloatingWindow.Location = location;
            }

            // Do we have a client size to apply?
            if (!clientSize.IsEmpty)
            {
                floatingWindow.FloatingWindow.ClientSize = clientSize;
            }

            // If the window has at least one visible page then show the window now
            if (floatingWindow.FloatspaceElement.VisiblePages > 0)
            {
                floatingWindow.FloatingWindow.Show();
            }

            return floatingWindow;
        }

        /// <summary>
        /// Add set of pages to a docking workspace.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingWorkspace.</param>
        /// <param name="pages">Array of pages to be added.</param>
        /// <returns>KryptonDockingWorkspace reference.</returns>
        public virtual KryptonDockingWorkspace AddToWorkspace(string path, [DisallowNull] KryptonPage[] pages)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking workspace element
            if (ResolvePath(path) is not KryptonDockingWorkspace workspace)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingWorkspace", nameof(path));
            }

            // Append pages to the workspace
            workspace.Append(pages);
            return workspace;
        }

        /// <summary>
        /// Add set of pages to a docking navigator.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingNavigator.</param>
        /// <param name="pages">Array of pages to be added.</param>
        /// <returns>KryptonDockingNavigator reference.</returns>
        public virtual KryptonDockingNavigator AddToNavigator(string path, [DisallowNull] KryptonPage[] pages)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking navigator element
            if (ResolvePath(path) is not KryptonDockingNavigator navigator)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingNavigator", nameof(path));
            }

            // Append pages to the navigator
            navigator.Append(pages);
            return navigator;
        }

        /// <summary>
        /// Add set of pages docked against a specified edge of the specified control.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingControl.</param>
        /// <param name="edge">Target edge within the KryptonDockingControl.</param>
        /// <param name="index">Insert index.</param>
        /// <param name="pages">Array of pages to be added as docked.</param>
        /// <param name="stackPages">Extra arrays of pages to be added in a stacked manner.</param>
        /// <returns>KryptonDockingDockspace reference.</returns>
        public virtual KryptonDockingDockspace InsertDockspace(string path,
                                                               DockingEdge edge,
                                                               int index,
                                                               [DisallowNull] KryptonPage[] pages,
                                                               params KryptonPage[][] stackPages)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking control element
            if (ResolvePath(path) is not KryptonDockingControl control)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingControl", nameof(path));
            }

            // Find the requested target edge
            if (control[edge.ToString()] is not KryptonDockingEdge edgeElement)
            {
                throw new ArgumentException(@"KryptonDockingControl does not have the requested edge.", nameof(edge));
            }

            // Find the docked edge
            if (edgeElement["Docked"] is not KryptonDockingEdgeDocked edgeDocked)
            {
                throw new ArgumentException(@"KryptonDockingControl edge does not have a docked element.", nameof(edge));
            }

            using var update = new DockingMultiUpdate(this);
            // Create a new dockspace and insert the provided array of pages
            KryptonDockingDockspace dockspace = edgeDocked.InsertDockspace(index);
            dockspace.Append(pages);

            // If we have extra pages then we need to add a stack of tabbed cells
            if (stackPages is { Length: > 0 })
            {
                // For each array of pages...
                foreach (var pageArray in stackPages)
                {
                    if (pageArray is { Length: > 0 })
                    {
                        // We need a new cell with all the pages from the array
                        var cell = new KryptonWorkspaceCell();
                        cell.Pages.AddRange(pageArray);

                        // Add into the root collection so the cells appear in a stack
                        dockspace.DockspaceControl.Root.Children?.Add(cell);
                    }
                }

                // Set the correct direction for the stacking of cells at the root
                switch (edge)
                {
                    case DockingEdge.Left:
                    case DockingEdge.Right:
                        dockspace.DockspaceControl.Root.Orientation = Orientation.Vertical;
                        break;
                    case DockingEdge.Top:
                    case DockingEdge.Bottom:
                        dockspace.DockspaceControl.Root.Orientation = Orientation.Horizontal;
                        break;
                }
            }

            return dockspace;
        }

        /// <summary>
        /// Add set of pages as a new auto hidden group to the specified edge of the specified control.
        /// </summary>
        /// <param name="path">Path for finding the target KryptonDockingControl.</param>
        /// <param name="edge">Target edge within the KryptonDockingControl.</param>
        /// <param name="index">Insert index.</param>
        /// <param name="pages">Array of pages to be added as an auto hidden group.</param>
        /// <param name="extraPages">Extra arrays of pages to be added as extra groups.</param>
        /// <returns>KryptonDockingAutoHiddenGroup reference.</returns>
        public virtual KryptonDockingAutoHiddenGroup InsertAutoHiddenGroup(string path,
                                                                           DockingEdge edge,
                                                                           int index,
                                                                           [DisallowNull] KryptonPage[] pages,
                                                                           params KryptonPage[][] extraPages)
        {
            // Cannot add a null array
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Array must contain some values
            if (pages.Length == 0)
            {
                throw new ArgumentException(@"pages cannot be zero length", nameof(pages));
            }

            // Cannot action a null page reference
            if (pages.Any(static page => page == null))
            {
                throw new ArgumentNullException(nameof(pages), @"pages array contains a null page reference");
            }

            // Resolve the given path to the expected docking control element
            if (ResolvePath(path) is not KryptonDockingControl control)
            {
                throw new ArgumentException(@"Path does not resolve to a KryptonDockingControl", nameof(path));
            }

            // Find the requested target edge
            if (control[edge.ToString()] is not KryptonDockingEdge edgeElement)
            {
                throw new ArgumentException(@"KryptonDockingControl does not have the requested edge.", nameof(edge));
            }

            // Find the auto hidden edge
            if (edgeElement[@"AutoHidden"] is not KryptonDockingEdgeAutoHidden edgeAutoHidden)
            {
                throw new ArgumentException(@"KryptonDockingControl edge does not have an auto hidden element.", nameof(edge));
            }

            using var update = new DockingMultiUpdate(this);
            // Create a new auto hidden group and add the provided array of pages
            KryptonDockingAutoHiddenGroup autoHiddenGroup = edgeAutoHidden.InsertAutoHiddenGroup(index);
            autoHiddenGroup.Append(pages);

            // If we have extra pages then we need to add extra auto hidden groups
            if (extraPages is { Length: > 0 })
            {
                // For each array of pages...
                foreach (var pageArray in extraPages)
                {
                    if (pageArray is { Length: > 0 })
                    {
                        // Create a new auto hidden group and add the provided array of pages
                        KryptonDockingAutoHiddenGroup extraAutoHiddenGroup = edgeAutoHidden.AppendAutoHiddenGroup();
                        extraAutoHiddenGroup.Append(pageArray);
                    }
                }
            }

            return autoHiddenGroup;
        }

        /// <summary>
        /// Generate an implementation of the IDragPageNotify class that will be used to handle the drag/drop operation.
        /// </summary>
        /// <param name="screenPoint">Screen point of the mouse for the drag operation.</param>
        /// <param name="elementOffset">Offset from top left of element causing the drag.</param>
        /// <param name="c">Control that started the drag operation.</param>
        /// <param name="pages">Set of pages requested to be dragged.</param>
        public virtual void DoDragDrop(Point screenPoint, Point elementOffset, Control c,
            [DisallowNull] KryptonPageCollection pages)
        {
            // Cannot drag a null reference
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            // Cannot drag an empty collection
            if (!pages.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(pages), @"collection cannot be empty");
            }

            // Create docking specific drag manager for moving the pages around
            var dragManager = new DockingDragManager(this, c)
            {
                FloatingWindowOffset = elementOffset
            };

            var atLeastOneFloating = false;
            KryptonPage firstFloatingPage = null!;  // this is protected by the `atLeastOneFloating` local var.
            foreach (KryptonPage? page in pages.Where(static page => page is not KryptonStorePage))
            {
                // Cannot drag a null page reference
                if (page == null)
                {
                    throw new ArgumentNullException(nameof(pages), @"pages collection contains a null page reference");
                }

                // Remember the first page that is allowed to be made floating
                if (!atLeastOneFloating && page.AreFlagsSet(KryptonPageFlags.DockingAllowFloating))
                {
                    // Use event to indicate the page is becoming floating and allow it to be cancelled
                    var args = new CancelUniqueNameEventArgs(page.UniqueName, false);
                    OnPageFloatingRequest(args);

                    if (!args.Cancel)
                    {
                        firstFloatingPage = page;
                        atLeastOneFloating = true;
                    }
                }
            }

            // If we have at least one page that is allowed to be floating
            if (atLeastOneFloating)
            {
                // Can we find an existing floating store page...
                if (FindStorePageElement(DockingLocation.Floating, firstFloatingPage) is KryptonDockingFloatspace floatspace)
                {
                    if (floatspace.GetParentType(typeof(KryptonDockingFloatingWindow)) is KryptonDockingFloatingWindow
                        {
                            FloatingWindow.Visible: false
                        } floatingWindow)
                    // If the floating window is not currently visible...
                    {
                        using var update = new DockingMultiUpdate(this);
                        //...then we can use it for dragging. We want the floating window to become visible and show just the set of pages
                        // that are allowed to be floating from the set of pages passed into this function. As the window is not currently
                        // visible it means all the contained pages are hidden and so we can make only the pages we are interested in visible
                        // and it will have the appearance we need.
                        dragManager.FloatingWindow = floatingWindow.FloatingWindow;

                        // Convert the existing page location, if any, to store and restore it in this floating window
                        KryptonPage[] firstFloatingPages = { firstFloatingPage };
                        PropogateAction(DockingPropogateAction.StorePages, firstFloatingPages);
                        floatingWindow.PropogateAction(DockingPropogateAction.RestorePages, firstFloatingPages);

                        // Make a list of all pages that should be appended to the floating window
                        var appendUniqueNames = new List<string>();
                        var appendPages = new List<KryptonPage>();
                        foreach (KryptonPage page in pages.Where(page =>
                                     page is not KryptonStorePage
                                     && (page != firstFloatingPage)
                                     && page.AreFlagsSet(KryptonPageFlags.DockingAllowFloating))
                                )
                        {
                            appendUniqueNames.Add(page.UniqueName);
                            appendPages.Add(page);
                        }

                        // Set the window location before it is shown otherwise we see a brief flash as it appears at the 
                        // existing location and then it moves to the correct location based on the screen mouse position
                        dragManager.FloatingWindow.Location = new Point(screenPoint.X - elementOffset.X, screenPoint.Y - elementOffset.Y);

                        // Convert the append pages to store pages and then append to the same cell as the just restore page above
                        PropogateAction(DockingPropogateAction.StorePages, appendUniqueNames.ToArray());
                        KryptonWorkspaceCell? cell = floatingWindow.CellForPage(firstFloatingPage.UniqueName);
                        cell?.Pages.AddRange(appendPages.ToArray());
                    }
                }

                // Do we need to create a new floating window?
                if (dragManager.FloatingWindow == null)
                {
                    // Get access to a floating element that allows a new floating window to be created
                    KryptonDockingFloating? floating = FindDockingFloating(firstFloatingPage.UniqueName);
                    KryptonDockingFloatingWindow? floatingWindow = floating?.AddFloatingWindow();
                    if (floatingWindow != null)
                    {
                        using var update = new DockingMultiUpdate(this);
                        // This is the window that will be moved during the drag operation
                        dragManager.FloatingWindow = floatingWindow.FloatingWindow;

                        // Make a list of all pages that should be appended to the floating window
                        var appendUniqueNames = new List<string>();
                        var appendPages = new List<KryptonPage>();
                        foreach (KryptonPage page in pages.Where(static page => page is not KryptonStorePage
                                     && page.AreFlagsSet(KryptonPageFlags.DockingAllowFloating))
                                 )
                        {
                            appendUniqueNames.Add(page.UniqueName);
                            appendPages.Add(page);
                        }

                        // Set the window location before it is shown otherwise we see a brief flash as it appears at the 
                        // existing location and then it moves to the correct location based on the screen mouse position
                        dragManager.FloatingWindow.Location = new Point(screenPoint.X - elementOffset.X, screenPoint.Y - elementOffset.Y);

                        // Append the pages inside the new window, storing the current locations for later use
                        PropogateAction(DockingPropogateAction.StorePages, appendUniqueNames.ToArray());
                        floatingWindow.FloatspaceElement.Append(appendPages.ToArray());
                        floatingWindow.FloatingWindow.Show();
                    }
                }
            }

            // Allow workspace controls to compact and update based on changes from above
            Application.DoEvents();

            // Add ourself as a source of drag targets and then begin the dragging process
            dragManager.DragTargetProviders.Add(new DockingDragTargetProvider(this, dragManager.FloatingWindow, pages));
            dragManager.DragStart(screenPoint, new PageDragEndData(this, pages));
        }

        /// <summary>
        /// Generate an implementation of the IDragPageNotify class that will be used to handle the drag/drop operation.
        /// </summary>
        /// <param name="screenPoint">Screen point of the mouse for the drag operation.</param>
        /// <param name="elementOffset">Offset from top left of element causing the drag.</param>
        /// <param name="c">Control that started the drag operation.</param>
        /// <param name="window">Reference to floating window element that should be dragged.</param>
        public virtual void DoDragDrop(Point screenPoint, Point elementOffset, Control? c,
            [DisallowNull] KryptonDockingFloatingWindow window)
        {
            // Cannot drag a null reference
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            // Create a list of all the visible pages inside the floating window
            var pages = new KryptonPageCollection();
            KryptonWorkspaceCell? cell = window.FloatspaceElement.FloatspaceControl.FirstVisibleCell();
            while (cell != null)
            {
                foreach (KryptonPage page in cell.Pages.Where(static page => page is not KryptonStorePage && page.LastVisibleSet))
                {
                    pages.Add(page);
                }

                cell = window.FloatspaceElement.FloatspaceControl.NextVisibleCell(cell);
            }

            // If it actually has any visible contents to be moved
            if (pages.Count > 0)
            {
                // Create docking specific drag manager for moving the pages around
                var dragManager = new DockingDragManager(this, null)
                {
                    FloatingWindow = window.FloatingWindow,
                    FloatingWindowOffset = elementOffset
                };

                // Set the window location before it is shown otherwise we see a brief flash as it appears at the 
                // existing location and then it moves to the correct location based on the screen mouse position
                dragManager.FloatingWindow.Location = new Point(screenPoint.X - elementOffset.X, screenPoint.Y - elementOffset.Y);

                // Add ourself as a source of drag targets and then begin the dragging process
                dragManager.DragTargetProviders.Add(new DockingDragTargetProvider(this, dragManager.FloatingWindow, pages));
                dragManager.DragStart(screenPoint, new PageDragEndData(this, pages));
            }
        }

        /// <summary>
        /// Saves docking configuration information into an array of bytes using Unicode Encoding.
        /// </summary>
        /// <returns>Array of created bytes.</returns>
        public byte[] SaveConfigToArray() => SaveConfigToArray(Encoding.Unicode);

        /// <summary>
        /// Saves docking configuration information into an array of bytes.
        /// </summary>
        /// <param name="encoding">Required encoding.</param>
        /// <returns>Array of created bytes.</returns>
        public byte[] SaveConfigToArray(Encoding encoding)
        {
            // Save into the file stream
            var ms = new MemoryStream();
            SaveConfigToStream(ms, encoding);
            ms.Close();

            // Return an array of bytes that contain the streamed XML
            return ms.GetBuffer();
        }

        /// <summary>
        /// Saves docking configuration information into a named file using Unicode Encoding.
        /// </summary>
        /// <param name="filename">Name of file to save to.</param>
        public void SaveConfigToFile(string filename) => SaveConfigToFile(filename, Encoding.Unicode);

        /// <summary>
        /// Saves docking configuration information into a named file.
        /// </summary>
        /// <param name="filename">Name of file to save to.</param>
        /// <param name="encoding">Required encoding.</param>
        public void SaveConfigToFile(string filename, Encoding encoding)
        {
            // Create/Overwrite existing file
            var fs = new FileStream(filename, FileMode.Create);

            try
            {
                // Save into the file stream
                SaveConfigToStream(fs, encoding);
            }
            catch
            {
                fs.Close();
            }
        }

        /// <summary>
        /// Saves docking configuration information into a stream object.
        /// </summary>
        /// <param name="stream">Stream object.</param>
        /// <param name="encoding">Required encoding.</param>
        public void SaveConfigToStream(Stream stream, Encoding encoding)
        {
            var xmlWriter = new XmlTextWriter(stream, encoding)
            {

                // Use indenting for readability
                Formatting = Formatting.Indented
            };
            xmlWriter.WriteStartDocument();
            SaveConfigToXml(xmlWriter);
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        /// <summary>
        /// Saves docking configuration information using a provider xml writer.
        /// </summary>
        /// <param name="xmlWriter">Xml writer object.</param>
        public void SaveConfigToXml(XmlWriter xmlWriter)
        {
            // Remember the current culture setting
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            try
            {
                // Associate a version number with the root element so that future versions of the code
                // will be able to be backwards compatible or at least recognize incompatible versions
                xmlWriter.WriteStartElement(@"KD");
                xmlWriter.WriteAttributeString(@"V", @"1");

                // Give event handlers chance to embed custom data
                xmlWriter.WriteStartElement(@"DGD");
                OnGlobalSaving(new DockGlobalSavingEventArgs(this, xmlWriter));
                xmlWriter.WriteEndElement();

                // The element saves itself and all children recursively
                SaveElementToXml(xmlWriter);

                // Terminate the root element and document        
                xmlWriter.WriteEndElement();
            }
            finally
            {
                // Put back the old culture before exiting routine
                Thread.CurrentThread.CurrentCulture = culture;
            }
        }

        /// <summary>
        /// Loads docking configuration information from given array of bytes.
        /// </summary>
        /// <param name="buffer">Array of source bytes.</param>
        public void LoadConfigFromArray(byte[] buffer)
        {
            var ms = new MemoryStream(buffer);
            LoadConfigFromStream(ms);
            ms.Close();
        }

        /// <summary>
        /// Loads docking configuration information from given filename.
        /// </summary>
        /// <param name="filename">Name of file to read from.</param>
        public void LoadConfigFromArray(string filename)
        {
            // Open existing file
            var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                // Load from the file stream
                LoadConfigFromStream(fs);
            }
            catch
            {
                // Must remember to close
                fs.Close();
            }
        }

        /// <summary>
        /// Loads docking configuration information from given filename.
        /// </summary>
        /// <param name="filename">Name of file to read from.</param>
        public void LoadConfigFromFile(string filename)
        {
            // Open existing file
            var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                // Load from the file stream
                LoadConfigFromStream(fs);
            }
            catch
            {
                // Must remember to close
                fs.Close();
            }
        }

        /// <summary>
        /// Loads docking configuration information from given stream object.
        /// </summary>
        /// <param name="stream">Stream object.</param>
        public void LoadConfigFromStream(Stream stream)
        {
            var xmlReader = new XmlTextReader(stream)
            {
                WhitespaceHandling = WhitespaceHandling.None
            };
            xmlReader.MoveToContent();

            // Use existing method to load from xml
            LoadConfigFromXml(xmlReader);
            xmlReader.Close();
        }

        /// <summary>
        /// Loads docking configuration information using the provided xml reader.
        /// </summary>
        /// <param name="xmlReader">Xml reader object.</param>
        public void LoadConfigFromXml(XmlReader xmlReader)
        {
            // Remember the current culture setting
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            try
            {
                // Double check this has the correct element name
                if (xmlReader.Name != @"KD")
                {
                    throw new ArgumentException(@"Root element must be named 'KD'", nameof(xmlReader));
                }

                // Load the format version number
                var version = xmlReader.GetAttribute(@"V");

                // Convert format version from string to double
                var formatVersion = (int)Convert.ToDouble(version);

                // We can only load 1 upward version formats
                if (formatVersion < 1)
                {
                    throw new ArgumentException(@"Can only load Version 1 and upwards of KryptonDockingManager persisted data.");
                }

                using var update = new DockingMultiUpdate(this);
                // Create a list of all the existing pages
                var currentPages = new KryptonPageCollection();
                PropogatePageList(DockingPropogatePageList.All, currentPages);

                // Reset docking hierarchy ready for the reload
                PropogateAction(DockingPropogateAction.Loading, null as string[]);

                // Read to custom data element
                if (!xmlReader.Read())
                {
                    throw new ArgumentException(@"An element was expected but could not be read in.", nameof(xmlReader));
                }

                if (xmlReader.Name != @"DGD")
                {
                    throw new ArgumentException(@"Expected 'DGD' element was not found.", nameof(xmlReader));
                }

                var finished = xmlReader.IsEmptyElement;

                // Give handlers chance to reload custom saved data
                OnGlobalLoading(new DockGlobalLoadingEventArgs(this, xmlReader));

                // Read everything until we get the end of custom data marker
                while (!finished)
                {
                    // Check it has the expected name
                    if (xmlReader.NodeType == XmlNodeType.EndElement)
                    {
                        finished = (xmlReader.Name == @"DGD");
                    }

                    if (!finished)
                    {
                        if (!xmlReader.Read())
                        {
                            throw new ArgumentException(@"An element was expected but could not be read in.", nameof(xmlReader));
                        }
                    }
                }

                // Read the next well known element
                if (!xmlReader.Read())
                {
                    throw new ArgumentException(@"An element was expected but could not be read in.", nameof(xmlReader));
                }

                // Is it the expected element?
                if (xmlReader.Name != @"DM")
                {
                    throw new ArgumentException(@"Element 'DM' was expected but not found.", nameof(xmlReader));
                }

                // Reload the root sequence
                LoadElementFromXml(xmlReader, currentPages);

                // Move past the end element
                if (!xmlReader.Read())
                {
                    throw new ArgumentException(@"Could not read in next expected node.", nameof(xmlReader));
                }

                // Check it has the expected name
                if (xmlReader.NodeType != XmlNodeType.EndElement)
                {
                    throw new ArgumentException(@"EndElement expected but not found.", nameof(xmlReader));
                }

                // Did we have any starting pages?
                if (currentPages.Count > 0)
                {
                    // Create a list of all the pages present after loading
                    var loadedPages = new KryptonPageCollection();
                    PropogatePageList(DockingPropogatePageList.All, loadedPages);

                    // Remove the loaded pages from the current page list
                    foreach (KryptonPage loadedPage in loadedPages)
                    {
                        currentPages.Remove(loadedPage);
                    }

                    // Did we any orphan pages? Those that existed at start of loading but
                    // are not present in the docking hierarchy after loading. So they are
                    // orphaned and we allow developers a chance to do something with them.
                    if (currentPages.Count > 0)
                    {
                        // Generate event so the pages can be processed manually
                        var args = new PagesEventArgs(currentPages);
                        OnOrphanedPages(args);

                        // If there are pages not processed by the event
                        if (args.Pages.Count > 0)
                        {
                            // Cleanup the no longer needed pages by disposing them
                            foreach (KryptonPage page in args.Pages)
                            {
                                page.Dispose();
                            }
                        }
                    }
                }
            }
            finally
            {
                // Put back the old culture before exiting routine
                Thread.CurrentThread.CurrentCulture = culture;
            }
        }

        /// <summary>
        /// Gets an array of all the pages inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonPage[] Pages
        {
            get
            {
                var pages = new KryptonPageCollection();
                PropogatePageList(DockingPropogatePageList.All, pages);
                return ArrayFromCollection(pages);
            }
        }

        /// <summary>
        /// Gets an array of all the pages docked inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonPage[] PagesDocked
        {
            get
            {
                var pages = new KryptonPageCollection();
                PropogatePageList(DockingPropogatePageList.Docked, pages);
                return ArrayFromCollection(pages);
            }
        }

        /// <summary>
        /// Gets an array of all the pages auto hidden inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonPage[] PagesAutoHidden
        {
            get
            {
                var pages = new KryptonPageCollection();
                PropogatePageList(DockingPropogatePageList.AutoHidden, pages);
                return ArrayFromCollection(pages);
            }
        }

        /// <summary>
        /// Gets an array of all the pages floating inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonPage[] PagesFloating
        {
            get
            {
                var pages = new KryptonPageCollection();
                PropogatePageList(DockingPropogatePageList.Floating, pages);
                return ArrayFromCollection(pages);
            }
        }

        /// <summary>
        /// Gets an array of all the pages inside a dockable workspace inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonPage[] PagesWorkspace
        {
            get
            {
                var pages = new KryptonPageCollection();
                PropogatePageList(DockingPropogatePageList.Filler, pages);
                return ArrayFromCollection(pages);
            }
        }

        /// <summary>
        /// Gets an array of all the cells inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonWorkspaceCell[] Cells
        {
            get
            {
                var cells = new KryptonWorkspaceCellList();
                PropogateCellList(DockingPropogateCellList.All, cells);
                return cells.ToArray();
            }
        }

        /// <summary>
        /// Gets an array of all the cells docked inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonWorkspaceCell[] CellsDocked
        {
            get
            {
                var cells = new KryptonWorkspaceCellList();
                PropogateCellList(DockingPropogateCellList.Docked, cells);
                return cells.ToArray();
            }
        }

        /// <summary>
        /// Gets an array of all the cells floating inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonWorkspaceCell[] CellsFloating
        {
            get
            {
                var cells = new KryptonWorkspaceCellList();
                PropogateCellList(DockingPropogateCellList.Floating, cells);
                return cells.ToArray();
            }
        }

        /// <summary>
        /// Gets an array of all the cells inside a dockable workspace inside the docking hierarchy.
        /// </summary>
        [Browsable(false)]
        public virtual KryptonWorkspaceCell[] CellsWorkspace
        {
            get
            {
                var cells = new KryptonWorkspaceCellList();
                PropogateCellList(DockingPropogateCellList.Workspace, cells);
                return cells.ToArray();
            }
        }

        /// <summary>
        /// Return the cell the page belongs to, when available (JDH Software add)
        /// </summary>
        /// <param name="uniqueName">The uniqueName of the page.</param>
        /// <returns>The KryptonWorkspaceCell.</returns>
        public KryptonWorkspaceCell? DockingCellForPage(string uniqueName)
        {
            //Action depends on current location of the page
            switch (FindPageLocation(uniqueName))
            {
                case DockingLocation.Docked:
                    {
                        // Unique name page must be inside a Dockspace instance
                        var dockspace = FindPageElement(uniqueName) as KryptonDockingDockspace;
                        // Find the cell containing the unique name page
                        return dockspace?.CellForPage(uniqueName);
                    }

                case DockingLocation.Floating:
                    {
                        // Unique name page must be inside a Dockspace instance
                        var floatspace = FindPageElement(uniqueName) as KryptonDockingFloatspace;
                        // Find the cell containing the unique name page
                        return floatspace?.CellForPage(uniqueName);
                    }

                case DockingLocation.Workspace:
                    {
                        var workspace = FindPageElement(uniqueName) as KryptonDockingWorkspace;
                        // Find the cell containing the unique name page
                        return workspace?.CellForPage(uniqueName);
                    }

                case DockingLocation.AutoHidden:
                case DockingLocation.Navigator:
                case DockingLocation.Custom:
                case DockingLocation.None:
                default:
                    return null;
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the AutoHiddenSeparatorResize event.
        /// </summary>
        /// <param name="e">An AutoHiddenSeparatorResizeEventArgs containing the event args.</param>
        protected virtual void OnAutoHiddenSeparatorResize(AutoHiddenSeparatorResizeEventArgs e) => AutoHiddenSeparatorResize?.Invoke(this, e);

        /// <summary>
        /// Raises the PageCloseRequest event.
        /// </summary>
        /// <param name="e">An CloseActionEventArgs containing the event args.</param>
        protected virtual void OnPageCloseRequest(CloseRequestEventArgs e) => PageCloseRequest?.Invoke(this, e);

        /// <summary>
        /// Raises the PageDockedRequest event.
        /// </summary>
        /// <param name="e">An CancelUniqueNameEventArgs containing the event args.</param>
        protected virtual void OnPageDockedRequest(CancelUniqueNameEventArgs e) => PageDockedRequest?.Invoke(this, e);

        /// <summary>
        /// Raises the PageAutoHiddenRequest event.
        /// </summary>
        /// <param name="e">An CancelUniqueNameEventArgs containing the event args.</param>
        protected virtual void OnPageAutoHiddenRequest(CancelUniqueNameEventArgs e) => PageAutoHiddenRequest?.Invoke(this, e);

        /// <summary>
        /// Raises the PageFloatingRequest event.
        /// </summary>
        /// <param name="e">An CancelUniqueNameEventArgs containing the event args.</param>
        protected virtual void OnPageFloatingRequest(CancelUniqueNameEventArgs e) => PageFloatingRequest?.Invoke(this, e);

        /// <summary>
        /// Raises the PageWorkspaceRequest event.
        /// </summary>
        /// <param name="e">An CancelUniqueNameEventArgs containing the event args.</param>
        protected virtual void OnPageWorkspaceRequest(CancelUniqueNameEventArgs e) => PageWorkspaceRequest?.Invoke(this, e);

        /// <summary>
        /// Raises the PageNavigatorRequest event.
        /// </summary>
        /// <param name="e">An CancelUniqueNameEventArgs containing the event args.</param>
        protected virtual void OnPageNavigatorRequest(CancelUniqueNameEventArgs e) => PageNavigatorRequest?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceSeparatorResize event.
        /// </summary>
        /// <param name="e">An DockspaceSeparatorResizeEventArgs containing the event args.</param>
        protected virtual void OnDockspaceSeparatorResize(DockspaceSeparatorResizeEventArgs e) => DockspaceSeparatorResize?.Invoke(this, e);

        /// <summary>
        /// Raises the ShowPageContextMenu event.
        /// </summary>
        /// <param name="e">An ContextPageEventArgs containing the event args.</param>
        protected virtual void OnShowPageContextMenu(ContextPageEventArgs e) => ShowPageContextMenu?.Invoke(this, e);

        /// <summary>
        /// Raises the ShowWorkspacePageContextMenu event.
        /// </summary>
        /// <param name="e">An ContextPageEventArgs containing the event args.</param>
        protected virtual void OnShowWorkspacePageContextMenu(ContextPageEventArgs e) => ShowWorkspacePageContextMenu?.Invoke(this, e);

        /// <summary>
        /// Raises the GlobalSaving event.
        /// </summary>
        /// <param name="e">An DockGlobalSavingEventArgs containing event data.</param>
        protected virtual void OnGlobalSaving(DockGlobalSavingEventArgs e) => GlobalSaving?.Invoke(this, e);

        /// <summary>
        /// Raises the GlobalLoading event.
        /// </summary>
        /// <param name="e">An DockGlobalLoadingEventArgs containing event data.</param>
        protected virtual void OnGlobalLoading(DockGlobalLoadingEventArgs e) => GlobalLoading?.Invoke(this, e);

        /// <summary>
        /// Raises the PageSaving event.
        /// </summary>
        /// <param name="e">An DockPageSavingEventArgs containing event data.</param>
        protected virtual void OnPageSaving(DockPageSavingEventArgs e) => PageSaving?.Invoke(this, e);

        /// <summary>
        /// Raises the PageLoading event.
        /// </summary>
        /// <param name="e">An DockPageLoadingEventArgs containing event data.</param>
        protected virtual void OnPageLoading(DockPageLoadingEventArgs e) => PageLoading?.Invoke(this, e);

        /// <summary>
        /// Raises the OrphanedPages event.
        /// </summary>
        /// <param name="e">An PagesEventArgs containing event data.</param>
        protected virtual void OnOrphanedPages(PagesEventArgs e) => OrphanedPages?.Invoke(this, e);

        /// <summary>
        /// Raises the RecreateLoadingPage event.
        /// </summary>
        /// <param name="e">An RecreateLoadingPageEventArgs containing event data.</param>
        protected virtual void OnRecreateLoadingPage(RecreateLoadingPageEventArgs e) => RecreateLoadingPage?.Invoke(this, e);

        /// <summary>
        /// Raises the AutoHiddenGroupAdding event.
        /// </summary>
        /// <param name="e">An AutoHiddenGroupEventArgs containing the event args.</param>
        protected virtual void OnAutoHiddenGroupAdding(AutoHiddenGroupEventArgs e) => AutoHiddenGroupAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the AutoHiddenGroupRemoved event.
        /// </summary>
        /// <param name="e">An AutoHiddenGroupEventArgs containing the event args.</param>
        protected virtual void OnAutoHiddenGroupRemoved(AutoHiddenGroupEventArgs e) => AutoHiddenGroupRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the AutoHiddenGroupPanelAdding event.
        /// </summary>
        /// <param name="e">An AutoHiddenGroupPanelEventArgs containing the event args.</param>
        protected virtual void OnAutoHiddenGroupPanelAdding(AutoHiddenGroupPanelEventArgs e) => AutoHiddenGroupPanelAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the AutoHiddenGroupPanelRemoved event.
        /// </summary>
        /// <param name="e">An AutoHiddenGroupPanelEventArgs containing the event args.</param>
        protected virtual void OnAutoHiddenGroupPanelRemoved(AutoHiddenGroupPanelEventArgs e) => AutoHiddenGroupPanelRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the DockableWorkspaceAdded event.
        /// </summary>
        /// <param name="e">An DockableWorkspaceEventArgs containing the event args.</param>
        protected virtual void OnDockableWorkspaceAdded(DockableWorkspaceEventArgs e) => DockableWorkspaceAdded?.Invoke(this, e);

        /// <summary>
        /// Raises the DockableWorkspaceRemoved event.
        /// </summary>
        /// <param name="e">An DockableWorkspaceEventArgs containing the event args.</param>
        protected virtual void OnDockableWorkspaceRemoved(DockableWorkspaceEventArgs e) => DockableWorkspaceRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the DockableNavigatorAdded event.
        /// </summary>
        /// <param name="e">An DockableNavigatorEventArgs containing the event args.</param>
        protected virtual void OnDockableNavigatorAdded(DockableNavigatorEventArgs e) => DockableNavigatorAdded?.Invoke(this, e);

        /// <summary>
        /// Raises the DockableNavigatorRemoved event.
        /// </summary>
        /// <param name="e">An DockableNavigatorEventArgs containing the event args.</param>
        protected virtual void OnDockableNavigatorRemoved(DockableNavigatorEventArgs e) => DockableNavigatorRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the DockableWorkspaceCellAdding event.
        /// </summary>
        /// <param name="e">An DockableWorkspaceCellEventArgs containing the event args.</param>
        protected virtual void OnDockableWorkspaceCellAdding(DockableWorkspaceCellEventArgs e) => DockableWorkspaceCellAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the DockableWorkspaceCellRemoved event.
        /// </summary>
        /// <param name="e">An DockableWorkspaceCellEventArgs containing the event args.</param>
        protected virtual void OnDockableWorkspaceCellRemoved(DockableWorkspaceCellEventArgs e) => DockableWorkspaceCellRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceAdding event.
        /// </summary>
        /// <param name="e">An DockspaceAddingEventArgs containing the event args.</param>
        protected virtual void OnDockspaceAdding(DockspaceEventArgs e) => DockspaceAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceRemoved event.
        /// </summary>
        /// <param name="e">An DockspaceAddingEventArgs containing the event args.</param>
        protected virtual void OnDockspaceRemoved(DockspaceEventArgs e) => DockspaceRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceCellAdding event.
        /// </summary>
        /// <param name="e">An DockspaceCellEventArgs containing the event args.</param>
        protected virtual void OnDockspaceCellAdding(DockspaceCellEventArgs e) => DockspaceCellAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceCellRemoved event.
        /// </summary>
        /// <param name="e">An DockspaceCellEventArgs containing the event args.</param>
        protected virtual void OnDockspaceCellRemoved(DockspaceCellEventArgs e) => DockspaceCellRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceSeparatorAdding event.
        /// </summary>
        /// <param name="e">An DockspaceSeparatorEventArgs containing the event args.</param>
        protected virtual void OnDockspaceSeparatorAdding(DockspaceSeparatorEventArgs e) => DockspaceSeparatorAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the DockspaceSeparatorRemoved event.
        /// </summary>
        /// <param name="e">An DockspaceSeparatorEventArgs containing the event args.</param>
        protected virtual void OnDockspaceSeparatorRemoved(DockspaceSeparatorEventArgs e) => DockspaceSeparatorRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the FloatspaceAdding event.
        /// </summary>
        /// <param name="e">An FloatspaceEventArgs containing the event args.</param>
        protected virtual void OnFloatspaceAdding(FloatspaceEventArgs e) => FloatspaceAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the FloatspaceRemoved event.
        /// </summary>
        /// <param name="e">An FloatspaceEventArgs containing the event args.</param>
        protected virtual void OnFloatspaceRemoved(FloatspaceEventArgs e) => FloatspaceRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the FloatspaceCellAdding event.
        /// </summary>
        /// <param name="e">An FloatspaceCellEventArgs containing the event args.</param>
        protected virtual void OnFloatspaceCellAdding(FloatspaceCellEventArgs e) => FloatspaceCellAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the FloatspaceCellRemoved event.
        /// </summary>
        /// <param name="e">An FloatspaceCellEventArgs containing the event args.</param>
        protected virtual void OnFloatspaceCellRemoved(FloatspaceCellEventArgs e) => FloatspaceCellRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the FloatingWindowAdding event.
        /// </summary>
        /// <param name="e">An FloatingWindowEventArgs containing the event args.</param>
        protected virtual void OnFloatingWindowAdding(FloatingWindowEventArgs e) => FloatingWindowAdding?.Invoke(this, e);

        /// <summary>
        /// Raises the FloatingWindowRemoved event.
        /// </summary>
        /// <param name="e">An FloatingWindowEventArgs containing the event args.</param>
        protected virtual void OnFloatingWindowRemoved(FloatingWindowEventArgs e) => FloatingWindowRemoved?.Invoke(this, e);

        /// <summary>
        /// Raises the AutoHiddenShowingStateChanged event.
        /// </summary>
        /// <param name="e">An AutoHiddenShowingStateEventArgs containing the event args.</param>
        protected virtual void OnAutoHiddenShowingStateChanged(AutoHiddenShowingStateEventArgs e) => AutoHiddenShowingStateChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the DoDragDropEnd event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event args.</param>
        protected virtual void OnDoDragDropEnd(EventArgs e) => DoDragDropEnd?.Invoke(this, e);

        /// <summary>
        /// Raises the DoDragDropQuit event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event args.</param>
        protected virtual void OnDoDragDropQuit(EventArgs e) => DoDragDropQuit?.Invoke(this, e);

        /// <summary>
        /// Gets the xml element name to use when saving.
        /// </summary>
        protected override string XmlElementName => @"DM";

        #endregion

        #region Internal
        internal void RaisePageDockedRequest(CancelUniqueNameEventArgs e) => OnPageDockedRequest(e);

        internal void RaisePageFloatingRequest(CancelUniqueNameEventArgs e) => OnPageFloatingRequest(e);

        internal void RaisePageNavigatorRequest(CancelUniqueNameEventArgs e) => OnPageNavigatorRequest(e);

        internal void RaisePageWorkspaceRequest(CancelUniqueNameEventArgs e) => OnPageWorkspaceRequest(e);

        internal void RaisePageLoading(DockPageLoadingEventArgs e) => OnPageLoading(e);

        internal void RaisePageSaving(DockPageSavingEventArgs e) => OnPageSaving(e);

        internal void RaiseAutoHiddenSeparatorResize(AutoHiddenSeparatorResizeEventArgs e) => OnAutoHiddenSeparatorResize(e);

        internal void RaiseDockspaceSeparatorResize(DockspaceSeparatorResizeEventArgs e) => OnDockspaceSeparatorResize(e);

        internal void RaiseRecreateLoadingPage(RecreateLoadingPageEventArgs e) => OnRecreateLoadingPage(e);

        internal void RaiseAutoHiddenGroupAdding(AutoHiddenGroupEventArgs e) => OnAutoHiddenGroupAdding(e);

        internal void RaiseAutoHiddenGroupRemoved(AutoHiddenGroupEventArgs e) => OnAutoHiddenGroupRemoved(e);

        internal void RaiseAutoHiddenGroupPanelAdding(AutoHiddenGroupPanelEventArgs e) => OnAutoHiddenGroupPanelAdding(e);

        internal void RaiseAutoHiddenGroupPanelRemoved(AutoHiddenGroupPanelEventArgs e) => OnAutoHiddenGroupPanelRemoved(e);

        internal void RaiseDockableWorkspaceAdded(DockableWorkspaceEventArgs e) => OnDockableWorkspaceAdded(e);

        internal void RaiseDockableWorkspaceRemoved(DockableWorkspaceEventArgs e) => OnDockableWorkspaceRemoved(e);

        internal void RaiseDockableNavigatorAdded(DockableNavigatorEventArgs e) => OnDockableNavigatorAdded(e);

        internal void RaiseDockableNavigatorRemoved(DockableNavigatorEventArgs e) => OnDockableNavigatorRemoved(e);

        internal void RaiseDockableWorkspaceCellAdding(DockableWorkspaceCellEventArgs e) => OnDockableWorkspaceCellAdding(e);

        internal void RaiseDockableWorkspaceCellRemoved(DockableWorkspaceCellEventArgs e) => OnDockableWorkspaceCellRemoved(e);

        internal void RaiseDockspaceAdding(DockspaceEventArgs e) => OnDockspaceAdding(e);

        internal void RaiseDockspaceRemoved(DockspaceEventArgs e) => OnDockspaceRemoved(e);

        internal void RaiseDockspaceCellAdding(DockspaceCellEventArgs e) => OnDockspaceCellAdding(e);

        internal void RaiseDockspaceCellRemoved(DockspaceCellEventArgs e) => OnDockspaceCellRemoved(e);

        internal void RaiseDockspaceSeparatorAdding(DockspaceSeparatorEventArgs e) => OnDockspaceSeparatorAdding(e);

        internal void RaiseDockspaceSeparatorRemoved(DockspaceSeparatorEventArgs e) => OnDockspaceSeparatorRemoved(e);

        internal void RaiseFloatspaceAdding(FloatspaceEventArgs e) => OnFloatspaceAdding(e);

        internal void RaiseFloatspaceRemoved(FloatspaceEventArgs e) => OnFloatspaceRemoved(e);

        internal void RaiseFloatspaceCellAdding(FloatspaceCellEventArgs e) => OnFloatspaceCellAdding(e);

        internal void RaiseFloatspaceCellRemoved(FloatspaceCellEventArgs e) => OnFloatspaceCellRemoved(e);

        internal void RaiseFloatingWindowAdding(FloatingWindowEventArgs e) => OnFloatingWindowAdding(e);

        internal void RaiseFloatingWindowRemoved(FloatingWindowEventArgs e) => OnFloatingWindowRemoved(e);

        internal void RaiseAutoHiddenShowingStateChanged(AutoHiddenShowingStateEventArgs e) => OnAutoHiddenShowingStateChanged(e);

        internal void RaiseDoDragDropEnd(EventArgs e) => OnDoDragDropEnd(e);

        internal void RaiseDoDragDropQuit(EventArgs e) => OnDoDragDropQuit(e);

        #endregion

        #region Implementation
        private void InitializeManager()
        {
            Strings = new DockingManagerStrings(this);
            Strings.PropertyChanged += OnStringPropertyChanged;
            DefaultCloseRequest = DockingCloseRequest.HidePage;
        }

        [return: NotNull]
        private IDockingElement? ExpectPageElement(string uniqueName, Type target)
        {
            IDockingElement? element = FindPageElement(uniqueName);

            // We expect that the provided unique name does have an associated element
            if (element == null)
            {
                throw new ApplicationException(@"Cannot find a docking element for the provided unique name");
            }

            // We expect the element to be an exact type
            if (element.GetType() != target)
            {
                throw new ApplicationException($@"Docking element of type '{element.GetType()}' found when type '{target}' was expected");
            }

            return element;
        }

        private static void RemoveControlStorePages(DockingElement element, string[] uniqueNames, bool autoHidden, bool docked)
        {
            // Find the control element from the provided starting point
            KryptonDockingControl? control = element as KryptonDockingControl ?? element.GetParentType(typeof(KryptonDockingControl)) as KryptonDockingControl;

            // If we managed to find a docking control element to work with
            if (control != null)
            {
                // Enumerate all the child elements
                foreach (IDockingElement child in control)
                {
                    // We are only interested in the edge elements
                    if (child is KryptonDockingEdge edge)
                    {
                        // Do we need to clear auto hidden elements?
                        if (autoHidden)
                        {
                            if (edge[@"AutoHidden"] is KryptonDockingEdgeAutoHidden autoHiddenEdge)
                            {
                                autoHiddenEdge.PropogateAction(DockingPropogateAction.ClearStoredPages, uniqueNames);
                            }
                        }

                        // Do we need to clear docked elements?
                        if (docked)
                        {
                            if (edge[@"Docked"] is KryptonDockingEdgeDocked dockedEdge)
                            {
                                dockedEdge.PropogateAction(DockingPropogateAction.ClearStoredPages, uniqueNames);
                            }
                        }
                    }
                }
            }
        }

        private void OnStringPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Piggyback the name of the changed property in the unique name parameter
            string[]? uniqueNames = e.PropertyName is null
                ? null
                : new string[] { e.PropertyName };

            PropogateAction(DockingPropogateAction.StringChanged, uniqueNames);
        }

        private void OnDropDownWorkspaceClicked(object? sender, EventArgs e)
        {
            var workspaceItem = sender as KryptonContextMenuItem ?? throw new ArgumentNullException(nameof(sender));

            // Action depends on the current location
            if (workspaceItem.Tag is string uniqueName)
            {
                switch (FindPageLocation(uniqueName))
                {
                    case DockingLocation.None:
                    case DockingLocation.AutoHidden:
                    case DockingLocation.Floating:
                    case DockingLocation.Docked:
                    case DockingLocation.Navigator:
                        MakeWorkspaceRequest(uniqueName);
                        break;
                    case DockingLocation.Workspace:
                        // Nothing to do, already workspace tabbed
                        break;
                }
            }
        }

        private void OnDropDownNavigatorClicked(object? sender, EventArgs e)
        {
            var workspaceItem = sender as KryptonContextMenuItem ?? throw new ArgumentNullException(nameof(sender));

            if (workspaceItem.Tag is string uniqueName)
            {
                // Action depends on the current location
                switch (FindPageLocation(uniqueName))
                {
                    case DockingLocation.None:
                    case DockingLocation.AutoHidden:
                    case DockingLocation.Floating:
                    case DockingLocation.Docked:
                    case DockingLocation.Workspace:
                        MakeNavigatorRequest(uniqueName);
                        break;
                    case DockingLocation.Navigator:
                        // Nothing to do, already workspace tabbed
                        break;
                }
            }
        }

        private void OnDropDownAutoHiddenClicked(object? sender, EventArgs e)
        {
            var autoHiddenItem = sender as KryptonContextMenuItem ?? throw new ArgumentNullException(nameof(sender));

            if (autoHiddenItem.Tag is string uniqueName)
            {
                // Action depends on the current location
                switch (FindPageLocation(uniqueName))
                {
                    case DockingLocation.None:
                    case DockingLocation.Docked:
                    case DockingLocation.Floating:
                    case DockingLocation.Navigator:
                    case DockingLocation.Workspace:
                        MakeAutoHiddenRequest(uniqueName);
                        break;
                    case DockingLocation.AutoHidden:
                        // Nothing to do, already auto hidden
                        break;
                }
            }
        }

        private void OnDropDownDockedClicked(object? sender, EventArgs e)
        {
            var dockedItem = sender as KryptonContextMenuItem ?? throw new ArgumentNullException(nameof(sender));

            if (dockedItem.Tag is string uniqueName)
            {
                // Action depends on the current location
                switch (FindPageLocation(uniqueName))
                {
                    case DockingLocation.None:
                    case DockingLocation.AutoHidden:
                    case DockingLocation.Floating:
                    case DockingLocation.Navigator:
                    case DockingLocation.Workspace:
                        MakeDockedRequest(uniqueName);
                        break;
                    case DockingLocation.Docked:
                        // Nothing to do, already docked
                        break;
                }
            }
        }

        private void OnDropDownFloatingClicked(object? sender, EventArgs e)
        {
            // Get the unique name of the page that needs to be converted to floating
            var floatingItem = sender as KryptonContextMenuItem ?? throw new ArgumentNullException(nameof(sender));

            if (floatingItem.Tag is string uniqueName)
            {
                // Action depends on the current location
                switch (FindPageLocation(uniqueName))
                {
                    case DockingLocation.None:
                    case DockingLocation.AutoHidden:
                    case DockingLocation.Docked:
                    case DockingLocation.Navigator:
                    case DockingLocation.Workspace:
                        MakeFloatingRequest(uniqueName);
                        break;
                    case DockingLocation.Floating:
                        // Nothing to do, already floating
                        break;
                }
            }
        }

        private void OnDropDownCloseClicked(object? sender, EventArgs e)
        {
            var closeItem = sender as KryptonContextMenuItem ?? throw new ArgumentNullException(nameof(sender));
            CloseRequest(new[] { (closeItem.Tag as string) ?? string.Empty });
        }

        private static KryptonPage[] ArrayFromCollection(KryptonPageCollection pages)
        {
            // Convert collection to array
            var array = new KryptonPage[pages.Count];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = pages[i];
            }

            return array;
        }
        #endregion
    }
}
