using System;
using System.Drawing;

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
        /// Determines which icons are displayed in buttons of the header.
        /// This setting only takes affect when theme is false. If you want to change icons when theme is true, use themeButtonIcons instead.
        /// A hash must be supplied that maps button names (from the header) to icon strings. These icon string are transformed into classNames which are styled by FullCalendar's CSS.
        /// If a button does not have an entry, it falls back to using buttonText.
        /// If you would prefer not to display any icons and would rather use buttonText instead, you can set the buttonIcons option to false.
        /// </summary>
        public object ButtonIcons { get; set; } = new
        {
            prev = "left-single-arrow",
            next = "right-single-arrow",
            prevYear = "left-double-arrow",
            nextYear = "right-double-arrow"
        };

        /// <summary>
        /// Renders the calendar with a given theme system.
        /// 'standard' renders a minimal look & feel, the look in most of the demos. Does not require any CSS files beyond the FullCalendar base files.
        /// 'bootstrap3' prepares the calendar for a Bootstrap 3 theme.The Bootstrap CSS file must be separately loaded in its own<link> tag.
        /// 'jquery-ui' prepares the calendar for a jQuery UI theme.The jQuery UI CSS file file must be separately loaded in its own <link> tag.
        /// </summary>
        public ThemeSystem ThemeSystem { get; set; }

        /// <summary>
        /// Determines which icons are displayed in buttons of the header when jQuery UI theming is on.
        /// This option only applies to calendars that have themeSystem set to 'jquery-ui'.
        /// A hash must be supplied that maps button names (from the header) to icon strings. The icon strings determine the CSS class that will be used on the button. For example, the string 'circle-triangle-w' will result in the class 'ui-icon-circle-triangle-w'.
        /// If a button does not have an entry, it falls back to using buttonText.
        /// If you are using a jQuery UI theme and would prefer not to display any icons and would rather use buttonText instead, you can set the themeButtonIcons option to false.
        /// </summary>
        public object ThemeButtonIcons { get; set; } = new
        {
            prev = "circle-triangle-w",
            next = "circle-triangle-e",
            prevYear = "seek-prev",
            nextYear = "seek-next"
        };

        /// <summary>
        /// Determines which icons are displayed in buttons of the header when Bootstrap theming is on.
        /// This option only applies to calendars that have themeSystem set to 'bootstrap3'.
        /// A hash must be supplied that maps button names (from the header) to icon strings. See a full list of Bootstrap glyphicons.
        /// If a button does not have an entry, it falls back to using buttonText.
        /// If you are using a Bootstrap theme and would prefer not to display any icons and would rather use buttonText instead, you can set the bootstrapGlyphicons option to false.
        /// </summary>
        public object BootstrapGlyphicons { get; set; } = new
        {
            close = "glyphicon-remove",
            prev = "glyphicon-chevron-left",
            next = "glyphicon-chevron-right",
            prevYear = "glyphicon-backward",
            nextYear = "glyphicon-forward"
        };

        /// <summary>
        /// The day that each week begins.
        /// The default value depends on the current locale.
        /// If weekNumberCalculation is set to 'ISO', this option defaults to 1 (Monday).
        /// </summary>
        public DayOfWeek FirstDay { get; set; }

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
        /// Exclude certain days-of-the-week from being displayed.
        /// </summary>
        public DayOfWeek[] HiddenDays { get; set; }

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

        /// <summary>
        /// Determines the width-to-height aspect ratio of the calendar.
        /// A calendar is a block-level element that fills its entire avaiable width. The calendar’s height, however, is determined by this ratio of width-to-height. (Hint: larger numbers make smaller heights).
        /// More precisely, this is the aspect ratio of the calendar's "content" area (the area with a className of "fc-view-container").
        /// </summary>
        public double AspectRatio { get; set; }

        /// <summary>
        /// Whether to automatically resize the calendar when the browser window resizes.
        /// If true, the calendar will automatically resize when the window resizes, and the windowResize callback will be called. If false, none of this will happen.
        /// </summary>
        public bool HandleWindowResize { get; set; } = true;

        /// <summary>
        /// Time, in milliseconds, the calendar will wait to adjust its size after a window resize event occurs.
        /// This delay exists in order to prevent overly frequent size adjustments while the user drags and resizes their browser window.
        /// </summary>
        public int WindowResizeDelay { get; set; }

        #endregion

        #region Timezone

        /// <summary>
        /// Explicitly sets the "today" date of the calendar. This is the day that is normally highlighted in yellow.
        /// Normally, the local browser's current date is used.
        /// Overriding the current date is particularly useful when your calendar is using a custom timezone parameter. 
        /// The current year/month/date in the custom timezone might be different than the local computer's current date.
        /// </summary>
        public DateTime Now { get; set; }

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

        #region List View

        /// <summary>
        /// A date formatting string that affects the text on the left side of the day headings in list view.
        /// </summary>
        public string ListDayFormat { get; set; }

        /// <summary>
        /// A date formatting string that affects the text on the right side of the day headings in list view.
        /// </summary>
        public string ListDayAltFormat { get; set; }

        /// <summary>
        /// The text that is displayed in the middle of list view, alerting the user that there are no events within the given range.
        /// </summary>
        public string NoEventsMessage { get; set; }

        #endregion

        #region Current Date

        /// <summary>
        /// The initial date displayed when the calendar first loads.
        /// When not specified, this value defaults to the current date.
        /// </summary>
        public DateTime DefaultDate { get; set; }

        /// <summary>
        /// Whether or not to display a marker indicating the current time.
        /// The indicator will automatically reposition itself while the user is viewing the calendar.
        /// </summary>
        public bool NowIndicator { get; set; }

        #endregion

        #region Text/Time Customization

        /// <summary>
        /// Determines the time-text that will be displayed on each event.
        /// Each view has a specific default. Get fine-tuned control with View-Specific Options. A single string alone will set the value for all views.
        /// The default values will change based on the current locale.
        /// Time-text will only be displayed for Event Objects that have allDay equal to false.
        /// </summary>
        public string TimeFormat { get; set; }

        /// <summary>
        /// Determines the text that will be displayed on the calendar's column headings.
        /// Each view has a specific default. Get fine-tuned control with View-Specific Options. A single string alone will set the value for all views.
        /// The default values will change based on the current locale.
        /// </summary>
        public string ColumnFormat { get; set; }

        /// <summary>
        /// Determines the text that will be displayed in the header's title.
        /// As noted above, each view has a specific default. Get fine-tuned control with View-Specific Options. A single string alone will set the value for all views.
        /// The default values will change based on the current locale.
        /// </summary>
        public string TitleFormat { get; set; }

        /// <summary>
        /// The heading text for week numbers.
        /// This text will go above the week number column in the month/basic views. It will go alongside the week number text in the top-left cell for agenda views.
        /// The default value will change based on the current locale.
        /// </summary>
        public string WeekNumberTitle { get; set; }

        /// <summary>
        /// Whether or not to display the text for an event's time.
        /// This setting only applies to events that have times (allDay equal to false). If set to true, time text will always be displayed on the event. If set to false, time text will never be displayed on the event.
        /// Events that are all-day will never display time text anyhow.
        /// When this setting is not specified, the default that is computed is based off of the current view. For example, time text will be displayed in all month, basic, and agenda views by default, for timeline views, it depends on the duration.
        /// </summary>
        public bool? DisplayEventTime { get; set; }

        /// <summary>
        /// Whether or not to display an event's end time text when it is rendered on the calendar.
        /// Each view has a specific default. Get fine-tuned control with View-Specific Options. A single boolean alone will set the value for all views.
        /// If an event does not have an end date/time, or displayEventTime is false, it won't be displayed anyway, regardless of this setting.
        /// </summary>
        public bool? DisplayEventEnd { get; set; }

        #endregion

        #region Clicking & Hovering

        /// <summary>
        /// Determines if day names and week names are clickable.
        /// When true, day headings and weekNumbers will become clickable. When clicked, these links will bring the user to a view that represents the day/week.
        /// The destination views are automatically determined by the views that are in the header. However, they can be explicity defined using navLinkDayClick and navLinkWeekClick.
        /// </summary>
        public bool NavLinks { get; set; }

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

        /// <summary>
        /// The minimum distance the user's mouse must travel after a mousedown, before a selection is allowed.
        /// The default value of 0 puts no restriction on the distance the mouse must travel.
        /// A non-zero value is useful for differentiating a selection from a dayClick.
        /// This setting is only applicable to mouse-related interaction. For touch interation, see selectLongPressDelay.
        /// </summary>
        public int SelectMinDistance { get; set; }

        /// <summary>
        /// For touch devices, the amount of time the user most hold down before a date becomes selectable.
        /// This value is specified in milliseconds.
        /// nly applicable when the calendar is being used on a touch device. Otherwise, there is no delay.
        /// </summary>
        public int SelectLongPressDelay { get; set; }

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

        /// <summary>
        /// A way to specify multiple event sources.
        /// This option is used instead of the events option.
        /// You can put any number of event arrays, functions, JSON feed URLs, or full-out Event Source Objects into the eventSources array.
        /// </summary>
        public string[] EventSources { get; set; }

        /// <summary>
        /// Determines the default value for each Event Object's allDay property when it is unspecified.
        /// By default, allDayDefault is not set. As a result, any Event Objects that do not specify an allDay property will be subject the guessing behavior mentioned in the Event Object article.
        /// Set this option to true or false to make it affect Event Objects without an allDay property.
        /// </summary>
        public bool? AllDayDefault { get; set; }

        /// <summary>
        /// A parameter of this name will be sent to each JSON event feed. It describes the start of the interval being fetched.
        /// The actual value of this parameter will be an ISO8601 date string.
        /// </summary>
        public string StartParam { get; set; }

        /// <summary>
        /// A parameter of this name will be sent to each JSON event feed. It describes the exclusive end of the interval being fetched.
        /// The actual value of this parameter will be an ISO8601 date string.
        /// </summary>
        public string EndParam { get; set; }

        /// <summary>
        /// Determines when event fetching should occur.
        /// When set to true (the default), the calendar will only fetch events when it absolutely needs to, minimizing AJAX calls. 
        /// For example, say your calendar starts out in month view, in February. FullCalendar will fetch events for the entire month of February and store them in its internal cache. 
        /// Then, say the user switches to week view and begins browsing the weeks in February. The calendar will avoid fetching events because it already has this information stored.
        /// When set to false, the calendar will fetch events any time the view is switched, or any time the current date changes(for example, as a result of the user clicking prev/next).
        /// </summary>
        public bool LazyFetching { get; set; } = true;

        /// <summary>
        /// A fallback duration for timed Event Objects without a specified end value.
        /// If an event does not have an end specified, it will appear to be this duration when rendered.
        /// The actual end of the event will remain unset unless forceEventDuration has been set to true.
        /// This setting only affects events with allDay equal to false. For all-day events, use defaultAllDayEventDuration.
        /// </summary>
        public TimeSpan DefaultTimedEventDuration { get; set; }

        /// <summary>
        /// A fallback duration for all-day Event Objects without a specified end value.
        /// If an event does not have an end specified, it will appear to be this duration when rendered.
        /// The actual end of the event will remain unset unless forceEventDuration has been set to true.
        /// This setting only affects events with allDay equal to true. For timed events, use defaultTimedEventDuration.
        /// </summary>
        public TimeSpan DefaultAllDayEventDuration { get; set; }

        /// <summary>
        /// A flag to force calculation of an event's end if it is unspecified.
        /// If an event's end is not specified, it will be calculated and assigned to the Event Object using defaultTimedEventDuration or defaultAllDayEventDuration.
        /// </summary>
        public bool ForceEventDuration { get; set; }

        #endregion

        #region Event Rendering

        /// <summary>
        /// Sets the background and border colors for all events on the calendar.
        /// This option can be overridden on a per-source basis with the color Event Source Object option or on a per-event basis with the color Event Object option.
        /// </summary>
        public Color EventColor { get; set; }

        /// <summary>
        /// Sets the background color for all events on the calendar.
        /// This option can be overridden on a per-source basis with the backgroundColor Event Source Object option or on a per-event basis with the backgroundColor Event Object option.
        /// </summary>
        public Color EventBackgroundColor { get; set; }

        /// <summary>
        /// Sets the border color for all events on the calendar.
        /// This option can be overridden on a per-source basis with the borderColor Event Source Object option or on a per-event basis with the borderColor Event Object option.
        /// </summary>
        public Color EventBorderColor { get; set; }

        /// <summary>
        /// Sets the text color for all events on the calendar.
        /// This option can be overridden on a per-source basis with the textColor Event Source Object option or on a per-event basis with the textColor Event Object option.
        /// </summary>
        public Color EventTextColor { get; set; }

        /// <summary>
        /// When an event's end time spans into another day, the minimum time it must be in order for it to render as if it were on that day.
        /// Only affects timed events that appear on whole-days. Whole-day cells occur in month view, basicDay, basicWeek and the all-day slots in the agenda views.
        /// </summary>
        public TimeSpan NextDayThreshold { get; set; }

        /// <summary>
        /// The amount of milliseconds to wait after an operation, before rendering events.
        /// When this value is specified as a millisecond number value, the calendar will begin to wait after any operation that might result in an event rerendering, such as renderEvent and updateEvent. After this time has passed, the calendar will render all events together. This reduces the number of rerenders, for performance reasons.
        /// This setting is experimental. It is turned off by default.
        /// </summary>
        public int? EventRenderWait { get; set; }

        #endregion

        #region Event Dragging & Resizing

        /// <summary>
        /// Determines whether the events on the calendar can be modified.
        /// This determines if the events can be dragged and resized. Enables/disables both at the same time. 
        /// If you don't want both, use the more specific eventStartEditable and eventDurationEditable instead.
        /// This option can be overridden on a per-event basis with the Event Object editable property.
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// Allow events' start times to be editable through dragging.
        /// This option can be overridden on a per-source basis with the startEditable Event Source Object option or on a per-event basis with the startEditable Event Object option.
        /// </summary>
        public bool EventStartEditable { get; set; } = true;

        /// <summary>
        /// Allow events' durations to be editable through resizing.
        /// This option can be overridden on a per-source basis with the durationEditable Event Source Object option or on a per-event basis with the durationEditable Event Object option.
        /// </summary>
        public bool EventDurationEditable { get; set; } = true;

        /// <summary>
        /// Time it takes for an event to revert to its original position after an unsuccessful drag.
        /// Time is in milliseconds (1 second = 1000 milliseconds).
        /// </summary>
        public int DragRevertDuration { get; set; }

        /// <summary>
        /// The opacity of an event while it is being dragged.
        /// Float values range from 0.0 to 1.0.
        /// </summary>
        public float DragOpacity { get; set; } = .75F;

        /// <summary>
        /// Whether to automatically move scroll containers during event drag-and-drop or while selecting.
        /// If enabled, the scroll container will automatically scroll once the mouse gets close to the edge.
        /// </summary>
        public bool DragScroll { get; set; } = true;

        /// <summary>
        /// For touch devices, the amount of time the user most hold down before an event becomes draggable or a date becomes selectable.
        /// This value is specified in milliseconds.
        /// Only applicable when the calendar is being used on a touch device. Otherwise, there is no delay.
        /// This setting controls event dragging and date selecting. For further granularity, please see the following settings: eventLongPressDelay, selectLongPressDelay
        /// </summary>
        public int LongPressDelay { get; set; }

        /// <summary>
        /// For touch devices, the amount of time the user most hold down before an event becomes draggable.
        /// This value is specified in milliseconds.
        /// Only applicable when the calendar is being used on a touch device. Otherwise, there is no delay.
        /// </summary>
        public int EventLongPressDelay { get; set; }

        #endregion

        #region Dropping External Elements

        /// <summary>
        /// Determines if jQuery UI draggables can be dropped onto the calendar.
        /// This option operates with jQuery UI draggables. You must download the appropriate jQuery UI files and initialize a draggable element. Additionally, you must set the calendar's droppable option to true.
        /// When there is no event data associated with the drag, the areas where the drop is allowed are determined by selectOverlap and selectConstraint.
        /// When there is event data associated with the drag(see eventReceive), normal event overlap/constraint rules apply, such as eventOverlap and eventConstraint.
        /// </summary>
        public bool Droppable { get; set; }

        #endregion

        /// <summary>
        /// Client-side events for the callback functions in the API
        /// </summary>
        public ClientSideEvents ClientSideEvents { get; set; } = new ClientSideEvents();
    }
}
