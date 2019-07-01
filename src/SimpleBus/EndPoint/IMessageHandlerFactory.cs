using SimpleBus.Messaging;

namespace SimpleBus.EndPoint
{
    public interface IMessageHandlerFactory
    {
        IQueryHandler<T1, T2> CreateQueryHandler<T1, T2>();
        ICommandHandler<T> CreateCommandHandler<T>();
        IEventHandler<T> CreateEventHandler<T>();
    }
}