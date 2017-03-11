using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Security.AntiXss;
using AutoMapper;
using Web.Models;

namespace Web.Areas.Api.Controllers
{
    public class ChildrenController : ApiController
    {
        private readonly IChildService _childService;
        private readonly IKindergardenService _kindergardenService;
        //private readonly IMapper mapper;

        public ChildrenController(IChildService childService, IKindergardenService kindergardenService)
        {
            _childService = childService;
            _kindergardenService = kindergardenService;
        }

        [HttpPost]
        public IHttpActionResult CreateChild([FromBody] ChildModel model)
        {
            if (model == null)
            {
                return BadRequest("Send correct request model");
            }

            var entity = new Child
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Age = model.Age,
            };
            if (model.GartenId > 0)
            {
                var gartend = _kindergardenService.GetKindergardenById(model.GartenId);
                entity.Kindergarden = gartend;
            }
            _childService.AddChild(entity);
            return Ok(entity);
        }

        [HttpPost]
        public IHttpActionResult DeleteChild([FromBody] int id)
        {
            var child = _childService.GetChildById(id);
            if (child == null) return BadRequest("No entity found");
            _childService.DeleteChild(child);
            return Ok("Child Deleted");
        }

        [HttpPost]
        public IHttpActionResult UpdateChild([FromBody] ChildModel model)
        {
            var entity = _childService.GetChildById(model.Id);
            if (entity == null) return BadRequest("No entity found");
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.MiddleName = model.MiddleName;
            entity.Age = model.Age;
            if (model.GartenId > 0)
            {
                var garten = _kindergardenService.GetKindergardenById(model.GartenId);
                entity.Kindergarden = garten;
                model.Kindergarden = garten;
            }
            _childService.UpdteChild(entity);
            //var mapped = mapper.Map<ChildModel, Child>(model);
            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetChildren([FromUri] int? gartenId, int? gartenNumber, string search = "", int age = 0, int page = 1)
        {
            var result = _childService.GetChildren(gartenId, gartenNumber, age, search, page);
            var mapped = Mapper.Map<IEnumerable<Child>, List<ChildModel>>(result);
            return Ok(mapped);
        }
    }
}
