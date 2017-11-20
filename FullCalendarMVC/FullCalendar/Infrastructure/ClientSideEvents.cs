namespace FullCalendar
{
    public class ClientSideEvents
    {
        #region General Display

        /// <summary>
        /// Triggered when a new date-range is rendered, or when the view type switches.
        /// This callback will get triggered when the user changes the view, or when any of the date navigation methods are called.
        /// This callback will trigger after the view has been fully rendered, but before events have been rendered (see also: eventAfterAllRender).
        /// </summary>
        public string ViewRender { get; set; }

        /// <summary>
        /// Triggered when a rendered date-range needs to be torn down.
        /// This callback will be triggered immediately before the view is about to be removed from the DOM. This could happen because of a view type switch, a date range change, or a destroy method call.
        /// </summary>
        public string ViewDestroy { get; set; }

        /// <summary>
        /// A hook for modifying a day cell.
        /// This callback lets you modify day cells that are part of the month, basicWeek, and basicDay views. See Available Views.
        /// This callback is called each time a cell needs to be freshly rendered.
        /// </summary>
        public string DayRender { get; set; }

        /// <summary>
        /// Triggered after the calendar's dimensions have been changed due to the browser window being resized.
        /// The calendar has automatically adapted to the new size when windowResize is triggered.
        /// </summary>
        public string WindowResize { get; set; }

        #endregion

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
        /// </summary>
        public string DayClick { get; set; }

        /// <summary>
        /// Triggered when the user clicks an event.
        /// </summary>
        public string EventClick { get; set; }

        /// <summary>
        /// Triggered when the user mouses over an event.
        /// </summary>
        public string EventMouseover { get; set; }

        /// <summary>
        /// Triggered when the user mouses out of an event.
        /// </summary>
        public string EventMouseout { get; set; }

        #endregion

        #region Selection

        /// <summary>
        /// Exact programmatic control over where the user can select.
        /// This callback will be called for every new potential selection as the user is dragging.
        /// The callback function will receive information about where the user is attempting to select (selectInfo) and must return either true or false.
        /// </summary>
        public string SelectAllow { get; set; }

        /// <summary>
        /// A callback that will fire after a selection is made.
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// A callback that will fire when the current selection is cleared.
        /// A selection might be cleared for a number of reasons:
        /// 1. The user clicks away from the current selection(doesn't happen when unselectAuto is false).
        /// 2. The user makes a new selection.The unselect callback will be fired before the new selection occurs.
        /// 3. The user moves forward or backward in the current view, or switches to a new view.
        /// 4. The unselect method is called through the API.
        /// </summary>
        public string Unselect { get; set; }

        #endregion

        #region Event Data

        /// <summary>
        /// Transforms custom data into a standard Event Object.
        /// This hook allows you to receive arbitrary event data from a JSON feed or any other Event Source and transform it into the type of data FullCalendar accepts. This let's you easily accept alternative data formats without having to write a completely custom events function.
        /// This function is called once per received event. eventData is the event data that has been receieved.The function must return a new object in the Event Object format.
        /// </summary>
        public string EventDataTransform { get; set; }

        /// <summary>
        /// Triggered when event fetching starts/stops.
        /// Triggered with a true argument when the calendar begins fetching events via AJAX. Triggered with false when done.
        /// This function is often used to show/hide a loading indicator.
        /// </summary>
        public string Loading { get; set; }

        #endregion

        #region Event Rendering

        /// <summary>
        /// Triggered while an event is being rendered.
        /// The eventRender callback function can modify element. For example, it can change its appearance via jQuery's .css().
        /// The function can also return a brand new element that will be used for rendering instead. For all-day background events, you must be sure to return a <td>.
        /// The function can also return false to completely cancel the rendering of the event.
        /// eventRender is a great way to attach other jQuery plugins to event elements, such as a qTip tooltip effect.
        /// </summary>
        public string EventRender { get; set; }

        /// <summary>
        /// Triggered after an event has been placed on the calendar in its final position.
        /// </summary>
        public string EventAfterRender { get; set; }

        /// <summary>
        /// Triggered after all events have finished rendering.
        /// </summary>
        public string EventAfterAllRender { get; set; }

        /// <summary>
        /// Called before an event's element is removed from the DOM.
        /// This callback gets called once for every event element. It is a great way to tear down any plugins you might have applied in eventRender.
        /// </summary>
        public string EventDestroy { get; set; }

        #endregion

        #region Event Dragging & Resizing

        /// <summary>
        /// Exact programmatic control over where an event can be dropped.
        /// After it has been determined that the eventOverlap and eventConstraint settings will allow the user to drop an event at a given position on the calendar, the eventAllow callback will be called. It will be called for every new potential droppable position as the user is dragging.
        /// If specified, it must return either true or false as to whether the calendar will allow the given event (draggedEvent) to be dropped at the given location (dropInfo).
        /// </summary>
        public string EventAllow { get; set; }

        /// <summary>
        /// Triggered when event dragging begins.
        /// </summary>
        public string EventDragStart { get; set; }

        /// <summary>
        /// Triggered when event dragging stops.
        /// This callback is guaranteed to be triggered after the user drags an event, even if the event doesn't change date/time. It is triggered before the event's information has been modified (if moved to a new date/time) and before the eventDrop callback is triggered.
        /// </summary>
        public string EventDragStop { get; set; }

        /// <summary>
        /// Triggered when dragging stops and the event has moved to a different day/time.
        /// eventDrop does not get called when an external event lands on the calendar. eventReceive is called instead.
        /// </summary>
        public string EventDrop { get; set; }

        /// <summary>
        /// Triggered when event resizing begins.
        /// </summary>
        public string EventResizeStart { get; set; }

        /// <summary>
        /// Triggered when event resizing stops.
        /// This callback is guaranteed to be triggered after the user resizes an event, even if the event doesn't change in duration. It is triggered before the event's information has been modified (if changed in duration) and before the eventResize callback is triggered.
        /// </summary>
        public string EventResizeStop { get; set; }

        /// <summary>
        /// Triggered when resizing stops and the event has changed in duration.
        /// </summary>
        public string EventResize { get; set; }

        #endregion

        #region Dropping External Elements

        /// <summary>
        /// Called when a valid jQuery UI draggable has been dropped onto the calendar.
        /// </summary>
        public string Drop { get; set; }

        /// <summary>
        /// Called when an external element, containing event data, is dropped on the calendar.
        /// This function is triggered after the drop callback has been called and after the new event has already been rendered on the calendar. event is the Event Object associated with the dropped element.
        /// The droppable setting must be activated and the necessary jQuery UI requirements must be fulfilled.
        /// The eventDrop callback does not get called when an external event is dragged onto the calendar.
        /// When there is event data associated with the drag, normal event overlap/constraint rules apply, such as eventOverlap and eventConstraint.
        /// </summary>
        public string EventReceive { get; set; }

        #endregion
    }
}
