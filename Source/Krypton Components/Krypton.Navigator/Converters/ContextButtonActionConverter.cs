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
    /// Custom type converter so that ContextButtonAction values appear as neat text at design time.
    /// </summary>
    public class ContextButtonActionConverter : StringLookupConverter<ContextButtonAction>
    {
        #region Static Fields

        [Localizable(true)]
        private static readonly BiDictionary<ContextButtonAction, string> _pairs = new BiDictionary<ContextButtonAction, string>(
            new Dictionary<ContextButtonAction, string>
            {
                { ContextButtonAction.None, @"None (Do nothing)" },
                { ContextButtonAction.SelectPage, @"Select Page" }
            });
        #endregion

        #region Protected
        /// <summary>
        /// Gets an array of lookup pairs.
        /// </summary>
        protected override IReadOnlyDictionary<string /*Display*/, ContextButtonAction /*Enum*/ > PairsStringToEnum  => _pairs.SecondToFirst;
        protected override IReadOnlyDictionary<ContextButtonAction /*Enum*/, string /*Display*/> PairsEnumToString => _pairs.FirstToSecond;
        #endregion
    }
}
