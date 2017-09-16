using System.Web.Mvc;
using PublisherService.Interfaces.Consumer.Managers;

namespace Web.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly IConsumerManager _consumerManager;

        public ChildrenController(IConsumerManager consumerManager)
        {
            this._consumerManager = consumerManager;
        }

        // GET: Children
        public ActionResult Children()
        {
            _consumerManager.ReciveMessage();
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