using System.Web;
using System.Web.Optimization;

namespace COMPRO
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // COMPRO CSS
            bundles.Add(new StyleBundle("~/Content/Comprocss").Include(
                     "~/Content/res/css/animate.css",
                     "~/Content/res/css/icomoon.css",
                     "~/Content/res/css/bootstrap.css",
                     "~/Content/res/css/magnific-popup.css",
                     "~/Content/res/css/flexslider.css",
                     "~/Content/res/css/owl.carousel.min.css",
                     "~/Content/res/css/owl.theme.default.min.css",
                     "~/Content/res/css/bootstrap-datepicker.css",
                     "~/Content/res/fonts/flaticon/font/flaticon.css",
                     "~/Content/res/css/style.css",
                     "~/Content/res/css/clockpicker.css",
                     "~/Content/res/css/fullcalendar.min.css",
                     "~/Content/res/css/fullcalendar.printsite.css"));

            // COMPRO JS
            bundles.Add(new ScriptBundle("~/Content/Comprojs").Include(
                     "~/Content/res/js/jquery.min.js",
                     "~/Content/res/js/jquery.3.3.1.min.js",
                     "~/Content/res/js/moment.min.js",
                     "~/Content/res/js/fullcalendar.js",
                     "~/Content/res/js/jquery.easing.1.3.js",
                     "~/Content/res/js/bootstrap.min.js",
                     "~/Content/res/js/jquery.waypoints.min.js",
                     "~/Content/res/js/jquery.flexslider-min.js",
                     "~/Content/res/js/owl.carousel.min.js",
                     "~/Content/res/js/jquery.magnific-popup.min.js",
                     "~/Content/res/js/magnific-popup-options.js",
                     "~/Content/res/js/bootstrap-datepicker.js",
                     "~/Content/res/js/main.js",
                     "~/Content/res/js/clockpicker.js",
                     "~/Content/res/js/bootstrap-datetimepicker.min.js"));
        }
    }
}
