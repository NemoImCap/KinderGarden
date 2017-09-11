using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string angularAppRoot = "~/Scripts/angular/";
            const string angularVendorsRoot = "~/Assets/framework/";
            const string angularMain = "~/Scripts/angular/main/";


            //Angular init 
            bundles.Add(new ScriptBundle("~/Angular/").Include(angularVendorsRoot + "angular/angular.min.js")
                .Include(angularVendorsRoot + "angular-ui-bs/ui-bootstrap-2.5.0.min.js")
                .IncludeDirectory(angularVendorsRoot, "*.js", true));
            bundles.Add(new ScriptBundle("~/AngularApp/").IncludeDirectory(angularMain, "*.js", true));
            bundles.Add(new ScriptBundle("~/AngularScript/")
                .IncludeDirectory(angularAppRoot + "common/", "*.js", true)
                .IncludeDirectory(angularAppRoot + "controllers/", "*.js", true));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/animate.min.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}