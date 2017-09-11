using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using AppLayer;

namespace Headquarter.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            DependencyConfig.ConfigContainer(assemblies);
        }
    }
}