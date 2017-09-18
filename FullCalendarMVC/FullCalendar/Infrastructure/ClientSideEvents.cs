namespace FullCalendar
{
    public class ClientSideEvents
    {
        #region Clicking & Hovering

        /// <summary>
        /// Determines what happens upon a day heading nav-link click.
        /// By default, the user is taken to the a the first day-view that appears in the header.
        /// A function argument can be provided that executes arbitrary code:
        /// When a custom function is specified, the user will not automatically navigate to any view.
        /// When navLinkDayClick fires, the dayClick callback will NOT be fired.
        /// </summary>
        public string NavLinkDayClick { get; set; }

        /// <summary>
        /// Determines what happens upon a week-number nav-link click.
        /// By default, the user is taken to the a the first week-view that appears in the header.
        /// A function argument can be provided that executes arbitrary code.
        /// When a custom function is specified, the user will not automatically navigate to any view.
        /// </summary>
        public string NavLinkWeekClick { get; set; }

        /// <summary>
        /// Triggered when the user clicks on a day.
        /// date holds a Moment for the clicked day. If an all-day area has been clicked, the moment will be ambiguously-timed. If a slot in the agendaWeek or agendaDay views has been clicked, date will have the slot's time.
        /// jsEvent holds the native JavaScript event with low-level information such as click coordinates.
        /// view is set to the current View Object.
        /// Within the callback function, this is set to the <td> of the clicked day.
        /// </summary>
        public string DayClick { get; set; }

        /// <summary>
        /// Triggered when the user clicks an event.
        /// event is an Event Object that holds the event's information (date, title, etc).
        /// jsEvent holds the native JavaScript event with low-level information such as click coordinates.
        /// view holds the current View Object.
        /// Within the callback function, this is set to the event's <div> element.
        /// </summary>
        public string EventClick { get; set; }

        /// <summary>
        /// Triggered when the user mouses over an event.
        /// event is an Event Object that holds the event's information (date, title, etc).
        /// jsEvent holds the native JavaScript event with low-level information such as mouse coordinates.
        /// view holds the current View Object.
        /// Within the callback function, this is set to the event's <div> element.
        /// eventMouseover will not be triggered for background events.
        /// </summary>
        public string EventMouseover { get; set; }

        /// <summary>
        /// Triggered when the user mouses out of an event.
        /// event is an Event Object that holds the event's information (date, title, etc).
        /// jsEvent holds the native JavaScript event with low-level information such as mouse coordinates.
        /// view holds the current View Object.
        /// Within the callback function, this is set to the event's <div> element.
        /// eventMouseout will not be triggered for background events.
        /// </summary>
        public string EventMouseout { get; set; }

        #endregion
    }
}
