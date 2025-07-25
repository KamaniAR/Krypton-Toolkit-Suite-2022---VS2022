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
    public class ViewDrawMonthDays : ViewLeaf,
                                     IContentValues
    {
        #region Static Fields

        private const int WEEKS = 6;
        private const int WEEKDAYS = 7;
        private const int DAYS = 42;
        private static readonly TimeSpan TIMESPAN_1DAY = new TimeSpan(1, 0, 0, 0);
        #endregion

        #region Instance Fields
        private readonly IKryptonMonthCalendar _calendar;
        private readonly ViewLayoutMonths _months;
        private readonly IDisposable?[] _dayMementos;
        private readonly Rectangle[] _dayRects;
        private DateTime _lastDay;
        private DateTime _firstDay;
        private DateTime _month;
        private bool _firstMonth;
        private bool _lastMonth;
        private string _drawText;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewDrawMonthDays class.
        /// </summary>
        /// <param name="calendar">Reference to calendar provider.</param>
        /// <param name="months">Reference to months instance.</param>
        public ViewDrawMonthDays(IKryptonMonthCalendar calendar, ViewLayoutMonths months)
        {
            _calendar = calendar;
            _months = months;
            _dayMementos = new IDisposable[DAYS];
            _dayRects = new Rectangle[DAYS];
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewDrawMonthDays:{Id}";

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
                    _dayMementos[i]?.Dispose();
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
                _firstDay -= TIMESPAN_1DAY;

                // Move backwards until we hit the starting day of the week
                while(_firstDay.DayOfWeek != _months.DisplayDayOfWeek)
                {
                    _firstDay -= TIMESPAN_1DAY;
                }
            }
        }

        /// <summary>
        /// Gets the day that is underneath the provided point.
        /// </summary>
        /// <param name="pt">Point to lookup.</param>
        /// <param name="exact">Exact requires that the day must be with the month range.</param>
        /// <returns>DateTime for matching day; otherwise null.</returns>
        public DateTime? DayFromPoint(Point pt, bool exact)
        {
            // Search the list of days for the one containing the requested point
            for (var i = 0; i < DAYS; i++)
            {
                if ((_dayMementos[i] != null) && _dayRects[i].Contains(pt))
                {
                    DateTime day = _firstDay.AddDays(i);
                    if (!exact || ((day >= _month) && (day <= _lastDay)))
                    {
                        return day;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the button for the day that is nearest (date wise) to the point provided.
        /// </summary>
        /// <param name="pt">Point to lookup.</param>
        /// <returns>DateTime for nearest matching day.</returns>
        public DateTime DayNearPoint(Point pt)
        {
            DateTime retDate = _month;

            // Search for an exact match
            var day = DayFromPoint(pt, true);
            if (day.HasValue)
            {
                retDate = day.Value;
            }
            else
            {
                // If the mouse is above area then return first day of the month
                if (pt.Y > ClientLocation.Y)
                {
                    if (pt.Y > ClientRectangle.Bottom)
                    {
                        retDate = _month.AddMonths(1).AddDays(-1);
                    }
                    else
                    {
                        // Find the row the mouse is within
                        for (var row = 0; row < WEEKS; row++)
                        {
                            if (pt.Y < _dayRects[row * WEEKDAYS].Bottom)
                            {
                                DateTime startRowDate = _firstDay.AddDays(row * WEEKDAYS);

                                if (pt.X < ClientLocation.X)
                                {
                                    retDate = startRowDate;
                                }
                                else if (pt.X >= ClientRectangle.Right)
                                {
                                    retDate = startRowDate.AddDays(WEEKDAYS - 1);
                                }
                                else
                                {
                                    var offsetDays = (pt.X - ClientLocation.X) / _dayRects[row * WEEKDAYS].Width;
                                    retDate = startRowDate.AddDays(offsetDays);
                                }

                                break;
                            }
                        }
                    }
                }
            }

            if (retDate > _lastDay)
            {
                return _lastDay;
            }

            return retDate < _month ? _month : retDate;
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
            return new Size(_months.SizeDays.Width * WEEKDAYS, _months.SizeDays.Height * WEEKS);
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

            // Get the current date values
            DateTime minDate = _calendar.MinDate.Date;
            DateTime maxDate = _calendar.MaxDate.Date;
            DateTime selectStart = _calendar.SelectionStart.Date;
            DateTime selectEnd = _calendar.SelectionEnd.Date;

            // We take on all the available display area
            ClientRectangle = context!.DisplayRectangle;

            var layoutXCell = ClientLocation.X;
            var layoutXDay = ClientLocation.X + ((_months.SizeDays.Width - _months.SizeDay.Width) / 2);
            var layoutRectCell = new Rectangle(layoutXCell, ClientLocation.Y, _months.SizeDays.Width,
                _months.SizeDays.Height);
            var layoutRectDay = new Rectangle(layoutXDay, ClientLocation.Y, _months.SizeDay.Width,
                _months.SizeDays.Height);

            // Layout each week as a row
            DateTime todayDate = _calendar.TodayDate;
            DateTime displayDate = _firstDay;
            for (var j = 0; j < WEEKS; j++)
            {
                // Layout each day as a column
                for (var i = 0; i < WEEKDAYS; i++)
                {
                    // Memento index
                    var index = (j * WEEKDAYS) + i;

                    // Define text to be drawn
                    _drawText = displayDate.Day.ToString();

                    if (_dayMementos[index] != null)
                    {
                        _dayMementos[index]?.Dispose();
                        _dayMementos[index] = null;
                    }

                    var skip = false;
                    var paletteState = PaletteState.Normal;
                    IPaletteTriple paletteTriple = _calendar.OverrideNormal;

                    // If the display date is not within the allowed range, do not draw it
                    if ((displayDate < minDate) || (displayDate > maxDate))
                    {
                        skip = true;
                    }
                    else
                    {
                        _calendar.SetFocusOverride(false);
                        _calendar.SetBoldedOverride(BoldedDate(displayDate));
                        _calendar.SetTodayOverride(_months.ShowTodayCircle && (displayDate == todayDate));

                        // If the day is not actually in the month we are drawing
                        if (displayDate.Month != _month.Month)
                        {
                            // If we need to show this day but disabled
                            if (((j < 3) && _firstMonth) || ((j > 3) && _lastMonth))
                            {
                                paletteState = PaletteState.Disabled;
                                paletteTriple = _calendar.OverrideDisabled;
                            }
                            else
                            {
                                skip = true;
                            }
                        }
                        else
                        {
                            // Is this day part of the selection?
                            if ((displayDate >= selectStart) && (displayDate <= selectEnd))
                            {
                                _calendar.SetFocusOverride((_months.FocusDay != null) && (_months.FocusDay.Value == displayDate));

                                if (_months.TrackingDay.HasValue && (_months.TrackingDay.Value == displayDate))
                                {
                                    paletteState = PaletteState.CheckedTracking;
                                    paletteTriple = _calendar.OverrideCheckedTracking;
                                }
                                else
                                {
                                    paletteState = PaletteState.CheckedNormal;
                                    paletteTriple = _calendar.OverrideCheckedNormal;
                                }
                            }
                            else
                            {
                                if (_months.TrackingDay.HasValue && (_months.TrackingDay.Value == displayDate))
                                {
                                    paletteState = PaletteState.Tracking;
                                    paletteTriple = _calendar.OverrideTracking;
                                }
                            }
                        }
                    }

                    if (!skip)
                    {
                        _dayMementos[index] = context.Renderer.RenderStandardContent.LayoutContent(context, layoutRectDay, paletteTriple.PaletteContent!,
                                                                                                   this, VisualOrientation.Top, paletteState);

                        // Track the maximum date displayed for this month (exclude disabled days that are shown for
                        // information but cannot actually be selected themselves as part of a multi selection action)
                        if (paletteState != PaletteState.Disabled)
                        {
                            _lastDay = displayDate;
                        }
                    }

                    _dayRects[index] = layoutRectCell;

                    // Move across to next column
                    layoutRectCell.X += _months.SizeDays.Width;
                    layoutRectDay.X += _months.SizeDays.Width;

                    // Move to next day
                    displayDate += TIMESPAN_1DAY;
                }

                // Move to start of the next row
                layoutRectCell.X = layoutXCell;
                layoutRectCell.Y += _months.SizeDays.Height;
                layoutRectDay.X = layoutXDay;
                layoutRectDay.Y += _months.SizeDays.Height;
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

            // Get the current date values
            DateTime minDate = _calendar.MinDate.Date;
            DateTime maxDate = _calendar.MaxDate.Date;
            DateTime selectStart = _calendar.SelectionStart.Date;
            DateTime selectEnd = _calendar.SelectionEnd.Date;

            var layoutXCell = ClientLocation.X;
            var layoutXDay = ClientLocation.X + ((_months.SizeDays.Width - _months.SizeDay.Width) / 2);
            var drawRectCell = new Rectangle(layoutXCell, ClientLocation.Y, _months.SizeDays.Width,
                _months.SizeDays.Height);
            var drawRectDay = new Rectangle(layoutXDay, ClientLocation.Y, _months.SizeDay.Width,
                _months.SizeDays.Height);

            // Draw each week as a row
            DateTime todayDate = _calendar.TodayDate;
            DateTime displayDate = _firstDay;
            for (var j = 0; j < WEEKS; j++)
            {
                // Draw each day as a column
                for (var i = 0; i < WEEKDAYS; i++)
                {
                    // Memento index
                    var index = (j * WEEKDAYS) + i;

                    // Draw using memento cached from the layout call
                    if (_dayMementos[index] != null)
                    {
                        var skip = false;
                        var paletteState = PaletteState.Normal;
                        IPaletteTriple paletteTriple = _calendar.OverrideNormal;

                        // If the display date is not within the allowed range, do not draw it
                        if ((displayDate < minDate) || (displayDate > maxDate))
                        {
                            skip = true;
                        }
                        else
                        {
                            _calendar.SetFocusOverride(false);
                            _calendar.SetBoldedOverride(BoldedDate(displayDate));
                            _calendar.SetTodayOverride(_months.ShowTodayCircle && (displayDate == todayDate));

                            // If the day is not actually in the month we are drawing
                            if (displayDate.Month != _month.Month)
                            {
                                // If we need to show this day but disabled
                                if (((j < 3) && _firstMonth) || ((j > 3) && _lastMonth))
                                {
                                    paletteState = PaletteState.Disabled;
                                    paletteTriple = _calendar.OverrideDisabled;
                                }
                                else
                                {
                                    skip = true;
                                }
                            }
                            else
                            {
                                // Is this day part of the selection?
                                if ((displayDate >= selectStart) && (displayDate <= selectEnd))
                                {
                                    _calendar.SetFocusOverride((_months.FocusDay != null) && (_months.FocusDay.Value == displayDate));

                                    if (_months.TrackingDay.HasValue && (_months.TrackingDay.Value == displayDate))
                                    {
                                        paletteState = PaletteState.CheckedTracking;
                                        paletteTriple = _calendar.OverrideCheckedTracking;
                                    }
                                    else
                                    {
                                        paletteState = PaletteState.CheckedNormal;
                                        paletteTriple = _calendar.OverrideCheckedNormal;
                                    }
                                }
                                else
                                {
                                    if (_months.TrackingDay.HasValue && (_months.TrackingDay.Value == displayDate))
                                    {
                                        paletteState = PaletteState.Tracking;
                                        paletteTriple = _calendar.OverrideTracking;
                                    }
                                }
                            }
                        }

                        if (!skip)
                        {
                            // Do we need to draw the background?
                            if (paletteTriple.PaletteBack.GetBackDraw(paletteState) == InheritBool.True)
                            {
                                using GraphicsPath path = context?.Renderer.RenderStandardBorder.GetBackPath(context, drawRectCell, paletteTriple.PaletteBorder!, 
                                    VisualOrientation.Top, paletteState)!;
                                using var gh = new GraphicsHint(context!.Graphics, paletteTriple.PaletteBorder!.GetBorderGraphicsHint(paletteState));
                                context.Renderer.RenderStandardBack.DrawBack(context, drawRectCell, path, paletteTriple.PaletteBack, VisualOrientation.Top, paletteState, null);
                            }

                            // Do we need to draw the border?
                            if (paletteTriple.PaletteBorder!.GetBorderDraw(paletteState) == InheritBool.True)
                            {
                                context?.Renderer.RenderStandardBorder.DrawBorder(context, drawRectCell, paletteTriple.PaletteBorder, VisualOrientation.Top, paletteState);
                            }

                            // Do we need to draw the content?
                            if (paletteTriple.PaletteContent!.GetContentDraw(paletteState) == InheritBool.True)
                            {
                                context?.Renderer.RenderStandardContent.DrawContent(context, drawRectDay, paletteTriple.PaletteContent, _dayMementos[index]!,
                                                                                   VisualOrientation.Top, paletteState, true);
                            }
                        }
                    }

                    // Move across to next column
                    drawRectCell.X += _months.SizeDays.Width;
                    drawRectDay.X += _months.SizeDays.Width;

                    // Move to next day
                    displayDate += TIMESPAN_1DAY;
                }

                // Move to start of the next row
                drawRectCell.X = layoutXCell;
                drawRectCell.Y += _months.SizeDays.Height;
                drawRectDay.X = layoutXDay;
                drawRectDay.Y += _months.SizeDays.Height;
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
        private bool BoldedDate(DateTime date)
        {
            // Convert date to a month mask
            var monthMask = 1 << (date.Day - 1);

            // Check the month bolded mask
            if ((monthMask & _calendar.MonthlyBoldedDatesMask) != 0)
            {
                return true;
            }

            // Check the year bolded mask
            if ((monthMask & _calendar.AnnuallyBoldedDatesMask[date.Month - 1]) != 0)
            {
                return true;
            }

            // Check the individual bolded date list
            foreach (DateTime dt in _calendar.BoldedDatesList)
            {
                if (dt == date)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
