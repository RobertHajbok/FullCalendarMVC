namespace FullCalendar.Interfaces
{
    /// <summary>
    /// Represents a class which can be serialized as an object
    /// </summary>
    public interface ISerializableObject
    {
        /// <summary>
        /// Gets the object representation before serialization
        /// </summary>
        /// <returns>The object representation before serialization</returns>
        object AsSerializableObject();
    }
}
