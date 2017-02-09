using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DomainLib.Context;
using DomainLib.Repository;
using DomainLib.Services;

namespace Web.App_Start
{
    public static class ConfigContainer
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<EfContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<EfContext>().AsSelf().InstancePerLifetimeScope();

            // Generic Repository Registration
            builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<KindergardernService>().As<IKindergardenService>().InstancePerRequest();
            builder.RegisterType<ChildService>().As<IChildService>().InstancePerRequest();

            // BUILD THE CONTAINER
            var container = builder.Build();

 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}