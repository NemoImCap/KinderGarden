using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            const string ANGULAR_APP_ROOT = "~/Scripts/angular/";
            const string ANGULAR_VENDORS_ROOT = "~/Assets/framework/";
            const string ANGULAR_MAIN = "~/Scripts/angular/main/";


            //Angular init 
            bundles.Add(new ScriptBundle("~/Angular/").Include(ANGULAR_VENDORS_ROOT + "angular/angular.min.js").IncludeDirectory(ANGULAR_VENDORS_ROOT, "*.js", searchSubdirectories: true));
            bundles.Add(new ScriptBundle("~/AngularApp/").IncludeDirectory(ANGULAR_MAIN, "*.js", searchSubdirectories: true));
            bundles.Add(new ScriptBundle("~/AngularScript/")
                .IncludeDirectory(ANGULAR_APP_ROOT + "common/", "*.js", searchSubdirectories: true)
                .IncludeDirectory(ANGULAR_APP_ROOT + "controllers/", "*.js", searchSubdirectories: true));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/animate.min.css",
                    "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

        }
    }
}