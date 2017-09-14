using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class StringPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public StringPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
                dictionary.Add("data-fc-" + _property.Name, value.ToString());
        }
    }
}
