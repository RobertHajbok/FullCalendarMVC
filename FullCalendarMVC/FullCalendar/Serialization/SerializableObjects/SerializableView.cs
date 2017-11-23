namespace FullCalendar.Serialization.SerializableObjects
{
    /// <summary>
    /// Class used to serialize BusinessHour objects. This is needed because NullPropertiesConverter is not working on object types.
    /// </summary>
    public class SerializableView
    {
        public string type { get; set; }

        public string buttonText { get; set; }

        public string titleFormat { get; set; }

        public object visibleRange { get; set; }

        public SerializableDuration dateIncrement { get; set; }

        public string dateAlignment { get; set; }

        public SerializableDuration duration { get; set; }

        public int dayCount { get; set; }
    }
}
