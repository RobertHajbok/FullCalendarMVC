using FullCalendar.Extensions;
using FullCalendar.Interfaces;
using FullCalendar.Serialization;
using FullCalendar.Serialization.SerializableObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers
{
    public class EventCollectionPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public EventCollectionPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            EventCollection eventCollection = (EventCollection)value;
            switch (eventCollection.Type)
            {
                case EventCollectionType.Array:
                    if (eventCollection.Events == null || !eventCollection.Events.Any())
                        return;

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });

                    dictionary.Add("data-fc-" + _property.Name, serializer.Serialize(eventCollection.Events.Select(x => new SerializableEvent
                    {
                        id = x.Id,
                        title = x.Title,
                        allDay = x.AllDay,
                        start = x.Start.ToString("s"),
                        end = x.End?.ToString("s"),
                        url = x.Url,
                        className = x.ClassName,
                        editable = x.Editable,
                        startEditable = x.StartEditable,
                        durationEditable = x.DurationEditable,
                        rendering = x.Rendering == null ? null : (x.Rendering.Value == Rendering.InverseBackground ? "inverse-background" :
                            x.Rendering.Value.ToString().FirstCharToLower()),
                        overlap = x.Overlap,
                        constraint = x.Constraint == null ? null : (x.Constraint.EventId != null ? (object)x.Constraint.EventId : new SerializableBusinessHour
                        {
                            dow = x.Constraint.BusinessHours.Dow,
                            start = x.Constraint.BusinessHours.Start != null && x.Constraint.BusinessHours.Start != default(TimeSpan) ? x.Constraint.BusinessHours.Start.ToString(@"hh\:mm") : null,
                            end = x.Constraint.BusinessHours.End != null && x.Constraint.BusinessHours.End != default(TimeSpan) ? x.Constraint.BusinessHours.End.ToString(@"hh\:mm") : null
                        }),
                        color = x.Color != default(Color) ? x.Color.ToHexString() : null,
                        backgroundColor = x.BackgroundColor != default(Color) ? x.BackgroundColor.ToHexString() : null,
                        borderColor = x.BorderColor != default(Color) ? x.BorderColor.ToHexString() : null,
                        textColor = x.TextColor != default(Color) ? x.TextColor.ToHexString() : null,
                        additionalFields = x.AdditionalFields
                    })).ToSingleQuotes());

                    break;
                case EventCollectionType.JsonFeed:
                    dictionary.Add("data-fc-" + _property.Name, eventCollection.Url);
                    break;
                case EventCollectionType.Function:
                    dictionary.Add("data-fc-" + _property.Name, eventCollection.Function);
                    break;
            }
        }
    }
}
