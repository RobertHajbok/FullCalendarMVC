using FullCalendar.Serialization;
using FullCalendar.Serialization.SerializableObjects;
using System;
using System.Web.Script.Serialization;

namespace FullCalendar
{
    public class ValidRange
    {
        public DateTime? Start { get; private set; }

        public DateTime? End { get; private set; }

        public string Function { get; private set; }

        /// <summary>
        /// The validRange property can have start and end properties. You may specify one without specifying the other to create an open-ended range.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        public ValidRange(DateTime start, DateTime? end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// The validRange property can have start and end properties. You may specify one without specifying the other to create an open-ended range.
        /// </summary>
        /// <param name="end">End date</param>
        public ValidRange(DateTime end)
        {
            End = end;
        }

        /// <summary>
        /// You can also dynamically generate the range via a function. It must return an object in the same format.
        /// </summary>
        /// <param name="function">Function</param>
        public ValidRange(string function)
        {
            Function = function;
        }

        public override string ToString()
        {
            if (Function != null)
                return Function;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
            return serializer.Serialize(new SerializableValidRange
            {
                start = Start != null && Start != default(DateTime) ? Start.Value.ToString("yyyy-MM-dd") : null,
                end = End != null && End != default(DateTime) ? End.Value.ToString("yyyy-MM-dd") : null
            }).ToSingleQuotes();
        }
    }
}
