using System;
using System.Collections.Generic;
using System.Drawing;

namespace FullCalendar
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool? AllDay { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string Url { get; set; }

        public string ClassName { get; set; }

        public bool Editable { get; set; }

        public bool StartEditable { get; set; } = true;

        public bool DurationEditable { get; set; } = true;

        public Rendering? Rendering { get; set; }

        public bool Overlap { get; set; } = true;

        public EventConstraint Constraint { get; set; }

        public Color Color { get; set; }

        public Color BackgroundColor { get; set; }

        public Color BorderColor { get; set; }

        public Color TextColor { get; set; }

        public string GoogleCalendarId { get; set; }

        public Dictionary<string, string> AdditionalFields { get; set; }
    }
}
