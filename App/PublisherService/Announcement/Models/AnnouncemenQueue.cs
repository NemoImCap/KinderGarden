using PublisherService.Interfaces.Queues;
using PublisherService.Interfaces.Queues.Managers;

namespace PublisherService.Announcement.Models
{
    public class AnnouncemenQueue : IQueuePublishManager
    {
        public void PublishQueue()
        {
            var bus = new QueueBase();
            bus.CreateQueue("TestMessage");
        }
    }
}