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
    /// Implement storage for palette border, background and image only content.
    /// </summary>
    public class PaletteTripleJustImageRedirect : Storage,
                                                  IPaletteTriple
    {
        #region Instance Fields

        private readonly PaletteBackInheritRedirect _backInherit;
        private readonly PaletteBorderInheritRedirect _borderInherit;
        private readonly PaletteContentInheritRedirect _contentInherit;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteTripleJustImageRedirect class.
        /// </summary>
        /// <param name="backStyle">Initial background style.</param>
        /// <param name="borderStyle">Initial border style.</param>
        /// <param name="contentStyle">Initial content style.</param>
        public PaletteTripleJustImageRedirect(PaletteBackStyle backStyle,
                                              PaletteBorderStyle borderStyle,
                                              PaletteContentStyle contentStyle)
            : this(null, backStyle, borderStyle, contentStyle, null)
        {
        }

        /// <summary>
        /// Initialize a new instance of the PaletteTripleJustImageRedirect class.
        /// </summary>
        /// <param name="redirect">inheritance redirection instance.</param>
        /// <param name="backStyle">Initial background style.</param>
        /// <param name="borderStyle">Initial border style.</param>
        /// <param name="contentStyle">Initial content style.</param>
        public PaletteTripleJustImageRedirect(PaletteRedirect redirect,
                                              PaletteBackStyle backStyle,
                                              PaletteBorderStyle borderStyle,
                                              PaletteContentStyle contentStyle)
            : this(redirect, backStyle, borderStyle, contentStyle, null)
        {
        }

        /// <summary>
        /// Initialize a new instance of the PaletteTripleJustImageRedirect class.
        /// </summary>
        /// <param name="redirect">inheritance redirection instance.</param>
        /// <param name="backStyle">Initial background style.</param>
        /// <param name="borderStyle">Initial border style.</param>
        /// <param name="contentStyle">Initial content style.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public PaletteTripleJustImageRedirect(PaletteRedirect? redirect,
                                              PaletteBackStyle backStyle,
                                              PaletteBorderStyle borderStyle,
                                              PaletteContentStyle contentStyle,
                                              NeedPaintHandler? needPaint)
        {
            // Store the provided paint notification delegate
            NeedPaint = needPaint;

            // Store the inherit instances
            _backInherit = new PaletteBackInheritRedirect(redirect, backStyle);
            _borderInherit = new PaletteBorderInheritRedirect(redirect, borderStyle);
            _contentInherit = new PaletteContentInheritRedirect(redirect, contentStyle);

            // Create storage that maps onto the inherit instances
            Back = new PaletteBack(_backInherit, needPaint);
            Border = new PaletteBorder(_borderInherit, needPaint);
            Content = new PaletteContentJustImage(_contentInherit, needPaint);
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool IsDefault => Back.IsDefault &&
                                            Border.IsDefault &&
                                            Content.IsDefault;

        #endregion

        #region GetRedirector
        /// <summary>
        /// Gets the redirector instance.
        /// </summary>
        /// <returns>Return the currently used redirector.</returns>
        public PaletteRedirect GetRedirector() => _backInherit.GetRedirector();

        #endregion

        #region SetRedirector
        /// <summary>
        /// Update the redirector with new reference.
        /// </summary>
        /// <param name="redirect">Target redirector.</param>
        public virtual void SetRedirector(PaletteRedirect redirect)
        {
            _backInherit.SetRedirector(redirect);
            _borderInherit.SetRedirector(redirect);
            _contentInherit.SetRedirector(redirect);
        }
        #endregion

        #region SetStyles
        /// <summary>
        /// Update each individual style.
        /// </summary>
        /// <param name="backStyle">New background style.</param>
        /// <param name="borderStyle">New border style.</param>
        /// <param name="contentStyle">New content style.</param>
        public void SetStyles(PaletteBackStyle backStyle,
                              PaletteBorderStyle borderStyle,
                              PaletteContentStyle contentStyle)
        {
            BackStyle = backStyle;
            BorderStyle = borderStyle;
            ContentStyle = contentStyle;
        }

        /// <summary>
        /// Update the palette styles using a button style.
        /// </summary>
        /// <param name="buttonStyle">New button style.</param>
        public void SetStyles(ButtonStyle buttonStyle)
        {
            switch (buttonStyle)
            {
                case ButtonStyle.Standalone:
                    SetStyles(PaletteBackStyle.ButtonStandalone,
                              PaletteBorderStyle.ButtonStandalone,
                              PaletteContentStyle.ButtonStandalone);
                    break;
                case ButtonStyle.Alternate:
                    SetStyles(PaletteBackStyle.ButtonAlternate,
                              PaletteBorderStyle.ButtonAlternate,
                              PaletteContentStyle.ButtonAlternate);
                    break;
                case ButtonStyle.LowProfile:
                    SetStyles(PaletteBackStyle.ButtonLowProfile,
                              PaletteBorderStyle.ButtonLowProfile,
                              PaletteContentStyle.ButtonLowProfile);
                    break;
                case ButtonStyle.ButtonSpec:
                    SetStyles(PaletteBackStyle.ButtonButtonSpec,
                              PaletteBorderStyle.ButtonButtonSpec,
                              PaletteContentStyle.ButtonButtonSpec);
                    break;
                case ButtonStyle.BreadCrumb:
                    SetStyles(PaletteBackStyle.ButtonBreadCrumb,
                              PaletteBorderStyle.ButtonBreadCrumb,
                              PaletteContentStyle.ButtonBreadCrumb);
                    break;
                case ButtonStyle.CalendarDay:
                    SetStyles(PaletteBackStyle.ButtonCalendarDay,
                              PaletteBorderStyle.ButtonCalendarDay,
                              PaletteContentStyle.ButtonCalendarDay);
                    break;
                case ButtonStyle.Cluster:
                    SetStyles(PaletteBackStyle.ButtonCluster,
                              PaletteBorderStyle.ButtonCluster,
                              PaletteContentStyle.ButtonCluster);
                    break;
                case ButtonStyle.Gallery:
                    SetStyles(PaletteBackStyle.ButtonGallery,
                              PaletteBorderStyle.ButtonGallery,
                              PaletteContentStyle.ButtonGallery);
                    break;
                case ButtonStyle.NavigatorStack:
                    SetStyles(PaletteBackStyle.ButtonNavigatorStack,
                              PaletteBorderStyle.ButtonNavigatorStack,
                              PaletteContentStyle.ButtonNavigatorStack);
                    break;
                case ButtonStyle.NavigatorOverflow:
                    SetStyles(PaletteBackStyle.ButtonNavigatorOverflow,
                              PaletteBorderStyle.ButtonNavigatorOverflow,
                              PaletteContentStyle.ButtonNavigatorOverflow);
                    break;
                case ButtonStyle.NavigatorMini:
                    SetStyles(PaletteBackStyle.ButtonNavigatorMini,
                              PaletteBorderStyle.ButtonNavigatorMini,
                              PaletteContentStyle.ButtonNavigatorMini);
                    break;
                case ButtonStyle.InputControl:
                    SetStyles(PaletteBackStyle.ButtonInputControl,
                              PaletteBorderStyle.ButtonInputControl,
                              PaletteContentStyle.ButtonInputControl);
                    break;
                case ButtonStyle.ListItem:
                    SetStyles(PaletteBackStyle.ButtonListItem,
                              PaletteBorderStyle.ButtonListItem,
                              PaletteContentStyle.ButtonListItem);
                    break;
                case ButtonStyle.Form:
                    SetStyles(PaletteBackStyle.ButtonForm,
                              PaletteBorderStyle.ButtonForm,
                              PaletteContentStyle.ButtonForm);
                    break;
                case ButtonStyle.FormClose:
                    SetStyles(PaletteBackStyle.ButtonFormClose,
                              PaletteBorderStyle.ButtonFormClose,
                              PaletteContentStyle.ButtonFormClose);
                    break;
                case ButtonStyle.Command:
                    SetStyles(PaletteBackStyle.ButtonCommand,
                              PaletteBorderStyle.ButtonCommand,
                              PaletteContentStyle.ButtonCommand);
                    break;
                case ButtonStyle.Custom1:
                    SetStyles(PaletteBackStyle.ButtonCustom1,
                              PaletteBorderStyle.ButtonCustom1,
                              PaletteContentStyle.ButtonCustom1);
                    break;
                case ButtonStyle.Custom2:
                    SetStyles(PaletteBackStyle.ButtonCustom2,
                              PaletteBorderStyle.ButtonCustom2,
                              PaletteContentStyle.ButtonCustom2);
                    break;
                case ButtonStyle.Custom3:
                    SetStyles(PaletteBackStyle.ButtonCustom3,
                              PaletteBorderStyle.ButtonCustom3,
                              PaletteContentStyle.ButtonCustom3);
                    break;
                default:
    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(buttonStyle.ToString());
                    break;
            }
        }

        /// <summary>
        /// Update the palette styles using a header style.
        /// </summary>
        /// <param name="headerStyle">New header style.</param>
        public void SetStyles(HeaderStyle headerStyle)
        {
            switch (headerStyle)
            {
                case HeaderStyle.Primary:
                    SetStyles(PaletteBackStyle.HeaderPrimary,
                              PaletteBorderStyle.HeaderPrimary,
                              PaletteContentStyle.HeaderPrimary);
                    break;
                case HeaderStyle.Secondary:
                    SetStyles(PaletteBackStyle.HeaderSecondary,
                              PaletteBorderStyle.HeaderSecondary,
                              PaletteContentStyle.HeaderSecondary);
                    break;
                case HeaderStyle.DockActive:
                    SetStyles(PaletteBackStyle.HeaderDockActive,
                              PaletteBorderStyle.HeaderDockActive,
                              PaletteContentStyle.HeaderDockActive);
                    break;
                case HeaderStyle.DockInactive:
                    SetStyles(PaletteBackStyle.HeaderDockInactive,
                              PaletteBorderStyle.HeaderDockInactive,
                              PaletteContentStyle.HeaderDockInactive);
                    break;
                case HeaderStyle.Form:
                    SetStyles(PaletteBackStyle.HeaderForm,
                              PaletteBorderStyle.HeaderForm,
                              PaletteContentStyle.HeaderForm);
                    break;
                case HeaderStyle.Calendar:
                    SetStyles(PaletteBackStyle.HeaderCalendar,
                              PaletteBorderStyle.HeaderCalendar,
                              PaletteContentStyle.HeaderCalendar);
                    break;
                case HeaderStyle.Custom1:
                    SetStyles(PaletteBackStyle.HeaderCustom1,
                              PaletteBorderStyle.HeaderCustom1,
                              PaletteContentStyle.HeaderCustom1);
                    break;
                case HeaderStyle.Custom2:
                    SetStyles(PaletteBackStyle.HeaderCustom2,
                              PaletteBorderStyle.HeaderCustom2,
                              PaletteContentStyle.HeaderCustom2);
                    break;
                case HeaderStyle.Custom3:
                    SetStyles(PaletteBackStyle.HeaderCustom3,
                        PaletteBorderStyle.HeaderCustom3,
                        PaletteContentStyle.HeaderCustom3);
                    break;
                default:
    // Should never happen!
                    Debug.Assert(false);
                    DebugTools.NotImplemented(headerStyle.ToString());
                    break;
            }
        }
        #endregion

        #region PopulateFromBase
        /// <summary>
        /// Populate values from the base palette.
        /// </summary>
        /// <param name="state">Palette state to use when populating.</param>
        public void PopulateFromBase(PaletteState state)
        {
            Back.PopulateFromBase(state);
            Border.PopulateFromBase(state);
            Content.PopulateFromBase(state);
        }
        #endregion

        #region Back
        /// <summary>
        /// Gets access to the background palette details.
        /// </summary>
        [KryptonPersist]
        [Category(@"Visuals")]
        [Description(@"Overrides for defining background appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteBack Back { get; }

        private bool ShouldSerializeBack() => !Back.IsDefault;

        /// <summary>
        /// Gets the background palette.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPaletteBack PaletteBack => Back;

        /// <summary>
        /// Gets and sets the back palette style.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PaletteBackStyle BackStyle
        {
            get => _backInherit.Style;
            set => _backInherit.Style = value;
        }
        #endregion

        #region Border
        /// <summary>
        /// Gets access to the border palette details.
        /// </summary>
        [KryptonPersist]
        [Category(@"Visuals")]
        [Description(@"Overrides for defining border appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteBorder Border { get; }

        private bool ShouldSerializeBorder() => !Border.IsDefault;

        /// <summary>
        /// Gets the border palette.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPaletteBorder? PaletteBorder => Border;

        /// <summary>
        /// Gets and sets the border palette style.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PaletteBorderStyle BorderStyle
        {
            get => _borderInherit.Style;
            set => _borderInherit.Style = value;
        }
        #endregion

        #region Content
        /// <summary>
        /// Gets access to the content palette details.
        /// </summary>
        [KryptonPersist]
        [Category(@"Visuals")]
        [Description(@"Overrides for defining content appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteContentJustImage Content { get; }

        private bool ShouldSerializeContent() => !Content.IsDefault;

        /// <summary>
        /// Gets the content palette.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPaletteContent? PaletteContent => Content;

        /// <summary>
        /// Gets and sets the content palette style.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PaletteContentStyle ContentStyle
        {
            get => _contentInherit.Style;
            set => _contentInherit.Style = value;
        }
        #endregion

        #region Protected
        /// <summary>
        /// Handle a change event from palette source.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="needLayout">True if a layout is also needed.</param>
        protected void OnNeedPaint(object? sender, bool needLayout) =>
            // Pass request from child to our own handler
            PerformNeedPaint(needLayout);

        #endregion
    }
}
