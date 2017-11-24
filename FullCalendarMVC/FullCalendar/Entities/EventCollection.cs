using System.Collections.Generic;

namespace FullCalendar
{
    public class EventCollection
    {
        public string Url { get; private set; }

        public IEnumerable<Event> Events { get; private set; }

        public string Function { get; private set; }

        public EventCollectionType Type { get; private set; }

        public EventCollection(string str, bool isFunction)
        {
            if (isFunction)
            {
                Url = str;
                Type = EventCollectionType.JsonFeed;
            }
            else
            {
                Function = str;
                Type = EventCollectionType.Function;
            }
        }

        public EventCollection(IEnumerable<Event> events)
        {
            Events = events;
            Type = EventCollectionType.Array;
        }
    }
}
