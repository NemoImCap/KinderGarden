using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKindergardenService _kindergardenService;

        public HomeController(IKindergardenService kindergardenService)
        {
            _kindergardenService = kindergardenService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}