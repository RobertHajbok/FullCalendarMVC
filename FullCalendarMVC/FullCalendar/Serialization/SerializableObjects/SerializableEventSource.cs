namespace FullCalendar.Serialization.SerializableObjects
{
    /// <summary>
    /// Class used to serialize EventSource objects. This is needed because NullPropertiesConverter is not working on object types.
    /// </summary>
    public class SerializableEventSource
    {
        public int id { get; set; }

        public object events { get; set; }

        public string color { get; set; }

        public string backgroundColor { get; set; }

        public string borderColor { get; set; }

        public string textColor { get; set; }

        public string className { get; set; }

        public bool editable { get; set; }

        public bool startEditable { get; set; }

        public bool durationEditable { get; set; }

        public string rendering { get; set; }

        public bool overlap { get; set; }

        public object constraint { get; set; }

        public bool? allDayDefault { get; set; }

        public string eventDataTransform { get; set; }

        public string url { get; set; }

        public string startParam { get; set; }

        public string endParam { get; set; }

        public string timezoneParam { get; set; }

        #region AJAX

        public string type { get; set; }

        public string success { get; set; }

        public string error { get; set; }

        public bool cache { get; set; }

        public object data { get; set; }

        #endregion
    }
}
