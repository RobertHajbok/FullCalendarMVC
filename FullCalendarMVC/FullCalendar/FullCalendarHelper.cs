using FullCalendar.Abstract;
using FullCalendar.Interfaces;
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
                if (property.Name == nameof(FullCalendarParameters.Name) || property.Name == nameof(FullCalendarParameters.CssClass))
                    continue;
                IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
                propertyParser.AddPropertyToDictionary(fullCalendarParameters, ref attributes);
            }

            return MvcHtmlString.Create(string.Format("<div {0} {1} class=\"fc {2}\" {3}></div>", !string.IsNullOrEmpty(fullCalendarParameters.Name) ?
                string.Format("id='{0}'", fullCalendarParameters.Name) : "", !string.IsNullOrEmpty(fullCalendarParameters.Name) ?
                string.Format("name='{0}'", fullCalendarParameters.Name) : "", fullCalendarParameters.CssClass,
                string.Join(" ", attributes.Select(x => x.Key + "=\"" + x.Value + "\""))));
        }
    }
}
