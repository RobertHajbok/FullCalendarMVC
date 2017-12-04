using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ObjectPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;
        private JavaScriptSerializer _serializer;

        public ObjectPropertyParser(PropertyInfo property, JavaScriptSerializer serializer)
        {
            _property = property;
            _serializer = serializer;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null)
                dictionary.Add("data-fc-" + _property.Name, !(value is ISerializableObject) ? value.ToString() :
                    _serializer.Serialize(((ISerializableObject)value).AsSerializableObject()).ToSingleQuotes());
        }
    }
}
