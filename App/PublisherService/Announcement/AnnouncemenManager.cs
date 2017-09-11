using System.Text;
using PublisherService.Interfaces.Announcement.Managers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PublisherService.Announcement
{
    public class AnnouncemenManager : IAnnouncementManager
    {
        public void Publish()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "announcemen", 
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                }
            }
        }

        public string Receive()
        {
            var message = "";
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "announcemen",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        message = Encoding.UTF8.GetString(body);
                    };
                    channel.BasicConsume(queue: "announcemen", autoAck: true, consumer: consumer);

                }
            }
            return message;
        }
    }
}