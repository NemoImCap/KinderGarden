using System.Web.Mvc;
using PublisherService.Interfaces.Consumer.Managers;

namespace Web.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly IAnnouncemenConsumerManager _consumerManager;

        public ChildrenController(IAnnouncemenConsumerManager consumerManager)
        {
            _consumerManager = consumerManager;
        }

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