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
    /// Draws all the month grid entries including the column names and day values
    /// </summary>
    public class ViewDrawWeekNumbers : ViewLeaf,
                                       IContentValues
    {
        #region Static Fields

        private const int WEEKS = 6;
        private static readonly TimeSpan _timespan1Day = new TimeSpan(1, 0, 0, 0);
        private static readonly TimeSpan _timespan6Days = new TimeSpan(6, 0, 0, 0);
        private static readonly TimeSpan _timespan1Week = new TimeSpan(7, 0, 0, 0);
        #endregion

        #region Instance Fields
        private readonly IKryptonMonthCalendar _calendar;
        private readonly ViewLayoutMonths _months;
        private readonly IDisposable?[] _dayMementos;
        private string _drawText;
        private DateTime _firstDay;
        private DateTime _weekDay;
        private DateTime _month;
        private bool _firstMonth;
        private bool _lastMonth;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewDrawWeekNumbers class.
        /// </summary>
        /// <param name="calendar">Reference to calendar provider.</param>
        /// <param name="months">Reference to months instance.</param>
        public ViewDrawWeekNumbers(IKryptonMonthCalendar calendar, ViewLayoutMonths months)
        {
            _drawText = string.Empty;
            _calendar = calendar;
            _months = months;
            _dayMementos = new IDisposable[WEEKS];
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewDrawWeekNumbers:{Id}";

        /// <summary>
        /// Release unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing">Called from Dispose method.</param>
        protected override void Dispose(bool disposing)
        {
            // Dispose of the mementos to prevent memory leak
            for(var i=0; i<_dayMementos.Length; i++)
            {
                if (_dayMementos[i] != null)
                {
                    _dayMementos[i]!.Dispose();
                    _dayMementos[i] = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public
        /// <summary>
        /// Is this the first month in the group.
        /// </summary>
        public bool FirstMonth
        {
            set => _firstMonth = value;
        }

        /// <summary>
        /// Is this the last month in the group.
        /// </summary>
        public bool LastMonth
        {
            set => _lastMonth = value;
        }

        /// <summary>
        /// Sets the date this month is used to represent.
        /// </summary>
        public DateTime Month
        {
            set
            {
                _month = value;

                // Begin with the day before the required month
                _firstDay = new DateTime(value.Year, value.Month, 1);
                _firstDay -= _timespan1Day;

                // Move backwards until we hit the starting day of the week
                while (_firstDay.DayOfWeek != _months.DisplayDayOfWeek)
                {
                    _firstDay -= _timespan1Day;
                }

                // Find the first day of the year
                var yearDay = new DateTime(value.Year, 1, 1);
                _weekDay = _firstDay;

                // Move forewards until we hit the starting day of the year
                while (_weekDay.DayOfWeek != yearDay.DayOfWeek)
                {
                    _weekDay += _timespan1Day;
                }
            }
        }
        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);
            return _months.SizeDay with { Height = _months.SizeDays.Height * WEEKS };
        }
        
        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context is not null);

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Renderer is null)
            {
                throw new ArgumentNullException(nameof(context.Renderer));
            }

            // We take on all the available display area
            ClientRectangle = context!.DisplayRectangle;
    
            // Do not draw week numbers in bold or focused
            _calendar.SetFocusOverride(false);
            _calendar.SetBoldedOverride(false);

            // Layout each week number
            var layoutRectWeek = new Rectangle(ClientLocation.X, ClientLocation.Y, _months.SizeDay.Width,
                _months.SizeDays.Height);
            DateTime weekDate = _weekDay;
            DateTime displayDate = _firstDay;
            for (var j = 0; j < WEEKS; j++)
            {
                // Should we draw a week number for a week starting on this date
                DateTime weekNumberDate = weekDate;
                if (DisplayWeekNumber(displayDate, ref weekNumberDate))
                {
                    // Define text to be drawn
                    _drawText = GetWeekNumber(weekNumberDate).ToString();

                    if (_dayMementos[j] != null)
                    {
                        _dayMementos[j]?.Dispose();
                        _dayMementos[j] = null;
                    }

                    var paletteState = Enabled ? PaletteState.Normal : PaletteState.Disabled;
                    IPaletteTriple paletteTriple = Enabled ? _calendar.StateNormal.Day : _calendar.StateDisabled.Day;

                    _dayMementos[j] = context.Renderer.RenderStandardContent.LayoutContent(context, layoutRectWeek, paletteTriple.PaletteContent!,
                                                                                           this, VisualOrientation.Top, paletteState);
                }

                // Move to next week
                weekDate += _timespan1Week;
                displayDate += _timespan1Week;
                layoutRectWeek.Y += _months.SizeDays.Height;
            }

            // Put back the original display value now we have finished
            context.DisplayRectangle = ClientRectangle;
        }
        #endregion

        #region Paint
        /// <summary>
        /// Perform rendering before child elements are rendered.
        /// </summary>
        /// <param name="context">Rendering context.</param>
        public override void RenderBefore([DisallowNull] RenderContext context)
        {
            Debug.Assert(context is not null);

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Renderer is null)
            {
                throw new ArgumentNullException(nameof(context.Renderer));
            }

            // Do not draw week numbers in bold or focused
            _calendar.SetFocusOverride(false);
            _calendar.SetBoldedOverride(false);

            // Layout each week number
            var drawRectWeek = new Rectangle(ClientLocation.X, ClientLocation.Y, _months.SizeDay.Width,
                _months.SizeDays.Height);
            DateTime weekDate = _weekDay;
            DateTime displayDate = _firstDay;
            for (var j = 0; j < WEEKS; j++)
            {
                // Should we draw a week number for a week starting on this date
                DateTime weekNumberDate = weekDate;
                if (DisplayWeekNumber(displayDate, ref weekNumberDate))
                {
                    // Define text to be drawn
                    _drawText = GetWeekNumber(weekNumberDate).ToString();

                    PaletteState paletteState = Enabled ? PaletteState.Normal : PaletteState.Disabled;
                    IPaletteTriple paletteTriple = Enabled ? _calendar.StateNormal.Day : _calendar.StateDisabled.Day;

                    // Do we need to draw the background?
                    if (paletteTriple.PaletteBack.GetBackDraw(paletteState) == InheritBool.True)
                    {
                        using GraphicsPath path = context!.Renderer.RenderStandardBorder.GetBackPath(context, drawRectWeek, paletteTriple.PaletteBorder!,
                            VisualOrientation.Top, paletteState);
                        context.Renderer.RenderStandardBack.DrawBack(context, drawRectWeek, path, paletteTriple.PaletteBack, VisualOrientation.Top, paletteState, null);
                    }

                    // Do we need to draw the border?
                    if (paletteTriple.PaletteBorder!.GetBorderDraw(paletteState) == InheritBool.True)
                    {
                        using var gh = new GraphicsHint(context!.Graphics, paletteTriple.PaletteBorder.GetBorderGraphicsHint(paletteState));
                        context.Renderer.RenderStandardBorder.DrawBorder(context, drawRectWeek, paletteTriple.PaletteBorder, VisualOrientation.Top, paletteState);
                    }

                    // Do we need to draw the content?
                    if (paletteTriple.PaletteContent!.GetContentDraw(paletteState) == InheritBool.True)
                    {
                        context?.Renderer.RenderStandardContent.DrawContent(context, drawRectWeek, paletteTriple.PaletteContent, _dayMementos[j]!,
                                                                           VisualOrientation.Top, paletteState, true);
                    }
                }

                // Move to next week
                weekDate += _timespan1Week;
                displayDate += _timespan1Week;
                drawRectWeek.Y += _months.SizeDays.Height;
            }
        }
        #endregion

        #region IContentValues
        /// <summary>
        /// Gets the content image.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Image value.</returns>
        public Image? GetImage(PaletteState state) => null;

        /// <summary>
        /// Gets the image color that should be transparent.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Color value.</returns>
        public Color GetImageTransparentColor(PaletteState state) => GlobalStaticValues.EMPTY_COLOR;

        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public string GetShortText() => _drawText;

        /// <summary>
        /// Gets the content long text.
        /// </summary>
        /// <returns>String value.</returns>
        public string GetLongText() => string.Empty;

        #endregion

        #region Implementation
        private int GetWeekNumber(DateTime dt) =>
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, 
                CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, 
                _months.DisplayDayOfWeek);

        private bool DisplayWeekNumber(DateTime displayDate, ref DateTime weekDate)
        {
            if (displayDate < _month)
            {
                displayDate += _timespan6Days;
                if (displayDate < _month)
                {
                    return _firstMonth;
                }
                else
                {
                    weekDate = _month;
                }
            }
            else
            {
                DateTime nextMonth = _month.AddMonths(1);
                DateTime displayDate2 = displayDate + _timespan6Days;
                if (displayDate2 >= nextMonth)
                {
                    if (displayDate >= nextMonth)
                    {
                        return _lastMonth;
                    }
                    else
                    {
                        weekDate = nextMonth.AddDays(-1);
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
