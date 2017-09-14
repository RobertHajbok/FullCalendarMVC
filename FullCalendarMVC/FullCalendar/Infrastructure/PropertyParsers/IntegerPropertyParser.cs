using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class IntegerPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public IntegerPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null && (int)value != default(int))
                dictionary.Add("data-fc-" + _property.Name, value.ToString());
        }
    }
}
