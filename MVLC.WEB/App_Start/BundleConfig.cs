using System.Web;
using System.Web.Optimization;

namespace MVLC.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJQuery").Include(
                       "~/Scripts/Custom/DynamicDiv.js",
                       "~/Scripts/Custom/SharedUtility.js",
                       "~/Scripts/Custom/DropDownDiv.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css", "~/Content/grid.css",
                      "~/Content/bootstrap.css", "~/Content/DynamicDiv.css",
                      "~/Content/CustomCss/Colors.css", "~/Content/site.css"));
        }
    }
}
