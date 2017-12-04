using FullCalendar.Interfaces;
using FullCalendar.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class EventCollectionPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;
        private JavaScriptSerializer _serializer;

        public EventCollectionPropertyParser(PropertyInfo property, JavaScriptSerializer serializer)
        {
            _property = property;
            _serializer = serializer;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            EventCollection eventCollection = (EventCollection)value;
            switch (eventCollection.Type)
            {
                case EventCollectionType.Array:
                    if (eventCollection.Events == null || !eventCollection.Events.Any())
                        return;

                    dictionary.Add("data-fc-" + _property.Name, _serializer.Serialize(eventCollection.SerializableEventArray()).ToSingleQuotes());
                    break;
                case EventCollectionType.JsonFeed:
                    dictionary.Add("data-fc-" + _property.Name, eventCollection.Url);
                    break;
                case EventCollectionType.Function:
                    dictionary.Add("data-fc-" + _property.Name, eventCollection.Function);
                    break;
                case EventCollectionType.GoogleCalendarFeed:
                    dictionary.Add("data-fc-" + _property.Name, _serializer.Serialize(new { googleCalendarId = eventCollection.GoogleCalendarId }).ToSingleQuotes());
                    break;
            }
        }
    }
}
