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
        public ActionResult Children(int? id)
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
    }
}