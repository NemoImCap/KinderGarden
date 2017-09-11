using System.Web.Http;
using PublisherService.Interfaces.Announcement.Managers;

namespace Headquarter.WebApi.Controllers
{
    public class AnnouncementController : ApiController
    {
        private readonly IAnnouncementManager _announcementManager;

        public AnnouncementController(IAnnouncementManager announcementManager)
        {
            this._announcementManager = announcementManager;
        }

        [HttpGet]
        public IHttpActionResult PublishMessage()
        {
            _announcementManager.Publish();
            return Ok("Published");
        }
    }
}