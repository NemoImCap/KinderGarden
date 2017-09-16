namespace PublisherService.Interfaces.Consumer
{
    public abstract class ConsumerBase
    {
        protected ConsumerBase(string hostName, string queueName)
        {
            HostName = hostName;
            QueueName = queueName;
        }

        private string HostName { get; }
        private string QueueName { get; }
    }
}