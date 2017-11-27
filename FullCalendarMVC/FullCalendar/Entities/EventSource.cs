using System.Drawing;

namespace FullCalendar
{
    public class EventSource
    {
        public int Id { get; set; }

        public EventCollection Events { get; set; }

        public Color Color { get; set; }

        public Color BackgroundColor { get; set; }

        public Color BorderColor { get; set; }

        public Color TextColor { get; set; }

        public string ClassName { get; set; }

        public bool Editable { get; set; }

        public bool StartEditable { get; set; } = true;

        public bool DurationEditable { get; set; } = true;

        public Rendering? Rendering { get; set; }

        public bool Overlap { get; set; } = true;

        public EventConstraint Constraint { get; set; }

        public bool? AllDayDefault { get; set; }

        public string EventDataTransform { get; set; }

        public string Url { get; set; }

        public string StartParam { get; set; }

        public string EndParam { get; set; }

        public string TimezoneParam { get; set; }

        #region AJAX

        public string Type { get; set; }

        public string Success { get; set; }

        public string Error { get; set; }

        public bool Cache { get; set; }

        public object Data { get; set; }

        #endregion
    }
}
