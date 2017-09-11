using AutoMapper;
using Web.Models;

namespace Web
{
    public class MapperContainer
    {
        public void InitMap()
        {
        }

        protected internal void InitMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Child, ChildModel>()
                .ForMember("Combine", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName)));
        }
    }
}