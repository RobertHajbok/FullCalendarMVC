using System;
using System.Collections.Generic;

namespace FullCalendar
{
    public class BusinessHour
    {
        public IEnumerable<DayOfWeek> Dow { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }
    }
}
