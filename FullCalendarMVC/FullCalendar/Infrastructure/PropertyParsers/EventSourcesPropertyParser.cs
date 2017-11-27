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
    public class EventSourcesPropertyParser : IPropertyParser
    {
        private PropertyInfo _property;

        public EventSourcesPropertyParser(PropertyInfo property)
        {
            _property = property;
        }

        public void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary)
        {
            object value = _property.GetValue(fullCalendarParameters, null);
            if (value == null)
                return;

            IEnumerable<EventSource> eventSources = (IEnumerable<EventSource>)value;
            if (!eventSources.Any())
                return;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });

            dictionary.Add("data-fc-" + _property.Name, serializer.Serialize(eventSources.Select(x => new SerializableEventSource
            {
                id = x.Id,
                events = x.Events?.AsSerializableObject(),
                color = x.Color != default(Color) ? x.Color.ToHexString() : null,
                backgroundColor = x.BackgroundColor != default(Color) ? x.BackgroundColor.ToHexString() : null,
                borderColor = x.BorderColor != default(Color) ? x.BorderColor.ToHexString() : null,
                textColor = x.TextColor != default(Color) ? x.TextColor.ToHexString() : null,
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
                allDayDefault = x.AllDayDefault,
                eventDataTransform = x.EventDataTransform,
                url = x.Url,
                startParam = x.StartParam,
                endParam = x.EndParam,
                timezoneParam = x.TimezoneParam,
                // AJAX
                type = x.Type,
                success = x.Success,
                error = x.Error,
                cache = x.Cache,
                data = x.Data
            })).ToSingleQuotes());
        }
    }
}
