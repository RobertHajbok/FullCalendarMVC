using FullCalendar.Interfaces;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ArrayPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public ArrayPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null)
                dictionary.Add("data-fc-" + _property.Name, new JavaScriptSerializer().Serialize(value).ToSingleQuotes());
        }
    }
}
