using System.Web;
using System.Web.Mvc;

namespace FullCalendar
{
    public static class FullCalendarHelper
    {
        public static IHtmlString FullCalendar(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create("<div class='fc'></div>");
        }
    }
}
