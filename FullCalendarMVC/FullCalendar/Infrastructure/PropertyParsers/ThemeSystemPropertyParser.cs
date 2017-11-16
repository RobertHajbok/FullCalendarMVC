using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ThemeSystemPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public ThemeSystemPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            ThemeSystem value = (ThemeSystem)_property.GetValue(fullCalendarParameters, null);
            dictionary.Add("data-fc-" + _property.Name, value != ThemeSystem.JqueryUI ? value.ToString().FirstCharToLower() : "jquery-ui");
        }
    }
}
