using PublisherService.Announcement.Models;
using PublisherService.Interfaces.Announcement.Managers;

namespace PublisherService.Announcement.Managers
{
    public class AnnouncemenManager : IAnnouncementManager
    {
        public void PublishAnnouncementQueue()
        {
            var announcemenQueue = new AnnouncemenQueue();
            announcemenQueue.PublishQueue();
        }
    }
}