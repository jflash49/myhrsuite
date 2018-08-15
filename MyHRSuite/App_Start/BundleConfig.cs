using System.Web;
using System.Web.Optimization;

namespace MyHRSuite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/assets/js/vendor/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/plugins.js",
                      "~/Scripts/main.js",
                     
  
                     "~/Scripts/popper.min.js",
                     "~/Scripts/selectFx.min.js",
                     "~/Scripts/widget.js",
                     "~/Scripts/lib/chart-js/Chart.bundle.js",
                    "~/Scripts/dashboard.js",
                    "~/Scripts/widgets.js",
                    "~/Scripts/lib/vector-map/jquery.vmap.js",
                    "~/Scripts/lib/vector-map/jquery.vmap.min.js",
                    "~/Scripts/lib/vector-map/jquery.vmap.sampledata.js" ,
                    "~/Scripts/lib/vector-map/country/jquery.vmap.world.js")
                      
                      );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/animate.css",
                      "~/Content/assets/css/normalize.css" ,
                        "~/Content/assets/css/bootstrap.min.css" ,
                        "~/Content/assets/css/font-awesome.min.css" ,
                        "~/Content/assets/css/themify-icons.css",
                        "~/Content/assets/css/flag-icon.min.css",
                        "~/Content/assets/css/cs-skin-elastic.css",
                        "~/Content/assets/scss/style.css",
                        "~/Content/assets/css/lib/vector-map/jqvmap.min.css" 
                      ));
        }
    }
}
