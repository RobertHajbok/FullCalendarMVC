namespace FullCalendar
{
    public class CustomButton
    {
        /// <summary>
        /// The text to be display on the button itself
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// A callback function that is called when the button is clicked. Accepts a single argument, a jqueryEvent.
        /// </summary>
        public string Click { get; set; }

        /// <summary>
        /// See buttonIcons. Optional
        /// </summary>
        public object Icon { get; set; }

        /// <summary>
        /// See themeButtonIcons. Optional
        /// </summary>
        public object ThemeIcon { get; set; }

        /// <summary>
        /// See bootstrapGlyphicons. Optional
        /// </summary>
        public object BootstrapGlyphicon { get; set; }
    }
}
