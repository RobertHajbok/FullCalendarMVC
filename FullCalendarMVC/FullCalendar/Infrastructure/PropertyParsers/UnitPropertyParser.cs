using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class UnitPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public UnitPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            Unit unit = (Unit)value;
            if (unit.Type == UnitType.Pixel)
                dictionary.Add("data-fc-" + _property.Name, unit.Value + "px");
            else if (unit.Type == UnitType.Function)
                dictionary.Add("data-fc-" + _property.Name, unit.Value);
            else
                dictionary.Add("data-fc-" + _property.Name, unit.Type.ToString().FirstCharToLower());
        }
    }
}
