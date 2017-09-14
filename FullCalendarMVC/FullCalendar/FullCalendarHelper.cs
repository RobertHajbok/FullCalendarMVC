using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FullCalendar
{
    public static class FullCalendarHelper
    {
        public static IHtmlString FullCalendar(this HtmlHelper htmlHelper)
        {
            return htmlHelper.FullCalendar(settings => new FullCalendarParameters());
        }

        public static IHtmlString FullCalendar(this HtmlHelper htmlHelper, Action<FullCalendarParameters> parameters)
        {
            var fullCalendarParameters = new FullCalendarParameters();
            parameters(fullCalendarParameters);

            Dictionary<string, string> attributes = new Dictionary<string, string>();
            foreach (var property in typeof(FullCalendarParameters).GetProperties())
            {
                if (property.PropertyType == typeof(DayOfWeek))
                {
                    // days enum
                    attributes.Add("data-fc-" + property.Name, ((int)property.GetValue(fullCalendarParameters, null)).ToString());
                }
                else if (property.PropertyType == typeof(bool) || property.PropertyType.BaseType == typeof(Enum))
                {
                    // boolean + enum
                    attributes.Add("data-fc-" + property.Name, property.GetValue(fullCalendarParameters, null).ToString().FirstCharToLower());
                }
                else if (property.PropertyType == typeof(TimeSpan))
                {
                    // timespan
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null && (TimeSpan)value != default(TimeSpan))
                        attributes.Add("data-fc-" + property.Name, ((TimeSpan)value).TotalMilliseconds.ToString());
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    // datetime
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null && (DateTime)value != default(DateTime))
                        attributes.Add("data-fc-" + property.Name, ((DateTime)value).ToString("MM/dd/yyyy hh:mm:ss"));
                }
                else if (property.PropertyType == typeof(string))
                {
                    // string
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                        attributes.Add("data-fc-" + property.Name, value.ToString());
                }
                else if (property.PropertyType == typeof(double))
                {
                    // double
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null && (double)value != default(double))
                        attributes.Add("data-fc-" + property.Name, value.ToString());
                }
                else if (property.PropertyType == typeof(int))
                {
                    // int
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null && (int)value != default(int))
                        attributes.Add("data-fc-" + property.Name, value.ToString());
                }
                else if (property.PropertyType.IsArray)
                {
                    // array
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null)
                        attributes.Add("data-fc-" + property.Name, new JavaScriptSerializer().Serialize(value).ToSingleQuotes());
                }
                else
                {
                    // object
                    object value = property.GetValue(fullCalendarParameters, null);
                    if (value != null)
                        attributes.Add("data-fc-" + property.Name, value.ToString());
                }
            }

            return MvcHtmlString.Create(string.Format("<div class=\"fc\" {0}></div>", string.Join(" ", attributes.Select(x => x.Key + "=\"" + x.Value + "\""))));
        }
    }
}
