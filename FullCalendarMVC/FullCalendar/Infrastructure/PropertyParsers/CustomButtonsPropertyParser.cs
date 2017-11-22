using FullCalendar.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class CustomButtonsPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public CustomButtonsPropertyParser(PropertyInfo property)
        {
            _property = property;
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

            dictionary.Add("data-fc-" + _property.Name, new JavaScriptSerializer().Serialize(serializedData).ToSingleQuotes());
        }
    }
}
