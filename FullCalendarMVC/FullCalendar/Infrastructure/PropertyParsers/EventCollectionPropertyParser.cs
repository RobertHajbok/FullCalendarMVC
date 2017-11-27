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

        public EventCollectionPropertyParser(PropertyInfo property)
        {
            _property = property;
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

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });

                    dictionary.Add("data-fc-" + _property.Name, serializer.Serialize(eventCollection.SerializableEventArray()).ToSingleQuotes());
                    break;
                case EventCollectionType.JsonFeed:
                    dictionary.Add("data-fc-" + _property.Name, eventCollection.Url);
                    break;
                case EventCollectionType.Function:
                    dictionary.Add("data-fc-" + _property.Name, eventCollection.Function);
                    break;
            }
        }
    }
}
