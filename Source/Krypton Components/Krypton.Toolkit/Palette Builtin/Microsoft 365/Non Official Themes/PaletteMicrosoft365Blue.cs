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
    public class PaletteMicrosoft365Blue : PaletteMicrosoft365Base
    {
        #region Static Fields

        #region Colors

        private static readonly Color _tabRowBackgroundColor = Color.FromArgb(187, 206, 230);

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

        #region Image Arrays

        private static readonly Image?[] _radioButtonArray;

        #endregion

        #region Images

        private static readonly Image? _blueDropDownButton = Office2010ArrowResources.Office2010BlueDropDownButton;
        private static readonly Image? _contextMenuSubMenu = Office2010ArrowResources.Office2010BlueContextMenuSub;
        private static readonly Image _formCloseNormal = Office2010ControlBoxResources.Office2010BlueCloseNormal;
        private static readonly Image _formCloseDisabled = Office2010ControlBoxResources.Office2010BlueCloseDisabled;
        private static readonly Image _formCloseActive = Office2010ControlBoxResources.Office2010BlueCloseActive;
        private static readonly Image _formClosePressed = Office2010ControlBoxResources.Office2010BlueClosePressed;
        private static readonly Image _formMaximiseNormal = Office2010ControlBoxResources.Office2010BlueMaximiseNormal;
        private static readonly Image _formMaximiseDisabled = Office2010ControlBoxResources.Office2010BlueMaximiseDisabled;
        private static readonly Image _formMaximiseActive = Office2010ControlBoxResources.Office2010BlueMaximiseActive;
        private static readonly Image _formMaximisePressed = Office2010ControlBoxResources.Office2010BlueMaximisePressed;
        private static readonly Image _formMinimiseNormal = Office2010ControlBoxResources.Office2010BlueMinimiseNormal;
        private static readonly Image _formMinimiseActive = Office2010ControlBoxResources.Office2010BlueMinimiseActive;
        private static readonly Image _formMinimiseDisabled = Office2010ControlBoxResources.Office2010BlueMinimiseDisabled;
        private static readonly Image _formMinimisePressed = Office2010ControlBoxResources.Office2010BlueMinimisePressed;
        private static readonly Image _formRestoreNormal = Office2010ControlBoxResources.Office2010BlueRestoreNormal;
        private static readonly Image _formRestoreDisabled = Office2010ControlBoxResources.Office2010BlueRestoreDisabled;
        private static readonly Image _formRestoreActive = Office2010ControlBoxResources.Office2010BlueRestoreActive;
        private static readonly Image _formRestorePressed = Office2010ControlBoxResources.Office2010BlueRestorePressed;
        private static readonly Image _formHelpNormal = Microsoft365ControlBoxResources.Microsoft365HelpIconNormal;
        private static readonly Image _formHelpActive = Microsoft365ControlBoxResources.Microsoft365HelpIconHover;
        private static readonly Image _formHelpPressed = Microsoft365ControlBoxResources.Microsoft365HelpIconPressed;
        private static readonly Image _formHelpDisabled = Microsoft365ControlBoxResources.Microsoft365HelpIconDisabled;

        #region Integrated Toolbar Images

        private static readonly Image _integratedToolbarNewNormal = Office2019ToolbarImageResources.Office2019ToolbarNewNormal;

        private static readonly Image _integratedToolbarNewDisabled = Office2019ToolbarImageResources.Office2019ToolbarNewDisabled;

        private static readonly Image _integratedToolbarOpenNormal = Office2019ToolbarImageResources.Office2019ToolbarOpenNormal;

        private static readonly Image _integratedToolbarOpenDisabled = Office2019ToolbarImageResources.Office2019ToolbarOpenDisabled;

        private static readonly Image _integratedToolbarSaveAllNormal = Office2019ToolbarImageResources.Office2019ToolbarSaveAllNormal;

        private static readonly Image _integratedToolbarSaveAllDisabled = Office2019ToolbarImageResources.Office2019ToolbarSaveAllDisabled;

        private static readonly Image _integratedToolbarSaveAsNormal = Office2019ToolbarImageResources.Office2019ToolbarSaveAsNormal;

        private static readonly Image _integratedToolbarSaveAsDisabled = Office2019ToolbarImageResources.Office2019ToolbarSaveAsDisabled;

        private static readonly Image _integratedToolbarSaveNormal = Office2019ToolbarImageResources.Office2019ToolbarSaveNormal;

        private static readonly Image _integratedToolbarSaveDisabled = Office2019ToolbarImageResources.Office2019ToolbarSaveDisabled;

        private static readonly Image _integratedToolbarCutNormal = Office2019ToolbarImageResources.Office2019ToolbarCutNormal;

        private static readonly Image _integratedToolbarCutDisabled = Office2019ToolbarImageResources.Office2019ToolbarCutDisabled;

        private static readonly Image _integratedToolbarCopyNormal = Office2019ToolbarImageResources.Office2019ToolbarCopyNormal;

        private static readonly Image _integratedToolbarCopyDisabled = Office2019ToolbarImageResources.Office2019ToolbarCopyDisabled;

        private static readonly Image _integratedToolbarPasteNormal = Office2019ToolbarImageResources.Office2019ToolbarPasteNormal;

        private static readonly Image _integratedToolbarPasteDisabled = Office2019ToolbarImageResources.Office2019ToolbarPasteDisabled;

        private static readonly Image _integratedToolbarUndoNormal = Office2019ToolbarImageResources.Office2019ToolbarUndoNormal;

        private static readonly Image _integratedToolbarUndoDisabled = Office2019ToolbarImageResources.Office2019ToolbarUndoDisabled;

        private static readonly Image _integratedToolbarRedoNormal = Office2019ToolbarImageResources.Office2019ToolbarRedoNormal;

        private static readonly Image _integratedToolbarRedoDisabled = Office2019ToolbarImageResources.Office2019ToolbarRedoDisabled;

        private static readonly Image _integratedToolbarPageSetupNormal = Office2019ToolbarImageResources.Office2019ToolbarPageSetupNormal;

        private static readonly Image _integratedToolbarPageSetupDisabled = Office2019ToolbarImageResources.Office2019ToolbarPageSetupDisabled;

        private static readonly Image _integratedToolbarPrintPreviewNormal = Office2019ToolbarImageResources.Office2019ToolbarPrintPreviewNormal;

        private static readonly Image _integratedToolbarPrintPreviewDisabled = Office2019ToolbarImageResources.Office2019ToolbarPrintPreviewDisabled;

        private static readonly Image _integratedToolbarPrintNormal = Office2019ToolbarImageResources.Office2019ToolbarPrintNormal;

        private static readonly Image _integratedToolbarPrintDisabled = Office2019ToolbarImageResources.Office2019ToolbarPrintDisabled;

        private static readonly Image _integratedToolbarQuickPrintNormal = Office2019ToolbarImageResources.Office2019ToolbarQuickPrintNormal;

        private static readonly Image _integratedToolbarQuickPrintDisabled = Office2019ToolbarImageResources.Office2019ToolbarQuickPrintDisabled;

        #endregion

        #endregion

        #region Colour Arrays

        private static readonly Color[] _trackBarColors =
        [
            Color.FromArgb(116, 150, 194), // Tick marks
            Color.FromArgb(116, 150, 194), // Top track
            Color.FromArgb(152, 190, 241), // Bottom track
            Color.FromArgb(142, 180, 231), // Fill track
            Color.FromArgb(64, Color.White), // Outside position
            Color.FromArgb(63, 101, 152) // Border (normal) position
        ];


        private static readonly Color[] _schemeOfficeColors =
        [
            Color.FromArgb(30, 57, 91), // TextLabelControl
            Color.FromArgb(30, 57, 91), // TextButtonNormal
            Color.Black, // TextButtonChecked
            Color.FromArgb(171, 186, 208), // ButtonNormalBorder
            Color.FromArgb(117, 144, 175), // ButtonNormalDefaultBorder
            Color.FromArgb(225, 237, 250), // ButtonNormalBack1
            Color.FromArgb(208, 223, 238), // ButtonNormalBack2
            Color.FromArgb(255, 255, 255), // ButtonNormalDefaultBack1
            Color.FromArgb(210, 229, 250), // ButtonNormalDefaultBack2
            Color.FromArgb(174, 194, 219), // ButtonNormalNavigatorBack1
            Color.FromArgb(174, 194, 219), // ButtonNormalNavigatorBack2
            Color.FromArgb(187, 206, 230), // PanelClient
            Color.FromArgb(174, 194, 219), // PanelAlternative
            Color.FromArgb(133, 158, 191), // ControlBorder
            Color.FromArgb(239, 245, 255), // SeparatorHighBorder1
            Color.FromArgb(200, 217, 239), // SeparatorHighBorder2
            Color.FromArgb(207, 221, 238), // HeaderPrimaryBack1
            Color.FromArgb(174, 194, 219), // HeaderPrimaryBack2
            Color.FromArgb(239, 246, 253), // HeaderSecondaryBack1
            Color.FromArgb(216, 228, 242), // HeaderSecondaryBack2
            Color.FromArgb(30, 57, 91), // HeaderText
            Color.FromArgb(30, 57, 91), // StatusStripText
            Color.FromArgb(236, 199, 87), // ButtonBorder
            Color.FromArgb(245, 249, 255), // SeparatorLight
            Color.FromArgb(120, 141, 165), // SeparatorDark
            Color.FromArgb(212, 225, 241), // GripLight
            Color.FromArgb(132, 157, 189), // GripDark
            Color.FromArgb(187, 206, 230), // ToolStripBack
            Color.FromArgb(220, 232, 246), // StatusStripLight
            Color.FromArgb(179, 196, 216), // StatusStripDark
            Color.White, // ImageMargin
            Color.FromArgb(220, 232, 246), // ToolStripBegin
            Color.FromArgb(179, 196, 216), // ToolStripMiddle
            Color.FromArgb(179, 196, 216), // ToolStripEnd
            Color.FromArgb(132, 157, 189), // OverflowBegin
            Color.FromArgb(132, 157, 189), // OverflowMiddle
            Color.FromArgb(132, 157, 189), // OverflowEnd
            Color.FromArgb(132, 157, 189), // ToolStripBorder
            Color.FromArgb(144, 154, 166), // FormBorderActive
            Color.FromArgb(162, 173, 185), // FormBorderInactive
            Color.FromArgb(187, 206, 230), // FormBorderActiveLight
            Color.FromArgb(212, 230, 245), // FormBorderActiveDark
            Color.FromArgb(223, 235, 247), // FormBorderInactiveLight
            Color.FromArgb(223, 235, 247), // FormBorderInactiveDark
            Color.FromArgb(144, 154, 166), // FormBorderHeaderActive
            Color.FromArgb(162, 173, 185), // FormBorderHeaderInactive
            Color.FromArgb(193, 212, 236), // FormBorderHeaderActive1
            Color.FromArgb(187, 206, 230), // FormBorderHeaderActive2
            Color.FromArgb(223, 235, 247), // FormBorderHeaderInctive1
            Color.FromArgb(223, 235, 247), // FormBorderHeaderInctive2
            Color.FromArgb(30, 57, 91), // FormHeaderShortActive
            Color.FromArgb(106, 128, 168), // FormHeaderShortInactive
            Color.FromArgb(30, 57, 91), // FormHeaderLongActive
            Color.FromArgb(106, 128, 168), // FormHeaderLongInactive
            Color.FromArgb(143, 165, 191), // FormButtonBorderTrack
            Color.FromArgb(214, 234, 255), // FormButtonBack1Track
            Color.FromArgb(188, 207, 231), // FormButtonBack2Track
            Color.FromArgb(143, 165, 191), // FormButtonBorderPressed
            Color.FromArgb(187, 206, 230), // FormButtonBack1Pressed
            Color.FromArgb(166, 182, 213), // FormButtonBack2Pressed
            Color.FromArgb(21, 66, 139), // TextButtonFormNormal
            Color.FromArgb(21, 66, 139), // TextButtonFormTracking
            Color.FromArgb(21, 66, 139), // TextButtonFormPressed
            Color.Blue, // LinkNotVisitedOverrideControl
            Color.Purple, // LinkVisitedOverrideControl
            Color.Red, // LinkPressedOverrideControl
            Color.Blue, // LinkNotVisitedOverridePanel
            Color.Purple, // LinkVisitedOverridePanel
            Color.Red, // LinkPressedOverridePanel
            Color.FromArgb(30, 57, 91), // TextLabelPanel
            Color.FromArgb(30, 57, 91), // RibbonTabTextNormal
            Color.FromArgb(30, 57, 91), // RibbonTabTextChecked
            Color.FromArgb(159, 178, 199), // RibbonTabSelected1
            Color.FromArgb(245, 250, 255), // RibbonTabSelected2
            Color.FromArgb(239, 246, 253), // RibbonTabSelected3
            Color.FromArgb(239, 246, 253), // RibbonTabSelected4
            Color.FromArgb(239, 246, 253), // RibbonTabSelected5
            Color.FromArgb(159, 178, 199), // RibbonTabTracking1
            Color.FromArgb(237, 241, 247), // RibbonTabTracking2
            Color.FromArgb(159, 178, 199), // RibbonTabHighlight1
            Color.FromArgb(245, 250, 255), // RibbonTabHighlight2
            Color.FromArgb(239, 246, 253), // RibbonTabHighlight3
            Color.FromArgb(239, 246, 253), // RibbonTabHighlight4
            Color.FromArgb(239, 246, 253), // RibbonTabHighlight5
            Color.FromArgb(182, 186, 191), // RibbonTabSeparatorColor
            Color.FromArgb(159, 178, 199), // RibbonGroupsArea1
            Color.FromArgb(114, 142, 173), // RibbonGroupsArea2
            Color.FromArgb(239, 246, 253), // RibbonGroupsArea3
            Color.FromArgb(221, 234, 247), // RibbonGroupsArea4
            Color.FromArgb(216, 228, 242), // RibbonGroupsArea5
            Color.FromArgb(235, 240, 246), // RibbonGroupBorder1
            Color.FromArgb(240, 246, 252), // RibbonGroupBorder2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitle1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitle2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupBorderContext1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupBorderContext2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleContext1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleContext2
            Color.FromArgb(135, 142, 152), // RibbonGroupDialogDark
            Color.FromArgb(165, 174, 183), // RibbonGroupDialogLight
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleTracking1
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupTitleTracking2
            Color.FromArgb(139, 160, 188), // RibbonMinimizeBarDark
            Color.FromArgb(187, 206, 230), // RibbonMinimizeBarLight
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
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBackT2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBackT3
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupCollapsedBackT4
            Color.FromArgb(189, 203, 218), // RibbonGroupFrameBorder1
            Color.FromArgb(184, 199, 216), // RibbonGroupFrameBorder2
            Color.FromArgb(233, 241, 250), // RibbonGroupFrameInside1
            Color.FromArgb(222, 233, 246), // RibbonGroupFrameInside2
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupFrameInside3
            GlobalStaticValues.EMPTY_COLOR, // RibbonGroupFrameInside4
            Color.FromArgb(30, 57, 91), // RibbonGroupCollapsedText
            Color.FromArgb(118, 153, 200), // AlternatePressedBack1
            Color.FromArgb(184, 215, 253), // AlternatePressedBack2
            Color.FromArgb(135, 156, 175), // AlternatePressedBorder1
            Color.FromArgb(177, 198, 216), // AlternatePressedBorder2
            Color.FromArgb(150, 194, 239), // FormButtonBack1Checked
            Color.FromArgb(210, 228, 254), // FormButtonBack2Checked
            Color.FromArgb(158, 193, 241), // FormButtonBorderCheck
            Color.FromArgb(140, 184, 229), // FormButtonBack1CheckTrack
            Color.FromArgb(225, 241, 255), // FormButtonBack2CheckTrack
            Color.FromArgb(154, 179, 213), // RibbonQATMini1
            Color.FromArgb(219, 231, 247), // RibbonQATMini2
            Color.FromArgb(195, 213, 236), // RibbonQATMini3
            Color.FromArgb(128, Color.White), // RibbonQATMini4
            Color.FromArgb(72, Color.White), // RibbonQATMini5                                                       
            Color.FromArgb(153, 176, 206), // RibbonQATMini1I
            Color.FromArgb(226, 233, 241), // RibbonQATMini2I
            Color.FromArgb(198, 210, 226), // RibbonQATMini3I
            Color.FromArgb(128, Color.White), // RibbonQATMini4I
            Color.FromArgb(72, Color.White), // RibbonQATMini5I                                                      
            Color.FromArgb(213, 232, 254), // RibbonQATFullbar1                                                      
            Color.FromArgb(205, 223, 245), // RibbonQATFullbar2                                                      
            Color.FromArgb(114, 142, 173), // RibbonQATFullbar3                                                      
            Color.FromArgb(90, 90, 90), // RibbonQATButtonDark                                                      
            Color.FromArgb(207, 214, 224), // RibbonQATButtonLight                                                      
            Color.FromArgb(222, 236, 252), // RibbonQATOverflow1                                                      
            Color.FromArgb(123, 139, 156), // RibbonQATOverflow2                                                      
            Color.FromArgb(145, 166,
                194), // RibbonGroupSeparatorDark                                                      
            Color.FromArgb(239, 245,
                250), // RibbonGroupSeparatorLight                                                      
            Color.FromArgb(192, 212,
                241), // ButtonClusterButtonBack1                                                      
            Color.FromArgb(200, 219,
                238), // ButtonClusterButtonBack2                                                      
            Color.FromArgb(155, 183,
                224), // ButtonClusterButtonBorder1                                                      
            Color.FromArgb(117, 150,
                191), // ButtonClusterButtonBorder2                                                      
            Color.FromArgb(213, 228, 242), // NavigatorMiniBackColor                                                    
            Color.FromArgb(244, 249, 255), // GridListNormal1                                                    
            Color.FromArgb(218, 231, 245), // GridListNormal2                                                    
            Color.FromArgb(198, 211, 225), // GridListPressed1                                                    
            Color.FromArgb(244, 249, 255), // GridListPressed2                                                    
            Color.FromArgb(160, 185, 230), // GridListSelected                                                    
            Color.FromArgb(233, 246, 255), // GridSheetColNormal1                                                    
            Color.FromArgb(213, 226, 240), // GridSheetColNormal2                                                    
            Color.FromArgb(255, 223, 107), // GridSheetColPressed1                                                    
            Color.FromArgb(255, 252, 230), // GridSheetColPressed2                                                    
            Color.FromArgb(255, 211, 89), // GridSheetColSelected1
            Color.FromArgb(255, 239, 113), // GridSheetColSelected2
            Color.FromArgb(218, 231, 245), // GridSheetRowNormal                                                   
            Color.FromArgb(255, 223, 107), // GridSheetRowPressed
            Color.FromArgb(245, 210, 87), // GridSheetRowSelected
            Color.FromArgb(218, 220, 221), // GridDataCellBorder
            Color.FromArgb(183, 219, 255), // GridDataCellSelected
            Color.Black, // InputControlTextNormal
            Color.FromArgb(168, 168, 168), // InputControlTextDisabled
            Color.FromArgb(177, 192, 214), // InputControlBorderNormal
            Color.FromArgb(177, 187, 198), // InputControlBorderDisabled
            Color.FromArgb(255, 255, 255), // InputControlBackNormal
            Color.FromArgb(240, 240, 240), // InputControlBackDisabled
            Color.FromArgb(237, 245, 253), // InputControlBackInactive
            Color.Black, // InputDropDownNormal1
            Color.Transparent, // InputDropDownNormal2
            Color.FromArgb(172, 168, 153), // InputDropDownDisabled1
            Color.Transparent, // InputDropDownDisabled2
            Color.FromArgb(240, 242, 245), // ContextMenuHeadingBack
            Color.FromArgb(30, 57, 91), // ContextMenuHeadingText
            Color.White, // ContextMenuImageColumn
            Color.FromArgb(195, 212, 235), // AppButtonBack1
            Color.FromArgb(195, 212, 235), // AppButtonBack2
            Color.FromArgb(114, 142, 173), // AppButtonBorder
            Color.FromArgb(195, 212, 235), // AppButtonOuter1
            Color.FromArgb(195, 212, 235), // AppButtonOuter2
            Color.FromArgb(195, 212, 235), // AppButtonOuter3
            GlobalStaticValues.EMPTY_COLOR, // AppButtonInner1
            Color.FromArgb(114, 142, 173), // AppButtonInner2
            Color.White, // AppButtonMenuDocs
            Color.Black, // AppButtonMenuDocsText
            Color.FromArgb(239, 245, 255), // SeparatorHighInternalBorder1
            Color.FromArgb(200, 217, 239), // SeparatorHighInternalBorder2
            Color.FromArgb(177, 192, 214), // RibbonGalleryBorder
            Color.FromArgb(237, 245, 253), // RibbonGalleryBackNormal
            Color.FromArgb(242, 247, 252), // RibbonGalleryBackTracking
            Color.FromArgb(237, 245, 253), // RibbonGalleryBack1
            Color.FromArgb(206, 221, 237), // RibbonGalleryBack2
            Color.FromArgb(214, 222, 234), // RibbonTabTracking3
            Color.FromArgb(200, 215, 233), // RibbonTabTracking4
            Color.FromArgb(147, 167, 195), // RibbonGroupBorder3
            Color.FromArgb(226, 236, 247), // RibbonGroupBorder4
            Color.FromArgb(251, 251, 252), // RibbonGroupBorder5
            Color.FromArgb(56, 78, 115), // RibbonGroupTitleText
            Color.FromArgb(151, 156, 163), // RibbonDropArrowLight
            Color.FromArgb(39, 49, 60), // RibbonDropArrowDark
            Color.FromArgb(208, 226, 248), // HeaderDockInactiveBack1
            Color.FromArgb(178, 196, 218), // HeaderDockInactiveBack2
            Color.FromArgb(133, 158, 191), // ButtonNavigatorBorder
            Color.FromArgb(0, 25, 56), // ButtonNavigatorText
            Color.FromArgb(177, 198, 224), // ButtonNavigatorTrack1
            Color.FromArgb(211, 224, 240), // ButtonNavigatorTrack2
            Color.FromArgb(148, 174, 205), // ButtonNavigatorPressed1
            Color.FromArgb(198, 214, 231), // ButtonNavigatorPressed2
            Color.FromArgb(200, 219, 240), // ButtonNavigatorChecked1
            Color.FromArgb(177, 201, 228), // ButtonNavigatorChecked2
            Color.FromArgb(201, 217,
                239) // ToolTipBottom                                                                      
        ];

        #endregion

        #endregion

        #region Constructors
        static PaletteMicrosoft365Blue()
        {
            _checkBoxList = new ImageList
            {
                ImageSize = new Size(13, 13),
                ColorDepth = ColorDepth.Depth24Bit
            };
            _checkBoxList.Images.AddStrip(CheckBoxStripResources.CheckBoxStrip2010Blue);
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
                Office2010RadioButtonImageResources.RadioButton2010BlueN,
                Office2010RadioButtonImageResources.RadioButton2010BlueT,
                Office2010RadioButtonImageResources.RadioButton2010BlueP,
                Office2010RadioButtonImageResources.RadioButton2010BlueDC,
                Office2010RadioButtonImageResources.RadioButton2010BlueNC,
                Office2010RadioButtonImageResources.RadioButton2010BlueTC,
                Office2010RadioButtonImageResources.RadioButton2010BluePC
            ];
        }

        /// <summary>
        /// Initializes a new instance of the PaletteMicrosoft365Blue class.
        /// </summary>
        public PaletteMicrosoft365Blue() : base(_schemeOfficeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
        {

        }
        #endregion

        #region Images        
        /// <summary>
        /// Gets an image indicating a sub-menu on a context menu item.
        /// </summary>
        /// <returns>
        /// Appropriate image for drawing; otherwise null.
        /// </returns>
        public override Image? GetContextMenuSubMenuImage() => _contextMenuSubMenu;

        #endregion

        #region ButtonSpec        
        /// <summary>
        /// Gets the image to display for the button.
        /// </summary>
        /// <param name="style">Style of button spec.</param>
        /// <param name="state">State for which image is required.</param>
        /// <returns>
        /// Image value.
        /// </returns>
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
            PaletteButtonSpecStyle.New => state switch
            {
                PaletteState.Normal => _integratedToolbarNewNormal,
                PaletteState.Disabled => _integratedToolbarNewDisabled,
                _ => _integratedToolbarNewDisabled
            },
            PaletteButtonSpecStyle.Open => state switch
            {
                PaletteState.Normal => _integratedToolbarOpenNormal,
                PaletteState.Disabled => _integratedToolbarOpenDisabled,
                _ => _integratedToolbarOpenDisabled
            },
            PaletteButtonSpecStyle.SaveAll => state switch
            {
                PaletteState.Normal => _integratedToolbarSaveAllNormal,
                PaletteState.Disabled => _integratedToolbarSaveAllDisabled,
                _ => _integratedToolbarSaveAllDisabled
            },
            PaletteButtonSpecStyle.SaveAs => state switch
            {
                PaletteState.Normal => _integratedToolbarSaveAsNormal,
                PaletteState.Disabled => _integratedToolbarSaveAsDisabled,
                _ => _integratedToolbarSaveAsDisabled
            },
            PaletteButtonSpecStyle.Save => state switch
            {
                PaletteState.Normal => _integratedToolbarSaveNormal,
                PaletteState.Disabled => _integratedToolbarSaveDisabled,
                _ => _integratedToolbarSaveDisabled
            },
            PaletteButtonSpecStyle.Cut => state switch
            {
                PaletteState.Normal => _integratedToolbarCutNormal,
                PaletteState.Disabled => _integratedToolbarCutDisabled,
                _ => _integratedToolbarCutDisabled
            },
            PaletteButtonSpecStyle.Copy => state switch
            {
                PaletteState.Normal => _integratedToolbarCopyNormal,
                PaletteState.Disabled => _integratedToolbarCopyDisabled,
                _ => _integratedToolbarCopyDisabled
            },
            PaletteButtonSpecStyle.Paste => state switch
            {
                PaletteState.Normal => _integratedToolbarPasteNormal,
                PaletteState.Disabled => _integratedToolbarPasteDisabled,
                _ => _integratedToolbarPasteDisabled
            },
            PaletteButtonSpecStyle.Undo => state switch
            {
                PaletteState.Normal => _integratedToolbarUndoNormal,
                PaletteState.Disabled => _integratedToolbarUndoDisabled,
                _ => _integratedToolbarUndoDisabled
            },
            PaletteButtonSpecStyle.Redo => state switch
            {
                PaletteState.Normal => _integratedToolbarRedoNormal,
                PaletteState.Disabled => _integratedToolbarRedoDisabled,
                _ => _integratedToolbarRedoDisabled
            },
            PaletteButtonSpecStyle.PageSetup => state switch
            {
                PaletteState.Normal => _integratedToolbarPageSetupNormal,
                PaletteState.Disabled => _integratedToolbarPageSetupDisabled,
                _ => _integratedToolbarPageSetupDisabled
            },
            PaletteButtonSpecStyle.PrintPreview => state switch
            {
                PaletteState.Normal => _integratedToolbarPrintPreviewNormal,
                PaletteState.Disabled => _integratedToolbarPrintPreviewDisabled,
                _ => _integratedToolbarPrintPreviewDisabled
            },
            PaletteButtonSpecStyle.Print => state switch
            {
                PaletteState.Normal => _integratedToolbarPrintNormal,
                PaletteState.Disabled => _integratedToolbarPrintDisabled,
                _ => _integratedToolbarPrintDisabled
            },
            PaletteButtonSpecStyle.QuickPrint => state switch
            {
                PaletteState.Normal => _integratedToolbarQuickPrintNormal,
                PaletteState.Disabled => _integratedToolbarQuickPrintDisabled,
                _ => _integratedToolbarQuickPrintDisabled
            },
            _ => base.GetButtonSpecImage(style, state)
        };
        #endregion#region Tab Row Background

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
}