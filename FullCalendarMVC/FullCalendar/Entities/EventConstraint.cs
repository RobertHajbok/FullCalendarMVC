using FullCalendar.Interfaces;
using FullCalendar.Serialization.SerializableObjects;
using System;

namespace FullCalendar
{
    public class EventConstraint : ISerializableObject
    {
        public string EventId { get; private set; }

        public BusinessHour BusinessHours { get; private set; }

        /// <summary>
        /// If an event ID is given, events that are being dragged or resized must be fully contained by at least one of the events linked to by the given event ID.
        /// If "businessHours" is given, events being dragged or resized must be fully contained within the week's business hours (Monday-Friday 9am-5pm by default). A custom businessHours value will be respected.
        /// </summary>
        /// <param name="eventId">An event ID or "businessHours" string</param>
        public EventConstraint(string eventId)
        {
            EventId = eventId;
        }

        /// <summary>
        /// A custom time-window, an object identical to what businessHours accepts, can also be given.
        /// A specific period of time with concrete start/end dates can also be given, similar to what an Event Object accepts.
        /// </summary>
        /// <param name="businessHours">A custom time-window, an object identical to what businessHours accepts</param>
        public EventConstraint(BusinessHour businessHours)
        {
            BusinessHours = businessHours;
        }

        public object AsSerializableObject()
        {
            if (EventId != null)
                return EventId;

            return new SerializableBusinessHour
            {
                dow = BusinessHours.Dow,
                start = BusinessHours.Start != null && BusinessHours.Start != default(TimeSpan) ? BusinessHours.Start.ToString(@"hh\:mm") : null,
                end = BusinessHours.End != null && BusinessHours.End != default(TimeSpan) ? BusinessHours.End.ToString(@"hh\:mm") : null
            };
        }
    }
}
