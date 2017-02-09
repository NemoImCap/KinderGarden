using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Web.App_Start;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Дополнительные сведения о настройке приложения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigContainer.Configure();
        }
    }
}
