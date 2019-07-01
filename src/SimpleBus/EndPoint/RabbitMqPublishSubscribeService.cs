using System;
using SimpleBus.Settings;
using SimpleBus.Settings.PubSub;

namespace SimpleBus.EndPoint
{
    internal class RabbitMqPublishSubscribeService : IPublishSubscribeService
    {
        public RabbitMqPublishSubscribeService(string server, string userName, string password)
        {
            
        }
        public void Publish<T>(string subject, T message)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T>(string subject, Action<T> handler)
        {
            throw new NotImplementedException();
        }
    }
}