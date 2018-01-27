using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DomainLib.Context;
using DomainLib.Domain.Services;
using DomainLib.Repository;
using DomainLib.Services;
using PublisherService.Announcement.Managers;
using PublisherService.Interfaces.Announcement.Managers;

namespace AppLayer.DependencyResolvers
{
    public static class DependencyConfig
    {
        public static void ConfigContainer(Assembly[] assembly)
        {
            var builder = new ContainerBuilder();


            builder.RegisterControllers(assembly);
            builder.RegisterApiControllers(assembly);

            builder.RegisterType<EfContext>().AsSelf().InstancePerLifetimeScope();

            // Generic Repository Registration
            builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<AnnouncemenService>().As<IAnnouncemenService>().InstancePerRequest();

            //Queueis
            builder.RegisterType<AnnouncemenManager>().As<IAnnouncementManager>().SingleInstance();

            // BUILD THE CONTAINER
            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}