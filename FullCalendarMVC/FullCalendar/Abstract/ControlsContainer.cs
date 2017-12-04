using FullCalendar.Interfaces;

namespace FullCalendar
{
    public abstract class ControlsContainer : ISerializableObject
    {
        public ControlsBuilder Left { get; set; }

        public ControlsBuilder Center { get; set; }

        public ControlsBuilder Right { get; set; }

        public object AsSerializableObject()
        {
            return new
            {
                left = Left?.ToString(),
                center = Center?.ToString(),
                right = Right?.ToString()
            };
        }
    }
}