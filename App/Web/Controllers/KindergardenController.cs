using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class KindergardenController : Controller
    {
        // GET: Kindergarden
        public ActionResult CreateKindergarden()
        {
            return PartialView();
        }

        public ActionResult Kindergartens()
        {
            return View();
        }
    }
}