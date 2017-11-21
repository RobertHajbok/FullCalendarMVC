### What is FullCalendarMVC?
FullCalendarMVC is a HTML helper for [FullCalendar](https://github.com/fullcalendar/fullcalendar). Current supported version is 3.5.1.

### Where can I get it?
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [FullCalendar.MVC5](https://www.nuget.org/packages/FullCalendar.MVC5/) from the package manager console:

```
PM> Install-Package FullCalendar.MVC5
```

or [FullCalendar.MVC4](https://www.nuget.org/packages/FullCalendar.MVC4/) if you are using MVC 4:

```
PM> Install-Package FullCalendar.MVC4
```

### How to use it?
- Reference the script and CSS files in your Bundle.config:

``` csharp
public static void RegisterBundles(BundleCollection bundles)
{
    bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
        "~/Scripts/jquery-{version}.js",
        "~/Scripts/moment.js",
        "~/Scripts/fullcalendar*"));

    bundles.Add(new StyleBundle("~/bundles/styles").Include(
        "~/Content/fullcalendar.css"));
}
```

or in the view (Shared/_Layout.cshtml for example):

``` html
<script src="~/Scripts/jquery-3.2.1.min.js"></script>
<script src="~/Scripts/moment.min.js"></script>
<script src="~/Scripts/fullcalendar.min.js"></script>
<script src="~/Scripts/fullcalendar.helper.min.js"></script>
<link href="~/Content/fullcalendar.min.css" rel="stylesheet" />
```

- Create an Action in your Controller to get the data:
``` csharp
public JsonResult GetDiaryEvents(DateTime start, DateTime end)
{
    return Json(LoadAllAppointmentsInDateRange(start, end).Select(x => new
    {
        id = x.ID,
        title = x.Title,
        start = x.StartDateString,
        end = x.EndDateString,
        color = x.StatusColor,
        className = x.ClassName,
        someKey = x.SomeImportantKeyID,
        allDay = false
    }).ToArray(), JsonRequestBehavior.AllowGet);
}
```

- Use the HTML helper in your view, like below (notice the Events property referencing the Action above):
``` csharp
@Html.FullCalendar(settings =>
{
    settings.Name = "calendar";
    settings.CssClass = "css-test";
    settings.Header = new Header
    {
        Left = new ControlsBuilder().AddButton(HeaderButton.Prev).AddSeparator(HeaderSeparator.Adjacent)
                    .AddButton(HeaderButton.Next).AddSeparator(HeaderSeparator.Gap).AddButton(HeaderButton.Today),
        Center = new ControlsBuilder().AddTitle(),
        Right = new ControlsBuilder("month,agendaWeek ").AddView(CalendarView.AgendaDay)
    };
    settings.DefaultView = CalendarView.AgendaDay;
    settings.Editable = true;
    settings.AllDaySlot = false;
    settings.Selectable = true;
    settings.SlotDuration = TimeSpan.FromMinutes(15);
    settings.Events = Url.Action("GetDiaryEvents", "Home");
})
```

- The calendar should be rendered. Check the options below to see if the option you want to use is supported by the HTML helper. For details about these, check the [full documentation](https://fullcalendar.io/docs/) on the FullCalendar website, or play with some settings in the [FullCalendar.UI](https://github.com/HajbokRobert/FullCalendarMVC/tree/master/FullCalendarMVC/FullCalendar.UI) project of the source code. Also, [this](https://www.codeproject.com/Articles/638674/Full-calendar-A-complete-web-diary-system-for-jQue#_articleTop) CodeProject article might help you understand how the jQuery plugin is linked to ASP.NET MVC.

### What are the available options?
| Option                        | Comment                                                                        | Status                                                                       |
|-------------------------------|--------------------------------------------------------------------------------|------------------------------------------------------------------------------|
| header                        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| footer                        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| customButtons                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| buttonIcons                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| themeSystem                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| themeButtonIcons              |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| bootstrapGlyphicons           |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| firstDay                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| isRTL                         |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| weekends                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| hiddenDays                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| fixedWeekCount                |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| weekNumbers                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| weekNumbersWithinDays         |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| weekNumberCalculation         |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| businessHours                 | Null is the default instead of false, empty list is used instead of true value | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| showNonCurrentDates           |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| height                        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| contentHeight                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| aspectRatio                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| handleWindowResize            |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| windowResizeDelay             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventLimit                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventLimitClick               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| viewRender (callback)         |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| viewDestroy (callback)        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dayRender (callback)          |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| windowResize (callback)       |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| render (method)               | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| destroy (method)              | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   | 
| timezone                      | Null is the default value instead of false                                     | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| now                           | Function is not needed, as server-side is supported by MVC                     | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| Available Views               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| Custom Views                  |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| Generic Views                 |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| View-Specific Options         |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| View Object                   |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| defaultView                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| getView (method)              | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| changeView (method)           | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| allDaySlot                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| allDayText                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| slotDuration                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| slotLabelFormat               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| slotLabelInterval             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| snapDuration                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| scrollTime                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| minTime                       |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| maxTime                       |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| slotEventOverlap              |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| What is List View?            |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| listDayFormat                 | Using empty string for the false value (no text displayed)                     | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| listDayAltFormat              | Using empty string for the false value (no text displayed)                     | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| noEventsMessage               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| defaultDate                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| nowIndicator                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| visibleRange                  |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| validRange                    |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| dateIncrement                 |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| dateAlignment                 |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| duration                      |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| dayCount                      |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| prev (method)                 | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| next (method)                 | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| prevYear (method)             | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| nextYear (method)             | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| today (method)                | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| gotoDate (method)             | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| incrementDate (method)        | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| getDate (method)              | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| locale                        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| timeFormat                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| columnFormat                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| titleFormat                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| buttonText                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| monthNames                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| monthNamesShort               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dayNames                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dayNamesShort                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| weekNumberTitle               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| displayEventTime              |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| displayEventEnd               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventLimitText                |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dayPopoverFormat              |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| navLinks                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| navLinkDayClick (callback)    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| navLinkWeekClick (callback)   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dayClick (callback)           |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventClick (callback)         |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventMouseover (callback)     |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventMouseout (callback)      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| Touch Support                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| selectable                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| selectHelper                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| unselectAuto                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| unselectCancel                |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| selectOverlap                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| selectConstraint              |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| selectAllow                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| selectMinDistance             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| selectLongPressDelay          |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| select (callback)             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| unselect (callback)           |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| select (method)               | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| unselect (method)             | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| Moment                        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| Duration                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| date formatting string        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| formatRange (function)        | This function attached to fullCalendar object just returns a string, no need for support                                                                               | ![#0073e5](https://placehold.it/13/0073e5/000000?text=+) not needed       |
| get / set options dynamically | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| on / off                      | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| Event Object                  |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| Event Source Object           |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| events (as an array)          |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| events (as a json feed)       |  Extended Form is not supported yet                                            | ![#ffd700](https://placehold.it/13/ffd700/000000?text=+) partially supported |
| events (as a function)        |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| eventSources                  |  Only JSON feed URL version is supported for now                               | ![#ffd700](https://placehold.it/13/ffd700/000000?text=+) partially supported |
| allDayDefault                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| startParam                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| endParam                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| timezoneParam                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| lazyFetching                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| defaultTimedEventDuration     |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| defaultAllDayEventDuration    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| forceEventDuration            |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventDataTransform (callback) |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| loading (callback)            |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| updateEvent (method)          | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| updateEvents (method)         | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| clientEvents (method)         | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| removeEvents (method)         | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| refetchEvents (method)        | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| refetchEventSources (method)  | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| addEventSource (method)       | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| removeEventSource (method)    | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| removeEventSources (method)   | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| getEventSources (method)      | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| getEventSourceById (method)   | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------       | ------------------------------------------------------                         | --------------------                                                   |
| Colors                        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| Background Events             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventColor                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventBackgroundColor          |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventBorderColor              |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventTextColor                |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| nextDayThreshold              |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventOrder                    |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| eventRenderWait               |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventRender (callback)        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventAfterRender (callback)   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventAfterAllRender (callback) |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventDestroy (callback)        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| renderEvent (method)           | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| renderEvents (method)          | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| rerenderEvent (method)         | Added Name and CssClass properties to enable selectors client-side             | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------        | ------------------------------------------------------                         | -------------------                                                   |
| Requirements                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| Touch Support                  |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| editable                       |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventStartEditable             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventDurationEditable          |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dragRevertDuration             |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dragOpacity                    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dragScroll                     |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventOverlap                   |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventConstraint                |                                                                                | ![#f03c15](https://placehold.it/13/f03c15/000000?text=+) not supported       |
| eventAllow                     |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| longPressDelay                 |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventLongPressDelay            |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventDragStart (callback)      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventDragStop (callback)       |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventDrop (callback)           |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventResizeStart (callback)    |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventResizeStop (callback)     |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventResize (callback)         |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| -----------------------        | ------------------------------------------------------                         | -------------------                                                   |
| droppable                      |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| dropAccept                     |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| drop (callback)                |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |
| eventReceive (callback)        |                                                                                | ![#008000](https://placehold.it/13/008000/000000?text=+) supported           |

### Do you have an issue?
Have a bug or a feature request? Please search for existing and closed issues before submitting a new one. If your problem or idea is not addressed yet, please open a new issue. Contributions are welcome!

### License, etc.
FullCalendarMVC is Copyright © 2017 Hajbok Robert under the [MIT](http://opensource.org/licenses/MIT) license.
