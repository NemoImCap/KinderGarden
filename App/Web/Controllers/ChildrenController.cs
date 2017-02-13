using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ChildrenController : Controller
    {
        // GET: Children
        public ActionResult Children()
        {
            return View();
        }

        public ActionResult CreateChild()
        {
            return PartialView();
        }

        public ActionResult UpdateChild()
        {
            return PartialView();
        }

        public ActionResult GetChildren(int gartenId)
        {
            return View();
        }
    }
}