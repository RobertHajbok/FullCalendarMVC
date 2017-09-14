using System;

namespace FullCalendar.UI.Models
{
    public class AppointmentDiary
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int SomeImportantKey { get; set; }

        public DateTime DateTimeScheduled { get; set; }

        public int AppointmentLength { get; set; }

        public int StatusENUM { get; set; }
    }
}