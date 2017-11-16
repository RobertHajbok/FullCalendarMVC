using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class ButtonIconsParser : IPropertyParser
    {
        private PropertyInfo _property;

        public ButtonIconsParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            dictionary.Add("data-fc-" + _property.Name, new JavaScriptSerializer().Serialize(value).ToSingleQuotes());
        }
    }
}
