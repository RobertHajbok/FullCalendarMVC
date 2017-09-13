namespace FullCalendar
{
    public class ControlsBuilder
    {
        private string _buildedString;

        /// <summary>
        /// ctor
        /// </summary>
        public ControlsBuilder()
        {
            _buildedString = string.Empty;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="buildedString">Initial string value for the builded string according to the API</param>
        public ControlsBuilder(string buildedString)
        {
            _buildedString = buildedString;
        }

        /// <summary>
        /// Adds a separator to the string. Values separated by a comma will be displayed adjacently. 
        /// Values separated by a space will be displayed with a small gap in between.
        /// </summary>
        /// <param name="separator">Header separator</param>
        /// <returns>Instance of the <see cref="ControlsBuilder"/></returns>
        public ControlsBuilder AddSeparator(HeaderSeparator separator)
        {
            switch(separator)
            {
                case HeaderSeparator.Adjacent:
                    _buildedString += ",";
                    return this;
                case HeaderSeparator.Gap:
                    _buildedString += " ";
                    return this;
                default:
                    return this;
            }
        }

        /// <summary>
        /// Adds title (text containing the current month/week/day) to the string. 
        /// </summary>
        /// <returns>Instance of the <see cref="ControlsBuilder"/></returns>
        public ControlsBuilder AddTitle()
        {
            _buildedString += "title";
            return this;
        }

        /// <summary>
        /// Adds a button (prev, next, prevYear, nextYear, today) to the string.
        /// </summary>
        /// <param name="headerButton">Header button</param>
        /// <returns>Instance of the <see cref="ControlsBuilder"/></returns>
        public ControlsBuilder AddButton(HeaderButton headerButton)
        {
            _buildedString += headerButton.ToString().FirstCharToLower();
            return this;
        }

        /// <summary>
        /// Adds a button that will switch the calendar to any of the Available Views to the stirng.
        /// </summary>
        /// <param name="calendarView">Calendar view</param>
        /// <returns>Instance of the <see cref="ControlsBuilder"/></returns>
        public ControlsBuilder AddView(CalendarView calendarView)
        {
            _buildedString += calendarView.ToString().FirstCharToLower();
            return this;
        }

        /// <summary>
        /// Returns the string representation of the builded header
        /// </summary>
        /// <returns>The string representation of the builded header</returns>
        public override string ToString()
        {
            return _buildedString;
        }
    }
}