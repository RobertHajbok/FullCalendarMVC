using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class FunctionPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public FunctionPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null)
            {
                object jsonString = new
                {
                    function = value
                };
                dictionary.Add("data-fc-" + _property.Name, new JavaScriptSerializer().Serialize(jsonString).ToSingleQuotes());
            }
        }
    }
}