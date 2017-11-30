using FullCalendar.Extensions;
using FullCalendar.Serialization.SerializableObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FullCalendar
{
    public class EventCollection
    {
        public string Url { get; private set; }

        public IEnumerable<Event> Events { get; private set; }

        public string Function { get; private set; }

        public string GoogleCalendarId { get; private set; }

        public EventCollectionType Type { get; private set; }

        public EventCollection(string str, EventCollectionType type)
        {
            Type = type;
            switch (type)
            {
                case EventCollectionType.JsonFeed:
                    Url = str;
                    break;
                case EventCollectionType.Function:
                    Function = str;
                    break;
                case EventCollectionType.GoogleCalendarFeed:
                    GoogleCalendarId = str;
                    break;
            }
        }

        public EventCollection(IEnumerable<Event> events)
        {
            Events = events;
            Type = EventCollectionType.Array;
        }

        public object AsSerializableObject()
        {
            switch (Type)
            {
                case EventCollectionType.Array:
                    if (Events == null || !Events.Any())
                        return null;
                    return SerializableEventArray();
                case EventCollectionType.JsonFeed:
                    return Url;
                case EventCollectionType.Function:
                    return Function;
                case EventCollectionType.GoogleCalendarFeed:
                    return new
                    {
                        googleCalendarId = GoogleCalendarId
                    };
                default:
                    return null;
            }
        }

        public IEnumerable<SerializableEvent> SerializableEventArray()
        {
            return Events.Select(x => new SerializableEvent
            {
                id = x.Id,
                title = x.Title,
                allDay = x.AllDay,
                start = x.Start?.ToString("s"),
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
                googleCalendarId = x.GoogleCalendarId,
                additionalFields = x.AdditionalFields
            });
        }
    }
}
