using System.Text;
using RabbitMQ.Client;

namespace PublisherService.Interfaces.Queues
{
    public abstract class QueueBase
    {
        private string HostName { get; }
        private string QueueName { get; }
        protected QueueBase(string queueName, string hostName)
        {
            QueueName = queueName;
            HostName = hostName;
        }

        protected void CreateQueue(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = HostName
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.QueueDeclare(queue: QueueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: QueueName,
                        basicProperties: properties,
                        body: body);
                }
            }
        }
    }
}