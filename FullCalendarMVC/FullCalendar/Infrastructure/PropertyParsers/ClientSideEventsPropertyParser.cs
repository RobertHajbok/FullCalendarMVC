using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ClientSideEventsPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;
        private JavaScriptSerializer _serializer;

        public ClientSideEventsPropertyParser(PropertyInfo property, JavaScriptSerializer serializer)
        {
            _property = property;
            _serializer = serializer;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            foreach (var property in typeof(ClientSideEvents).GetProperties())
            {
                object callbackValue = property.GetValue(fullCalendarParameters.ClientSideEvents, null);
                if (!string.IsNullOrEmpty(callbackValue?.ToString()))
                {
                    object jsonString = new
                    {
                        function = callbackValue
                    };

                    dictionary.Add("data-fc-" + property.Name, _serializer.Serialize(jsonString).ToSingleQuotes());
                }
            }
        }
    }
}
