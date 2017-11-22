namespace FullCalendar.Serialization.SerializableObjects
{
    /// <summary>
    /// Class used to serialize ValidRange objects. This is needed because NullPropertiesConverter is not working on object types.
    /// </summary>
    public class SerializableValidRange
    {
        public string start { get; set; }

        public string end { get; set; }
    }
}
