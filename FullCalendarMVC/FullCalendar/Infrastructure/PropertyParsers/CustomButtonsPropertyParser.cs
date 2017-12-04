using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class CustomButtonsPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;
        private JavaScriptSerializer _serializer;

        public CustomButtonsPropertyParser(PropertyInfo property, JavaScriptSerializer serializer)
        {
            _property = property;
            _serializer = serializer;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            Dictionary<string, object> serializedData = new Dictionary<string, object>();
            foreach(var button in (Dictionary<string, CustomButton>)value)
            {
                object data = new
                {
                    text = button.Value.Text,
                    click = button.Value.Click,
                    icon = button.Value.Icon,
                    themeIcon = button.Value.ThemeIcon,
                    bootstrapGlyphicon = button.Value.BootstrapGlyphicon
                };
                serializedData.Add(button.Key, data);
            }

            dictionary.Add("data-fc-" + _property.Name, _serializer.Serialize(serializedData).ToSingleQuotes());
        }
    }
}
