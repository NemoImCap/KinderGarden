using System;
using EasyNetQ;
using Messages;

namespace PublisherService.Interfaces.Queues
{
    public class QueueBase
    {
        public void CreateQueue(string message)
        {
            try
            {
                using (var bus = RabbitHutch.CreateBus("host=localhost"))
                {
                    //bus.Publish(new TextMessage {Text = message});
                    bus.Send("my.queue", message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}