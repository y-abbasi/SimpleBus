using System;

namespace SimpleBus.Settings.PubSub
{
    public interface IPublishSubscribeService
    {
        void Publish<T>(string subject, T message);
        void Subscribe<T>(string subject, Action<T> handler);
    }
}