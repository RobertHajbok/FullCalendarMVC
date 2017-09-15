using System.Drawing;

namespace FullCalendar.Extensions
{
    /// <summary>
    /// General Color extensions
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Gets the hex representation of the current color for CSS properties
        /// </summary>
        /// <param name="color">Color object</param>
        /// <returns>The hex representation of the current color for CSS properties</returns>
        public static string ToHexString(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
