namespace PublisherService.Interfaces.Announcement.Managers
{
    public interface IAnnouncementManager
    {
        void Publish();

        string Receive();
    }
}