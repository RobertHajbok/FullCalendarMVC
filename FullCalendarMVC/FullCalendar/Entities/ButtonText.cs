using FullCalendar.Interfaces;

namespace FullCalendar
{
    public class ButtonText : ISerializableObject
    {
        public string Today { get; set; }

        public string Month { get; set; }

        public string Week { get; set; }

        public string Day { get; set; }

        public string List { get; set; }

        public object AsSerializableObject()
        {
            // This trick is done because if today is sent as null, the text of the button will be 'undefined'
            if (!string.IsNullOrEmpty(Today))
                return new
                {
                    today = Today,
                    month = Month,
                    week = Week,
                    day = Day,
                    list = List
                };
            else
                return new
                {
                    month = Month,
                    week = Week,
                    day = Day,
                    list = List
                };
        }
    }
}
