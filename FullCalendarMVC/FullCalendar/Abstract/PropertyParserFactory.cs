using FullCalendar.Infrastructure.PropertyParsers;
using FullCalendar.Interfaces;
using FullCalendar.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace FullCalendar.Abstract
{
    public abstract class PropertyParserFactory
    {
        public static IPropertyParser GetPropertyParser(PropertyInfo property)
        {
            IPropertyParser propertyParser = null;

            if (property.Name == nameof(FullCalendarParameters.ButtonIcons) || property.Name == nameof(FullCalendarParameters.ThemeButtonIcons) ||
                property.Name == nameof(FullCalendarParameters.BootstrapGlyphicons))
                propertyParser = new ButtonIconsPropertyParser(property, SerializationHelpers.GetSerializer());
            else if (property.Name == nameof(FullCalendarParameters.WeekNumberCalculation) || property.Name == nameof(FullCalendarParameters.DropAccept) ||
                property.Name == nameof(FullCalendarParameters.EventLimitClick) || property.Name == nameof(FullCalendarParameters.EventLimitText) ||
                property.Name == nameof(FullCalendarParameters.ColumnHeaderText) || property.Name == nameof(FullCalendarParameters.ColumnHeaderHtml))
                propertyParser = new FunctionPropertyParser(property, SerializationHelpers.GetSerializer());
            else if (property.PropertyType == typeof(EventCollection))
                propertyParser = new EventCollectionPropertyParser(property, SerializationHelpers.GetSerializer(true));
            else if (property.PropertyType == typeof(ClientSideEvents))
                propertyParser = new ClientSideEventsPropertyParser(property, SerializationHelpers.GetSerializer());
            else if (property.PropertyType == typeof(Dictionary<string, CustomButton>))
                propertyParser = new CustomButtonsPropertyParser(property, SerializationHelpers.GetSerializer());
            else if (property.PropertyType == typeof(Dictionary<string, View>))
                propertyParser = new CustomViewPropertyParser(property, SerializationHelpers.GetSerializer(true));
            else if (property.PropertyType == typeof(IEnumerable<BusinessHour>))
                propertyParser = new BusinessHoursPropertyParser(property, SerializationHelpers.GetSerializer(true));
            else if (property.PropertyType == typeof(IEnumerable<EventSource>))
                propertyParser = new EventSourcesPropertyParser(property, SerializationHelpers.GetSerializer(true));
            else if (property.PropertyType == typeof(DayOfWeek))
                propertyParser = new DayOfWeekPropertyParser(property);
            else if (property.PropertyType == typeof(ThemeSystem))
                propertyParser = new ThemeSystemPropertyParser(property);
            else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                propertyParser = new BoolPropertyParser(property);
            else if (Nullable.GetUnderlyingType(property.PropertyType)?.IsEnum == true)
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
            else if (property.PropertyType == typeof(Unit))
                propertyParser = new UnitPropertyParser(property);
            else if (property.PropertyType.IsArray)
                propertyParser = new ArrayPropertyParser(property, SerializationHelpers.GetSerializer());
            else
                propertyParser = new ObjectPropertyParser(property, SerializationHelpers.GetSerializer(true));

            return propertyParser;
        }
    }
}
