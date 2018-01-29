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

        public ActionResult UpdateKindergarten()
        {
            return PartialView();
        }
    }
}