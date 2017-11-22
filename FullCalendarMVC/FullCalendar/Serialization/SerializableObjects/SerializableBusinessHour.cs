using System;
using System.Collections.Generic;

namespace FullCalendar.Serialization.SerializableObjects
{
    /// <summary>
    /// Class used to serialize BusinessHour objects. This is needed because NullPropertiesConverter is not working on object types.
    /// </summary>
    public class SerializableBusinessHour
    {
        public IEnumerable<DayOfWeek> dow { get; set; }

        public string start { get; set; }

        public string end { get; set; }
    }
}
