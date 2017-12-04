using System.Web.Script.Serialization;

namespace FullCalendar.Serialization
{
    /// <summary>
    /// Container for serialization helpers
    /// </summary>
    public static class SerializationHelpers
    {
        /// <summary>
        /// Instantiates a <see cref="JavaScriptSerializer"/> object and registers <see cref="NullPropertiesConverter"/> as converter, if requested
        /// </summary>
        /// <param name="useNullConverter">True if <see cref="NullPropertiesConverter"/> has to registered as converter, otherwise false</param>
        /// <returns>A <see cref="JavaScriptSerializer"/> object with <see cref="NullPropertiesConverter"/> registered as converter, if requested</returns>
        public static JavaScriptSerializer GetSerializer(bool useNullConverter = false)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (useNullConverter)
                serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
            return serializer;
        }
    }
}
