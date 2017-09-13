namespace FullCalendar
{
    public class FullCalendarParameters
    {
        #region General Display

        /// <summary>
        /// Defines the buttons and title at the top of the calendar.
        /// Setting the header options to null will display no header.
        /// </summary>
        public Header Header { get; set; }

        /// <summary>
        /// Renders a set of controls at the bottom of the calendar.
        /// This settings accepts the same exact values as the header option.
        /// It is null by default, meaning no controls will be rendered at the foot of the calendar.
        /// </summary>
        public Footer Footer { get; set; }

        /// <summary>
        /// Displays the calendar in right-to-left mode.
        /// This option is useful for right-to-left languages such as Arabic and Hebrew.
        /// </summary>
        public bool IsRTL { get; set; }

        /// <summary>
        /// Whether to include Saturday/Sunday columns in any of the calendar views.
        /// </summary>
        public bool Weekends { get; set; } = true;

        /// <summary>
        /// Determines the number of weeks displayed in a month view.
        /// If true, the calendar will always be 6 weeks tall. If false, the calendar will have either 4, 5, or 6 weeks, depending on the month.
        /// </summary>
        public bool FixedWeekCount { get; set; } = true;

        /// <summary>
        /// Determines if week numbers should be displayed on the calendar.
        /// If set to true, week numbers will be displayed in a separate left column in the month/basic views as well as at the top-left corner of the agenda views. See Available Views.
        /// By default, FullCalendar will use the current locale's week number calculation method. To display other types of week numbers, see weekNumberCalculation.
        /// </summary>
        public bool WeekNumbers { get; set; }

        /// <summary>
        /// Determines the styling for week numbers in month view and the basic views.
        /// </summary>
        public bool WeekNumbersWithinDays { get; set; }

        /// <summary>
        /// In month view, whether dates in the previous or next month should be rendered at all.
        /// Days that are disabled will not render events.
        /// </summary>
        public bool ShowNonCurrentDates { get; set; } = true;

        #endregion

        #region Views

        /// <summary>
        /// The initial view when the calendar loads. Any of the Available Views.
        /// </summary>
        public CalendarView DefaultView { get; set; } = CalendarView.Month;

        #endregion

        #region Agenda Options

        /// <summary>
        /// Determines if the "all-day" slot is displayed at the top of the calendar.
        /// When hidden with false, all-day events will not be displayed in agenda views.
        /// </summary>
        public bool AllDaySlot { get; set; } = true;

        #endregion

        #region Selection

        /// <summary>
        /// Allows a user to highlight multiple days or timeslots by clicking and dragging.
        /// To let the user make selections by clicking and dragging, this option must be set to true.
        /// </summary>
        public bool Selectable { get; set; }

        /// <summary>
        /// Whether to draw a "placeholder" event while the user is dragging.
        /// This option only applies to the agenda views. A value of true will draw a "placeholder" event while the user is dragging 
        /// (similar to what Google Calendar does for its week and day views). A value of false (the default) will draw the standard 
        /// highlighting over each cell.
        /// </summary>
        public bool SelectHelper { get; set; }

        /// <summary>
        /// Whether clicking elsewhere on the page will cause the current selection to be cleared.
        /// This option can only take effect when selectable is set to true.
        /// </summary>
        public bool UnselectAuto { get; set; } = true;

        #endregion

        #region Event Dragging & Resizing

        /// <summary>
        /// Determines whether the events on the calendar can be modified.
        /// This determines if the events can be dragged and resized. Enables/disables both at the same time. 
        /// If you don't want both, use the more specific eventStartEditable and eventDurationEditable instead.
        /// This option can be overridden on a per-event basis with the Event Object editable property.
        /// </summary>
        public bool Editable { get; set; }

        #endregion
    }
}
