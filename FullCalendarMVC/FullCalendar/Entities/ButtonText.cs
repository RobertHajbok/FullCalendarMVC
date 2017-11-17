using System.Web.Script.Serialization;

namespace FullCalendar
{
    public class ButtonText
    {
        public string Today { get; set; }

        public string Month { get; set; }

        public string Week { get; set; }

        public string Day { get; set; }
   
        public string List { get; set; }

        public override string ToString()
        {
            // This trick is done because if today is sent as null, the text of the button will be 'undefined'
            if (!string.IsNullOrEmpty(Today))
                return new JavaScriptSerializer().Serialize(new
                {
                    today = Today,
                    month = Month,
                    week = Week,
                    day = Day,
                    list = List
                }).ToSingleQuotes();
            else
                return new JavaScriptSerializer().Serialize(new
                {
                    month = Month,
                    week = Week,
                    day = Day,
                    list = List
                }).ToSingleQuotes();
        }
    }
}
