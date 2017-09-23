using System.IO;
using System.Text;
using System.Threading;
using DomainLib.Domain.Services;
using PublisherService.Interfaces.Consumer;
using PublisherService.Interfaces.Consumer.Managers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PublisherService.Announcement.Models
{
    public class AnnouncemenConsumer : ConsumerBase, IAnnouncemenConsumerManager
    {
        private readonly IAnnouncemenService _announcemenService;

        public AnnouncemenConsumer(IAnnouncemenService announcemenService) : base("localhost", "announcemen")
        {
            _announcemenService = announcemenService;
        }

        public override void OnReciveMessageFromQueue()
        {
            var factory = new ConnectionFactory {HostName = HostName};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(QueueName,
                        true,
                        false,
                        false,
                        null);
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(QueueName, true, consumer);

                }
            }
        }

        public void ReciveMessage()
        {
            OnReciveMessageFromQueue();
        }

        //private void OnRecive(object model, BasicDeliverEventArgs args)
        //{
        //    var body =  args.Body;

        //    var message = Encoding.UTF8.GetString(body);
        //    //_announcemenService.CreateAnnouncemen(message);
        //    var file = new StreamWriter("c:\\likes.txt", true);
        //    file.WriteLine(message);

        //    file.Close();
        //    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        //}
    }
}