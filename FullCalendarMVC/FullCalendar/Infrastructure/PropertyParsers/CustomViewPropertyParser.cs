using FullCalendar.Interfaces;
using FullCalendar.Serialization;
using FullCalendar.Serialization.SerializableObjects;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class CustomViewPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public CustomViewPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            Dictionary<string, View> views = (Dictionary<string, View>)value;
            if (views.Count == 0)
                return;

            Dictionary<string, object> serializedData = new Dictionary<string, object>();
            foreach (var view in views)
            {
                object data = new SerializableView
                {
                    type = view.Value.Type,
                    buttonText = view.Value.ButtonText,
                    titleFormat = view.Value.TitleFormat,
                    visibleRange = view.Value.VisibleRange == null ? null : (view.Value.VisibleRange.Function != null ? (object)view.Value.VisibleRange.Function : new
                    {
                        start = view.Value.VisibleRange.Start.ToString("yyyy-MM-dd"),
                        end = view.Value.VisibleRange.End.ToString("yyyy-MM-dd")
                    }),
                    dateIncrement = view.Value.DateIncrement == null ? null : new SerializableDuration
                    {
                        days = view.Value.DateIncrement.Days,
                        months = view.Value.DateIncrement.Months,
                        weeks = view.Value.DateIncrement.Weeks
                    },
                    dateAlignment = view.Value.DateAlignment?.ToString().FirstCharToLower(),
                    duration = view.Value.Duration == null ? null : new SerializableDuration
                    {
                        days = view.Value.Duration.Days,
                        months = view.Value.Duration.Months,
                        weeks = view.Value.Duration.Weeks
                    },
                    dayCount = view.Value.DayCount
                };
                serializedData.Add(view.Key, data);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
            dictionary.Add("data-fc-" + _property.Name, serializer.Serialize(serializedData).ToSingleQuotes());
        }
    }
}
