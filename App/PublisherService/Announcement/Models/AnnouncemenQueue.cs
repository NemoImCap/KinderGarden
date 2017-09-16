using PublisherService.Interfaces.Queues;
using PublisherService.Interfaces.Queues.Managers;

namespace PublisherService.Announcement.Models
{
    public class AnnouncemenQueue : QueueBase, IQueuePublishManager
    {
        public AnnouncemenQueue() : base("announcemen", "localhost")
        {
        }

        public void PublishQueue()
        {
            CreateQueue("Hello Bill");
        }
    }
}