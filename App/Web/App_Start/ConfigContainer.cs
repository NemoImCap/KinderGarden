using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using DomainLib.Context;
using DomainLib.Repository;

namespace Web.App_Start
{
    public static class ConfigContainer
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EfContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<EfContext>().AsSelf().InstancePerLifetimeScope();

            // Generic Repository Registration
            builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }
    }
}