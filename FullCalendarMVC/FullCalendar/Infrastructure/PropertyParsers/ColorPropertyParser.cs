using FullCalendar.Interfaces;
using FullCalendar.Extensions;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ColorPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public ColorPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if ((Color)value != default(Color))
                dictionary.Add("data-fc-" + _property.Name, ((Color)value).ToHexString());
        }
    }
}
