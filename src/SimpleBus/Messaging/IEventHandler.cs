namespace SimpleBus.Messaging
{
    public interface IEventHandler<in T>
    {
        void Handle(T message, MessageContext context);
    }
}