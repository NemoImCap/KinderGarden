using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        public IHttpActionResult CreateKindergarden([FromUri] string id)
        {
            return Json("Hello");
        }
    }
}
