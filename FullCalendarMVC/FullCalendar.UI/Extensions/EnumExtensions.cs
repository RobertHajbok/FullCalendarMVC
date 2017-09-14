using System;
using System.ComponentModel;
using System.Linq;

namespace FullCalendar.UI.Extensions
{
    public static class Enums
    {
        /// Get the name for the enum value
        public static string GetName<T>(T enumValue)
        {
            return Enum.GetName(typeof(T), enumValue);
        }

        public static string GetEnumDescription<T>(string value)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

            if (name == null)
            {
                return string.Empty;
            }
            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        }
    }
}