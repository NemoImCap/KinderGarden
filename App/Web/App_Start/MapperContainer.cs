using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.App_Start
{
    public class MapperContainer : Module
    {
        public void InitMap() {
            //Mapper.Initialize(cfg => cfg.CreateMap<Child, ChildModel>());
        }

        protected override void Load(ContainerBuilder builder)
        {

            ////register all profile classes in the calling assembly
            //builder.RegisterAssemblyTypes(typeof(Module).Assembly).As<Profile>();

            //builder.Register(context => new MapperConfiguration(cfg =>
            //{
            //    foreach (var profile in context.Resolve<IEnumerable<Profile>>())
            //    {
            //        cfg.AddProfile(profile);
            //    }
            //})).AsSelf().SingleInstance();

            //builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
            //    .As<IMapper>()
            //    .InstancePerLifetimeScope();
        }

        protected internal void InitMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Child, ChildModel>().ForMember("Combine", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName)));
        }
    }
}