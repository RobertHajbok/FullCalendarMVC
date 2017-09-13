using System.Web.Script.Serialization;

namespace FullCalendar
{
    public abstract class ControlsContainer
    {
        public ControlsBuilder Left { get; set; }

        public ControlsBuilder Center { get; set; }

        public ControlsBuilder Right { get; set; }

        public override string ToString()
        {
            object jsonString = new
            {
                left = Left?.ToString(),
                center = Center?.ToString(),
                right = Right?.ToString()
            };

            return new JavaScriptSerializer().Serialize(jsonString).ToSingleQuotes();
        }
    }
}