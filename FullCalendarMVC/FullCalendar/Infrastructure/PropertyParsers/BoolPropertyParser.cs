using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class BoolPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public BoolPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            dictionary.Add("data-fc-" + _property.Name, _property.GetValue(fullCalendarParameters, null).ToString().FirstCharToLower());
        }
    }
}
