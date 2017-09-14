using System;

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

        /// <summary>
        /// The text titling the "all-day" slot at the top of the calendar.
        /// The default value depends on the current locale.
        /// </summary>
        public string AllDayText { get; set; }

        /// <summary>
        /// The frequency for displaying time slots.
        /// </summary>
        public TimeSpan SlotDuration { get; set; }

        /// <summary>
        /// Determines the time-text that will be displayed on the vertical axis of the agenda views.
        /// The default value depends on the current locale.
        /// The default English value - h(:mm)a - will produce times that look like "5pm" and "5:30pm".
        /// </summary>
        public string SlotLabelFormat { get; set; }

        /// <summary>
        /// Determines how often the time-axis is labeled with text displaying the date/time of slots.
        /// If not specified, this value is automatically computed from slotDuration. With slotDuration's default value of 30 minutes, this value will be 1 hour.
        /// </summary>
        public TimeSpan SlotLabelInterval { get; set; }

        /// <summary>
        /// The time interval at which a dragged event will snap to the agenda view time grid. Also affects the granularity at which selections can be made.
        /// The default value will be whatever slotDuration is, which defaults to half an hour.
        /// </summary>
        public TimeSpan SnapDuration { get; set; }

        /// <summary>
        /// Determines how far down the scroll pane is initially scrolled down.
        /// The user will be able to scroll upwards to see events before this time. If you want to prevent users from doing this, use the minTime option instead.
        /// </summary>
        public TimeSpan ScrollTime { get; set; }

        /// <summary>
        /// Determines the starting time that will be displayed, even when the scrollbars have been scrolled all the way up.
        /// The default "00:00:00" means the start time will be at the very beginning of the day (midnight).
        /// </summary>
        public TimeSpan MinTime { get; set; }

        /// <summary>
        /// Determines the end time (exclusively) that will be displayed, even when the scrollbars have been scrolled all the way down.
        /// The default "24:00:00" means the end time will be at the very end of the day (midnight).
        /// </summary>
        public TimeSpan MaxTime { get; set; }

        /// <summary>
        /// Determines if timed events in agenda view should visually overlap.
        /// When set to true (the default), events will overlap each other. At most half of each event will be obscured.
        /// </summary>
        public bool SlotEventOverlap { get; set; } = true;

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

        #region Event Data

        /// <summary>
        /// A URL of a JSON feed that the calendar will fetch Event Objects from. 
        /// FullCalendar will visit the URL whenever it needs new event data. This happens when the user clicks prev/next or changes views.
        /// FullCalendar will determine the date-range it needs events for and will pass that information along in GET parameters.
        /// The GET parameter names will be determined by the startParam and endParam options. ("start" and "end" by default).
        /// The values of these parameters will be ISO8601 date strings(like 2013-12-01). For precise behavior, see the timezone docs.
        /// </summary>
        public string Events { get; set; }

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
