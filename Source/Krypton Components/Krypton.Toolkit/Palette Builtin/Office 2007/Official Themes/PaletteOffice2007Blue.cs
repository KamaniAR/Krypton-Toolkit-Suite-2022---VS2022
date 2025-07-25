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
    /// Provides the Blue color scheme variant of the Office 2007 palette.
    /// </summary>
    public class PaletteOffice2007Blue : PaletteOffice2007Base
    {
        #region Static Fields

        #region Image List

        private static readonly ImageList _checkBoxList;
        private static readonly ImageList _galleryButtonList;

        #endregion

        #region Image Array

        private static readonly Image?[] _radioButtonArray;

        #endregion

        #region Images

        private static readonly Image? _blueDropDownButton = GenericImageResources.BlueDropDownButton;
        private static readonly Image _blueCloseNormal = Office2007ControlBoxResources.Office2007ControlBoxBlueCloseNormal;
        private static readonly Image _blueCloseActive = Office2007ControlBoxResources.Office2007ControlBoxBlueCloseActive;
        private static readonly Image _blueCloseDisabled = Office2007ControlBoxResources.Office2007ControlBoxBlueCloseDisabled;
        private static readonly Image _blueClosePressed = Office2007ControlBoxResources.Office2007ControlBoxBlueClosePressed;
        private static readonly Image _blueMaximiseNormal = Office2007ControlBoxResources.Office2007ControlBoxBlueMaximiseNormal;
        private static readonly Image _blueMaximiseActive = Office2007ControlBoxResources.Office2007ControlBoxBlueMaximiseActive;
        private static readonly Image _blueMaximiseDisabled = Office2007ControlBoxResources.Office2007ControlBoxBlueMaximiseDisabled;
        private static readonly Image _blueMaximisePressed = Office2007ControlBoxResources.Office2007ControlBoxBlueMaximisePressed;
        private static readonly Image _blueMinimiseNormal = Office2007ControlBoxResources.Office2007ControlBoxBlueMinimiseNormal;
        private static readonly Image _blueMinimiseActive = Office2007ControlBoxResources.Office2007ControlBoxBlueMinimiseActive;
        private static readonly Image _blueMinimiseDisabled = Office2007ControlBoxResources.Office2007ControlBoxBlueMinimiseDisabled;
        private static readonly Image _blueMinimisePressed = Office2007ControlBoxResources.Office2007ControlBoxBlueMinimisePessed;
        private static readonly Image _blueRestoreNormal = Office2007ControlBoxResources.Office2007ControlBoxBlueRestoreNormal;
        private static readonly Image _blueRestoreActive = Office2007ControlBoxResources.Office2007ControlBoxBlueRestoreActive;
        private static readonly Image _blueRestoreDisabled = Office2007ControlBoxResources.Office2007ControlBoxBlueRestoreDisabled;
        private static readonly Image _blueRestorePressed = Office2007ControlBoxResources.Office2007ControlBoxBlueRestorePressed;
        private static readonly Image _blueHelpNormal = Office2007ControlBoxResources.Office2007HelpIconNormal;
        private static readonly Image _blueHelpActive = Office2007ControlBoxResources.Office2007HelpIconHover;
        private static readonly Image _blueHelpDisabled = Office2007ControlBoxResources.Office2007HelpIconDisabled;
        private static readonly Image _blueHelpPressed = Office2007ControlBoxResources.Office2007HelpIconPressed;
        private static readonly Image? _contextMenuSubMenu = GenericImageResources.BlueContextMenuSub;

        #endregion

        #region Color Arrays

        private static readonly Color[] _trackBarColors =
        [
            Color.FromArgb(116, 150, 194),      // Tick marks
            Color.FromArgb(116, 150, 194),      // Top track
            Color.FromArgb(152, 190, 241),      // Bottom track
            Color.FromArgb(142, 180, 231),      // Fill track
            Color.FromArgb(64, Color.White),    // Outside position
            Color.FromArgb(63, 101, 152)        // Border (normal) position
        ];
        private static readonly Color[] _schemeOfficeColors =
        [
            Color.FromArgb( 21,  66, 139),    // TextLabelControl
            Color.FromArgb( 21,  66, 139),    // TextButtonNormal
            Color.Blue,                      // TextButtonChecked
            Color.FromArgb(161, 189, 207),    // ButtonNormalBorder
            Color.FromArgb(121, 157, 182),    // ButtonNormalDefaultBorder
            Color.FromArgb(210, 225, 244),    // ButtonNormalBack1
            Color.FromArgb(235, 243, 254),    // ButtonNormalBack2
            Color.FromArgb(123, 192, 232),    // ButtonNormalDefaultBack1
            Color.FromArgb(177, 252, 255),    // ButtonNormalDefaultBack2
            Color.FromArgb(178, 214, 255),    // ButtonNormalNavigatorBack1
            Color.FromArgb(202, 229, 255),    // ButtonNormalNavigatorBack2
            Color.FromArgb(191, 219, 255),    // PanelClient
            Color.FromArgb(177, 208, 248),    // PanelAlternative
            Color.FromArgb(101, 147, 207),    // ControlBorder
            Color.FromArgb(227, 239, 255),    // SeparatorHighBorder1
            Color.FromArgb(182, 214, 255),    // SeparatorHighBorder2
            Color.FromArgb(227, 239, 255),    // HeaderPrimaryBack1
            Color.FromArgb(175, 210, 255),    // HeaderPrimaryBack2
            Color.FromArgb(214, 232, 255),    // HeaderSecondaryBack1
            Color.FromArgb(214, 232, 255),    // HeaderSecondaryBack2
            Color.FromArgb( 21,  66, 139),    // HeaderText
            Color.FromArgb( 21,  66, 139),    // StatusStripText
            Color.FromArgb(121, 153, 194),    // ButtonBorder
            Color.FromArgb(255, 255, 255),    // SeparatorLight
            Color.FromArgb(154, 198, 255),    // SeparatorDark
            Color.FromArgb(248, 248, 248),    // GripLight
            Color.FromArgb(114, 152, 204),    // GripDark
            Color.FromArgb(191, 219, 255),    // ToolStripBack
            Color.FromArgb(215, 229, 247),    // StatusStripLight
            Color.FromArgb(172, 201, 238),    // StatusStripDark
            Color.FromArgb(233, 238, 238),    // ImageMargin
            Color.FromArgb(227, 239, 255),    // ToolStripBegin
            Color.FromArgb(222, 236, 255),    // ToolStripMiddle
            Color.FromArgb(152, 186, 230),    // ToolStripEnd
            Color.FromArgb(167, 204, 251),    // OverflowBegin
            Color.FromArgb(167, 204, 251),    // OverflowMiddle
            Color.FromArgb(101, 147, 207),    // OverflowEnd
            Color.FromArgb(111, 157, 217),    // ToolStripBorder
            Color.FromArgb( 59,  90, 130),    // FormBorderActive
            Color.FromArgb(192, 198, 206),    // FormBorderInactive
            Color.FromArgb(176, 203, 239),    // FormBorderActiveLight
            Color.FromArgb(194, 217, 247),    // FormBorderActiveDark
            Color.FromArgb(204, 216, 232),    // FormBorderInactiveLight
            Color.FromArgb(212, 222, 236),    // FormBorderInactiveDark
            Color.FromArgb(221, 233, 248),    // FormBorderHeaderActive
            Color.FromArgb(223, 229, 237),    // FormBorderHeaderInactive
            Color.FromArgb(176, 207, 247),    // FormBorderHeaderActive1
            Color.FromArgb(228, 239, 253),    // FormBorderHeaderActive2
            Color.FromArgb(204, 218, 236),    // FormBorderHeaderInctive1
            Color.FromArgb(227, 232, 239),    // FormBorderHeaderInctive2
            Color.FromArgb( 62, 106, 184),    // FormHeaderShortActive
            Color.FromArgb(160, 160, 160),    // FormHeaderShortInactive
            Color.FromArgb(105, 112, 121),    // FormHeaderLongActive
            Color.FromArgb(160, 160, 160),    // FormHeaderLongInactive
            Color.FromArgb(158, 193, 241),    // FormButtonBorderTrack
            Color.FromArgb(210, 228, 254),    // FormButtonBack1Track
            Color.FromArgb(255, 255, 255),    // FormButtonBack2Track
            Color.FromArgb(162, 191, 227),    // FormButtonBorderPressed
            Color.FromArgb(132, 178, 233),    // FormButtonBack1Pressed
            Color.FromArgb(192, 231, 252),    // FormButtonBack2Pressed
            Color.FromArgb( 21,  66, 139),    // TextButtonFormNormal
            Color.FromArgb( 21,  66, 139),    // TextButtonFormTracking
            Color.FromArgb( 21,  66, 139),    // TextButtonFormPressed
            Color.Blue,                       // LinkNotVisitedOverrideControl
            Color.Purple,                     // LinkVisitedOverrideControl
            Color.Red,                        // LinkPressedOverrideControl
            Color.Blue,                       // LinkNotVisitedOverridePanel
            Color.Purple,                     // LinkVisitedOverridePanel
            Color.Red,                        // LinkPressedOverridePanel
            Color.FromArgb( 21,  66, 139),    // TextLabelPanel
            Color.FromArgb( 21,  66, 139),    // RibbonTabTextNormal
            Color.FromArgb( 21,  66, 139),    // RibbonTabTextChecked
            Color.FromArgb(145, 180, 228),    // RibbonTabSelected1
            Color.FromArgb(209, 251, 255),    // RibbonTabSelected2
            Color.FromArgb(246, 250, 255),    // RibbonTabSelected3
            Color.FromArgb(239, 246, 254),    // RibbonTabSelected4
            Color.FromArgb(222, 232, 245),    // RibbonTabSelected5
            Color.FromArgb(153, 187, 232),    // RibbonTabTracking1
            Color.FromArgb(255, 180,  86),    // RibbonTabTracking2
            Color.FromArgb(255, 255, 189),    // RibbonTabHighlight1
            Color.FromArgb(249, 237, 198),    // RibbonTabHighlight2
            Color.FromArgb(218, 185, 127),    // RibbonTabHighlight3
            Color.FromArgb(254, 209,  94),    // RibbonTabHighlight4
            Color.FromArgb(205, 209, 180),    // RibbonTabHighlight5
            Color.FromArgb(116, 153, 203),    // RibbonTabSeparatorColor
            Color.FromArgb(219, 230, 244),    // RibbonGroupsArea1
            Color.FromArgb(231, 242, 255),    // RibbonGroupsArea2
            Color.FromArgb(201, 217, 237),    // RibbonGroupsArea3
            Color.FromArgb(192, 249, 255),    // RibbonGroupsArea4
            Color.FromArgb(141, 178, 227),    // RibbonGroupsArea5
            Color.FromArgb(197, 210, 223),    // RibbonGroupBorder1
            Color.FromArgb(158, 191, 219),    // RibbonGroupBorder2
            Color.FromArgb(193, 216, 242),    // RibbonGroupTitle1
            Color.FromArgb(193, 216, 242),    // RibbonGroupTitle2
            Color.FromArgb(202, 202, 202),    // RibbonGroupBorderContext1
            Color.FromArgb(196, 196, 196),    // RibbonGroupBorderContext2
            Color.FromArgb(223, 223, 245),    // RibbonGroupTitleContext1
            Color.FromArgb(210, 221, 242),    // RibbonGroupTitleContext2
            Color.FromArgb(102, 142, 175),    // RibbonGroupDialogDark
            Color.FromArgb(254, 254, 255),    // RibbonGroupDialogLight
            Color.FromArgb(200, 224, 255),    // RibbonGroupTitleTracking1
            Color.FromArgb(214, 237, 255),    // RibbonGroupTitleTracking2
            Color.FromArgb(155, 187, 227),    // RibbonMinimizeBarDark
            Color.FromArgb(213, 226, 243),    // RibbonMinimizeBarLight
            Color.FromArgb(165, 191, 213),    // RibbonGroupCollapsedBorder1
            Color.FromArgb(148, 185, 213),    // RibbonGroupCollapsedBorder2
            Color.FromArgb(64, Color.White),  // RibbonGroupCollapsedBorder3
            Color.FromArgb(202, 244, 254),    // RibbonGroupCollapsedBorder4
            Color.FromArgb(221, 233, 249),    // RibbonGroupCollapsedBack1
            Color.FromArgb(199, 218, 243),    // RibbonGroupCollapsedBack2
            Color.FromArgb(186, 209, 240),    // RibbonGroupCollapsedBack3
            Color.FromArgb(214, 238, 252),    // RibbonGroupCollapsedBack4
            Color.FromArgb(186, 205, 225),    // RibbonGroupCollapsedBorderT1
            Color.FromArgb(177, 230, 235),    // RibbonGroupCollapsedBorderT2
            Color.FromArgb(192, Color.White), // RibbonGroupCollapsedBorderT3
            Color.FromArgb(247, 251, 254),    // RibbonGroupCollapsedBorderT4
            Color.FromArgb(240, 244, 250),    // RibbonGroupCollapsedBackT1
            Color.FromArgb(226, 234, 245),    // RibbonGroupCollapsedBackT2
            Color.FromArgb(216, 227, 241),    // RibbonGroupCollapsedBackT3
            Color.FromArgb(214, 237, 253),    // RibbonGroupCollapsedBackT4
            Color.FromArgb(170, 195, 217),    // RibbonGroupFrameBorder1
            Color.FromArgb(195, 217, 242),    // RibbonGroupFrameBorder2
            Color.FromArgb(227, 237, 250),    // RibbonGroupFrameInside1
            Color.FromArgb(221, 233, 248),    // RibbonGroupFrameInside2
            Color.FromArgb(214, 228, 246),    // RibbonGroupFrameInside3
            Color.FromArgb(227, 236, 248),    // RibbonGroupFrameInside4
            Color.FromArgb( 21,  66, 139),    // RibbonGroupCollapsedText
            Color.FromArgb(118, 153, 200),    // AlternatePressedBack1
            Color.FromArgb(184, 215, 253),    // AlternatePressedBack2
            Color.FromArgb(135, 156, 175),    // AlternatePressedBorder1
            Color.FromArgb(177, 198, 216),    // AlternatePressedBorder2
            Color.FromArgb(150, 194, 239),    // FormButtonBack1Checked
            Color.FromArgb(210, 228, 254),    // FormButtonBack2Checked
            Color.FromArgb(158, 193, 241),    // FormButtonBorderCheck
            Color.FromArgb(140, 184, 229),    // FormButtonBack1CheckTrack
            Color.FromArgb(225, 241, 255),    // FormButtonBack2CheckTrack
            Color.FromArgb(154, 179, 213),    // RibbonQATMini1
            Color.FromArgb(219, 231, 247),    // RibbonQATMini2
            Color.FromArgb(195, 213, 236),    // RibbonQATMini3
            Color.FromArgb(128, Color.White), // RibbonQATMini4
            Color.FromArgb(72, Color.White),  // RibbonQATMini5                                                       
            Color.FromArgb(153, 176, 206),    // RibbonQATMini1I
            Color.FromArgb(226, 233, 241),    // RibbonQATMini2I
            Color.FromArgb(198, 210, 226),    // RibbonQATMini3I
            Color.FromArgb(128, Color.White), // RibbonQATMini4I
            Color.FromArgb(72, Color.White),  // RibbonQATMini5I                                                      
            Color.FromArgb(178, 205, 237),    // RibbonQATFullbar1                                                      
            Color.FromArgb(170, 197, 234),    // RibbonQATFullbar2                                                      
            Color.FromArgb(126, 161, 205),    // RibbonQATFullbar3                                                      
            Color.FromArgb( 86, 125, 177),    // RibbonQATButtonDark                                                      
            Color.FromArgb(234, 242, 249),    // RibbonQATButtonLight                                                      
            Color.FromArgb(192, 220, 255),    // RibbonQATOverflow1                                                      
            Color.FromArgb( 55, 100, 160),    // RibbonQATOverflow2                                                      
            Color.FromArgb(140, 172, 211),    // RibbonGroupSeparatorDark                                                      
            Color.FromArgb(248, 250, 252),    // RibbonGroupSeparatorLight                                                      
            Color.FromArgb(192, 212, 241),    // ButtonClusterButtonBack1                                                      
            Color.FromArgb(200, 219, 238),    // ButtonClusterButtonBack2                                                      
            Color.FromArgb(155, 183, 224),    // ButtonClusterButtonBorder1                                                      
            Color.FromArgb(117, 150, 191),    // ButtonClusterButtonBorder2                                                      
            Color.FromArgb(213, 228, 242),    // NavigatorMiniBackColor                                                    
            Color.White,                      // GridListNormal1                                                    
            Color.FromArgb(196, 221, 255),    // GridListNormal2                                                    
            Color.FromArgb(194, 220, 255),    // GridListPressed1                                                    
            Color.FromArgb(252, 253, 255),    // GridListPressed2                                                    
            Color.FromArgb(170, 195, 240),    // GridListSelected                                                    
            Color.FromArgb(249, 252, 253),    // GridSheetColNormal1                                                    
            Color.FromArgb(211, 219, 233),    // GridSheetColNormal2                                                    
            Color.FromArgb(223, 226, 228),    // GridSheetColPressed1                                                    
            Color.FromArgb(188, 197, 210),    // GridSheetColPressed2                                                    
            Color.FromArgb(249, 217, 159),    // GridSheetColSelected1
            Color.FromArgb(241, 193,  95),    // GridSheetColSelected2
            Color.FromArgb(228, 236, 247),    // GridSheetRowNormal                                                   
            Color.FromArgb(187, 196, 209),    // GridSheetRowPressed
            Color.FromArgb(255, 213, 141),    // GridSheetRowSelected
            Color.FromArgb(188, 195, 209),    // GridDataCellBorder
            Color.FromArgb(194, 217, 240),    // GridDataCellSelected
            Color.Blue,                      // InputControlTextNormal
            Color.FromArgb(172, 168, 153),    // InputControlTextDisabled
            Color.FromArgb(171, 193, 222),    // InputControlBorderNormal
            Color.FromArgb(177, 187, 198),    // InputControlBorderDisabled
            Color.FromArgb(255, 255, 255),    // InputControlBackNormal
            SystemColors.Control,             // InputControlBackDisabled
            Color.FromArgb(234, 242, 251),    // InputControlBackInactive
            Color.FromArgb( 86, 125, 177),    // InputDropDownNormal1
            Color.FromArgb(255, 248, 203),    // InputDropDownNormal2
            Color.FromArgb(172, 168, 153),    // InputDropDownDisabled1
            Color.Transparent,                // InputDropDownDisabled2
            Color.FromArgb(221, 231, 238),    // ContextMenuHeadingBack
            Color.FromArgb(0,    21, 110),    // ContextMenuHeadingText
            Color.FromArgb(233, 238, 238),    // ContextMenuImageColumn
            Color.White,                      // AppButtonBack1
            Color.FromArgb(201, 238, 255),    // AppButtonBack2
            Color.FromArgb(155, 175, 202),    // AppButtonBorder
            Color.FromArgb(189, 211, 238),    // AppButtonOuter1
            Color.FromArgb(176, 201, 234),    // AppButtonOuter2
            Color.FromArgb(207, 224, 245),    // AppButtonOuter3
            Color.White,                      // AppButtonInner1
            Color.FromArgb(155, 175, 202),    // AppButtonInner2
            Color.FromArgb(233, 234, 238),    // AppButtonMenuDocs
            Color.FromArgb(0,   21,  110),    // AppButtonMenuDocsText
            Color.FromArgb(227, 239, 255),    // SeparatorHighInternalBorder1
            Color.FromArgb(182, 214, 255),    // SeparatorHighInternalBorder2
            Color.FromArgb(185, 208, 237),    // RibbonGalleryBorder
            Color.FromArgb(212, 230, 248),    // RibbonGalleryBackNormal
            Color.FromArgb(236, 243, 251),    // RibbonGalleryBackTracking
            Color.FromArgb(193, 213, 241),    // RibbonGalleryBack1
            Color.FromArgb(215, 233, 251),    // RibbonGalleryBack2
            GlobalStaticValues.EMPTY_COLOR,                      // RibbonTabTracking3
            GlobalStaticValues.EMPTY_COLOR,                      // RibbonTabTracking4
            GlobalStaticValues.EMPTY_COLOR,                      // RibbonGroupBorder3
            GlobalStaticValues.EMPTY_COLOR,                      // RibbonGroupBorder4
            GlobalStaticValues.EMPTY_COLOR,                      // RibbonDropArrowLight
            GlobalStaticValues.EMPTY_COLOR // RibbonDropArrowDark
        ];

        #endregion

        #endregion

        #region Identity
        static PaletteOffice2007Blue()
        {
            _checkBoxList = new ImageList
            {
                ImageSize = new Size(13, 13),
                ColorDepth = ColorDepth.Depth24Bit
            };
            _checkBoxList.Images.AddStrip(CheckBoxStripResources.CheckBoxStrip2007Blue);
            _galleryButtonList = new ImageList
            {
                ImageSize = new Size(13, 7),
                ColorDepth = ColorDepth.Depth24Bit,
                TransparentColor = GlobalStaticValues.TRANSPARENCY_KEY_COLOR
            };
            _galleryButtonList.Images.AddStrip(GalleryImageResources.GalleryBlue);
            _radioButtonArray =
            [
                Office2007RadioButtonImageResources.RadioButton2007BlueD,
                Office2007RadioButtonImageResources.RadioButton2007BlueN,
                Office2007RadioButtonImageResources.RadioButton2007BlueT,
                Office2007RadioButtonImageResources.RadioButton2007BlueP,
                Office2007RadioButtonImageResources.RadioButton2007BlueDC,
                Office2007RadioButtonImageResources.RadioButton2007BlueNC,
                Office2007RadioButtonImageResources.RadioButton2007BlueTC,
                Office2007RadioButtonImageResources.RadioButton2007BluePC
            ];
        }

        /// <summary>
        /// Initialize a new instance of the PaletteOffice2007Blue class.
        /// </summary>
        public PaletteOffice2007Blue()
            : base("Office 2007 - Blue",
                    _schemeOfficeColors,
                    _checkBoxList,
                    _galleryButtonList,
                    _radioButtonArray,
                    _trackBarColors)
        {
        }
        #endregion

        #region Back
        /// <summary>
        /// Gets the color background drawing style.
        /// </summary>
        /// <param name="style">Background style.</param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color drawing style.</returns>
        public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state) => style switch
        {
            PaletteBackStyle.HeaderForm => PaletteColorStyle.Rounding4,
            _ => base.GetBackColorStyle(style, state)
        };
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
        public override Image? GetButtonSpecImage(PaletteButtonSpecStyle style,
                                                 PaletteState state) => style switch
                                                 {
                                                     PaletteButtonSpecStyle.FormClose => state switch
                                                     {
                                                         PaletteState.Disabled => _blueCloseDisabled,
                                                         PaletteState.Tracking => _blueCloseActive,
                                                         PaletteState.Pressed => _blueClosePressed,
                                                         _ => _blueCloseNormal
                                                     },
                                                     PaletteButtonSpecStyle.FormMin => state switch
                                                     {
                                                         PaletteState.Disabled => _blueMinimiseDisabled,
                                                         PaletteState.Tracking => _blueMinimiseActive,
                                                         PaletteState.Pressed => _blueMinimisePressed,
                                                         _ => _blueMinimiseNormal
                                                     },
                                                     PaletteButtonSpecStyle.FormMax => state switch
                                                     {
                                                         PaletteState.Disabled => _blueMaximiseDisabled,
                                                         PaletteState.Tracking => _blueMaximiseActive,
                                                         PaletteState.Pressed => _blueMaximisePressed,
                                                         _ => _blueMaximiseNormal
                                                     },
                                                     PaletteButtonSpecStyle.FormRestore => state switch
                                                     {
                                                         PaletteState.Disabled => _blueRestoreDisabled,
                                                         PaletteState.Tracking => _blueRestoreActive,
                                                         PaletteState.Pressed => _blueRestorePressed,
                                                         _ => _blueRestoreNormal
                                                     },
                                                     PaletteButtonSpecStyle.FormHelp => state switch
                                                     {
                                                         PaletteState.Disabled => _blueHelpDisabled,
                                                         PaletteState.Tracking => _blueHelpActive,
                                                         PaletteState.Pressed => _blueHelpPressed,
                                                         _ => _blueHelpNormal
                                                     },
                                                     _ => base.GetButtonSpecImage(style, state)
                                                 };
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
                case PaletteRibbonBackStyle.RibbonGroupArea:
                    if (state == PaletteState.CheckedNormal)
                    {
                        return PaletteRibbonColorStyle.RibbonGroupAreaBorder;
                    }

                    break;
                case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
                    if (state == PaletteState.Tracking)
                    {
                        return PaletteRibbonColorStyle.RibbonGroupNormalBorderTrackingLight;
                    }

                    break;
            }

            return base.GetRibbonBackColorStyle(style, state);
        }
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
        public override Color GetRibbonTabRowBackgroundSolidColor(PaletteState state) => GlobalStaticValues.EMPTY_COLOR;

        /// <inheritdoc />
        public override float GetRibbonTabRowGradientRaftingAngle(PaletteState state) => -1;

        #endregion

        #region AppButton Colors

        /// <inheritdoc />
        public override Color GetRibbonFileAppTabBottomColor(PaletteState state) => GlobalStaticValues.EMPTY_COLOR;

        /// <inheritdoc />
        public override Color GetRibbonFileAppTabTopColor(PaletteState state) => GlobalStaticValues.EMPTY_COLOR;

        /// <inheritdoc />
        public override Color GetRibbonFileAppTabTextColor(PaletteState state) => GlobalStaticValues.EMPTY_COLOR;

        #endregion
    }
}
