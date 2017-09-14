using FullCalendar.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class TimeSpanPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public TimeSpanPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null && (TimeSpan)value != default(TimeSpan))
                dictionary.Add("data-fc-" + _property.Name, ((TimeSpan)value).TotalMilliseconds.ToString());
        }
    }
}
