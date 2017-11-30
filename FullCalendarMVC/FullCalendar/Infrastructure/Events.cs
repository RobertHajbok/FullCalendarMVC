using System.Collections.Generic;

namespace FullCalendar
{
    public static class Events
    {
        /// <summary>
        /// A URL of a JSON feed that the calendar will fetch Event Objects from. 
        /// FullCalendar will visit the URL whenever it needs new event data. This happens when the user clicks prev/next or changes views.
        /// FullCalendar will determine the date-range it needs events for and will pass that information along in GET parameters.
        /// The GET parameter names will be determined by the startParam and endParam options. ("start" and "end" by default).
        /// The values of these parameters will be ISO8601 date strings(like 2013-12-01). For precise behavior, see the timezone docs. 
        /// </summary>
        /// <param name="url">A URL of a JSON feed that the calendar will fetch Event Objects from</param>
        /// <returns>An <see cref="EventCollection"/> object</returns>
        public static EventCollection AsJsonFeed(string url)
        {
            return new EventCollection(url, EventCollectionType.JsonFeed);
        }

        /// <summary>
        /// An array of Event Objects that will be displayed on the calendar.
        /// </summary>
        /// <param name="events">A <see cref="List{Event}"/> that will be displayed on the calendar.</param>
        /// <returns></returns>
        public static EventCollection AsArray(IEnumerable<Event> events)
        {
            return new EventCollection(events);
        }

        /// <summary>
        /// A custom function for programmatically generating Event Objects.
        /// FullCalendar will call this function whenever it needs new event data. This is triggered when the user clicks prev/next or switches views.
        /// This function will be given start and end parameters, which are Moments denoting the range the calendar needs events for.
        /// timezone is a string/boolean describing the calendar's current timezone. It is the exact value of the timezone option.
        /// It will also be given callback, a function that must be called when the custom event function has generated its events. It is the event function's responsibility to make sure callback is being called with an array of Event Objects.
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public static EventCollection AsFunction(string function)
        {
            return new EventCollection(function, EventCollectionType.Function);
        }

        public static EventCollection AsGoogleCalendarFeed(string googleCalendarId)
        {
            return new EventCollection(googleCalendarId, EventCollectionType.GoogleCalendarFeed);
        }
    }
}
