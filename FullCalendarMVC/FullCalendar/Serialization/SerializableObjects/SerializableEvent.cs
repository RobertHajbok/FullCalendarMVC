using System.Collections.Generic;

namespace FullCalendar.Serialization.SerializableObjects
{
    /// <summary>
    /// Class used to serialize Event objects. This is needed because NullPropertiesConverter is not working on object types.
    /// </summary>
    public class SerializableEvent
    {
        public int id { get; set; }

        public string title { get; set; }

        public bool? allDay { get; set; }

        public string start { get; set; }

        public string end { get; set; }

        public string url { get; set; }

        public string className { get; set; }

        public bool editable { get; set; }

        public bool startEditable { get; set; }

        public bool durationEditable { get; set; }

        public string rendering { get; set; }

        public bool overlap { get; set; }

        public object constraint { get; set; }

        public string color { get; set; }

        public string backgroundColor { get; set; }

        public string borderColor { get; set; }

        public string textColor { get; set; }

        public string googleCalendarId { get; set; }

        public Dictionary<string, string> additionalFields { get; set; }
    }
}
