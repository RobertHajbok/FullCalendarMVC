using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace FullCalendar
{
    public class MonthNames
    {
        public string January { get; set; }

        public string February { get; set; }

        public string March { get; set; }

        public string April { get; set; }

        public string May { get; set; }

        public string June { get; set; }

        public string July { get; set; }

        public string August { get; set; }

        public string September { get; set; }

        public string October { get; set; }

        public string November { get; set; }

        public string December { get; set; }

        public override string ToString()
        {
            IEnumerable<string> monthNames = new List<string>
            {
                January ?? "undefined", February ?? "undefined", March ?? "undefined", April ?? "undefined",
                May ?? "undefined", June ?? "undefined", July ?? "undefined", August ?? "undefined",
                September?? "undefined", October?? "undefined", November?? "undefined", December?? "undefined"
            };
            return new JavaScriptSerializer().Serialize(monthNames).ToSingleQuotes();
        }
    }
}