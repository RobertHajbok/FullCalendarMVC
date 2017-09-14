using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class DayOfWeekPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public DayOfWeekPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            dictionary.Add("data-fc-" + _property.Name, ((int)_property.GetValue(fullCalendarParameters, null)).ToString());
        }
    }
}
