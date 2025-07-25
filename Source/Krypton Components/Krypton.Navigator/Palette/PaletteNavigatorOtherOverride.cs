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
    /// Allow the palette to be overriden optionally.
	/// </summary>
    public class PaletteNavigatorOverride
    {
        #region Instance Fields
        private PaletteTripleOverride _overrideCheckButton;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteNavigatorOverride class.
		/// </summary>
        /// <param name="normalOther">Normal palette to use.</param>
        /// <param name="overrideOther">Override palette to use.</param>
        /// <param name="overrideState">State used by the override.</param>
        public PaletteNavigatorOverride(PaletteNavigatorOtherRedirect normalOther,
                                             PaletteNavigatorOther overrideOther,
                                             PaletteState overrideState)
            : this(normalOther.CheckButton, overrideOther.CheckButton, overrideState)
        {
        }

        /// <summary>
        /// Initialize a new instance of the PaletteNavigatorOverride class.
        /// </summary>
        /// <param name="normalOther">Normal palette to use.</param>
        /// <param name="overrideOther">Override palette to use.</param>
        /// <param name="overrideState">State used by the override.</param>
        public PaletteNavigatorOverride(PaletteNavigatorOtherRedirect normalOther,
                                        PaletteNavigator overrideOther,
                                        PaletteState overrideState)
            : this(normalOther.CheckButton, overrideOther.CheckButton, overrideState)
        {
        }

        /// <summary>
        /// Initialize a new instance of the PaletteNavigatorOverride class.
		/// </summary>
        /// <param name="checkButtonNormal">Normal palette to use.</param>
        /// <param name="checkButtonOther">Override palette to use.</param>
        /// <param name="overrideState">State used by the override.</param>
        public PaletteNavigatorOverride(IPaletteTriple checkButtonNormal,
                                        IPaletteTriple checkButtonOther,
                                        PaletteState overrideState) 
		{
            Debug.Assert(checkButtonNormal != null);
            Debug.Assert(checkButtonOther != null);

            // Create the palette storage
            _overrideCheckButton = new PaletteTripleOverride(checkButtonNormal, 
                                                             checkButtonOther, 
                                                             overrideState);

            // Do not apply an override by default
            Apply = false;
        }
        #endregion

        #region Apply
        /// <summary>
        /// Gets and sets a value indicating if override should be applied.
        /// </summary>
        public bool Apply
        {
            get { return _overrideCheckButton.Apply; }
            set { _overrideCheckButton.Apply = value; }
        }
        #endregion

        #region Override
        /// <summary>
        /// Gets and sets a value indicating if override state should be applied.
        /// </summary>
        public bool Override
        {
            get { return _overrideCheckButton.Override; }
            set { _overrideCheckButton.Override = value; }
        }
        #endregion

        #region OverrideState
        /// <summary>
        /// Gets and sets the override palette state to use.
        /// </summary>
        public PaletteState OverrideState
        {
            get { return _overrideCheckButton.OverrideState; }
            set { _overrideCheckButton.OverrideState = value; }
        }
        #endregion

        #region Palette Accessors
        /// <summary>
        /// Gets access to the check button palette.
        /// </summary>
        public PaletteTripleOverride CheckButton
        {
            get { return _overrideCheckButton; }
        }
        #endregion
    }
}
