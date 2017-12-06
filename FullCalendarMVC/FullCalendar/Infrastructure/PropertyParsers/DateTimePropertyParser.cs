using FullCalendar.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class DateTimePropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public DateTimePropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if ((DateTime)value != default(DateTime))
                dictionary.Add("data-fc-" + _property.Name, ((DateTime)value).ToString("MM/dd/yyyy hh:mm:ss"));
        }
    }
}
