using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace Web.Areas.Api.Controllers
{
    public class KindergardenController : ApiController
    {
        private readonly IKindergardenService _kindergardenService;

        public KindergardenController(IKindergardenService kindergardenService)
        {
            _kindergardenService = kindergardenService;
        }

        [HttpPost]
        public IHttpActionResult CreateGarten([FromBody] Kindergarden kindergarden)
        {
            if (string.IsNullOrEmpty(kindergarden.Address) || kindergarden.Number == 0)
            {
                return BadRequest("Address and number is requeried");
            }
            var entity = new Kindergarden { Address = kindergarden.Address, Number = kindergarden.Number };
            _kindergardenService.AddKindergarden(entity);
            return Ok(entity);
        }

        [HttpGet]
        public IHttpActionResult GetKindergardens([FromUri] string search = "", int number = 0, int page = 1)
        {
            var items = _kindergardenService.GetKindergardens(search, number, page).Select(x=> new{ Id = x.Id, Address = x.Address, Number = x.Number});
            return Ok(items);
        }

        [HttpPost]
        public IHttpActionResult DeleteKindergaten([FromBody] int id)
        {
            var item = _kindergardenService.GetKindergardenById(id);
            if (item == null) return BadRequest("Kindergarten not found");
            _kindergardenService.DeleteKindergarden(item);
            return Ok("Kindergarten was deleted successfully");
        }
        [HttpPost]
        public IHttpActionResult UpdateKindergarten([FromBody] Kindergarden kindergarden)
        {
            var entity = _kindergardenService.GetKindergardenById(kindergarden.Id);
            if (entity == null) return BadRequest("Kindergarten not found");
            entity.Address = kindergarden.Address;
            entity.Number = kindergarden.Number;
            _kindergardenService.UpdateKindergarden(entity);
            return Ok(kindergarden);
        }
    }
}
