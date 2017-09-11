using System.Web.Optimization;

namespace FullCalendar.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/moment.js",
                "~/Scripts/fullcalendar*"
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/fullcalendar.css",
                "~/Content/site.css"
                ));
        }
    }
}