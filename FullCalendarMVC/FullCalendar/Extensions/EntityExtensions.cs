using System.Text.RegularExpressions;

namespace FullCalendar
{
    /// <summary>
    /// General entity extensions
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Changes double quotes to single quotes in a text. This is mainly used to format serialized strings in data- attributes
        /// </summary>
        /// <param name="text">Text to be formatted</param>
        /// <returns>Text with double quotes replaced with single quotes</returns>
        public static string ToSingleQuotes(this string text)
        {
            return Regex.Replace(text, @"\\\\|\\(""|')|(""|')", match => {
                if (match.Groups[1].Value == "\"") return "\""; // Unescape \"
                if (match.Groups[2].Value == "\"") return "'";  // Replace " with '
                if (match.Groups[2].Value == "'") return "\\'"; // Escape '
                return match.Value;                             // Leave \\ and \' unchanged
            });
        }
    }
}
