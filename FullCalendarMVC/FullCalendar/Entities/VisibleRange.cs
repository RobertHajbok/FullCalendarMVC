using System;
using System.Web.Script.Serialization;

namespace FullCalendar
{
    public class VisibleRange
    {
        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public string Function { get; private set; }

        /// <summary>
        /// The visibleRange object must have start/end properties that resolve to Moment values. The end moment is exclusive, just like all other places in the API.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        public VisibleRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// You can also specify a function that dynamically generates a range from the current date marker.
        /// </summary>
        /// <param name="function">Function</param>
        public VisibleRange(string function)
        {
            Function = function;
        }

        public override string ToString()
        {
            if (Function != null)
                return Function;

            return new JavaScriptSerializer().Serialize(new
            {
                start = Start.ToString("yyyy-MM-dd"),
                end = End.ToString("yyyy-MM-dd")
            }).ToSingleQuotes();
        }
    }
}
