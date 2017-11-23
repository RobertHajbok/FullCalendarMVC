namespace FullCalendar
{
    public class View
    {
        public string Type { get; set; }

        /// <summary>
        /// Text that will be displayed on buttons of the header.
        /// buttonIcons and themeButtonIcons affects the appearance of certain other buttons.
        /// HTML injection is not supported. All special characters will be escaped.
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// Determines the text that will be displayed in the header's title.
        /// As noted above, each view has a specific default. Get fine-tuned control with View-Specific Options. A single string alone will set the value for all views.
        /// The default values will change based on the current locale.
        /// </summary>
        public string TitleFormat { get; set; }

        /// <summary>
        /// Sets the exact date range that is visible in a view.
        /// </summary>
        public VisibleRange VisibleRange { get; set; }

        /// <summary>
        /// Limits which dates the user can navigate to and where events can go.
        /// Dates outside of the valid range will be grayed-out. The user will not be able to drag or resize events into these areas.
        /// The prev/next buttons in the header will be grayed out to prevent the user from navigating to an invalid range.
        /// </summary>
        public ValidRange ValidRange { get; set; }

        /// <summary>
        /// How far into the future/past the calendar navigates when prev/next is executed.
        /// Determines how far the calendar will jump when the user presses the prev/next buttons in the header or when the prev or next methods are executed.
        /// When using a Custom View with a specified duration, the duration value will be the default for dateIncrement.
        /// </summary>
        public Duration DateIncrement { get; set; }

        /// <summary>
        /// Determines the first visible day for a Custom or Generic view.
        /// When a Custom View is being used, and you'd like to guarantee that the view begins at a certain interval, like the start-of-week or start-of-month, specify a value like "week" or "month".
        /// If not specified, a reasonable default will be generated based on the view's duration.
        /// If a view's range is explicity defined with visibleRange, dateAlignment will be ignored.
        /// </summary>
        public DateAlignment? DateAlignment { get; set; }

        /// <summary>
        /// Sets the exact duration of the Custom view.
        /// If the duration is specified like {weeks:1}, then the dateAlignment will automatically default to start-of-week. However, if it is specified as {days:7}, then no such alignment will happen.
        /// </summary>
        public Duration Duration { get; set; }

        /// <summary>
        /// Sets the exact number of days displayed in a Custom or Generic view, regardless of weekends or hiddenDays.
        /// When a view's range is specified with a duration, hidden days will simply be omitted, and the view will stretch to fill the missing space. However, if you specify dayCount, you are guaranteed to see a certain number of days.
        /// </summary>
        public int DayCount { get; set; }
    }
}
