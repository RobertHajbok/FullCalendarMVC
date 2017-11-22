using FullCalendar.Serialization;
using FullCalendar.Serialization.SerializableObjects;
using System.Web.Script.Serialization;

namespace FullCalendar
{
    public class Duration
    {
        public int Days { get; set; }

        public int Weeks { get; set; }

        public int Months { get; set; }

        public override string ToString()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
            return serializer.Serialize(new SerializableDuration
            {
                days = Days,
                weeks = Weeks,
                months = Months
            }).ToSingleQuotes();
        }
    }
}
