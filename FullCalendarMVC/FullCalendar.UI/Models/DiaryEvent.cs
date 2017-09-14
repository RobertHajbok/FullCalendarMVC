namespace FullCalendar.UI.Models
{
    public class DiaryEvent
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int SomeImportantKeyID { get; set; }

        public string StartDateString { get; set; }

        public string EndDateString { get; set; }

        public string StatusString { get; set; }

        public string StatusColor { get; set; }

        public string ClassName { get; set; }        
    }
}