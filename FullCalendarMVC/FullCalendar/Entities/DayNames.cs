using FullCalendar.Interfaces;
using System.Collections.Generic;

namespace FullCalendar
{
    public class DayNames : ISerializableObject
    {
        public string Sunday { get; set; }

        public string Monday { get; set; }

        public string Tuesday { get; set; }

        public string Wednesday { get; set; }

        public string Thursday { get; set; }

        public string Friday { get; set; }

        public string Saturday { get; set; }

        public object AsSerializableObject()
        {
            return new List<string>
            {
                Sunday ?? "undefined", Monday ?? "undefined", Tuesday ?? "undefined", Wednesday ?? "undefined",
                Thursday ?? "undefined", Friday ?? "undefined", Saturday ?? "undefined"
            };
        }
    }
}
