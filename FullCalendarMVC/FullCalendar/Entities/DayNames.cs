using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace FullCalendar
{
    public class DayNames
    {
        public string Sunday { get; set; }

        public string Monday { get; set; }

        public string Tuesday { get; set; }

        public string Wednesday { get; set; }

        public string Thursday { get; set; }

        public string Friday { get; set; }

        public string Saturday { get; set; }

        public override string ToString()
        {
            IEnumerable<string> dayNames = new List<string>
            {
                Sunday ?? "undefined", Monday ?? "undefined", Tuesday ?? "undefined", Wednesday ?? "undefined",
                Thursday ?? "undefined", Friday ?? "undefined", Saturday ?? "undefined"
            };
            return new JavaScriptSerializer().Serialize(dayNames).ToSingleQuotes();
        }
    }
}
