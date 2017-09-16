namespace PublisherService.Interfaces.Consumer
{
    public abstract class ConsumerBase
    {
        protected ConsumerBase(string hostName, string queueName)
        {
            HostName = hostName;
            QueueName = queueName;
        }

        public string HostName { get; }
        public string QueueName { get; }

        public abstract void OnReciveMessageFromQueue();
    }
}