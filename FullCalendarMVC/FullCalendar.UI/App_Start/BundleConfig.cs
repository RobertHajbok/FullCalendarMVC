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
                "~/Scripts/qTip/jquery.qtip.js",
                "~/Scripts/moment.js",
                "~/Scripts/fullcalendar*",
                "~/Scripts/locale-all.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.css",
                "~/Content/themes/flat/jquery-ui-{version}.css",
                "~/Content/fullcalendar.css",
                "~/Content/site.css"
                ));
        }
    }
}