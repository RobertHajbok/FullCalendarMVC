using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class DoublePropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public DoublePropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null && (double)value != default(double))
                dictionary.Add("data-fc-" + _property.Name, value.ToString());
        }
    }
}
