using FullCalendar.Interfaces;
using FullCalendar.Serialization;
using FullCalendar.Serialization.SerializableObjects;
using System;
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
            if (value == null)
                return;

            IEnumerable<BusinessHour> businessHours = (IEnumerable<BusinessHour>)value;
            if (!businessHours.Any())
            {
                dictionary.Add("data-fc-" + _property.Name, bool.TrueString.ToLower());
                return;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });

            dictionary.Add("data-fc-" + _property.Name, serializer.Serialize(businessHours.Select(x => new SerializableBusinessHour
            {
                dow = x.Dow,
                start = x.Start != null && x.Start != default(TimeSpan) ? x.Start.ToString(@"hh\:mm") : null,
                end = x.End != null && x.End != default(TimeSpan) ? x.End.ToString(@"hh\:mm") : null
            })).ToSingleQuotes());
        }
    }
}
