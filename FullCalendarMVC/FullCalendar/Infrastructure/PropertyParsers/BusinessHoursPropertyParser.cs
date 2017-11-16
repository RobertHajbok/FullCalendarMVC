using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class BusinessHoursPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public BusinessHoursPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value != null)
            {
                IEnumerable<BusinessHour> businessHours = (IEnumerable<BusinessHour>)value;
                if (businessHours.Any())
                    dictionary.Add("data-fc-" + _property.Name, new JavaScriptSerializer().Serialize(businessHours.Select(x => new
                    {
                        dow = x.Dow,
                        start = x.Start.ToString(@"hh\:mm"),
                        end = x.End.ToString(@"hh\:mm")
                    })).ToSingleQuotes());
                else
                    dictionary.Add("data-fc-" + _property.Name, bool.TrueString.ToLower());
            }
        }
    }
}
