using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ButtonIconsPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;
        private JavaScriptSerializer _serializer;

        public ButtonIconsPropertyParser(PropertyInfo property, JavaScriptSerializer serializer)
        {
            _serializer = serializer;
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            dictionary.Add("data-fc-" + _property.Name, _serializer.Serialize(value).ToSingleQuotes());
        }
    }
}
