﻿#region BSD License
/*
 *
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, (Version 4.5.0.0) All rights reserved.
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2017 - 2025. All rights reserved.
 *
 */
#endregion

namespace Krypton.Toolkit
{
    /// <summary>
    /// Provides the White color scheme variant of the Office 2013 palette.
    /// </summary>
    public class PaletteOffice2013White : PaletteOffice2013WhiteBase
    {
        #region Static Fields

        #region Colors

        private readonly Color _tabRowBackgroundColor = Color.White;

        #endregion

        #region Ribbon Specific Colors

        private static readonly Color _ribbonAppButtonDarkColor = GlobalStaticValues.DEFAULT_RIBBON_FILE_APP_TAB_BOTTOM_COLOR;

        private static readonly Color _ribbonAppButtonLightColor = GlobalStaticValues.DEFAULT_RIBBON_FILE_APP_TAB_TOP_COLOR;

        private static readonly Color _ribbonAppButtonTextColor = GlobalStaticValues.DEFAULT_RIBBON_FILE_APP_TAB_TEXT_COLOR;

        #endregion

        #region Image Lists

        private static readonly ImageList _checkBoxList;
        private static readonly ImageList _galleryButtonList;

        #endregion

        #region Image Array

        private static readonly Image?[] _radioButtonArray;

        #endregion

        #region Images

        private static readonly Image? _silverDropDownButton = Office2010ArrowResources.Office2010BlueDropDownButton;
        private static readonly Image? _contextMenuSubMenu = Office2010ArrowResources.Office2010BlueContextMenuSub;
        private static readonly Image _formCloseNormal = Office2013ControlBoxResources.Office2013CloseNormal;
        private static readonly Image _formCloseDisabled = Office2013ControlBoxResources.Office2013CloseDisabled;
        private static readonly Image _formCloseActive = Office2013ControlBoxResources.Office2013CloseActive;
        private static readonly Image _formClosePressed = Office2013ControlBoxResources.Office2013ClosePressed;
        private static readonly Image _formMaximiseNormal = Office2013ControlBoxResources.Office2013MaximiseNormal;
        private static readonly Image _formMaximiseDisabled = Office2013ControlBoxResources.Office2013MaximiseDisabled;
        private static readonly Image _formMaximiseActive = Office2013ControlBoxResources.Office2013MaximiseActive;
        private static readonly Image _formMaximisePressed = Office2013ControlBoxResources.Office2013MaximisePressed;
        private static readonly Image _formMinimiseNormal = Office2013ControlBoxResources.Office2013MinimiseNormal;
        private static readonly Image _formMinimiseActive = Office2013ControlBoxResources.Office2013MinimiseActive;
        private static readonly Image _formMinimiseDisabled = Office2013ControlBoxResources.Office2013MinimiseDisabled;
        private static readonly Image _formMinimisePressed = Office2013ControlBoxResources.Office2013MinimisePressed;
        private static readonly Image _formRestoreNormal = Office2013ControlBoxResources.Office2013RestoreNormal;
        private static readonly Image _formRestoreDisabled = Office2013ControlBoxResources.Office2013RestoreDisabled;
        private static readonly Image _formRestoreActive = Office2013ControlBoxResources.Office2013RestoreActive;
        private static readonly Image _formRestorePressed = Office2013ControlBoxResources.Office2013RestorePressed;
        private static readonly Image _formHelpNormal = Office2013ControlBoxResources.Office2013HelpNormal;
        private static readonly Image _formHelpActive = Office2013ControlBoxResources.Office2013HelpActive;
        private static readonly Image _formHelpPressed = Office2013ControlBoxResources.Office2013HelpPressed;
        private static readonly Image _formHelpDisabled = Office2013ControlBoxResources.Office2013HelpDisabled;

        #endregion

        #region Color Arrays

        private static readonly Color[] _trackBarColors =
        [
            Color.Red, // Tick marks
            Color.FromArgb(166, 170, 175), // Top track
            Color.FromArgb(226, 220, 235), // Bottom track
            Color.FromArgb(206, 200, 215), // Fill track
            Color.FromArgb(64, Color.White), // Outside position
            Color.FromArgb(80, 81, 82) // Border (normal) position
        ];

        private static readonly Color[] _schemeOfficeColors =
        [
            Color.FromArgb(59, 59, 59), // TextLabelControl
            Color.FromArgb(59, 59, 59), // TextButtonNormal
            Color.Black, // TextButtonChecked
            Color.FromArgb(170, 170, 170), // ButtonNormalBorder1 -n
            Color.FromArgb(170, 170, 170), // ButtonNormalDefaultBorder -n
            Color.FromArgb(253, 253, 253), // ButtonNormalBack1 -n
            Color.FromArgb(253, 253, 253), // ButtonNormalBack2 -n
            Color.FromArgb(235, 235, 235), // ButtonNormalDefaultBack1
            Color.FromArgb(195, 195, 195), // ButtonNormalDefaultBack2
            Color.FromArgb(207, 212, 218), // ButtonNormalNavigatorBack1
            Color.FromArgb(207, 212, 218), // ButtonNormalNavigatorBack2
            Color.White, // PanelClient -n
            Color.FromArgb(207, 212, 218), // PanelAlternative
            Color.FromArgb(213, 213, 213), // ControlBorder -n
            Color.FromArgb(250, 253, 255), // SeparatorHighBorder1
            Color.FromArgb(227, 232, 237), // SeparatorHighBorder2
            Color.FromArgb(255, 255, 255), // HeaderPrimaryBack1 -n
            Color.FromArgb(255, 255, 255), // HeaderPrimaryBack2 -n
            Color.FromArgb(255, 255, 255), // HeaderSecondaryBack1
            Color.FromArgb(255, 255, 255), // HeaderSecondaryBack2-n
            Color.FromArgb(255, 255, 255), // HeaderText (59, 59, 59)
            Color.FromArgb(255, 255, 255), // StatusStripText
            Color.FromArgb(236, 199, 87), // ButtonBorder
            Color.FromArgb(247, 250, 252), // SeparatorLight
            Color.FromArgb(119, 123, 127), // SeparatorDark
            Color.FromArgb(191, 191, 191), // GripLight
            Color.FromArgb(191, 191, 191), // GripDark
            Color.FromArgb(227, 230, 232), // ToolStripBack
            Color.FromArgb(0, 114, 198), // StatusStripLight
            Color.FromArgb(0, 114, 198), // StatusStripDark
            Color.White, // ImageMargin
            Color.FromArgb(255, 255, 255), // ToolStripBegin
            Color.FromArgb(255, 255, 255), // ToolStripMiddle
            Color.FromArgb(255, 255, 255), // ToolStripEnd
            Color.FromArgb(147, 154, 163), // OverflowBegin
            Color.FromArgb(147, 154, 163), // OverflowMiddle
            Color.FromArgb(147, 154, 163), // OverflowEnd
            Color.FromArgb(147, 154, 163), // ToolStripBorder
            Color.FromArgb(0, 114, 198), // FormBorderActive -n
            Color.FromArgb(134, 139, 145), // FormBorderInactive
            Color.FromArgb(228, 230, 232), // FormBorderActiveLight
            Color.FromArgb(255, 255, 255), // FormBorderActiveDark
            Color.FromArgb(248, 247, 247), // FormBorderInactiveLight
            Color.FromArgb(248, 247, 247), // FormBorderInactiveDark
            Color.FromArgb(101, 109, 117), // FormBorderHeaderActive
            Color.FromArgb(134, 139, 145), // FormBorderHeaderInactive
            Color.FromArgb(235, 237, 240), // FormBorderHeaderActive1
            Color.FromArgb(228, 230, 232), // FormBorderHeaderActive2
            Color.FromArgb(248, 247, 247), // FormBorderHeaderInctive1
            Color.FromArgb(248, 247, 247), // FormBorderHeaderInctive2
            Color.FromArgb(59, 59, 59), // FormHeaderShortActive
            Color.FromArgb(138, 138, 138), // FormHeaderShortInactive
            Color.FromArgb(59, 59, 59), // FormHeaderLongActive
            Color.FromArgb(138, 138, 138), // FormHeaderLongInactive
            Color.FromArgb(166, 172, 179), // FormButtonBorderTrack
            Color.FromArgb(255, 255, 255), // FormButtonBack1Track
            Color.FromArgb(228, 228, 229), // FormButtonBack2Track
            Color.FromArgb(166, 172, 179), // FormButtonBorderPressed
            Color.FromArgb(223, 228, 235), // FormButtonBack1Pressed
            Color.FromArgb(188, 193, 200), // FormButtonBack2Pressed
            Color.Black, // TextButtonFormNormal
            Color.Black, // TextButtonFormTracking
            Color.Black, // TextButtonFormPressed
            Color.Blue, // LinkNotVisitedOverrideControl
            Color.Purple, // LinkVisitedOverrideControl
            Color.Red, // LinkPressedOverrideControl
            Color.Blue, // LinkNotVisitedOverridePanel
            Color.Purple, // LinkVisitedOverridePanel
            Color.Red, // LinkPressedOverridePanel
            Color.FromArgb(59, 59, 59), // TextLabelPanel
            Color.FromArgb(102, 102, 102), // RibbonTabTextNormal -n
            Color.FromArgb(0, 114, 198), // RibbonTabTextChecked -n
            Color.FromArgb(212, 212, 212), // RibbonTabSelected1 - Tab Border 1
            Color.White, // RibbonTabSelected2
            Color.White, // RibbonTabSelected3
            Color.White, // RibbonTabSelected4
            Color.White, // RibbonTabSelected5
            Color.FromArgb(177, 181, 186), // RibbonTabTracking1
            Color.FromArgb(248, 249, 249), // RibbonTabTracking2
            Color.FromArgb(182, 186, 191), // RibbonTabHighlight1
            Color.White, // RibbonTabHighlight2
            Color.White, // RibbonTabHighlight3
            Color.White, // RibbonTabHighlight4
            Color.White, // RibbonTabHighlight5
            Color.FromArgb(182, 186, 191), // RibbonTabSeparatorColor
            Color.FromArgb(212, 212, 212), // RibbonGroupsArea1 -n
            Color.FromArgb(212, 212, 212), // RibbonGroupsArea2 -n
            Color.White, // RibbonGroupsArea3 -n
            Color.White, // RibbonGroupsArea4 -n
            Color.White, // RibbonGroupsArea5 -n
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupBorder1 -n
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupBorder2 -n
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitle1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitle2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupBorderContext1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupBorderContext2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleContext1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleContext2
            Color.FromArgb(148, 149, 152), // RibbonGroupDialogDark
            Color.FromArgb(180, 182, 183), // RibbonGroupDialogLight
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleTracking1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleTracking2
            Color.FromArgb(207, 212, 218), // RibbonMinimizeBarDark
            Color.FromArgb(255, 255, 255), // RibbonMinimizeBarLight
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorder1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorder2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorder3
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorder4
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBack1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBack2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBack3
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBack4
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorderT1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorderT2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorderT3
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBorderT4
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBackT1
            Color.FromArgb(242, 244, 247), // RibbonGroupCollapsedBackT2
            Color.FromArgb(238, 241, 245), // RibbonGroupCollapsedBackT3
            Color.FromArgb(234, 235, 235), // RibbonGroupCollapsedBackT4
            Color.FromArgb(208, 212, 217), // RibbonGroupFrameBorder1
            Color.FromArgb(208, 212, 217), // RibbonGroupFrameBorder2
            Color.FromArgb(254, 254, 254), // RibbonGroupFrameInside1
            Color.FromArgb(254, 254, 254), // RibbonGroupFrameInside2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupFrameInside3
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupFrameInside4
            Color.FromArgb(59, 59, 59), // RibbonGroupCollapsedText
            Color.FromArgb(179, 185, 195), // AlternatePressedBack1
            Color.FromArgb(216, 224, 224), // AlternatePressedBack2
            Color.FromArgb(125, 125, 125), // AlternatePressedBorder1
            Color.FromArgb(186, 186, 186), // AlternatePressedBorder2
            Color.FromArgb(157, 166, 174), // FormButtonBack1Checked
            Color.FromArgb(222, 230, 242), // FormButtonBack2Checked
            Color.FromArgb(149, 154, 160), // FormButtonBorderCheck
            Color.FromArgb(147, 156, 164), // FormButtonBack1CheckTrack
            Color.FromArgb(237, 245, 250), // FormButtonBack2CheckTrack
            Color.FromArgb(180, 180, 180), // RibbonQATMini1
            Color.FromArgb(210, 215, 221), // RibbonQATMini2
            Color.FromArgb(195, 200, 206), // RibbonQATMini3
            Color.FromArgb(10, Color.White), // RibbonQATMini4
            Color.FromArgb(32, Color.White), // RibbonQATMini5
            Color.FromArgb(200, 200, 200), // RibbonQATMini1I
            Color.FromArgb(233, 234, 238), // RibbonQATMini2I
            Color.FromArgb(223, 224, 228), // RibbonQATMini3I
            Color.FromArgb(10, Color.White), // RibbonQATMini4I
            Color.FromArgb(32, Color.White), // RibbonQATMini5I
            Color.FromArgb(223, 227, 234), // RibbonQATFullbar1
            Color.FromArgb(213, 217, 222), // RibbonQATFullbar2
            Color.FromArgb(135, 140, 146), // RibbonQATFullbar3
            Color.FromArgb(90, 90, 90), // RibbonQATButtonDark
            Color.FromArgb(210, 212, 215), // RibbonQATButtonLight
            Color.FromArgb(233, 237, 241), // RibbonQATOverflow1
            Color.FromArgb(138, 144, 150), // RibbonQATOverflow2
            Color.FromArgb(191, 195, 199), // RibbonGroupSeparatorDark
            Color.FromArgb(255, 255, 255), // RibbonGroupSeparatorLight
            Color.FromArgb(231, 234, 238), // ButtonClusterButtonBack1
            Color.FromArgb(241, 243, 243), // ButtonClusterButtonBack2
            Color.FromArgb(197, 198, 199), // ButtonClusterButtonBorder1
            Color.FromArgb(157, 158, 159), // ButtonClusterButtonBorder2
            Color.FromArgb(238, 238, 244), // NavigatorMiniBackColor
            Color.White, // GridListNormal1
            Color.White, // GridListNormal2
            Color.FromArgb(203, 207, 212), // GridListPressed1
            Color.White, // GridListPressed2
            Color.FromArgb(186, 189, 194), // GridListSelected
            Color.FromArgb(238, 241, 247), // GridSheetColNormal1
            Color.FromArgb(218, 222, 227), // GridSheetColNormal2
            Color.FromArgb(255, 223, 107), // GridSheetColPressed1
            Color.FromArgb(255, 252, 230), // GridSheetColPressed2
            Color.FromArgb(255, 211, 89), // GridSheetColSelected1
            Color.FromArgb(255, 239, 113), // GridSheetColSelected2
            Color.FromArgb(223, 227, 232), // GridSheetRowNormal
            Color.FromArgb(255, 223, 107), // GridSheetRowPressed
            Color.FromArgb(245, 210, 87), // GridSheetRowSelected
            Color.FromArgb(218, 220, 221), // GridDataCellBorder
            Color.FromArgb(183, 219, 255), // GridDataCellSelected
            Color.Black, // InputControlTextNormal
            Color.FromArgb(168, 168, 168), // InputControlTextDisabled
            Color.FromArgb(212, 214, 217), // InputControlBorderNormal
            Color.FromArgb(187, 187, 187), // InputControlBorderDisabled
            Color.FromArgb(255, 255, 255), // InputControlBackNormal
            Color.FromArgb(240, 240, 240), // InputControlBackDisabled
            Color.FromArgb(247, 247, 247), // InputControlBackInactive
            Color.Black, // InputDropDownNormal1
            Color.Transparent, // InputDropDownNormal2
            Color.FromArgb(172, 168, 153), // InputDropDownDisabled1
            Color.Transparent, // InputDropDownDisabled2
            Color.FromArgb(240, 242, 245), // ContextMenuHeadingBack
            Color.FromArgb(59, 59, 59), // ContextMenuHeadingText
            Color.White, // ContextMenuImageColumn
            Color.FromArgb(224, 227, 231), // AppButtonBack1
            Color.FromArgb(224, 227, 231), // AppButtonBack2
            Color.FromArgb(135, 140, 146), // AppButtonBorder
            Color.FromArgb(224, 227, 231), // AppButtonOuter1
            Color.FromArgb(224, 227, 231), // AppButtonOuter2
            Color.FromArgb(224, 227, 231), // AppButtonOuter3
            GlobalStaticValues.EMPTY_COLOR, // AppButtonInner1
            Color.FromArgb(135, 140, 146), // AppButtonInner2
            Color.White, // AppButtonMenuDocs
            Color.Black, // AppButtonMenuDocsText
            Color.FromArgb(250, 253, 255), // SeparatorHighInternalBorder1
            Color.FromArgb(227, 232, 237), // SeparatorHighInternalBorder2
            Color.FromArgb(198, 202, 205), // RibbonGalleryBorder
            Color.FromArgb(255, 255, 255), // RibbonGalleryBackNormal
            Color.FromArgb(255, 255, 255), // RibbonGalleryBackTracking
            Color.FromArgb(250, 250, 250), // RibbonGalleryBack1
            Color.FromArgb(228, 231, 235), // RibbonGalleryBack2                      // Color.FromArgb(177, 181, 186),    // RibbonTabTracking1
            Color.FromArgb(229, 231, 235), // RibbonTabTracking3
            Color.FromArgb(231, 233, 235), // RibbonTabTracking4
            Color.FromArgb(176, 182, 188), // RibbonGroupBorder3
            Color.FromArgb(246, 247, 248), // RibbonGroupBorder4
            Color.FromArgb(249, 250, 250), // RibbonGroupBorder5
            Color.FromArgb(102, 109, 124), // RibbonGroupTitleText
            Color.FromArgb(151, 156, 163), // RibbonDropArrowLight
            Color.FromArgb(39, 49, 60), // RibbonDropArrowDark
            Color.FromArgb(237, 242, 248), // HeaderDockInactiveBack1
            Color.FromArgb(207, 213, 220), // HeaderDockInactiveBack2
            Color.FromArgb(161, 169, 179), // ButtonNavigatorBorder
            Color.Black, // ButtonNavigatorText
            Color.FromArgb(207, 213, 220), // ButtonNavigatorTrack1
            Color.FromArgb(232, 234, 238), // ButtonNavigatorTrack2
            Color.FromArgb(191, 196, 202), // ButtonNavigatorPressed1
            Color.FromArgb(225, 226, 230), // ButtonNavigatorPressed2
            Color.FromArgb(222, 227, 234), // ButtonNavigatorChecked1
            Color.FromArgb(206, 214, 221), // ButtonNavigatorChecked2
            Color.FromArgb(221, 221, 221) // ToolTipBottom
        ];

        #endregion
        #endregion

        #region Identity
        static PaletteOffice2013White()
        {
            _checkBoxList = new ImageList
            {
                ImageSize = new Size(13, 13),
                ColorDepth = ColorDepth.Depth24Bit
            };
            _checkBoxList.Images.AddStrip(CheckBoxStripResources.CheckBoxStrip2010Silver);
            _galleryButtonList = new ImageList
            {
                ImageSize = new Size(13, 7),
                ColorDepth = ColorDepth.Depth24Bit,
                TransparentColor = GlobalStaticValues.TRANSPARENCY_KEY_COLOR
            };
            _galleryButtonList.Images.AddStrip(GalleryImageResources.Gallery2010);
            _radioButtonArray =
            [
                Office2010RadioButtonImageResources.RadioButton2010BlueD,
                Office2010RadioButtonImageResources.RadioButton2010SilverN,
                Office2010RadioButtonImageResources.RadioButton2010BlueT,
                Office2010RadioButtonImageResources.RadioButton2010BlueP,
                Office2010RadioButtonImageResources.RadioButton2010BlueDC,
                Office2010RadioButtonImageResources.RadioButton2010SilverNC,
                Office2010RadioButtonImageResources.RadioButton2010SilverTC,
                Office2010RadioButtonImageResources.RadioButton2010SilverPC
            ];
        }

        /// <summary>
        /// Initialize a new instance of the PaletteOffice2010Silver class.
        /// </summary>
        public PaletteOffice2013White()
            : base(_schemeOfficeColors,
                   _checkBoxList,
                   _galleryButtonList,
                   _radioButtonArray,
                   _trackBarColors)
        {
            ThemeName = nameof(PaletteOffice2013White);
        }
        #endregion

        #region Images
        /// <summary>
        /// Gets an image indicating a sub-menu on a context menu item.
        /// </summary>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetContextMenuSubMenuImage() => _contextMenuSubMenu;

        #endregion

        #region ButtonSpec
        /// <summary>
        /// Gets the image to display for the button.
        /// </summary>
        /// <param name="style">Style of button spec.</param>
        /// <param name="state">State for which image is required.</param>
        /// <returns>Image value.</returns>
        public override Image? GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state) => style switch
        {
            PaletteButtonSpecStyle.FormClose => state switch
            {
                PaletteState.Tracking => _formCloseActive,
                PaletteState.Normal => _formCloseNormal,
                PaletteState.Pressed => _formClosePressed,
                _ => _formCloseDisabled
            },
            PaletteButtonSpecStyle.FormMin => state switch
            {
                PaletteState.Normal => _formMinimiseNormal,
                PaletteState.Tracking => _formMinimiseActive,
                PaletteState.Pressed => _formMinimisePressed,
                _ => _formMinimiseDisabled
            },
            PaletteButtonSpecStyle.FormMax => state switch
            {
                PaletteState.Normal => _formMaximiseNormal,
                PaletteState.Tracking => _formMaximiseActive,
                PaletteState.Pressed => _formMaximisePressed,
                _ => _formMaximiseDisabled
            },
            PaletteButtonSpecStyle.FormRestore => state switch
            {
                PaletteState.Normal => _formRestoreNormal,
                PaletteState.Tracking => _formRestoreActive,
                PaletteState.Pressed => _formRestorePressed,
                _ => _formRestoreDisabled
            },
            PaletteButtonSpecStyle.FormHelp => state switch
            {
                PaletteState.Tracking => _formHelpActive,
                PaletteState.Pressed => _formHelpPressed,
                PaletteState.Normal => _formHelpNormal,
                _ => _formHelpDisabled
            },
            _ => base.GetButtonSpecImage(style, state)
        };
        #endregion

        #region Tab Row Background

        /// <inheritdoc />
        public override Color GetRibbonTabRowGradientColor1(PaletteState state) => GlobalStaticValues.EMPTY_COLOR;

        /// <inheritdoc />
        public override Color GetRibbonTabRowBackgroundGradientRaftingDark(PaletteState state) =>
            GlobalStaticValues.EMPTY_COLOR;

        /// <inheritdoc />
        public override Color GetRibbonTabRowBackgroundGradientRaftingLight(PaletteState state) =>
            GlobalStaticValues.EMPTY_COLOR;

        /// <inheritdoc />
        public override Color GetRibbonTabRowBackgroundSolidColor(PaletteState state) => _tabRowBackgroundColor;

        /// <inheritdoc />
        public override float GetRibbonTabRowGradientRaftingAngle(PaletteState state) => -1;

        #endregion

        #region AppButton Colors

        /// <inheritdoc />
        public override Color GetRibbonFileAppTabBottomColor(PaletteState state) => _ribbonAppButtonDarkColor;

        /// <inheritdoc />
        public override Color GetRibbonFileAppTabTopColor(PaletteState state) => _ribbonAppButtonLightColor;

        /// <inheritdoc />
        public override Color GetRibbonFileAppTabTextColor(PaletteState state) => _ribbonAppButtonTextColor;

        #endregion
    }

    #region Class: PaletteOffice2013WhiteBase

    /// <summary>
    /// Gets the single instance of the PaletteOffice2013WhiteBase palette.
    /// </summary>
    public abstract class PaletteOffice2013WhiteBase : PaletteBase
    {
        #region Static Fields

        #region Padding

        private static readonly Padding _contentPaddingGrid = new Padding(2, 1, 2, 1);
        private static readonly Padding _contentPaddingHeader1 = new Padding(2, 1, 2, 1);
        private static readonly Padding _contentPaddingHeader2 = new Padding(2, 1, 2, 1);
        private static readonly Padding _contentPaddingDock = new Padding(2, 2, 2, 1);
        private static readonly Padding _contentPaddingCalendar = new Padding(2);
        //private static readonly Padding _contentPaddingHeaderForm = new Padding(owningForm!.RealWindowBorders.Left, owningForm!.RealWindowBorders.Bottom / 2, 0, 0);         
        private static readonly Padding _contentPaddingLabel = new Padding(3, 1, 3, 1);
        private static readonly Padding _contentPaddingLabel2 = new Padding(8, 2, 8, 2);
        private static readonly Padding _contentPaddingButtonInputControl = new Padding(0);
        private static readonly Padding _contentPaddingButton12 = new Padding(1);
        private static readonly Padding _contentPaddingButton3 = new Padding(1, 0, 1, 0);
        private static readonly Padding _contentPaddingButton4 = new Padding(4, 3, 4, 3);
        private static readonly Padding _contentPaddingButton5 = new Padding(3, 3, 3, 2);
        private static readonly Padding _contentPaddingButton6 = new Padding(3);
        private static readonly Padding _contentPaddingButton7 = new Padding(1, 1, 0, 1);
        private static readonly Padding _contentPaddingButtonForm = new Padding(0);
        private static readonly Padding _contentPaddingButtonGallery = new Padding(1, 0, 1, 0);
        private static readonly Padding _contentPaddingButtonListItem = new Padding(0);
        private static readonly Padding _contentPaddingToolTip = new Padding(2);
        private static readonly Padding _contentPaddingSuperTip = new Padding(4);
        private static readonly Padding _contentPaddingKeyTip = new Padding(0, -1, 0, -3);
        private static readonly Padding _contentPaddingContextMenuHeading = new Padding(8, 2, 8, 0);
        private static readonly Padding _contentPaddingContextMenuImage = new Padding(0);
        private static readonly Padding _contentPaddingContextMenuItemText = new Padding(9, 1, 7, 0);
        private static readonly Padding _contentPaddingContextMenuItemTextAlt = new Padding(7, 1, 6, 0);
        private static readonly Padding _contentPaddingContextMenuItemShortcutText = new Padding(3, 1, 4, 0);
        private static readonly Padding _metricPaddingRibbon = new Padding(0, 1, 1, 1);
        private static readonly Padding _metricPaddingRibbonAppButton = new Padding(3, 0, 3, 0);
        private static readonly Padding _metricPaddingHeader = new Padding(0, 3, 1, 3);
        //private static readonly Padding _metricPaddingHeaderForm = new Padding(0, owningForm!.RealWindowBorders.Right, 0, 0);//, 3, 0, -3); // Move the Maximised Form buttons down a bit
        private static readonly Padding _metricPaddingInputControl = new Padding(0, 1, 0, 1);
        private static readonly Padding _metricPaddingBarInside = new Padding(3);
        private static readonly Padding _metricPaddingBarTabs = new Padding(0);
        private static readonly Padding _metricPaddingBarOutside = new Padding(0, 0, 0, 3);
        private static readonly Padding _metricPaddingPageButtons = new Padding(1, 3, 1, 3);

        #endregion

        #region Images

        private static readonly Image? _treeExpandWhite = TreeItemImageResources.TreeExpandWhite;
        private static readonly Image? _treeCollapseBlack = TreeItemImageResources.TreeCollapseBlack;

        private static readonly Image? _disabledDropDown = DropDownArrowImageResources.DisabledDropDownButton;
        private static readonly Image _buttonSpecClose = ProfessionalButtonSpecResources.ProfessionalCloseButton;
        private static readonly Image _buttonSpecContext = GenericProfessionalImageResources.ProfessionalContextButton;
        private static readonly Image _buttonSpecNext = GenericProfessionalImageResources.ProfessionalNextButton;
        private static readonly Image _buttonSpecPrevious = GenericProfessionalImageResources.ProfessionalPreviousButton;
        private static readonly Image _buttonSpecArrowLeft = GenericProfessionalImageResources.ProfessionalArrowLeftButton;
        private static readonly Image _buttonSpecArrowRight = GenericProfessionalImageResources.ProfessionalArrowRightButton;
        private static readonly Image _buttonSpecArrowUp = GenericProfessionalImageResources.ProfessionalArrowUpButton;
        private static readonly Image _buttonSpecArrowDown = GenericProfessionalImageResources.ProfessionalArrowDownButton;
        private static readonly Image _buttonSpecDropDown = GenericProfessionalImageResources.ProfessionalDropDownButton;
        private static readonly Image _buttonSpecPinVertical = ProfessionalPinImageResources.ProfessionalPinVerticalButton;
        private static readonly Image _buttonSpecPinHorizontal = ProfessionalPinImageResources.ProfessionalPinHorizontalButton;
        private static readonly Image _buttonSpecPendantClose = Office2010MDIImageResources.Office2010ButtonMDIClose;
        private static readonly Image _buttonSpecPendantMin = Office2010MDIImageResources.Office2010ButtonMDIMin;
        private static readonly Image _buttonSpecPendantRestore = Office2010MDIImageResources.Office2010ButtonMDIRestore;
        private static readonly Image _buttonSpecWorkspaceMaximize = ProfessionalControlBoxResources.ProfessionalMaximize;
        private static readonly Image _buttonSpecWorkspaceRestore = GenericProfessionalImageResources.ProfessionalRestore;
        private static readonly Image _buttonSpecRibbonMinimize = RibbonArrowImageResources.RibbonUp2010;
        private static readonly Image _buttonSpecRibbonExpand = RibbonArrowImageResources.RibbonDown2010;
        private static readonly Image? _contextMenuChecked = GenericOffice2007ImageResources.Office2007Checked;
        private static readonly Image? _contextMenuIndeterminate = GenericOffice2007ImageResources.Office2007Indeterminate;

        #region Integrated Tool Bar Images

        private static readonly Image _integratedToolbarNewNormal = Office2013ToolbarImageResources.Office2013ToolbarNewNormal;

        private static readonly Image _integratedToolbarOpenNormal = Office2013ToolbarImageResources.Office2013ToolbarOpenNormal;

        private static readonly Image _integratedToolbarSaveAllNormal = Office2013ToolbarImageResources.Office2013ToolbarSaveAllNormal;

        private static readonly Image _integratedToolbarSaveAsNormal = Office2013ToolbarImageResources.Office2013ToolbarSaveAsNormal;

        private static readonly Image _integratedToolbarSaveNormal = Office2013ToolbarImageResources.Office2013ToolbarSaveNormal;

        private static readonly Image _integratedToolbarCutNormal = Office2013ToolbarImageResources.Office2013ToolbarCutNormal;

        private static readonly Image _integratedToolbarCopyNormal = Office2013ToolbarImageResources.Office2013ToolbarCopyNormal;

        private static readonly Image _integratedToolbarPasteNormal = Office2013ToolbarImageResources.Office2013ToolbarPasteNormal;

        private static readonly Image _integratedToolbarUndoNormal = Office2013ToolbarImageResources.Office2013ToolbarUndoNormal;

        private static readonly Image _integratedToolbarRedoNormal = Office2013ToolbarImageResources.Office2013ToolbarRedoNormal;

        private static readonly Image _integratedToolbarPageSetupNormal = Office2013ToolbarImageResources.Office2013ToolbarPageSetupNormal;

        private static readonly Image _integratedToolbarPrintPreviewNormal = Office2013ToolbarImageResources.Office2013ToolbarPrintPreviewNormal;

        private static readonly Image _integratedToolbarPrintNormal = Office2013ToolbarImageResources.Office2013ToolbarPrintNormal;

        private static readonly Image _integratedToolbarQuickPrintNormal = Office2013ToolbarImageResources.Office2013ToolbarQuickPrintNormal;

        #endregion

        #endregion

        #region Colors

        private static readonly Color _gridTextColor = Color.Black;
        private static readonly Color _disabledText2 = Color.FromArgb(128, 128, 128);
        private static readonly Color _disabledText = Color.FromArgb(167, 167, 167);
        private static readonly Color _disabledBack = Color.FromArgb(235, 235, 235);
        private static readonly Color _disabledBorder = Color.FromArgb(212, 212, 212);
        private static readonly Color _disabledGlyphDark = Color.FromArgb(183, 183, 183);
        private static readonly Color _disabledGlyphLight = Color.FromArgb(237, 237, 237);
        private static readonly Color _contextCheckedTabBorder1 = Color.FromArgb(223, 119, 0);
        private static readonly Color _contextCheckedTabBorder2 = Color.FromArgb(230, 190, 129);
        private static readonly Color _contextCheckedTabBorder3 = Color.FromArgb(220, 202, 171);
        private static readonly Color _contextCheckedTabBorder4 = Color.FromArgb(255, 252, 247);
        private static readonly Color _contextTabSeparator = Color.White;
        private static readonly Color _contextTextColor = Color.White;
        private static readonly Color _todayBorder = Color.FromArgb(187, 85, 3);
        private static readonly Color _toolTipBack1 = Color.FromArgb(255, 255, 255);
        private static readonly Color _toolTipBack2 = Color.FromArgb(201, 217, 239);
        private static readonly Color _toolTipBorder = Color.FromArgb(118, 118, 118);
        private static readonly Color _toolTipText = Color.FromArgb(76, 76, 76);
        private static readonly Color _contextMenuBack = Color.White;
        private static readonly Color _contextMenuBorder = Color.FromArgb(134, 134, 134);
        private static readonly Color _contextMenuHeadingBorder = Color.FromArgb(197, 197, 197);
        private static readonly Color _contextMenuImageBackChecked = Color.FromArgb(252, 241, 194);
        private static readonly Color _contextMenuImageBorderChecked = Color.FromArgb(242, 149, 54);
        private static readonly Color _formCloseBorderTracking = Color.FromArgb(155, 61, 61);
        private static readonly Color _formCloseBorderPressed = Color.FromArgb(155, 61, 61);
        private static readonly Color _formCloseBorderCheckedNormal = Color.FromArgb(155, 61, 61);
        private static readonly Color _formCloseTracking1 = Color.FromArgb(255, 132, 130);
        private static readonly Color _formCloseTracking2 = Color.FromArgb(227, 97, 98);
        private static readonly Color _formClosePressed1 = Color.FromArgb(242, 119, 118);
        private static readonly Color _formClosePressed2 = Color.FromArgb(206, 85, 84);
        private static readonly Color _formCloseChecked1 = Color.FromArgb(255, 132, 130);
        private static readonly Color _formCloseChecked2 = Color.FromArgb(255, 132, 130);
        private static readonly Color _formCloseCheckedTracking1 = Color.FromArgb(255, 132, 130);
        private static readonly Color _formCloseCheckedTracking2 = Color.FromArgb(255, 132, 130);

        #endregion

        #region Colour Arrays

        private static readonly Color[] _appButtonNormal =
        [
            Color.FromArgb(243, 245, 248),
            Color.FromArgb(214, 220, 231),
            Color.FromArgb(188, 198, 211),
            Color.FromArgb(254, 254, 255),
            Color.FromArgb(206, 213, 225)
        ];

        private static readonly Color[] _appButtonTrack =
        [
            Color.FromArgb(255, 251, 230),
            Color.FromArgb(248, 230, 143),
            Color.FromArgb(238, 213, 126),
            Color.FromArgb(254, 247, 129),
            Color.FromArgb(240, 201, 41)
        ];

        private static readonly Color[] _appButtonPressed =
        [
            Color.FromArgb(235, 227, 196),
            Color.FromArgb(228, 198, 149),
            Color.FromArgb(166, 97, 7),
            Color.FromArgb(242, 155, 57),
            Color.FromArgb(236, 136, 9)
        ];

        private static readonly Color[] _buttonBorderColors =
        [
            Color.FromArgb(180, 180, 180), // Button, Disabled, Border
            Color.FromArgb(205, 230, 247), // Button, Tracking, Border 1
            Color.FromArgb(205, 230, 247), // Button, Tracking, Border 2
            Color.FromArgb(146, 192, 244), // Button, Pressed, Border 1
            Color.FromArgb(146, 192, 244), // Button, Pressed, Border 2
            Color.FromArgb(146, 192, 244), // Button, Checked, Border 1
            Color.FromArgb(146, 192, 244) // Button, Checked, Border 2
        ];

        private static readonly Color[] _buttonBackColors =
        [
            Color.FromArgb(250, 250, 250), // Button, Disabled, Back 1
            Color.FromArgb(250, 250, 250), // Button, Disabled, Back 2
            Color.FromArgb(205, 230, 247), // Button, Tracking, Back 1
            Color.FromArgb(205, 230, 247), // Button, Tracking, Back 2
            Color.FromArgb(146, 192, 244), // Button, Pressed, Back 1
            Color.FromArgb(146, 192, 244), // Button, Pressed, Back 2
            Color.FromArgb(146, 192, 244), // Button, Checked, Back 1
            Color.FromArgb(146, 192, 244), // Button, Checked, Back 2
            Color.FromArgb(255, 225, 104), // Button, Checked Tracking, Back 1
            Color.FromArgb(255, 249, 196)  // Button, Checked Tracking, Back 2
        ];
        #endregion

        #endregion

        #region Instance Fields
        protected KryptonColorTable2013White? Table { get; set; }
        private readonly Color[] _ribbonColors;
        private readonly Color[] _trackBarColors;
        private readonly ImageList _checkBoxList;
        private readonly ImageList _galleryButtonList;
        private readonly Image?[] _radioButtonArray;

        //TODO rendre dynamique
        //public static Color baseUserColor = Color.FromArgb(255, 248, 56);
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteOffice2013WhiteBase class.
        /// </summary>
        /// <param name="schemeColors">Array of palette specific colors.</param>
        /// <param name="checkBoxList">List of images for check box.</param>
        /// <param name="galleryButtonList">List of images for gallery buttons.</param>
        /// <param name="radioButtonArray">Array of images for radio button.</param>
        /// <param name="trackBarColors">Array of track bar specific colors.</param>
        protected PaletteOffice2013WhiteBase([DisallowNull] Color[] schemeColors,
                                             [DisallowNull] ImageList checkBoxList,
                                             [DisallowNull] ImageList galleryButtonList,
                                             [DisallowNull] Image?[] radioButtonArray,
                                             Color[] trackBarColors)
        {
            Debug.Assert(schemeColors is not null);
            Debug.Assert(checkBoxList is not null);
            Debug.Assert(galleryButtonList is not null);
            Debug.Assert(radioButtonArray is not null);

            // Remember incoming sets of values
            ThemeName = nameof(PaletteOffice2013WhiteBase);
            _ribbonColors = schemeColors ?? throw new ArgumentNullException(nameof(schemeColors));
            _checkBoxList = checkBoxList ?? throw new ArgumentNullException(nameof(CheckedListBox));
            _galleryButtonList = galleryButtonList ?? throw new ArgumentNullException(nameof(galleryButtonList));
            _radioButtonArray = radioButtonArray ?? throw new ArgumentNullException(nameof(radioButtonArray));
            _trackBarColors = trackBarColors ?? throw new ArgumentNullException(nameof(trackBarColors));

            // Get the font settings from the system
            DefineFonts();
        }
        #endregion

        #region Renderer
        /// <summary>
        /// Gets the renderer to use for this palette.
        /// </summary>
        /// <returns>Renderer to use for drawing palette settings.</returns>
        public override IRenderer GetRenderer() =>
            // We always want the professional renderer
            KryptonManager.RenderOffice2013;

        #endregion

        #region Back
        /// <summary>
        /// Gets a value indicating if background should be drawn.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return InheritBool.Inherit;
            }

            return style switch
            {
                PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 => InheritBool.False,
                PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => InheritBool.False,
                    _ => InheritBool.True
                },
                PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight => state switch
                {
                    PaletteState.Normal or PaletteState.NormalDefaultOverride => InheritBool.False,
                    _ => InheritBool.True
                },
                PaletteBackStyle.ButtonInputControl => state is PaletteState.Disabled or PaletteState.Normal ? InheritBool.False : InheritBool.True,
                _ => InheritBool.True // Default to drawing the background
            };
        }

        /// <summary>
        /// Gets the graphics drawing hint for the background.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteGraphicsHint value.</returns>
        public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteGraphicsHint.Inherit;
            }

            return style switch
            {
                PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabStandardProfile or PaletteBackStyle.TabLowProfile or PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 or PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.SeparatorHighInternalProfile or PaletteBackStyle.SeparatorHighProfile or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlToolTip or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ControlRibbonAppMenu or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit or PaletteBackStyle.ContextMenuItemImageColumn or PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 or PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderDockActive or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderForm or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 or PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 or PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowSheet or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 or PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellSheet or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 => PaletteGraphicsHint.None,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the first background color.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (style)
            {
                case PaletteBackStyle.GridHeaderColumnList:
                case PaletteBackStyle.GridHeaderColumnCustom1:
                case PaletteBackStyle.GridHeaderColumnCustom2:
                case PaletteBackStyle.GridHeaderColumnCustom3:
                case PaletteBackStyle.GridHeaderRowList:
                case PaletteBackStyle.GridHeaderRowCustom1:
                case PaletteBackStyle.GridHeaderRowCustom2:
                case PaletteBackStyle.GridHeaderRowCustom3:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.GridListPressed1],
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.GridListSelected],
                        _ => _ribbonColors[(int)SchemeOfficeColors.GridListNormal1]
                    };
                case PaletteBackStyle.GridHeaderColumnSheet:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Tracking or PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.GridSheetColPressed1],
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.GridSheetColSelected1],
                        _ => _ribbonColors[(int)SchemeOfficeColors.GridSheetColNormal1]
                    };
                case PaletteBackStyle.GridHeaderRowSheet:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Tracking or PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.GridSheetRowPressed],
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.GridSheetRowSelected],
                        _ => _ribbonColors[(int)SchemeOfficeColors.GridSheetRowNormal]
                    };
                case PaletteBackStyle.GridDataCellList:
                case PaletteBackStyle.GridDataCellCustom1:
                case PaletteBackStyle.GridDataCellCustom2:
                case PaletteBackStyle.GridDataCellCustom3:
                    return state == PaletteState.CheckedNormal ? _ribbonColors[(int)SchemeOfficeColors.GridDataCellSelected] : SystemColors.Window;

                case PaletteBackStyle.GridDataCellSheet:
                    return state == PaletteState.CheckedNormal ? _buttonBackColors[6] : SystemColors.Window;

                case PaletteBackStyle.TabHighProfile:
                case PaletteBackStyle.TabStandardProfile:
                case PaletteBackStyle.TabLowProfile:
                case PaletteBackStyle.TabOneNote:
                case PaletteBackStyle.TabCustom1:
                case PaletteBackStyle.TabCustom2:
                case PaletteBackStyle.TabCustom3:
                    switch (state)
                    {
                        case PaletteState.Disabled:
                            return style == PaletteBackStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _disabledBack;

                        case PaletteState.Normal:
                            return style == PaletteBackStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : SystemColors.Window;

                        case PaletteState.Pressed:
                        case PaletteState.Tracking:
                            switch (style)
                            {
                                case PaletteBackStyle.TabLowProfile:
                                    return GlobalStaticValues.EMPTY_COLOR;
                                case PaletteBackStyle.TabHighProfile:
                                    return state == PaletteState.Tracking ? _buttonBackColors[2] : _buttonBackColors[4];
                                default:
                                    return SystemColors.Window;
                            }

                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedPressed:
                        case PaletteState.CheckedTracking:
                            if (style == PaletteBackStyle.TabHighProfile)
                            {
                                if (state == PaletteState.CheckedNormal)
                                {
                                    return _buttonBackColors[6];
                                }
                                else
                                {
                                    return state == PaletteState.CheckedPressed ? _buttonBackColors[4] : _buttonBackColors[8];
                                }
                            }
                            else
                            {
                                return SystemColors.Window;
                            }

                        default:
                            throw DebugTools.NotImplemented(state.ToString());
                    }
                case PaletteBackStyle.TabDock:
                case PaletteBackStyle.TabDockAutoHidden:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Normal or PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking or PaletteState.Pressed or PaletteState.Tracking => SystemColors.Window,
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.HeaderForm:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderInactive1]
                        : _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderActive1];

                case PaletteBackStyle.HeaderCalendar:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack1]
                        : _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack2];

                case PaletteBackStyle.HeaderPrimary:
                case PaletteBackStyle.HeaderCustom1:
                case PaletteBackStyle.HeaderCustom2:
                case PaletteBackStyle.HeaderCustom3:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack1];

                case PaletteBackStyle.HeaderDockInactive:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.HeaderDockInactiveBack1];

                case PaletteBackStyle.HeaderDockActive:
                    return state == PaletteState.Disabled ? _disabledBack : _buttonBackColors[6];

                case PaletteBackStyle.HeaderSecondary:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.HeaderSecondaryBack1];

                case PaletteBackStyle.SeparatorHighInternalProfile:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.SeparatorHighInternalBorder1];

                case PaletteBackStyle.SeparatorHighProfile:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.SeparatorHighBorder1];

                case PaletteBackStyle.SeparatorLowProfile:
                case PaletteBackStyle.SeparatorCustom1:
                case PaletteBackStyle.SeparatorCustom2:
                case PaletteBackStyle.SeparatorCustom3:
                case PaletteBackStyle.PanelClient:
                case PaletteBackStyle.PanelCustom1:
                case PaletteBackStyle.PanelCustom2:
                case PaletteBackStyle.PanelCustom3:
                case PaletteBackStyle.ControlGroupBox:
                case PaletteBackStyle.GridBackgroundList:
                case PaletteBackStyle.GridBackgroundSheet:
                case PaletteBackStyle.GridBackgroundCustom1:
                case PaletteBackStyle.GridBackgroundCustom2:
                case PaletteBackStyle.GridBackgroundCustom3:
                    return _ribbonColors[(int)SchemeOfficeColors.PanelClient];
                case PaletteBackStyle.PanelAlternate:
                    return _ribbonColors[(int)SchemeOfficeColors.PanelAlternative];
                case PaletteBackStyle.PanelRibbonInactive:
                    return _ribbonColors[(int)SchemeOfficeColors.FormBorderInactiveLight];
                case PaletteBackStyle.FormMain:
                case PaletteBackStyle.FormCustom1:
                case PaletteBackStyle.FormCustom2:
                case PaletteBackStyle.FormCustom3:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormBorderInactiveLight]
                        : _ribbonColors[(int)SchemeOfficeColors.FormBorderActiveLight];

                case PaletteBackStyle.ControlClient:
                case PaletteBackStyle.ControlAlternate:
                case PaletteBackStyle.ControlCustom1:
                case PaletteBackStyle.ControlCustom2:
                case PaletteBackStyle.ControlCustom3:
                    return SystemColors.Window;
                case PaletteBackStyle.InputControlStandalone:
                case PaletteBackStyle.InputControlRibbon:
                case PaletteBackStyle.InputControlCustom1:
                case PaletteBackStyle.InputControlCustom2:
                case PaletteBackStyle.InputControlCustom3:
                    if (state == PaletteState.Disabled)
                    {
                        return _ribbonColors[(int)SchemeOfficeColors.InputControlBackDisabled];
                    }
                    else
                    {
                        return (state == PaletteState.Tracking) || (style == PaletteBackStyle.InputControlStandalone)
                            ? _ribbonColors[(int)SchemeOfficeColors.InputControlBackNormal]
                            : _ribbonColors[(int)SchemeOfficeColors.InputControlBackInactive];
                    }
                case PaletteBackStyle.ControlRibbon:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonTabSelected4];
                case PaletteBackStyle.ControlRibbonAppMenu:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonBack1];
                case PaletteBackStyle.ControlToolTip:
                    return _toolTipBack1;
                case PaletteBackStyle.ContextMenuOuter:
                    return _contextMenuBack;
                case PaletteBackStyle.ContextMenuSeparator:
                case PaletteBackStyle.ContextMenuItemSplit:
                    return state switch
                    {
                        PaletteState.Tracking => _buttonBackColors[2],
                        _ => _contextMenuBack
                    };
                case PaletteBackStyle.ContextMenuInner:
                    return _contextMenuBack;
                case PaletteBackStyle.ContextMenuHeading:
                    return _ribbonColors[(int)SchemeOfficeColors.ContextMenuHeadingBack];
                case PaletteBackStyle.ContextMenuItemImageColumn:
                    return _ribbonColors[(int)SchemeOfficeColors.ContextMenuImageColumn];
                case PaletteBackStyle.ContextMenuItemImage:
                    return _contextMenuImageBackChecked;
                case PaletteBackStyle.ButtonForm:
                    return state switch
                    {
                        PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack1Checked],
                        PaletteState.Tracking => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack1Track],
                        PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack1CheckTrack],
                        PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack1Pressed],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.ButtonFormClose:
                    return state switch
                    {
                        PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                        PaletteState.CheckedNormal => _formCloseChecked1,
                        PaletteState.Tracking => _formCloseTracking1,
                        PaletteState.CheckedTracking => _formCloseCheckedTracking1,
                        PaletteState.Pressed or PaletteState.CheckedPressed => _formClosePressed1,
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.ButtonStandalone:
                case PaletteBackStyle.ButtonGallery:
                case PaletteBackStyle.ButtonAlternate:
                case PaletteBackStyle.ButtonLowProfile:
                case PaletteBackStyle.ButtonBreadCrumb:
                case PaletteBackStyle.ButtonListItem:
                case PaletteBackStyle.ButtonCommand:
                case PaletteBackStyle.ButtonButtonSpec:
                case PaletteBackStyle.ButtonCalendarDay:
                case PaletteBackStyle.ButtonCluster:
                case PaletteBackStyle.ButtonCustom1:
                case PaletteBackStyle.ButtonCustom2:
                case PaletteBackStyle.ButtonCustom3:
                case PaletteBackStyle.ButtonInputControl:
                case PaletteBackStyle.ContextMenuItemHighlight:
                    return state switch
                    {
                        PaletteState.Disabled => style == PaletteBackStyle.ButtonGallery ? _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBack1] : _disabledBack,
                        PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1],
                        PaletteState.NormalDefaultOverride => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalDefaultBack1],
                        PaletteState.CheckedNormal => style == PaletteBackStyle.ButtonInputControl ? _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1] : _buttonBackColors[6],
                        PaletteState.Tracking => _buttonBackColors[2],
                        PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBackColors[4],
                        PaletteState.CheckedTracking => style == PaletteBackStyle.ButtonInputControl ? _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1] : _buttonBackColors[8],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.ButtonNavigatorStack:
                case PaletteBackStyle.ButtonNavigatorOverflow:
                case PaletteBackStyle.ButtonNavigatorMini:
                    return state switch
                    {
                        PaletteState.Disabled => _buttonBackColors[1],
                        PaletteState.Tracking => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorTrack1],
                        PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorPressed1],
                        PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorChecked1],
                        _ => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalNavigatorBack1]
                    };
                default:
                    throw DebugTools.NotImplemented(style.ToString());
            }
        }

        /// <summary>
        /// Gets the second back color.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (style)
            {
                case PaletteBackStyle.GridHeaderColumnList:
                case PaletteBackStyle.GridHeaderColumnCustom1:
                case PaletteBackStyle.GridHeaderColumnCustom2:
                case PaletteBackStyle.GridHeaderColumnCustom3:
                case PaletteBackStyle.GridHeaderRowList:
                case PaletteBackStyle.GridHeaderRowCustom1:
                case PaletteBackStyle.GridHeaderRowCustom2:
                case PaletteBackStyle.GridHeaderRowCustom3:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.GridListPressed2],
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.GridListSelected],
                        _ => _ribbonColors[(int)SchemeOfficeColors.GridListNormal2]
                    };
                case PaletteBackStyle.GridHeaderColumnSheet:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Tracking or PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.GridSheetColPressed2],
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.GridSheetColSelected2],
                        _ => _ribbonColors[(int)SchemeOfficeColors.GridSheetColNormal2]
                    };
                case PaletteBackStyle.GridHeaderRowSheet:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Tracking or PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.GridSheetRowPressed],
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.GridSheetRowSelected],
                        _ => _ribbonColors[(int)SchemeOfficeColors.GridSheetRowNormal]
                    };
                case PaletteBackStyle.GridDataCellList:
                case PaletteBackStyle.GridDataCellCustom1:
                case PaletteBackStyle.GridDataCellCustom2:
                case PaletteBackStyle.GridDataCellCustom3:
                    return state == PaletteState.CheckedNormal ? _ribbonColors[(int)SchemeOfficeColors.GridDataCellSelected] : SystemColors.Window;

                case PaletteBackStyle.GridDataCellSheet:
                    return state == PaletteState.CheckedNormal ? _buttonBackColors[7] : SystemColors.Window;

                case PaletteBackStyle.TabHighProfile:
                case PaletteBackStyle.TabStandardProfile:
                case PaletteBackStyle.TabLowProfile:
                case PaletteBackStyle.TabOneNote:
                case PaletteBackStyle.TabCustom1:
                case PaletteBackStyle.TabCustom2:
                case PaletteBackStyle.TabCustom3:
                    return state switch
                    {
                        PaletteState.Disabled => style == PaletteBackStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _disabledBack,
                        PaletteState.Normal => style == PaletteBackStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack2],
                        PaletteState.Tracking or PaletteState.Pressed => style == PaletteBackStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : SystemColors.Window,
                        PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => SystemColors.Window,
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.TabDock:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.HeaderDockInactiveBack1],
                        PaletteState.Tracking or PaletteState.Pressed => _buttonBackColors[4],
                        PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => SystemColors.Window,
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.TabDockAutoHidden:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Normal or PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.HeaderDockInactiveBack1],
                        PaletteState.Tracking or PaletteState.CheckedTracking or PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBackColors[4],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.HeaderForm:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderInactive2]
                        : _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderActive2];

                case PaletteBackStyle.HeaderCalendar:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack1]
                        : _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack2];

                case PaletteBackStyle.HeaderPrimary:
                case PaletteBackStyle.HeaderCustom1:
                case PaletteBackStyle.HeaderCustom2:
                case PaletteBackStyle.HeaderCustom3:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack2];

                case PaletteBackStyle.HeaderDockInactive:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.HeaderDockInactiveBack2];

                case PaletteBackStyle.HeaderDockActive:
                    return state == PaletteState.Disabled ? _disabledBack : _buttonBackColors[7];

                case PaletteBackStyle.HeaderSecondary:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.HeaderSecondaryBack2];

                case PaletteBackStyle.SeparatorHighInternalProfile:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.SeparatorHighInternalBorder2];

                case PaletteBackStyle.SeparatorHighProfile:
                    return state == PaletteState.Disabled ? _disabledBack : _ribbonColors[(int)SchemeOfficeColors.SeparatorHighBorder2];

                case PaletteBackStyle.SeparatorLowProfile:
                case PaletteBackStyle.SeparatorCustom1:
                case PaletteBackStyle.SeparatorCustom2:
                case PaletteBackStyle.SeparatorCustom3:
                case PaletteBackStyle.PanelClient:
                case PaletteBackStyle.PanelCustom1:
                case PaletteBackStyle.PanelCustom2:
                case PaletteBackStyle.PanelCustom3:
                case PaletteBackStyle.ControlGroupBox:
                case PaletteBackStyle.GridBackgroundList:
                case PaletteBackStyle.GridBackgroundSheet:
                case PaletteBackStyle.GridBackgroundCustom1:
                case PaletteBackStyle.GridBackgroundCustom2:
                case PaletteBackStyle.GridBackgroundCustom3:
                    return _ribbonColors[(int)SchemeOfficeColors.PanelClient];
                case PaletteBackStyle.PanelAlternate:
                    return _ribbonColors[(int)SchemeOfficeColors.PanelAlternative];
                case PaletteBackStyle.PanelRibbonInactive:
                    return _ribbonColors[(int)SchemeOfficeColors.FormBorderInactiveDark];
                case PaletteBackStyle.FormMain:
                case PaletteBackStyle.FormCustom1:
                case PaletteBackStyle.FormCustom2:
                case PaletteBackStyle.FormCustom3:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormBorderInactiveDark]
                        : _ribbonColors[(int)SchemeOfficeColors.FormBorderActiveDark];

                case PaletteBackStyle.ControlClient:
                case PaletteBackStyle.ControlAlternate:
                case PaletteBackStyle.ControlCustom1:
                case PaletteBackStyle.ControlCustom2:
                case PaletteBackStyle.ControlCustom3:
                    return SystemColors.Window;
                case PaletteBackStyle.InputControlStandalone:
                case PaletteBackStyle.InputControlRibbon:
                case PaletteBackStyle.InputControlCustom1:
                case PaletteBackStyle.InputControlCustom2:
                case PaletteBackStyle.InputControlCustom3:
                    if (state == PaletteState.Disabled)
                    {
                        return _ribbonColors[(int)SchemeOfficeColors.InputControlBackDisabled];
                    }
                    else
                    {
                        return (state == PaletteState.Tracking) || (style == PaletteBackStyle.InputControlStandalone)
                            ? _ribbonColors[(int)SchemeOfficeColors.InputControlBackNormal]
                            : _ribbonColors[(int)SchemeOfficeColors.InputControlBackInactive];
                    }
                case PaletteBackStyle.ControlRibbon:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonTabSelected4];
                case PaletteBackStyle.ControlRibbonAppMenu:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonBack2];
                case PaletteBackStyle.ControlToolTip:
                    return _ribbonColors[(int)SchemeOfficeColors.ToolTipBottom];
                case PaletteBackStyle.ContextMenuOuter:
                    return _contextMenuBack;
                case PaletteBackStyle.ContextMenuSeparator:
                case PaletteBackStyle.ContextMenuItemSplit:
                    return state switch
                    {
                        PaletteState.Tracking => _buttonBackColors[3],
                        _ => _contextMenuBack
                    };
                case PaletteBackStyle.ContextMenuInner:
                    return _contextMenuBack;
                case PaletteBackStyle.ContextMenuHeading:
                    return _ribbonColors[(int)SchemeOfficeColors.ContextMenuHeadingBack];
                case PaletteBackStyle.ContextMenuItemImageColumn:
                    return _ribbonColors[(int)SchemeOfficeColors.ContextMenuImageColumn];
                case PaletteBackStyle.ContextMenuItemImage:
                    return _contextMenuImageBackChecked;
                case PaletteBackStyle.ButtonForm:
                    return state switch
                    {
                        PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                        PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack2Checked],
                        PaletteState.Tracking => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack2Track],
                        PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack2CheckTrack],
                        PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.FormButtonBack2Pressed],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.ButtonFormClose:
                    return state switch
                    {
                        PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                        PaletteState.CheckedNormal => _formCloseChecked2,
                        PaletteState.Tracking => _formCloseTracking2,
                        PaletteState.CheckedTracking => _formCloseCheckedTracking2,
                        PaletteState.Pressed or PaletteState.CheckedPressed => _formClosePressed2,
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.ButtonStandalone:
                case PaletteBackStyle.ButtonGallery:
                case PaletteBackStyle.ButtonAlternate:
                case PaletteBackStyle.ButtonLowProfile:
                case PaletteBackStyle.ButtonBreadCrumb:
                case PaletteBackStyle.ButtonListItem:
                case PaletteBackStyle.ButtonCommand:
                case PaletteBackStyle.ButtonButtonSpec:
                case PaletteBackStyle.ButtonCalendarDay:
                case PaletteBackStyle.ButtonCluster:
                case PaletteBackStyle.ButtonCustom1:
                case PaletteBackStyle.ButtonCustom2:
                case PaletteBackStyle.ButtonCustom3:
                case PaletteBackStyle.ButtonInputControl:
                case PaletteBackStyle.ContextMenuItemHighlight:
                    return state switch
                    {
                        PaletteState.Disabled => style == PaletteBackStyle.ButtonGallery ? _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBack1] : _buttonBackColors[1],
                        PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack2],
                        PaletteState.NormalDefaultOverride => style is PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ContextMenuItemHighlight
? GlobalStaticValues.EMPTY_COLOR
: _ribbonColors[(int)SchemeOfficeColors.ButtonNormalDefaultBack2],
                        PaletteState.CheckedNormal => style == PaletteBackStyle.ButtonInputControl ? _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack2] : _buttonBackColors[7],
                        PaletteState.Tracking => _buttonBackColors[3],
                        PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBackColors[5],
                        PaletteState.CheckedTracking => style == PaletteBackStyle.ButtonInputControl ? _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1] : _buttonBackColors[9],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                case PaletteBackStyle.ButtonNavigatorStack:
                case PaletteBackStyle.ButtonNavigatorOverflow:
                case PaletteBackStyle.ButtonNavigatorMini:
                    return state switch
                    {
                        PaletteState.Disabled => _buttonBackColors[1],
                        PaletteState.Tracking => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorTrack2],
                        PaletteState.Pressed => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorPressed2],
                        PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorChecked2],
                        _ => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalNavigatorBack2]
                    };
                default:
                    throw DebugTools.NotImplemented(style.ToString());
            }
        }

        /// <summary>
        /// Gets the color background drawing style.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color drawing style.</returns>
        public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteColorStyle.Inherit;
            }

            return style switch
            {
                PaletteBackStyle.HeaderForm => PaletteColorStyle.Rounding5,
                PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 => PaletteColorStyle.Rounded,
                PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 => PaletteColorStyle.Linear,
                PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderRowSheet => PaletteColorStyle.Linear,
                PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 => PaletteColorStyle.Solid,
                PaletteBackStyle.GridDataCellSheet => PaletteColorStyle.ExpertChecked,
                PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 => state switch
                {
                    PaletteState.Tracking or PaletteState.Pressed or PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => PaletteColorStyle.GlassFade,
                    _ => PaletteColorStyle.QuarterPhase
                },
                PaletteBackStyle.TabStandardProfile => state switch
                {
                    PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => PaletteColorStyle.Solid,
                    PaletteState.Tracking or PaletteState.Pressed => PaletteColorStyle.GlassFade,
                    _ => PaletteColorStyle.QuarterPhase
                },
                PaletteBackStyle.TabLowProfile => PaletteColorStyle.Solid,
                PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden => PaletteColorStyle.Linear,
                PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuItemImageColumn or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.ButtonCalendarDay => PaletteColorStyle.Solid,
                PaletteBackStyle.ControlRibbonAppMenu => PaletteColorStyle.Switch90,
                PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit => state == PaletteState.Tracking ? PaletteColorStyle.GlassTrackingFull : PaletteColorStyle.Solid,
                PaletteBackStyle.ControlToolTip => PaletteColorStyle.Linear,
                PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 => PaletteColorStyle.SolidAllLine,
                PaletteBackStyle.SeparatorHighProfile => PaletteColorStyle.RoundedTopLight,
                PaletteBackStyle.SeparatorHighInternalProfile => PaletteColorStyle.Linear,
                PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.HeaderDockActive => PaletteColorStyle.Rounded,
                PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride or PaletteState.CheckedNormal or PaletteState.Tracking or PaletteState.CheckedTracking => PaletteColorStyle.Linear,
                    PaletteState.Pressed or PaletteState.CheckedPressed => PaletteColorStyle.LinearShadow,
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.ContextMenuItemHighlight => state switch
                {
                    PaletteState.Disabled => PaletteColorStyle.Solid,
                    PaletteState.Normal => PaletteColorStyle.Linear,
                    PaletteState.Tracking => PaletteColorStyle.ExpertTracking,
                    PaletteState.Pressed or PaletteState.CheckedPressed => PaletteColorStyle.ExpertPressed,
                    PaletteState.CheckedNormal => PaletteColorStyle.ExpertChecked,
                    PaletteState.CheckedTracking => PaletteColorStyle.ExpertCheckedTracking,
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBackStyle.ContextMenuItemImage => PaletteColorStyle.Solid,
                PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini => state switch
                {
                    PaletteState.Tracking or PaletteState.Pressed => PaletteColorStyle.SolidAllLine,
                    PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => PaletteColorStyle.ExpertSquareHighlight,
                    _ => PaletteColorStyle.Solid
                },
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color alignment.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color alignment style.</returns>
        public override PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ControlRibbonAppMenu or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 or PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 => PaletteRectangleAlign.Control,
                PaletteBackStyle.ControlToolTip or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorHighInternalProfile or PaletteBackStyle.SeparatorHighProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderDockActive or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderForm or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabStandardProfile or PaletteBackStyle.TabLowProfile or PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 or PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowSheet or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 or PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellSheet or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 or PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit or PaletteBackStyle.ContextMenuItemImageColumn => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color background angle.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Angle used for color drawing.</returns>
        public override float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return -1f;
            }

            return style switch
            {
                PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorHighInternalProfile or PaletteBackStyle.SeparatorHighProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlToolTip or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ControlRibbonAppMenu or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit or PaletteBackStyle.ContextMenuItemImageColumn or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 or PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderDockActive or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderForm or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabStandardProfile or PaletteBackStyle.TabLowProfile or PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 or PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 or PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowSheet or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 or PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellSheet or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 => 90f,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets a background image.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image instance.</returns>
        public override Image? GetBackImage(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return null;
            }

            return style switch
            {
                PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorHighInternalProfile or PaletteBackStyle.SeparatorHighProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlToolTip or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ControlRibbonAppMenu or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit or PaletteBackStyle.ContextMenuItemImageColumn or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 or PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderDockActive or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderForm or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabStandardProfile or PaletteBackStyle.TabLowProfile or PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 or PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 or PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowSheet or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 or PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellSheet or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 => null,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the background image style.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image style value.</returns>
        public override PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteImageStyle.Inherit;
            }

            return style switch
            {
                PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorHighInternalProfile or PaletteBackStyle.SeparatorHighProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlToolTip or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ControlRibbonAppMenu or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit or PaletteBackStyle.ContextMenuItemImageColumn or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 or PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderDockActive or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderForm or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabStandardProfile or PaletteBackStyle.TabLowProfile or PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 or PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 or PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowSheet or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 or PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellSheet or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 => PaletteImageStyle.Tile,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the image alignment.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image alignment style.</returns>
        public override PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteBackStyle.PanelClient or PaletteBackStyle.PanelRibbonInactive or PaletteBackStyle.PanelAlternate or PaletteBackStyle.PanelCustom1 or PaletteBackStyle.PanelCustom2 or PaletteBackStyle.PanelCustom3 or PaletteBackStyle.SeparatorLowProfile or PaletteBackStyle.SeparatorHighInternalProfile or PaletteBackStyle.SeparatorHighProfile or PaletteBackStyle.SeparatorCustom1 or PaletteBackStyle.SeparatorCustom2 or PaletteBackStyle.SeparatorCustom3 or PaletteBackStyle.ControlClient or PaletteBackStyle.ControlAlternate or PaletteBackStyle.ControlGroupBox or PaletteBackStyle.ControlToolTip or PaletteBackStyle.ControlRibbon or PaletteBackStyle.ControlRibbonAppMenu or PaletteBackStyle.ControlCustom1 or PaletteBackStyle.ControlCustom2 or PaletteBackStyle.ControlCustom3 or PaletteBackStyle.ContextMenuOuter or PaletteBackStyle.ContextMenuInner or PaletteBackStyle.ContextMenuHeading or PaletteBackStyle.ContextMenuSeparator or PaletteBackStyle.ContextMenuItemSplit or PaletteBackStyle.ContextMenuItemImageColumn or PaletteBackStyle.InputControlStandalone or PaletteBackStyle.InputControlRibbon or PaletteBackStyle.InputControlCustom1 or PaletteBackStyle.InputControlCustom2 or PaletteBackStyle.InputControlCustom3 or PaletteBackStyle.FormMain or PaletteBackStyle.FormCustom1 or PaletteBackStyle.FormCustom2 or PaletteBackStyle.FormCustom3 or PaletteBackStyle.HeaderPrimary or PaletteBackStyle.HeaderDockInactive or PaletteBackStyle.HeaderDockActive or PaletteBackStyle.HeaderCalendar or PaletteBackStyle.HeaderSecondary or PaletteBackStyle.HeaderForm or PaletteBackStyle.HeaderCustom1 or PaletteBackStyle.HeaderCustom2 or PaletteBackStyle.HeaderCustom3 or PaletteBackStyle.TabHighProfile or PaletteBackStyle.TabStandardProfile or PaletteBackStyle.TabLowProfile or PaletteBackStyle.TabOneNote or PaletteBackStyle.TabDock or PaletteBackStyle.TabDockAutoHidden or PaletteBackStyle.TabCustom1 or PaletteBackStyle.TabCustom2 or PaletteBackStyle.TabCustom3 or PaletteBackStyle.ButtonStandalone or PaletteBackStyle.ButtonGallery or PaletteBackStyle.ButtonAlternate or PaletteBackStyle.ButtonLowProfile or PaletteBackStyle.ButtonBreadCrumb or PaletteBackStyle.ButtonListItem or PaletteBackStyle.ButtonCommand or PaletteBackStyle.ButtonButtonSpec or PaletteBackStyle.ButtonCalendarDay or PaletteBackStyle.ButtonCluster or PaletteBackStyle.ButtonNavigatorStack or PaletteBackStyle.ButtonNavigatorOverflow or PaletteBackStyle.ButtonNavigatorMini or PaletteBackStyle.ButtonForm or PaletteBackStyle.ButtonFormClose or PaletteBackStyle.ButtonCustom1 or PaletteBackStyle.ButtonCustom2 or PaletteBackStyle.ButtonCustom3 or PaletteBackStyle.ButtonInputControl or PaletteBackStyle.ContextMenuItemImage or PaletteBackStyle.ContextMenuItemHighlight or PaletteBackStyle.GridBackgroundList or PaletteBackStyle.GridBackgroundSheet or PaletteBackStyle.GridBackgroundCustom1
                    or PaletteBackStyle.GridBackgroundCustom2
                    or PaletteBackStyle.GridBackgroundCustom3
 or PaletteBackStyle.GridHeaderColumnList or PaletteBackStyle.GridHeaderColumnSheet or PaletteBackStyle.GridHeaderColumnCustom1 or PaletteBackStyle.GridHeaderColumnCustom2 or PaletteBackStyle.GridHeaderColumnCustom3 or PaletteBackStyle.GridHeaderRowList or PaletteBackStyle.GridHeaderRowSheet or PaletteBackStyle.GridHeaderRowCustom1 or PaletteBackStyle.GridHeaderRowCustom2 or PaletteBackStyle.GridHeaderRowCustom3 or PaletteBackStyle.GridDataCellList or PaletteBackStyle.GridDataCellSheet or PaletteBackStyle.GridDataCellCustom1 or PaletteBackStyle.GridDataCellCustom2 or PaletteBackStyle.GridDataCellCustom3 => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }
        #endregion

        #region Border
        /// <summary>
        /// Gets a value indicating if border should be drawn.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
        {
            // Check for the calendar day today override
            if (state == PaletteState.TodayOverride)
            {
                if (style == PaletteBorderStyle.ButtonCalendarDay)
                {
                    return InheritBool.True;
                }
            }

            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return InheritBool.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ContextMenuInner => InheritBool.False,
                PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => InheritBool.True,
                PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonInputControl => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => InheritBool.False,
                    _ => InheritBool.True
                },
                PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight => state switch
                {
                    PaletteState.Normal or PaletteState.NormalDefaultOverride => InheritBool.False,
                    _ => InheritBool.True
                },
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets a value indicating which borders to draw.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteDrawBorders value.</returns>
        public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteDrawBorders.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => PaletteDrawBorders.All,
                PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 => PaletteDrawBorders.All,
                PaletteBorderStyle.ContextMenuHeading => PaletteDrawBorders.Bottom,
                PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit => PaletteDrawBorders.Top,
                PaletteBorderStyle.ContextMenuItemImageColumn => PaletteDrawBorders.Right,
                PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ContextMenuInner => PaletteDrawBorders.None,
                PaletteBorderStyle.HeaderForm => PaletteDrawBorders.None,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the graphics drawing hint for the border.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteGraphicsHint value.</returns>
        public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteGraphicsHint.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => PaletteGraphicsHint.AntiAlias,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the first border color.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
        {
            if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
            {
                // Check for the calendar day today override
                if (state == PaletteState.TodayOverride)
                {
                    if (style == PaletteBorderStyle.ButtonCalendarDay)
                    {
                        return state == PaletteState.Disabled ? _disabledBorder : _todayBorder;
                    }
                }

                return GlobalStaticValues.EMPTY_COLOR;
            }

            return style switch
            {
                PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 => state switch
                {
                    PaletteState.Disabled => style == PaletteBorderStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _disabledBorder,
                    PaletteState.Normal or PaletteState.Tracking or PaletteState.Pressed => style == PaletteBorderStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.ControlBorder],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.TabDock => state switch
                {
                    PaletteState.Disabled => _disabledBorder,
                    PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.Tracking or PaletteState.Pressed => _buttonBorderColors[2],
                    PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.ControlBorder],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.TabDockAutoHidden => state switch
                {
                    PaletteState.Disabled => _disabledBorder,
                    PaletteState.Normal or PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.Tracking or PaletteState.CheckedTracking or PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBorderColors[2],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.HeaderCalendar => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack1]
: _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack2],
                PaletteBorderStyle.HeaderForm => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderInactive]
: _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderActive],
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.ControlBorder],
                PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuItemImageColumn => _contextMenuHeadingBorder,
                PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit => state switch
                {
                    PaletteState.Disabled => _buttonBorderColors[0],
                    PaletteState.Tracking => _buttonBorderColors[1],
                    _ => _contextMenuHeadingBorder
                },
                PaletteBorderStyle.ContextMenuItemImage => _contextMenuImageBorderChecked,
                PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputControlBorderDisabled]
: _ribbonColors[(int)SchemeOfficeColors.InputControlBorderNormal],
                PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.GridDataCellBorder],
                PaletteBorderStyle.ControlRibbon => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea1],
                PaletteBorderStyle.ControlRibbonAppMenu => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.AppButtonBorder],
                PaletteBorderStyle.ContextMenuOuter => _contextMenuBorder,
                PaletteBorderStyle.ContextMenuInner => _contextMenuBack,
                PaletteBorderStyle.ControlToolTip => state == PaletteState.Disabled ? _disabledBorder : _toolTipBorder,
                PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.FormBorderInactive]
: _ribbonColors[(int)SchemeOfficeColors.FormBorderActive],
                PaletteBorderStyle.ButtonForm => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                    PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.FormButtonBorderCheck],
                    PaletteState.Tracking or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.FormButtonBorderTrack],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.FormButtonBorderPressed],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonFormClose => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                    PaletteState.CheckedNormal => _formCloseBorderCheckedNormal,
                    PaletteState.Tracking or PaletteState.CheckedTracking => _formCloseBorderTracking,
                    PaletteState.Pressed or PaletteState.CheckedPressed => _formCloseBorderPressed,
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ContextMenuItemHighlight => state switch
                {
                    PaletteState.Disabled => style == PaletteBorderStyle.ButtonGallery ? _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBack2] : _buttonBorderColors[0],
                    PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.NormalDefaultOverride => style is PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ContextMenuItemHighlight
? GlobalStaticValues.EMPTY_COLOR
: _ribbonColors[(int)SchemeOfficeColors.ButtonNormalDefaultBorder],
                    PaletteState.CheckedNormal => _buttonBorderColors[5],
                    PaletteState.Tracking => _buttonBorderColors[1],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBorderColors[3],
                    PaletteState.CheckedTracking => _buttonBorderColors[3],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonInputControl => state switch
                {
                    PaletteState.Disabled => _buttonBorderColors[0],
                    PaletteState.Normal or PaletteState.CheckedNormal or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.Tracking => _buttonBorderColors[1],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBorderColors[3],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonCalendarDay => state switch
                {
                    PaletteState.Disabled => _disabledBack,
                    PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1],
                    PaletteState.NormalDefaultOverride => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalDefaultBack1],
                    PaletteState.CheckedNormal => _buttonBackColors[6],
                    PaletteState.Tracking => _buttonBackColors[2],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBackColors[4],
                    PaletteState.CheckedTracking => _buttonBackColors[8],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorBorder],
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the second border color.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
        {
            if (CommonHelper.IsOverrideState(state))
            {
                // Check for the calendar day today override
                if (state == PaletteState.TodayOverride)
                {
                    if (style == PaletteBorderStyle.ButtonCalendarDay)
                    {
                        return state == PaletteState.Disabled ? _disabledBorder : _todayBorder;
                    }
                }

                return GlobalStaticValues.EMPTY_COLOR;
            }

            return style switch
            {
                PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 => state switch
                {
                    PaletteState.Disabled => style == PaletteBorderStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _disabledBorder,
                    PaletteState.Normal or PaletteState.Tracking or PaletteState.Pressed => style == PaletteBorderStyle.TabLowProfile ? GlobalStaticValues.EMPTY_COLOR : _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.ControlBorder],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.TabDock => state switch
                {
                    PaletteState.Disabled => _disabledBorder,
                    PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.Tracking or PaletteState.Pressed => _buttonBorderColors[2],
                    PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.ControlBorder],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.TabDockAutoHidden => state switch
                {
                    PaletteState.Disabled => _disabledBorder,
                    PaletteState.Normal or PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.Tracking or PaletteState.CheckedTracking or PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBorderColors[2],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.HeaderForm => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderInactive]
: _ribbonColors[(int)SchemeOfficeColors.FormBorderHeaderActive],
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.ControlBorder],
                PaletteBorderStyle.HeaderCalendar => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack1]
: _ribbonColors[(int)SchemeOfficeColors.HeaderPrimaryBack2],
                PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuItemImageColumn => _contextMenuHeadingBorder,
                PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit => state switch
                {
                    PaletteState.Disabled => _buttonBorderColors[0],
                    PaletteState.Tracking => _buttonBorderColors[2],
                    _ => _contextMenuHeadingBorder
                },
                PaletteBorderStyle.ContextMenuItemImage => _contextMenuImageBorderChecked,
                PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputControlBorderDisabled]
: _ribbonColors[(int)SchemeOfficeColors.InputControlBorderNormal],
                PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.GridDataCellBorder],
                PaletteBorderStyle.ControlRibbon => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea1],
                PaletteBorderStyle.ControlRibbonAppMenu => state == PaletteState.Disabled ? _disabledBorder : _ribbonColors[(int)SchemeOfficeColors.AppButtonBorder],
                PaletteBorderStyle.ContextMenuOuter => _contextMenuBorder,
                PaletteBorderStyle.ContextMenuInner => _contextMenuBack,
                PaletteBorderStyle.ControlToolTip => state == PaletteState.Disabled ? _disabledBorder : _toolTipBorder,
                PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.FormBorderInactive]
: _ribbonColors[(int)SchemeOfficeColors.FormBorderActive],
                PaletteBorderStyle.ButtonForm => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                    PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.FormButtonBorderCheck],
                    PaletteState.Tracking or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.FormButtonBorderTrack],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.FormButtonBorderPressed],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonFormClose => state switch
                {
                    PaletteState.Disabled or PaletteState.Normal or PaletteState.NormalDefaultOverride => GlobalStaticValues.EMPTY_COLOR,
                    PaletteState.CheckedNormal => _formCloseBorderCheckedNormal,
                    PaletteState.Tracking or PaletteState.CheckedTracking => _formCloseBorderTracking,
                    PaletteState.Pressed or PaletteState.CheckedPressed => _formCloseBorderPressed,
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ContextMenuItemHighlight => state switch
                {
                    PaletteState.Disabled => style == PaletteBorderStyle.ButtonGallery ? _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBack2] : _buttonBorderColors[0],
                    PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.NormalDefaultOverride => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalDefaultBorder],
                    PaletteState.CheckedNormal => _buttonBorderColors[6],
                    PaletteState.Tracking => _buttonBorderColors[2],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBorderColors[4],
                    PaletteState.CheckedTracking => _buttonBorderColors[4],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonInputControl => state switch
                {
                    PaletteState.Disabled => _buttonBorderColors[0],
                    PaletteState.Normal or PaletteState.CheckedNormal or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                    PaletteState.Tracking => _buttonBorderColors[2],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBorderColors[4],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonCalendarDay => state switch
                {
                    PaletteState.Disabled => _disabledBack,
                    PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1],
                    PaletteState.NormalDefaultOverride => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalDefaultBack1],
                    PaletteState.CheckedNormal => _buttonBackColors[6],
                    PaletteState.Tracking => _buttonBackColors[2],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _buttonBackColors[4],
                    PaletteState.CheckedTracking => _buttonBackColors[8],
                    _ => throw DebugTools.NotImplemented(state.ToString())
                },
                PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini => _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorBorder],
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color border drawing style.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color drawing style.</returns>
        public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
            {
                return PaletteColorStyle.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 => PaletteColorStyle.Sigma,
                PaletteBorderStyle.TabDock => state switch
                {
                    PaletteState.Tracking or PaletteState.Pressed => PaletteColorStyle.Solid,
                    _ => PaletteColorStyle.Sigma
                },
                PaletteBorderStyle.TabDockAutoHidden => state switch
                {
                    PaletteState.Tracking or PaletteState.CheckedTracking or PaletteState.Pressed or PaletteState.CheckedPressed => PaletteColorStyle.Solid,
                    _ => PaletteColorStyle.Sigma
                },
                PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.ButtonCalendarDay => PaletteColorStyle.Solid,
                PaletteBorderStyle.ContextMenuItemSplit => state == PaletteState.Tracking ? PaletteColorStyle.Sigma : PaletteColorStyle.Solid,
                PaletteBorderStyle.ContextMenuSeparator => PaletteColorStyle.Dashed,
                PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.ContextMenuItemHighlight => state switch
                {
                    PaletteState.Normal => PaletteColorStyle.Solid,
                    PaletteState.Disabled or PaletteState.NormalDefaultOverride => PaletteColorStyle.Solid,
                    _ => PaletteColorStyle.Linear
                },
                PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose => PaletteColorStyle.Solid,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color border alignment.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color alignment style.</returns>
        public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 => PaletteRectangleAlign.Control,
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color border angle.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Angle used for color drawing.</returns>
        public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return -1f;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => 90f,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the border width.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Integer width.</returns>
        public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return -1;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ContextMenuInner => 0,
                PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => 1,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the border corner rounding.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Float rounding.</returns>
        public override float GetBorderRounding(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.DEFAULT_PRIMARY_CORNER_ROUNDING_VALUE;
            }

            return style switch
            {
                PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini => 0,
                PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ContextMenuItemImage => 1,
                PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuItemHighlight => 0,//Changed 2013
                PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlGroupBox => 3,
                PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 => 0,//Changed 2013
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets a border image.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image instance.</returns>
        public override Image? GetBorderImage(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return null;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => null,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the border image style.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image style value.</returns>
        public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteImageStyle.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => PaletteImageStyle.Tile,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the image border alignment.
        /// </summary>
        /// <param name="style">Border style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image alignment style.</returns>
        public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteBorderStyle.SeparatorLowProfile or PaletteBorderStyle.SeparatorHighInternalProfile or PaletteBorderStyle.SeparatorHighProfile or PaletteBorderStyle.SeparatorCustom1 or PaletteBorderStyle.SeparatorCustom2 or PaletteBorderStyle.SeparatorCustom3 or PaletteBorderStyle.ControlClient or PaletteBorderStyle.ControlAlternate or PaletteBorderStyle.ControlGroupBox or PaletteBorderStyle.ControlToolTip or PaletteBorderStyle.ControlRibbon or PaletteBorderStyle.ControlRibbonAppMenu or PaletteBorderStyle.ControlCustom1 or PaletteBorderStyle.ControlCustom2 or PaletteBorderStyle.ControlCustom3 or PaletteBorderStyle.ContextMenuOuter or PaletteBorderStyle.ContextMenuInner or PaletteBorderStyle.ContextMenuHeading or PaletteBorderStyle.ContextMenuSeparator or PaletteBorderStyle.ContextMenuItemSplit or PaletteBorderStyle.ContextMenuItemImage or PaletteBorderStyle.ContextMenuItemImageColumn or PaletteBorderStyle.ContextMenuItemHighlight or PaletteBorderStyle.InputControlStandalone or PaletteBorderStyle.InputControlRibbon or PaletteBorderStyle.InputControlCustom1 or PaletteBorderStyle.InputControlCustom2 or PaletteBorderStyle.InputControlCustom3 or PaletteBorderStyle.FormMain or PaletteBorderStyle.FormCustom1 or PaletteBorderStyle.FormCustom2 or PaletteBorderStyle.FormCustom3 or PaletteBorderStyle.HeaderPrimary or PaletteBorderStyle.HeaderDockInactive or PaletteBorderStyle.HeaderDockActive or PaletteBorderStyle.HeaderCalendar or PaletteBorderStyle.HeaderSecondary or PaletteBorderStyle.HeaderForm or PaletteBorderStyle.HeaderCustom1 or PaletteBorderStyle.HeaderCustom2 or PaletteBorderStyle.HeaderCustom3 or PaletteBorderStyle.TabHighProfile or PaletteBorderStyle.TabStandardProfile or PaletteBorderStyle.TabLowProfile or PaletteBorderStyle.TabOneNote or PaletteBorderStyle.TabDock or PaletteBorderStyle.TabDockAutoHidden or PaletteBorderStyle.TabCustom1 or PaletteBorderStyle.TabCustom2 or PaletteBorderStyle.TabCustom3 or PaletteBorderStyle.ButtonStandalone or PaletteBorderStyle.ButtonGallery or PaletteBorderStyle.ButtonAlternate or PaletteBorderStyle.ButtonLowProfile or PaletteBorderStyle.ButtonBreadCrumb or PaletteBorderStyle.ButtonListItem or PaletteBorderStyle.ButtonCommand or PaletteBorderStyle.ButtonButtonSpec or PaletteBorderStyle.ButtonCalendarDay or PaletteBorderStyle.ButtonCluster or PaletteBorderStyle.ButtonNavigatorStack or PaletteBorderStyle.ButtonNavigatorOverflow or PaletteBorderStyle.ButtonNavigatorMini or PaletteBorderStyle.ButtonForm or PaletteBorderStyle.ButtonFormClose or PaletteBorderStyle.ButtonCustom1 or PaletteBorderStyle.ButtonCustom2 or PaletteBorderStyle.ButtonCustom3 or PaletteBorderStyle.ButtonInputControl or PaletteBorderStyle.GridHeaderColumnList or PaletteBorderStyle.GridHeaderColumnSheet or PaletteBorderStyle.GridHeaderColumnCustom1 or PaletteBorderStyle.GridHeaderColumnCustom2 or PaletteBorderStyle.GridHeaderColumnCustom3 or PaletteBorderStyle.GridHeaderRowList or PaletteBorderStyle.GridHeaderRowSheet or PaletteBorderStyle.GridHeaderRowCustom1 or PaletteBorderStyle.GridHeaderRowCustom2 or PaletteBorderStyle.GridHeaderRowCustom3 or PaletteBorderStyle.GridDataCellList or PaletteBorderStyle.GridDataCellSheet or PaletteBorderStyle.GridDataCellCustom1 or PaletteBorderStyle.GridDataCellCustom2 or PaletteBorderStyle.GridDataCellCustom3 => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }
        #endregion

        #region Content
        /// <summary>
        /// Gets a value indicating if content should be drawn.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return InheritBool.Inherit;
            }

            // Always draw everything
            return InheritBool.True;
        }

        /// <summary>
        /// Gets a value indicating if content should be drawn with focus indication.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
        {
            // By default, the focus override shows the focus!
            if (state == PaletteState.FocusOverride)
            {
                return InheritBool.True;
            }

            // We do not override the other override states
            if (CommonHelper.IsOverrideState(state))
            {
                return InheritBool.Inherit;
            }

            // By default, never show the focus indication, we let individual controls
            // override this functionality as required by the controls requirements
            return InheritBool.False;
        }

        /// <summary>
        /// Gets the horizontal relative alignment of the image.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Near,
                PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText => PaletteRelativeAlign.Center,
                PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl => PaletteRelativeAlign.Center,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the vertical relative alignment of the image.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Center,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the effect applied to drawing of the image.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteImageEffect value.</returns>
        public override PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteImageEffect.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => state == PaletteState.Disabled ? PaletteImageEffect.Disabled : PaletteImageEffect.Normal,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the image color to remap into another color.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => GlobalStaticValues.EMPTY_COLOR,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color to use in place of the image map color.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => GlobalStaticValues.EMPTY_COLOR,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the image color that should be transparent.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentImageColorTransparent(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => GlobalStaticValues.EMPTY_COLOR,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the font for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Font? GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
        {
            if (CommonHelper.IsOverrideState(state))
            {
                return (state == PaletteState.BoldedOverride) && (style == PaletteContentStyle.ButtonCalendarDay) ? CalendarBoldFont : null;
            }

            return style switch
            {
                PaletteContentStyle.HeaderForm => HeaderFormFont,
                PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.ButtonCommand => Header1ShortFont,
                PaletteContentStyle.LabelSuperTip or PaletteContentStyle.ContextMenuHeading => SuperToolFont,
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemShortcutText => Header2ShortFont,
                PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelBoldPanel => BoldFont,
                PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelItalicControl => ItalicFont,
                PaletteContentStyle.ContextMenuItemTextAlternate => SuperToolFont,
                PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden => TabFontNormal,
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 => state switch
                {
                    PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => TabFontSelected,
                    _ => TabFontNormal
                },
                PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl => ButtonFont,
                PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow => ButtonFontNavigatorStack,
                PaletteContentStyle.ButtonNavigatorMini => ButtonFontNavigatorMini,
                PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.HeaderCalendar => GridFont,
                PaletteContentStyle.ButtonCalendarDay => CalendarFont,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the font for the short text by generating a new font instance.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Font? GetContentShortTextNewFont(PaletteContentStyle style, PaletteState state)
        {
            DefineFonts();
            return GetContentShortTextFont(style, state);
        }

        /// <summary>
        /// Gets the rendering hint for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextHint value.</returns>
        public override PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteTextHint.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteTextHint.ClearTypeGridFit,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the prefix drawing setting for short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextPrefix value.</returns>
        public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteTextHotkeyPrefix.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.HeaderForm => PaletteTextHotkeyPrefix.Show,
                PaletteContentStyle.ButtonListItem or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemShortcutText => PaletteTextHotkeyPrefix.None,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the flag indicating if multiline text is allowed for short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return InheritBool.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => InheritBool.True,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the text trimming to use for short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextTrim value.</returns>
        public override PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteTextTrim.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteTextTrim.EllipsisCharacter,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the horizontal relative alignment of the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Near,
                PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.HeaderCalendar => PaletteRelativeAlign.Center,
                PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl => PaletteRelativeAlign.Center,
                PaletteContentStyle.ContextMenuItemShortcutText => PaletteRelativeAlign.Far,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the vertical relative alignment of the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Center,
                PaletteContentStyle.LabelSuperTip => PaletteRelativeAlign.Near,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the horizontal relative alignment of multiline short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Near,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the first back color for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
        {
            // Always work out value for an override state
            if (CommonHelper.IsOverrideState(state))
            {
                return style switch
                {
                    PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl => state switch
                    {
                        PaletteState.LinkNotVisitedOverride => _ribbonColors[(int)SchemeOfficeColors.LinkNotVisitedOverrideControl],
                        PaletteState.LinkVisitedOverride => _ribbonColors[(int)SchemeOfficeColors.LinkVisitedOverrideControl],
                        PaletteState.LinkPressedOverride => _ribbonColors[(int)SchemeOfficeColors.LinkPressedOverrideControl],
                        _ => GlobalStaticValues.EMPTY_COLOR // All other override states do nothing
                    },
                    PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption => state switch
                    {
                        PaletteState.LinkNotVisitedOverride => _ribbonColors[(int)SchemeOfficeColors.LinkNotVisitedOverridePanel],
                        PaletteState.LinkVisitedOverride => _ribbonColors[(int)SchemeOfficeColors.LinkVisitedOverridePanel],
                        PaletteState.LinkPressedOverride => _ribbonColors[(int)SchemeOfficeColors.LinkPressedOverridePanel],
                        _ => GlobalStaticValues.EMPTY_COLOR // All other override states do nothing
                    },
                    _ => GlobalStaticValues.EMPTY_COLOR
                };
            }

            switch (style)
            {
                case PaletteContentStyle.HeaderForm:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormHeaderShortInactive]
                        : _ribbonColors[(int)SchemeOfficeColors.FormHeaderShortActive];
            }

            if ((state == PaletteState.Disabled) &&
                (style != PaletteContentStyle.LabelToolTip) &&
                (style != PaletteContentStyle.LabelSuperTip) &&
                (style != PaletteContentStyle.LabelKeyTip) &&
                (style != PaletteContentStyle.InputControlStandalone) &&
                (style != PaletteContentStyle.InputControlRibbon) &&
                (style != PaletteContentStyle.InputControlCustom1) &&
                (style != PaletteContentStyle.InputControlCustom2) &&
                (style != PaletteContentStyle.InputControlCustom3) &&
                (style != PaletteContentStyle.ButtonInputControl) &&
                (style != PaletteContentStyle.ButtonCalendarDay))
            {
                return _disabledText;
            }

            return style switch
            {
                PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.HeaderCalendar => _gridTextColor,
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 => _ribbonColors[(int)SchemeOfficeColors.HeaderText],
                PaletteContentStyle.HeaderDockActive => Color.Black,
                PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputControlTextDisabled]
: _ribbonColors[(int)SchemeOfficeColors.InputControlTextNormal],
                PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption => _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.ContextMenuItemTextAlternate => _ribbonColors[(int)SchemeOfficeColors.TextLabelControl],
                PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip => _toolTipText,
                PaletteContentStyle.ContextMenuHeading => _ribbonColors[(int)SchemeOfficeColors.ContextMenuHeadingText],
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.TabDockAutoHidden => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.ButtonCalendarDay => state == PaletteState.Disabled ? _disabledText2 : Color.Black,
                PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonButtonSpec => state switch
                {
                    PaletteState.Normal => style == PaletteContentStyle.ButtonListItem
                                                   ? _ribbonColors[(int)SchemeOfficeColors.TextLabelControl]
                                                   : _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                    PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal]
                },
                PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose => state switch
                {
                    PaletteState.Tracking or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormTracking],
                    PaletteState.Pressed or PaletteState.CheckedPressed or PaletteState.CheckedNormal => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormPressed],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormNormal]
                },
                PaletteContentStyle.ButtonInputControl => state != PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputDropDownNormal1]
: _ribbonColors[(int)SchemeOfficeColors.InputDropDownDisabled1],
                PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorText]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the second back color for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (style)
            {
                case PaletteContentStyle.HeaderForm:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormHeaderShortInactive]
                        : _ribbonColors[(int)SchemeOfficeColors.FormHeaderShortActive];
            }

            if ((state == PaletteState.Disabled) &&
                (style != PaletteContentStyle.LabelToolTip) &&
                (style != PaletteContentStyle.LabelSuperTip) &&
                (style != PaletteContentStyle.LabelKeyTip) &&
                (style != PaletteContentStyle.InputControlStandalone) &&
                (style != PaletteContentStyle.InputControlRibbon) &&
                (style != PaletteContentStyle.InputControlCustom1) &&
                (style != PaletteContentStyle.InputControlCustom2) &&
                (style != PaletteContentStyle.InputControlCustom3) &&
                (style != PaletteContentStyle.ButtonInputControl) &&
                (style != PaletteContentStyle.ButtonCalendarDay))
            {
                return _disabledText;
            }

            return style switch
            {
                PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.HeaderCalendar => _gridTextColor,
                PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 => _ribbonColors[(int)SchemeOfficeColors.HeaderText],
                PaletteContentStyle.HeaderDockActive => Color.Black,
                PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputControlTextDisabled]
: _ribbonColors[(int)SchemeOfficeColors.InputControlTextNormal],
                PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption => _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText => _ribbonColors[(int)SchemeOfficeColors.TextLabelControl],
                PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip => _toolTipText,
                PaletteContentStyle.ContextMenuHeading => _ribbonColors[(int)SchemeOfficeColors.ContextMenuHeadingText],
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.TabDockAutoHidden => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.ButtonCalendarDay => state == PaletteState.Disabled ? _disabledText2 : Color.Black,
                PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonButtonSpec => state switch
                {
                    PaletteState.Normal => style == PaletteContentStyle.ButtonListItem
                                                   ? _ribbonColors[(int)SchemeOfficeColors.TextLabelControl]
                                                   : _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                    PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal]
                },
                PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose => state switch
                {
                    PaletteState.Tracking or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormTracking],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormPressed],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormNormal]
                },
                PaletteContentStyle.ButtonInputControl => state != PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputDropDownNormal2]
: _ribbonColors[(int)SchemeOfficeColors.InputDropDownDisabled2],
                PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorText]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color drawing style for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color drawing style.</returns>
        public override PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteColorStyle.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteColorStyle.Solid,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color alignment for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color alignment style.</returns>
        public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color background angle for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Angle used for color drawing.</returns>
        public override float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return -1f;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => 90f,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets a background image for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image instance.</returns>
        public override Image? GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return null;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => null,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the background image style.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image style value.</returns>
        public override PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteImageStyle.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteImageStyle.TileFlipXY,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the image alignment for the short text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image alignment style.</returns>
        public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the font for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Font? GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
        {
            if (CommonHelper.IsOverrideState(state))
            {
                return (state == PaletteState.BoldedOverride) && (style == PaletteContentStyle.ButtonCalendarDay) ? CalendarBoldFont : null;
            }

            return style switch
            {
                PaletteContentStyle.ButtonCalendarDay => CalendarFont,
                PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.HeaderCalendar => GridFont,
                PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 => Header1LongFont,
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.HeaderSecondary => Header2LongFont,
                PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden => TabFontNormal,
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 => state switch
                {
                    PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking => TabFontSelected,
                    _ => TabFontNormal
                },
                PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl => ButtonFont,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the font for the long text by generating a new font instance.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Font? GetContentLongTextNewFont(PaletteContentStyle style, PaletteState state)
        {
            DefineFonts();
            return GetContentLongTextFont(style, state);
        }

        /// <summary>
        /// Gets the rendering hint for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextHint value.</returns>
        public override PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteTextHint.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteTextHint.ClearTypeGridFit,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the flag indicating if multiline text is allowed for long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return InheritBool.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => InheritBool.True,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the text trimming to use for long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextTrim value.</returns>
        public override PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteTextTrim.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteTextTrim.EllipsisCharacter,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the prefix drawing setting for long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextPrefix value.</returns>
        public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteTextHotkeyPrefix.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl => PaletteTextHotkeyPrefix.Show,
                PaletteContentStyle.ButtonListItem or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteTextHotkeyPrefix.None,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the horizontal relative alignment of the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.ContextMenuItemTextAlternate => PaletteRelativeAlign.Near,
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Far,
                PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl => PaletteRelativeAlign.Center,
                PaletteContentStyle.ButtonCalendarDay => PaletteRelativeAlign.Far,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the vertical relative alignment of the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Center,
                PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.ContextMenuItemTextAlternate => PaletteRelativeAlign.Far,
                PaletteContentStyle.LabelSuperTip => PaletteRelativeAlign.Center,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the horizontal relative alignment of multiline long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>RelativeAlignment value.</returns>
        public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRelativeAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRelativeAlign.Center,
                PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ButtonCommand => PaletteRelativeAlign.Near,
                PaletteContentStyle.ContextMenuItemShortcutText => PaletteRelativeAlign.Far,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the first back color for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (style)
            {
                case PaletteContentStyle.HeaderForm:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormHeaderLongInactive]
                        : _ribbonColors[(int)SchemeOfficeColors.FormHeaderLongActive];
            }

            if ((state == PaletteState.Disabled) &&
                (style != PaletteContentStyle.LabelToolTip) &&
                (style != PaletteContentStyle.LabelSuperTip) &&
                (style != PaletteContentStyle.LabelKeyTip) &&
                (style != PaletteContentStyle.InputControlStandalone) &&
                (style != PaletteContentStyle.InputControlRibbon) &&
                (style != PaletteContentStyle.InputControlCustom1) &&
                (style != PaletteContentStyle.InputControlCustom2) &&
                (style != PaletteContentStyle.InputControlCustom3) &&
                (style != PaletteContentStyle.ButtonInputControl))
            {
                return _disabledText;
            }

            return style switch
            {
                PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.HeaderCalendar => _gridTextColor,
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 => _ribbonColors[(int)SchemeOfficeColors.HeaderText],
                PaletteContentStyle.HeaderDockActive => Color.Black,
                PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputControlTextDisabled]
: _ribbonColors[(int)SchemeOfficeColors.InputControlTextNormal],
                PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption => _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.ContextMenuItemTextAlternate => _ribbonColors[(int)SchemeOfficeColors.TextLabelControl],
                PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip => _toolTipText,
                PaletteContentStyle.ContextMenuHeading => _ribbonColors[(int)SchemeOfficeColors.ContextMenuHeadingText],
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.TabDockAutoHidden => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay => state switch
                {
                    PaletteState.Normal => style == PaletteContentStyle.ButtonListItem
                                                   ? _ribbonColors[(int)SchemeOfficeColors.TextLabelControl]
                                                   : _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                    PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal]
                },
                PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose => state switch
                {
                    PaletteState.Tracking or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormTracking],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormPressed],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormNormal]
                },
                PaletteContentStyle.ButtonInputControl => state != PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputDropDownNormal1]
: _ribbonColors[(int)SchemeOfficeColors.InputDropDownDisabled1],
                PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorText]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the second back color for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (style)
            {
                case PaletteContentStyle.HeaderForm:
                    return state == PaletteState.Disabled
                        ? _ribbonColors[(int)SchemeOfficeColors.FormHeaderLongInactive]
                        : _ribbonColors[(int)SchemeOfficeColors.FormHeaderLongActive];
            }

            if ((state == PaletteState.Disabled) &&
                (style != PaletteContentStyle.LabelToolTip) &&
                (style != PaletteContentStyle.LabelSuperTip) &&
                (style != PaletteContentStyle.LabelKeyTip) &&
                (style != PaletteContentStyle.InputControlStandalone) &&
                (style != PaletteContentStyle.InputControlRibbon) &&
                (style != PaletteContentStyle.InputControlCustom1) &&
                (style != PaletteContentStyle.InputControlCustom2) &&
                (style != PaletteContentStyle.InputControlCustom3) &&
                (style != PaletteContentStyle.ButtonInputControl))
            {
                return _disabledText;
            }

            return style switch
            {
                PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 or PaletteContentStyle.HeaderCalendar => _gridTextColor,
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 => _ribbonColors[(int)SchemeOfficeColors.HeaderText],
                PaletteContentStyle.HeaderDockActive => Color.Black,
                PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 => state == PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputControlTextDisabled]
: _ribbonColors[(int)SchemeOfficeColors.InputControlTextNormal],
                PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption => _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText => _ribbonColors[(int)SchemeOfficeColors.TextLabelControl],
                PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip => _toolTipText,
                PaletteContentStyle.ContextMenuHeading => _ribbonColors[(int)SchemeOfficeColors.ContextMenuHeadingText],
                PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.TabDockAutoHidden => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay => state switch
                {
                    PaletteState.Normal => style == PaletteContentStyle.ButtonListItem
                                                   ? _ribbonColors[(int)SchemeOfficeColors.TextLabelControl]
                                                   : _ribbonColors[(int)SchemeOfficeColors.TextLabelPanel],
                    PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonChecked],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal]
                },
                PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose => state switch
                {
                    PaletteState.Tracking or PaletteState.CheckedTracking => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormTracking],
                    PaletteState.Pressed or PaletteState.CheckedPressed => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormPressed],
                    _ => _ribbonColors[(int)SchemeOfficeColors.TextButtonFormNormal]
                },
                PaletteContentStyle.ButtonInputControl => state != PaletteState.Disabled
? _ribbonColors[(int)SchemeOfficeColors.InputDropDownNormal2]
: _ribbonColors[(int)SchemeOfficeColors.InputDropDownDisabled2],
                PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow => state != PaletteState.Normal
? _ribbonColors[(int)SchemeOfficeColors.ButtonNavigatorText]
: _ribbonColors[(int)SchemeOfficeColors.TextButtonNormal],
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color drawing style for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color drawing style.</returns>
        public override PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteColorStyle.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteColorStyle.Solid,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color alignment for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color alignment style.</returns>
        public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the color background angle for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Angle used for color drawing.</returns>
        public override float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return -1f;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => 90f,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets a background image for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image instance.</returns>
        public override Image? GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return null;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => null,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the background image style for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image style value.</returns>
        public override PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteImageStyle.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteImageStyle.TileFlipXY,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the image alignment for the long text.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Image alignment style.</returns>
        public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return PaletteRectangleAlign.Inherit;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelSuperTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => PaletteRectangleAlign.Local,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }

        /// <summary>
        /// Gets the padding between the border and content drawing.
        /// </summary>
        /// <param name="owningForm"></param>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Padding value.</returns>
        public override Padding GetBorderContentPadding(KryptonForm? owningForm, PaletteContentStyle style,
            PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return CommonHelper.InheritPadding;
            }

            switch (style)
            {
                case PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet
                    or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2
                    or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList
                    or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1
                    or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3
                    or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet
                    or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2
                    or PaletteContentStyle.GridDataCellCustom3:
                    return _contentPaddingGrid;
                case PaletteContentStyle.HeaderForm:
                    {
                        Padding borders = owningForm!.RealWindowBorders;
                        return new Padding(borders.Left, borders.Bottom / 2, 0, 0);
                    }
                case PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderCustom1
                    or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3:
                    return _contentPaddingHeader1;
                case PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive:
                    return _contentPaddingDock;
                case PaletteContentStyle.HeaderSecondary:
                    return _contentPaddingHeader2;
                case PaletteContentStyle.HeaderCalendar:
                    return _contentPaddingCalendar;
                case PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl
                    or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl
                    or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel
                    or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel
                    or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2
                    or PaletteContentStyle.LabelCustom3:
                    return _contentPaddingLabel;
                case PaletteContentStyle.LabelGroupBoxCaption:
                    return _contentPaddingLabel2;
                case PaletteContentStyle.ContextMenuItemTextStandard:
                    return _contentPaddingContextMenuItemText;
                case PaletteContentStyle.ContextMenuItemTextAlternate:
                    return _contentPaddingContextMenuItemTextAlt;
                case PaletteContentStyle.ContextMenuItemShortcutText:
                    return _contentPaddingContextMenuItemShortcutText;
                case PaletteContentStyle.ContextMenuItemImage:
                    return _contentPaddingContextMenuImage;
                case PaletteContentStyle.LabelToolTip:
                    return _contentPaddingToolTip;
                case PaletteContentStyle.LabelSuperTip:
                    return _contentPaddingSuperTip;
                case PaletteContentStyle.LabelKeyTip:
                    return _contentPaddingKeyTip;
                case PaletteContentStyle.ContextMenuHeading:
                    return _contentPaddingContextMenuHeading;
                case PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon
                    or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2
                    or PaletteContentStyle.InputControlCustom3:
                    return InputControlPadding;
                case PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonCommand
                    or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile
                    or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini
                    or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2
                    or PaletteContentStyle.ButtonCustom3:
                    return _contentPaddingButton12;
                case PaletteContentStyle.ButtonInputControl or PaletteContentStyle.ButtonCalendarDay:
                    return _contentPaddingButtonInputControl;
                case PaletteContentStyle.ButtonButtonSpec:
                    return _contentPaddingButton3;
                case PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow:
                    return _contentPaddingButton4;
                case PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose:
                    return _contentPaddingButtonForm;
                case PaletteContentStyle.ButtonGallery:
                    return _contentPaddingButtonGallery;
                case PaletteContentStyle.ButtonListItem:
                    return _contentPaddingButtonListItem;
                case PaletteContentStyle.ButtonBreadCrumb:
                    return _contentPaddingButton6;
                case PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile
                    or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote
                    or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2
                    or PaletteContentStyle.TabCustom3:
                    return _contentPaddingButton5;
                case PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden:
                    return _contentPaddingButton7;
                default:
                    throw new ArgumentOutOfRangeException(nameof(style));
            }
        }

        /// <summary>
        /// Gets the padding between adjacent content items.
        /// </summary>
        /// <param name="style">Content style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Integer value.</returns>
        public override int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return -1;
            }

            return style switch
            {
                PaletteContentStyle.HeaderPrimary or PaletteContentStyle.HeaderDockInactive or PaletteContentStyle.HeaderDockActive or PaletteContentStyle.HeaderCalendar or PaletteContentStyle.HeaderSecondary or PaletteContentStyle.HeaderForm or PaletteContentStyle.HeaderCustom1 or PaletteContentStyle.HeaderCustom2 or PaletteContentStyle.HeaderCustom3 or PaletteContentStyle.LabelNormalControl or PaletteContentStyle.LabelBoldControl or PaletteContentStyle.LabelItalicControl or PaletteContentStyle.LabelTitleControl or PaletteContentStyle.LabelNormalPanel or PaletteContentStyle.LabelBoldPanel or PaletteContentStyle.LabelItalicPanel or PaletteContentStyle.LabelTitlePanel or PaletteContentStyle.LabelGroupBoxCaption or PaletteContentStyle.LabelToolTip or PaletteContentStyle.LabelKeyTip or PaletteContentStyle.LabelCustom1 or PaletteContentStyle.LabelCustom2 or PaletteContentStyle.LabelCustom3 or PaletteContentStyle.ContextMenuHeading or PaletteContentStyle.ContextMenuItemImage or PaletteContentStyle.ContextMenuItemTextStandard or PaletteContentStyle.ContextMenuItemTextAlternate or PaletteContentStyle.ContextMenuItemShortcutText or PaletteContentStyle.InputControlStandalone or PaletteContentStyle.InputControlRibbon or PaletteContentStyle.InputControlCustom1 or PaletteContentStyle.InputControlCustom2 or PaletteContentStyle.InputControlCustom3 or PaletteContentStyle.TabHighProfile or PaletteContentStyle.TabStandardProfile or PaletteContentStyle.TabLowProfile or PaletteContentStyle.TabOneNote or PaletteContentStyle.TabDock or PaletteContentStyle.TabDockAutoHidden or PaletteContentStyle.TabCustom1 or PaletteContentStyle.TabCustom2 or PaletteContentStyle.TabCustom3 or PaletteContentStyle.ButtonStandalone or PaletteContentStyle.ButtonGallery or PaletteContentStyle.ButtonAlternate or PaletteContentStyle.ButtonLowProfile or PaletteContentStyle.ButtonBreadCrumb or PaletteContentStyle.ButtonListItem or PaletteContentStyle.ButtonCommand or PaletteContentStyle.ButtonButtonSpec or PaletteContentStyle.ButtonCalendarDay or PaletteContentStyle.ButtonCluster or PaletteContentStyle.ButtonNavigatorMini or PaletteContentStyle.ButtonNavigatorStack or PaletteContentStyle.ButtonNavigatorOverflow or PaletteContentStyle.ButtonForm or PaletteContentStyle.ButtonFormClose or PaletteContentStyle.ButtonCustom1 or PaletteContentStyle.ButtonCustom2 or PaletteContentStyle.ButtonCustom3 or PaletteContentStyle.ButtonInputControl or PaletteContentStyle.GridHeaderColumnList or PaletteContentStyle.GridHeaderColumnSheet or PaletteContentStyle.GridHeaderColumnCustom1 or PaletteContentStyle.GridHeaderColumnCustom2 or PaletteContentStyle.GridHeaderColumnCustom3 or PaletteContentStyle.GridHeaderRowList or PaletteContentStyle.GridHeaderRowSheet or PaletteContentStyle.GridHeaderRowCustom1 or PaletteContentStyle.GridHeaderRowCustom2 or PaletteContentStyle.GridHeaderRowCustom3 or PaletteContentStyle.GridDataCellList or PaletteContentStyle.GridDataCellSheet or PaletteContentStyle.GridDataCellCustom1 or PaletteContentStyle.GridDataCellCustom2 or PaletteContentStyle.GridDataCellCustom3 => 1,
                PaletteContentStyle.LabelSuperTip => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(style))
            };
        }
        #endregion

        #region Metric

        /// <summary>
        /// Gets an integer metric value.
        /// </summary>
        /// <param name="owningForm"></param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <param name="metric">Requested metric.</param>
        /// <returns>Integer value.</returns>
        public override int GetMetricInt(KryptonForm? owningForm, PaletteState state, PaletteMetricInt metric)
        {
            switch (metric)
            {
                case PaletteMetricInt.PageButtonInset:
                case PaletteMetricInt.RibbonTabGap:
                case PaletteMetricInt.HeaderButtonEdgeInsetCalendar:
                    return 2;
                case PaletteMetricInt.CheckButtonGap:
                    return 5;
                case PaletteMetricInt.HeaderButtonEdgeInsetForm:
                    return Math.Max(2, owningForm!.RealWindowBorders.Right);
                case PaletteMetricInt.HeaderButtonEdgeInsetInputControl:
                    return 1;
                case PaletteMetricInt.HeaderButtonEdgeInsetPrimary:
                case PaletteMetricInt.HeaderButtonEdgeInsetSecondary:
                case PaletteMetricInt.HeaderButtonEdgeInsetDockInactive:
                case PaletteMetricInt.HeaderButtonEdgeInsetDockActive:
                case PaletteMetricInt.HeaderButtonEdgeInsetCustom1:
                case PaletteMetricInt.HeaderButtonEdgeInsetCustom2:
                case PaletteMetricInt.HeaderButtonEdgeInsetCustom3:
                case PaletteMetricInt.BarButtonEdgeOutside:
                case PaletteMetricInt.BarButtonEdgeInside:
                    return 3;
                case PaletteMetricInt.None:
                    return 0;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(metric.ToString());
                    break;
            }

            return -1;
        }

        /// <summary>
        /// Gets a boolean metric value.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <param name="metric">Requested metric.</param>
        /// <returns>InheritBool value.</returns>
        public override InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
        {
            switch (metric)
            {
                case PaletteMetricBool.HeaderGroupOverlay:
                case PaletteMetricBool.SplitWithFading:
                case PaletteMetricBool.RibbonTabsSpareCaption:
                    return InheritBool.True;
                case PaletteMetricBool.TreeViewLines:
                    return InheritBool.False;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(metric.ToString());
                    break;
            }

            return InheritBool.Inherit;
        }

        /// <summary>
        /// Gets a padding metric value.
        /// </summary>
        /// <param name="owningForm"></param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <param name="metric">Requested metric.</param>
        /// <returns>Padding value.</returns>
        public override Padding GetMetricPadding(KryptonForm? owningForm, PaletteState state,
            PaletteMetricPadding metric)
        {
            switch (metric)
            {
                case PaletteMetricPadding.PageButtonPadding:
                    return _metricPaddingPageButtons;
                case PaletteMetricPadding.BarPaddingTabs:
                    return _metricPaddingBarTabs;
                case PaletteMetricPadding.BarPaddingInside:
                case PaletteMetricPadding.BarPaddingOnly:
                    return _metricPaddingBarInside;
                case PaletteMetricPadding.BarPaddingOutside:
                    return _metricPaddingBarOutside;
                case PaletteMetricPadding.HeaderButtonPaddingForm:
                    return new Padding(0, owningForm!.RealWindowBorders.Right, 0, 0);
                case PaletteMetricPadding.RibbonButtonPadding:
                    return _metricPaddingRibbon;
                case PaletteMetricPadding.RibbonAppButton:
                    return _metricPaddingRibbonAppButton;
                case PaletteMetricPadding.HeaderButtonPaddingInputControl:
                    return _metricPaddingInputControl;
                case PaletteMetricPadding.HeaderButtonPaddingPrimary:
                case PaletteMetricPadding.HeaderButtonPaddingSecondary:
                case PaletteMetricPadding.HeaderButtonPaddingDockInactive:
                case PaletteMetricPadding.HeaderButtonPaddingDockActive:
                case PaletteMetricPadding.HeaderButtonPaddingCustom1:
                case PaletteMetricPadding.HeaderButtonPaddingCustom2:
                case PaletteMetricPadding.HeaderButtonPaddingCustom3:
                case PaletteMetricPadding.HeaderButtonPaddingCalendar:
                case PaletteMetricPadding.BarButtonPadding:
                    return _metricPaddingHeader;
                case PaletteMetricPadding.HeaderGroupPaddingPrimary:
                case PaletteMetricPadding.HeaderGroupPaddingSecondary:
                case PaletteMetricPadding.HeaderGroupPaddingDockInactive:
                case PaletteMetricPadding.HeaderGroupPaddingDockActive:
                case PaletteMetricPadding.SeparatorPaddingLowProfile:
                case PaletteMetricPadding.SeparatorPaddingHighInternalProfile:
                case PaletteMetricPadding.SeparatorPaddingHighProfile:
                case PaletteMetricPadding.SeparatorPaddingCustom1:
                case PaletteMetricPadding.SeparatorPaddingCustom2:
                case PaletteMetricPadding.SeparatorPaddingCustom3:
                case PaletteMetricPadding.ContextMenuItemHighlight:
                case PaletteMetricPadding.ContextMenuItemsCollection:
                case PaletteMetricPadding.ContextMenuItemOuter:
                    return Padding.Empty;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(metric.ToString());
                    break;
            }

            return Padding.Empty;
        }
        #endregion

        #region Images
        /// <summary>
        /// Gets a tree view image appropriate for the provided state.
        /// </summary>
        /// <param name="expanded">Is the node expanded</param>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetTreeViewImage(bool expanded) => expanded ? _treeCollapseBlack : _treeExpandWhite;

        /// <summary>
        /// Gets a check box image appropriate for the provided state.
        /// </summary>
        /// <param name="enabled">Is the check box enabled.</param>
        /// <param name="checkState">Is the check box checked/unchecked/indeterminate.</param>
        /// <param name="tracking">Is the check box being hot tracked.</param>
        /// <param name="pressed">Is the check box being pressed.</param>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
        {
            switch (checkState)
            {
                default:
                case CheckState.Unchecked:
                    if (!enabled)
                    {
                        return _checkBoxList.Images[0];
                    }
                    else if (pressed)
                    {
                        return _checkBoxList.Images[3];
                    }
                    else
                    {
                        return tracking ? _checkBoxList.Images[2] : _checkBoxList.Images[1];
                    }

                case CheckState.Checked:
                    if (!enabled)
                    {
                        return _checkBoxList.Images[4];
                    }
                    else if (pressed)
                    {
                        return _checkBoxList.Images[7];
                    }
                    else
                    {
                        return tracking ? _checkBoxList.Images[6] : _checkBoxList.Images[5];
                    }

                case CheckState.Indeterminate:
                    if (!enabled)
                    {
                        return _checkBoxList.Images[8];
                    }
                    else if (pressed)
                    {
                        return _checkBoxList.Images[11];
                    }
                    else
                    {
                        return tracking ? _checkBoxList.Images[10] : _checkBoxList.Images[9];
                    }
            }
        }

        /// <summary>
        /// Gets a check box image appropriate for the provided state.
        /// </summary>
        /// <param name="enabled">Is the radio button enabled.</param>
        /// <param name="checkState">Is the radio button checked.</param>
        /// <param name="tracking">Is the radio button being hot tracked.</param>
        /// <param name="pressed">Is the radio button being pressed.</param>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed)
        {
            if (!checkState)
            {
                if (!enabled)
                {
                    return _radioButtonArray[0];
                }
                else if (pressed)
                {
                    return _radioButtonArray[3];
                }
                else
                {
                    return tracking ? _radioButtonArray[2] : _radioButtonArray[1];
                }
            }
            else
            {
                if (!enabled)
                {
                    return _radioButtonArray[4];
                }
                else if (pressed)
                {
                    return _radioButtonArray[7];
                }
                else
                {
                    return tracking ? _radioButtonArray[6] : _radioButtonArray[5];
                }
            }
        }

        /// <summary>
        /// Gets a checked image appropriate for a context menu item.
        /// </summary>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetContextMenuCheckedImage() => _contextMenuChecked;

        /// <summary>
        /// Gets a indeterminate image appropriate for a context menu item.
        /// </summary>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetContextMenuIndeterminateImage() => _contextMenuIndeterminate;

        /// <summary>
        /// Gets a check box image appropriate for the provided state.
        /// </summary>
        /// <param name="button">Enum of the button to fetch.</param>
        /// <param name="state">State of the button to fetch.</param>
        /// <returns>Appropriate image for drawing; otherwise null.</returns>
        public override Image? GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state) => button switch
        {
            PaletteRibbonGalleryButton.Up => _galleryButtonList.Images[1],
            PaletteRibbonGalleryButton.DropDown => _galleryButtonList.Images[2],
            _ => _galleryButtonList.Images[0]
        };
        #endregion

        #region ButtonSpec

        /// <summary>
        /// Gets the image to display for the button.
        /// </summary>
        /// <param name="style">Style of button spec.</param>
        /// <param name="state">State for which image is required.</param>
        /// <returns>Image value.</returns>
        public override Image? GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteButtonSpecStyle.Close:
                    return _buttonSpecClose;
                case PaletteButtonSpecStyle.Context:
                    return _buttonSpecContext;
                case PaletteButtonSpecStyle.Next:
                    return _buttonSpecNext;
                case PaletteButtonSpecStyle.Previous:
                    return _buttonSpecPrevious;
                case PaletteButtonSpecStyle.ArrowLeft:
                    return _buttonSpecArrowLeft;
                case PaletteButtonSpecStyle.ArrowRight:
                    return _buttonSpecArrowRight;
                case PaletteButtonSpecStyle.ArrowUp:
                    return _buttonSpecArrowUp;
                case PaletteButtonSpecStyle.ArrowDown:
                    return _buttonSpecArrowDown;
                case PaletteButtonSpecStyle.DropDown:
                    return _buttonSpecDropDown;
                case PaletteButtonSpecStyle.PinVertical:
                    return _buttonSpecPinVertical;
                case PaletteButtonSpecStyle.PinHorizontal:
                    return _buttonSpecPinHorizontal;
                case PaletteButtonSpecStyle.PendantClose:
                    return _buttonSpecPendantClose;
                case PaletteButtonSpecStyle.PendantMin:
                    return _buttonSpecPendantMin;
                case PaletteButtonSpecStyle.PendantRestore:
                    return _buttonSpecPendantRestore;
                case PaletteButtonSpecStyle.WorkspaceMaximize:
                    return _buttonSpecWorkspaceMaximize;
                case PaletteButtonSpecStyle.WorkspaceRestore:
                    return _buttonSpecWorkspaceRestore;
                case PaletteButtonSpecStyle.RibbonMinimize:
                    return _buttonSpecRibbonMinimize;
                case PaletteButtonSpecStyle.RibbonExpand:
                    return _buttonSpecRibbonExpand;
                case PaletteButtonSpecStyle.New:
                    return _integratedToolbarNewNormal;
                case PaletteButtonSpecStyle.Open:
                    return _integratedToolbarOpenNormal;
                case PaletteButtonSpecStyle.Save:
                    return _integratedToolbarSaveNormal;
                case PaletteButtonSpecStyle.SaveAs:
                    return _integratedToolbarSaveAsNormal;
                case PaletteButtonSpecStyle.SaveAll:
                    return _integratedToolbarSaveAllNormal;
                case PaletteButtonSpecStyle.Cut:
                    return _integratedToolbarCutNormal;
                case PaletteButtonSpecStyle.Copy:
                    return _integratedToolbarCopyNormal;
                case PaletteButtonSpecStyle.Paste:
                    return _integratedToolbarPasteNormal;
                case PaletteButtonSpecStyle.Undo:
                    return _integratedToolbarUndoNormal;
                case PaletteButtonSpecStyle.Redo:
                    return _integratedToolbarRedoNormal;
                case PaletteButtonSpecStyle.PageSetup:
                    return _integratedToolbarPageSetupNormal;
                case PaletteButtonSpecStyle.PrintPreview:
                    return _integratedToolbarPrintPreviewNormal;
                case PaletteButtonSpecStyle.Print:
                    return _integratedToolbarPrintNormal;
                case PaletteButtonSpecStyle.QuickPrint:
                    return _integratedToolbarQuickPrintNormal;
                case PaletteButtonSpecStyle.Generic:
                    return null;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    throw DebugTools.NotImplemented(style.ToString());
            }
        }

        #endregion

        #region RibbonGeneral
        /// <summary>
        /// Gets the ribbon shape that should be used.
        /// </summary>
        /// <returns>Ribbon shape value.</returns>
        public override PaletteRibbonShape GetRibbonShape() => PaletteRibbonShape.Office2013;

        //public override PaletteRibbonShape GetRibbonShape()
        //{
        //    return PaletteRibbonShape.Office365;
        //}

        /// <summary>
        /// Gets the text alignment for the ribbon context text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state) => PaletteRelativeAlign.Center;

        /// <summary>
        /// Gets the font for the ribbon context text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Font GetRibbonContextTextFont(PaletteState state) => RibbonTabContextFont!;

        /// <summary>
        /// Gets the color for the ribbon context text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Color GetRibbonContextTextColor(PaletteState state) => _contextTextColor;

        /// <summary>
        /// Gets the dark disabled color used for ribbon glyphs.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonDisabledDark(PaletteState state) => _disabledGlyphDark;

        /// <summary>
        /// Gets the light disabled color used for ribbon glyphs.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonDisabledLight(PaletteState state) => _disabledGlyphLight;

        /// <summary>
        /// Gets the color for the drop arrow light.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonDropArrowLight(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonDropArrowLight];

        /// <summary>
        /// Gets the color for the drop arrow dark.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonDropArrowDark(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonDropArrowDark];

        /// <summary>
        /// Gets the color for the dialog launcher dark.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonGroupDialogDark(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonGroupDialogDark];

        /// <summary>
        /// Gets the color for the dialog launcher light.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonGroupDialogLight(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonGroupDialogLight];

        /// <summary>
        /// Gets the color for the group separator dark.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonGroupSeparatorDark(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonGroupSeparatorDark];

        /// <summary>
        /// Gets the color for the group separator light.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonGroupSeparatorLight(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonGroupSeparatorLight];

        /// <summary>
        /// Gets the color for the minimize bar dark.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonMinimizeBarDark(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonMinimizeBarDark];

        /// <summary>
        /// Gets the color for the minimize bar light.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonMinimizeBarLight(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonMinimizeBarLight];

        /// <summary>
        /// Gets the color for the tab separator.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonTabSeparatorColor(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonTabSeparatorColor];

        /// <summary>
        /// Gets the color for the tab context separators.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonTabSeparatorContextColor(PaletteState state) => _contextTabSeparator;

        /// <summary>
        /// Gets the font for the ribbon text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Font value.</returns>
        public override Font GetRibbonTextFont(PaletteState state) => RibbonTabFont!;

        /// <summary>
        /// Gets the rendering hint for the ribbon font.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteTextHint value.</returns>
        public override PaletteTextHint GetRibbonTextHint(PaletteState state) => PaletteTextHint.ClearTypeGridFit;

        /// <summary>
        /// Gets the color for the extra QAT button dark content color.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonQATButtonDark(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonQATButtonDark];

        /// <summary>
        /// Gets the color for the extra QAT button light content color.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonQATButtonLight(PaletteState state) => _ribbonColors[(int)SchemeOfficeColors.RibbonQATButtonLight];

        #endregion

        #region RibbonBack
        /// <summary>
        /// Gets the method used to draw the background of a ribbon item.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteRibbonBackStyle value.</returns>
        public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonBackStyle.RibbonAppMenuDocs:
                    return PaletteRibbonColorStyle.Solid;
                case PaletteRibbonBackStyle.RibbonAppMenuInner:
                    return PaletteRibbonColorStyle.RibbonAppMenuInner;
                case PaletteRibbonBackStyle.RibbonAppMenuOuter:
                    return PaletteRibbonColorStyle.RibbonAppMenuOuter;
                case PaletteRibbonBackStyle.RibbonQATMinibar:
                    return state == PaletteState.CheckedNormal
                        ? PaletteRibbonColorStyle.RibbonQATMinibarDouble
                        : PaletteRibbonColorStyle.RibbonQATMinibarSingle;

                case PaletteRibbonBackStyle.RibbonQATFullbar:
                    return PaletteRibbonColorStyle.RibbonQATFullbarSquare;
                case PaletteRibbonBackStyle.RibbonQATOverflow:
                    return PaletteRibbonColorStyle.RibbonQATOverflow;
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
                    return PaletteRibbonColorStyle.LinearBorder;
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
                    return state == PaletteState.Pressed ? PaletteRibbonColorStyle.Empty : PaletteRibbonColorStyle.Linear;

                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
                    switch (state)
                    {
                        case PaletteState.Normal:
                        case PaletteState.ContextNormal:
                            return PaletteRibbonColorStyle.RibbonGroupNormalBorderSep;
                        case PaletteState.Tracking:
                        case PaletteState.ContextTracking:
                            return PaletteRibbonColorStyle.RibbonGroupNormalBorderSepTrackingLight;
                        case PaletteState.Pressed:
                        case PaletteState.ContextPressed:
                            return PaletteRibbonColorStyle.RibbonGroupNormalBorderSepPressedLight;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
                    return PaletteRibbonColorStyle.Empty;
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    switch (state)
                    {
                        case PaletteState.Normal:
                        case PaletteState.CheckedNormal:
                        case PaletteState.ContextNormal:
                        case PaletteState.ContextCheckedNormal:
                            return PaletteRibbonColorStyle.Empty;
                        case PaletteState.Tracking:
                        case PaletteState.ContextTracking:
                        case PaletteState.ContextCheckedTracking:
                            return PaletteRibbonColorStyle.RibbonGroupNormalTrackingLight;
                        case PaletteState.FocusOverride:
                            return PaletteRibbonColorStyle.RibbonTabFocus2010;
                        case PaletteState.ContextPressed:
                            return PaletteRibbonColorStyle.RibbonGroupNormalPressedDark;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonTab:
                    switch (state)
                    {
                        case PaletteState.Disabled:
                        case PaletteState.Normal:
                            return PaletteRibbonColorStyle.Empty;
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextTracking:
                            return PaletteRibbonColorStyle.RibbonTabTracking2010;
                        case PaletteState.FocusOverride:
                            return PaletteRibbonColorStyle.RibbonTabFocus2010;
                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedTracking:
                        case PaletteState.CheckedPressed:
                        case PaletteState.ContextCheckedNormal:
                        case PaletteState.ContextCheckedTracking:
                            return PaletteRibbonColorStyle.RibbonTabSelected2010;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(state.ToString());
                    break;
            }

            return PaletteRibbonColorStyle.Empty;
        }

        /// <summary>
        /// Gets the first background color for the ribbon item.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonBackStyle.RibbonGalleryBack:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBack,
                        PaletteState.Tracking => _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBackTracking],
                        _ => _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBackNormal]
                    };
                case PaletteRibbonBackStyle.RibbonGalleryBorder:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledBorder,
                        _ => _ribbonColors[(int)SchemeOfficeColors.RibbonGalleryBorder]
                    };
                case PaletteRibbonBackStyle.RibbonAppMenuDocs:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonMenuDocsBack];
                case PaletteRibbonBackStyle.RibbonAppMenuInner:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonInner1];
                case PaletteRibbonBackStyle.RibbonAppMenuOuter:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonOuter1];
                case PaletteRibbonBackStyle.RibbonQATMinibar:
                    return state == PaletteState.Normal
                        ? _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini1]
                        : _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini1I];

                case PaletteRibbonBackStyle.RibbonQATFullbar:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonQATFullbar1];
                case PaletteRibbonBackStyle.RibbonQATOverflow:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonQATOverflow1];
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupFrameBorder1];
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupFrameInside1];
                case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
                    return GlobalStaticValues.EMPTY_COLOR;
                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
                    switch (state)
                    {
                        case PaletteState.Normal:
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextNormal:
                        case PaletteState.ContextTracking:
                        case PaletteState.ContextPressed:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupBorder1];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonAppButton:
                    switch (state)
                    {
                        case PaletteState.Normal:
                            return _appButtonNormal[0];
                        case PaletteState.Tracking:
                            return _appButtonTrack[0];
                        case PaletteState.Pressed:
                            return _appButtonPressed[0];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    return state == PaletteState.ContextCheckedNormal ? GlobalStaticValues.EMPTY_COLOR : _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea1];

                case PaletteRibbonBackStyle.RibbonTab:
                    switch (state)
                    {
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabTracking1];
                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedTracking:
                        case PaletteState.CheckedPressed:
                        case PaletteState.ContextCheckedNormal:
                        case PaletteState.ContextCheckedTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabSelected1];
                        case PaletteState.FocusOverride:
                            return _contextCheckedTabBorder1;
                        case PaletteState.Normal:
                            return GlobalStaticValues.EMPTY_COLOR;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the second background color for the ribbon item.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonBackStyle.RibbonAppMenuInner:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonInner2];
                case PaletteRibbonBackStyle.RibbonAppMenuOuter:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonOuter2];
                case PaletteRibbonBackStyle.RibbonQATMinibar:
                    return state == PaletteState.Normal
                        ? _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini2]
                        : _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini2I];

                case PaletteRibbonBackStyle.RibbonQATFullbar:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonQATFullbar2];
                case PaletteRibbonBackStyle.RibbonQATOverflow:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonQATOverflow2];
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupFrameBorder2];
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupFrameInside2];
                case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
                    switch (state)
                    {
                        case PaletteState.Normal:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupTitle2];
                        case PaletteState.ContextNormal:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupTitleContext2];
                        case PaletteState.Tracking:
                        case PaletteState.ContextTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupTitleTracking2];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
                    switch (state)
                    {
                        case PaletteState.Normal:
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextNormal:
                        case PaletteState.ContextTracking:
                        case PaletteState.ContextPressed:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupBorder2];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonAppButton:
                    switch (state)
                    {
                        case PaletteState.Normal:
                            return _appButtonNormal[1];
                        case PaletteState.Tracking:
                            return _appButtonTrack[1];
                        case PaletteState.Pressed:
                            return _appButtonPressed[1];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea2];
                case PaletteRibbonBackStyle.RibbonTab:
                    switch (state)
                    {
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabTracking2];
                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedTracking:
                        case PaletteState.CheckedPressed:
                        case PaletteState.ContextCheckedTracking:
                        case PaletteState.ContextCheckedNormal:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabSelected2];
                        case PaletteState.FocusOverride:
                            return _contextCheckedTabBorder2;
                        case PaletteState.Normal:
                            return GlobalStaticValues.EMPTY_COLOR;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonAppMenuDocs:
                case PaletteRibbonBackStyle.RibbonGalleryBack:
                case PaletteRibbonBackStyle.RibbonGalleryBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
                    return GlobalStaticValues.EMPTY_COLOR;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the third background color for the ribbon item.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonBackStyle.RibbonAppMenuOuter:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonOuter3];
                case PaletteRibbonBackStyle.RibbonQATMinibar:
                    return state == PaletteState.Normal
                        ? _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini3]
                        : _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini3I];

                case PaletteRibbonBackStyle.RibbonQATFullbar:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonQATFullbar3];
                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupBorder3];
                case PaletteRibbonBackStyle.RibbonAppMenuDocs:
                case PaletteRibbonBackStyle.RibbonAppMenuInner:
                case PaletteRibbonBackStyle.RibbonQATOverflow:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
                case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
                case PaletteRibbonBackStyle.RibbonGalleryBack:
                case PaletteRibbonBackStyle.RibbonGalleryBorder:
                    return GlobalStaticValues.EMPTY_COLOR;
                case PaletteRibbonBackStyle.RibbonAppButton:
                    switch (state)
                    {
                        case PaletteState.Normal:
                            return _appButtonNormal[2];
                        case PaletteState.Tracking:
                            return _appButtonTrack[2];
                        case PaletteState.Pressed:
                            return _appButtonPressed[2];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea3];
                case PaletteRibbonBackStyle.RibbonTab:
                    switch (state)
                    {
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabTracking3];
                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedTracking:
                        case PaletteState.CheckedPressed:
                        case PaletteState.ContextCheckedNormal:
                        case PaletteState.ContextCheckedTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabSelected3];
                        case PaletteState.FocusOverride:
                            return _contextCheckedTabBorder3;
                        case PaletteState.Normal:
                            return GlobalStaticValues.EMPTY_COLOR;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the fourth background color for the ribbon item.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonBackStyle.RibbonQATMinibar:
                    return state == PaletteState.Normal
                        ? _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini4]
                        : _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini4I];

                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupBorder4];
                case PaletteRibbonBackStyle.RibbonAppMenuDocs:
                case PaletteRibbonBackStyle.RibbonAppMenuInner:
                case PaletteRibbonBackStyle.RibbonAppMenuOuter:
                case PaletteRibbonBackStyle.RibbonQATFullbar:
                case PaletteRibbonBackStyle.RibbonQATOverflow:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
                case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
                case PaletteRibbonBackStyle.RibbonGalleryBack:
                case PaletteRibbonBackStyle.RibbonGalleryBorder:
                    return GlobalStaticValues.EMPTY_COLOR;
                case PaletteRibbonBackStyle.RibbonAppButton:
                    switch (state)
                    {
                        case PaletteState.Normal:
                            return _appButtonNormal[3];
                        case PaletteState.Tracking:
                            return _appButtonTrack[3];
                        case PaletteState.Pressed:
                            return _appButtonPressed[3];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea4];
                case PaletteRibbonBackStyle.RibbonTab:
                    switch (state)
                    {
                        case PaletteState.Tracking:
                        case PaletteState.Pressed:
                        case PaletteState.ContextTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabTracking4];
                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedTracking:
                        case PaletteState.CheckedPressed:
                        case PaletteState.ContextCheckedNormal:
                        case PaletteState.ContextCheckedTracking:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabSelected4];
                        case PaletteState.FocusOverride:
                            return _contextCheckedTabBorder4;
                        case PaletteState.Normal:
                            return GlobalStaticValues.EMPTY_COLOR;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the fifth background color for the ribbon item.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonBackStyle.RibbonAppMenuDocs:
                case PaletteRibbonBackStyle.RibbonAppMenuInner:
                case PaletteRibbonBackStyle.RibbonAppMenuOuter:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
                case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
                case PaletteRibbonBackStyle.RibbonQATFullbar:
                case PaletteRibbonBackStyle.RibbonQATOverflow:
                case PaletteRibbonBackStyle.RibbonGalleryBack:
                case PaletteRibbonBackStyle.RibbonGalleryBorder:
                    return GlobalStaticValues.EMPTY_COLOR;
                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupBorder5];
                case PaletteRibbonBackStyle.RibbonQATMinibar:
                    return state == PaletteState.Normal
                        ? _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini5]
                        : _ribbonColors[(int)SchemeOfficeColors.RibbonQATMini5I];

                case PaletteRibbonBackStyle.RibbonAppButton:
                    switch (state)
                    {
                        case PaletteState.Normal:
                            return _appButtonNormal[4];
                        case PaletteState.Tracking:
                            return _appButtonTrack[4];
                        case PaletteState.Pressed:
                            return _appButtonPressed[4];
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupsArea5];
                case PaletteRibbonBackStyle.RibbonTab:
                    switch (state)
                    {
                        case PaletteState.Disabled:
                            return _disabledText;
                        case PaletteState.Pressed:
                            return _ribbonColors[(int)SchemeOfficeColors.RibbonTabTracking2];
                        case PaletteState.Tracking:
                        case PaletteState.CheckedNormal:
                        case PaletteState.CheckedTracking:
                        case PaletteState.CheckedPressed:
                        case PaletteState.ContextTracking:
                        case PaletteState.ContextCheckedNormal:
                        case PaletteState.ContextCheckedTracking:
                        case PaletteState.FocusOverride:
                        case PaletteState.Normal:
                            return GlobalStaticValues.EMPTY_COLOR;
                        default:
                            // Should never happen!
                            Debug.Assert(false);
                            DebugTools.NotImplemented(state.ToString());
                            break;
                    }
                    break;
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }

            return Color.Red;
        }
        #endregion

        #region RibbonText
        /// <summary>
        /// Gets the =color for the item text.
        /// </summary>
        /// <param name="style">Text style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state)
        {
            switch (style)
            {
                case PaletteRibbonTextStyle.RibbonAppMenuDocsTitle:
                case PaletteRibbonTextStyle.RibbonAppMenuDocsEntry:
                    return _ribbonColors[(int)SchemeOfficeColors.AppButtonMenuDocsText];
                case PaletteRibbonTextStyle.RibbonGroupNormalTitle:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledText,
                        _ => _ribbonColors[(int)SchemeOfficeColors.RibbonGroupTitleText]
                    };
                case PaletteRibbonTextStyle.RibbonTab:
                    return state switch
                    {
                        PaletteState.Disabled => _disabledText,
                        PaletteState.CheckedNormal or PaletteState.CheckedPressed or PaletteState.CheckedTracking or PaletteState.ContextCheckedNormal or PaletteState.ContextCheckedTracking or PaletteState.FocusOverride => _ribbonColors[(int)SchemeOfficeColors.RibbonTabTextChecked],
                        _ => _ribbonColors[(int)SchemeOfficeColors.RibbonTabTextNormal]
                    };
                case PaletteRibbonTextStyle.RibbonGroupCollapsedText:
                    return _ribbonColors[(int)SchemeOfficeColors.RibbonGroupCollapsedText];
                case PaletteRibbonTextStyle.RibbonGroupButtonText:
                case PaletteRibbonTextStyle.RibbonGroupLabelText:
                case PaletteRibbonTextStyle.RibbonGroupCheckBoxText:
                case PaletteRibbonTextStyle.RibbonGroupRadioButtonText:
                    return state == PaletteState.Disabled ? _disabledText : _ribbonColors[(int)SchemeOfficeColors.RibbonGroupCollapsedText];

                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(style.ToString());
                    break;
            }

            return Color.Red;
        }
        #endregion

        #region ElementColor
        /// <summary>
        /// Gets the first element color.
        /// </summary>
        /// <param name="element">Element for which color is required.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetElementColor1(PaletteElement element, PaletteState state)
        {
            // We do not provide override values
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (element)
            {
                case PaletteElement.TrackBarTick:
                    return _trackBarColors[0];
                case PaletteElement.TrackBarTrack:
                    return _trackBarColors[1];
                case PaletteElement.TrackBarPosition:
                    return state switch
                    {
                        PaletteState.Disabled => GlobalStaticValues.EMPTY_COLOR,
                        _ => _trackBarColors[4]
                    };
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(element.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the second element color.
        /// </summary>
        /// <param name="element">Element for which color is required.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetElementColor2(PaletteElement element, PaletteState state)
        {
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (element)
            {
                case PaletteElement.TrackBarTick:
                    return _trackBarColors[0];
                case PaletteElement.TrackBarTrack:
                    return _trackBarColors[2];
                case PaletteElement.TrackBarPosition:
                    return state switch
                    {
                        PaletteState.Disabled => ControlPaint.Light(_ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder]),
                        PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBorder],
                        PaletteState.Tracking or PaletteState.FocusOverride => _buttonBorderColors[1],
                        PaletteState.Pressed => _buttonBorderColors[3],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(element.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the third element color.
        /// </summary>
        /// <param name="element">Element for which color is required.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetElementColor3(PaletteElement element, PaletteState state)
        {
            if (CommonHelper.IsOverrideState(state))
            {
                return GlobalStaticValues.EMPTY_COLOR;
            }

            switch (element)
            {
                case PaletteElement.TrackBarTick:
                    return _trackBarColors[0];
                case PaletteElement.TrackBarTrack:
                    return _trackBarColors[3];
                case PaletteElement.TrackBarPosition:
                    return state switch
                    {
                        PaletteState.Disabled => ControlPaint.LightLight(_ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1]),
                        PaletteState.Normal => ControlPaint.Light(_ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1]),
                        PaletteState.Tracking => ControlPaint.Light(_buttonBackColors[2]),
                        PaletteState.Pressed => ControlPaint.Light(_buttonBackColors[4]),
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(element.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the fourth element color.
        /// </summary>
        /// <param name="element">Element for which color is required.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetElementColor4(PaletteElement element, PaletteState state)
        {
            switch (element)
            {
                case PaletteElement.TrackBarTick:
                    if (CommonHelper.IsOverrideState(state))
                    {
                        return GlobalStaticValues.EMPTY_COLOR;
                    }

                    return _trackBarColors[0];
                case PaletteElement.TrackBarTrack:
                    if (CommonHelper.IsOverrideState(state))
                    {
                        return GlobalStaticValues.EMPTY_COLOR;
                    }

                    return _trackBarColors[3];
                case PaletteElement.TrackBarPosition:
                    if (CommonHelper.IsOverrideStateExclude(state, PaletteState.FocusOverride))
                    {
                        return GlobalStaticValues.EMPTY_COLOR;
                    }

                    return state switch
                    {
                        PaletteState.Disabled => ControlPaint.LightLight(_ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1]),
                        PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1],
                        PaletteState.Tracking or PaletteState.FocusOverride => _buttonBackColors[2],
                        PaletteState.Pressed => _buttonBackColors[4],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(element.ToString());
                    break;
            }

            return Color.Red;
        }

        /// <summary>
        /// Gets the fifth element color.
        /// </summary>
        /// <param name="element">Element for which color is required.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetElementColor5(PaletteElement element, PaletteState state)
        {
            switch (element)
            {
                case PaletteElement.TrackBarTick:
                    if (CommonHelper.IsOverrideState(state))
                    {
                        return GlobalStaticValues.EMPTY_COLOR;
                    }

                    return _trackBarColors[0];
                case PaletteElement.TrackBarTrack:
                    if (CommonHelper.IsOverrideState(state))
                    {
                        return GlobalStaticValues.EMPTY_COLOR;
                    }

                    return _trackBarColors[3];
                case PaletteElement.TrackBarPosition:
                    if (CommonHelper.IsOverrideStateExclude(state, PaletteState.FocusOverride))
                    {
                        return GlobalStaticValues.EMPTY_COLOR;
                    }

                    return state switch
                    {
                        PaletteState.Disabled => ControlPaint.LightLight(_ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack1]),
                        PaletteState.Normal => _ribbonColors[(int)SchemeOfficeColors.ButtonNormalBack2],
                        PaletteState.Tracking or PaletteState.FocusOverride => _buttonBackColors[3],
                        PaletteState.Pressed => _buttonBackColors[5],
                        _ => throw DebugTools.NotImplemented(state.ToString())
                    };
                default:
                    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(element.ToString());
                    break;
            }

            return Color.Red;
        }
        #endregion

        #region ColorTable
        /// <summary>
        /// Gets access to the color table instance.
        /// </summary>
        public override KryptonColorTable ColorTable => Table ??= new KryptonColorTable2013White(_ribbonColors, InheritBool.True, this);
        #endregion

        #region OnUserPreferenceChanged
        /// <summary>
        /// Handle a change in the user preferences.
        /// </summary>
        /// <param name="sender">Source of event.</param>
        /// <param name="e">Event data.</param>
        protected override void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            // Remove the current table, so it gets regenerated when next requested
            Table = null;

            // Update fonts to reflect any change in system settings
            DefineFonts();

            base.OnUserPreferenceChanged(sender, e);
        }
        #endregion
    }
    #endregion
}
