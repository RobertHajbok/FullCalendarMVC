namespace FullCalendar
{
    public class Unit
    {
        public string Value { get; private set; }

        public UnitType Type { get; private set; }

        public static Unit Pixel(int px)
        {
            return new Unit
            {
                Value = px.ToString(),
                Type = UnitType.Pixel
            };
        }

        public static Unit Function(string function)
        {
            return new Unit
            {
                Value = function,
                Type = UnitType.Function
            };
        }

        public static Unit Auto()
        {
            return new Unit
            {
                Type = UnitType.Auto
            };
        }

        public static Unit Parent()
        {
            return new Unit
            {
                Type = UnitType.Parent
            };
        }
    }
}
