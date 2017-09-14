using System.Collections.Generic;

namespace FullCalendar.Interfaces
{
    /// <summary>
    /// Defines methods to be implemented in property parsers
    /// </summary>
    public interface IPropertyParser
    {
        void AddPropertyToDictionary(FullCalendarParameters fullCalendarParameters, ref Dictionary<string, string> dictionary);
    }
}
