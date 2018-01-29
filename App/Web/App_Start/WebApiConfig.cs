using System.Web.Http;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "app-api/{controller}/{action}/{id}",
                new {id = RouteParameter.Optional}
            );

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}