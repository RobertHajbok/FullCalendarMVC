using FullCalendar.Interfaces;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ArrayPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;
        private JavaScriptSerializer _serializer;

        public ArrayPropertyParser(PropertyInfo property, JavaScriptSerializer serializer)
        {
            _property = property;
            _serializer = serializer;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null)
                dictionary.Add("data-fc-" + _property.Name, _serializer.Serialize(value).ToSingleQuotes());
        }
    }
}
