using System;

namespace SimpleBus.EndPoint
{
    public interface IPublishSubscribeService<T>
    {
        void Publish(string subject, T message);
        void Subscribe(string subject, Action<T> handler);
    }
}