using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
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
           

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<EfContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<EfContext>().AsSelf().InstancePerLifetimeScope();

            // Generic Repository Registration
            builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<KindergardernService>().As<IKindergardenService>().InstancePerRequest();
            builder.RegisterType<ChildService>().As<IChildService>().InstancePerRequest();

            //builder.RegisterModule(new MapperContainer());
            // BUILD THE CONTAINER
            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}