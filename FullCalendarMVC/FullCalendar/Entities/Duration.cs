using FullCalendar.Interfaces;
using FullCalendar.Serialization.SerializableObjects;

namespace FullCalendar
{
    public class Duration : ISerializableObject
    {
        public int Days { get; set; }

        public int Weeks { get; set; }

        public int Months { get; set; }

        public object AsSerializableObject()
        {
            return new SerializableDuration
            {
                days = Days,
                weeks = Weeks,
                months = Months
            };
        }
    }
}
