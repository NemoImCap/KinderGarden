using System.IO;
using System.Text;
using PublisherService.Interfaces.Consumer;
using PublisherService.Interfaces.Consumer.Managers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PublisherService.Announcement.Models
{
    public class AnnouncemenConsumer : ConsumerBase, IConsumerManager
    {
        public AnnouncemenConsumer() : base("localhost", "announcemen")
        {
        }

        public void ReciveMessage()
        {
            var factory = new ConnectionFactory {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("announcemen",
                        false,
                        false,
                        false,
                        null);
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        var file = new StreamWriter("c:\\likes.txt", true);
                        file.WriteLine(message);

                        file.Close();
                    };
                    channel.BasicConsume("announcemen", true, consumer);
                }
            }
        }
    }
}