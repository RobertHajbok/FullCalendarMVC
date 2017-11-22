namespace FullCalendar.Serialization.SerializableObjects
{
    /// <summary>
    /// Class used to serialize Duration objects. This is needed because NullPropertiesConverter is not working on object types.
    /// </summary>
    public class SerializableDuration
    {
        public int days { get; set; }

        public int weeks { get; set; }

        public int months { get; set; }
    }
}
