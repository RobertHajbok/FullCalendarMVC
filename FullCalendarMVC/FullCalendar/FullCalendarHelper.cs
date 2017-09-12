using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                attributes.Add("data-fc-" + property.Name, property.GetValue(fullCalendarParameters, null).ToString().ToLower());
            }

            return MvcHtmlString.Create(string.Format("<div class='fc' {0}></div>", string.Join(" ", attributes.Select(x => x.Key + "=" + x.Value))));
        }
    }
}
