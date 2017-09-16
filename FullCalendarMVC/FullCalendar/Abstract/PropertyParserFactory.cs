using FullCalendar.Infrastructure.PropertyParsers;
using FullCalendar.Interfaces;
using System;
using System.Drawing;
using System.Reflection;

namespace FullCalendar.Abstract
{
    public class PropertyParserFactory
    {
        public static IPropertyParser GetPropertyParser(PropertyInfo property)
        {
            IPropertyParser propertyParser = null;

            if (property.PropertyType == typeof(DayOfWeek))
                propertyParser = new DayOfWeekPropertyParser(property);
            else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                propertyParser = new BoolPropertyParser(property);
            else if (property.PropertyType.BaseType == typeof(Enum))
                propertyParser = new EnumPropertyParser(property);
            else if (property.PropertyType == typeof(TimeSpan))
                propertyParser = new TimeSpanPropertyParser(property);
            else if (property.PropertyType == typeof(DateTime))
                propertyParser = new DateTimePropertyParser(property);
            else if (property.PropertyType == typeof(string))
                propertyParser = new StringPropertyParser(property);
            else if (property.PropertyType == typeof(double))
                propertyParser = new DoublePropertyParser(property);
            else if (property.PropertyType == typeof(float))
                propertyParser = new FloatPropertyParser(property);
            else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                propertyParser = new IntegerPropertyParser(property);
            else if (property.PropertyType == typeof(Color))
                propertyParser = new ColorPropertyParser(property);
            else if (property.PropertyType.IsArray)
                propertyParser = new ArrayPropertyParser(property);
            else
                propertyParser = new ObjectPropertyParser(property);

            return propertyParser;
        }
    }
}
