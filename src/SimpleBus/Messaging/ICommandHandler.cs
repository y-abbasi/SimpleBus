namespace SimpleBus.Messaging
{
    public interface ICommandHandler<in T>
    {
        void Handle(T message, MessageContext context);
    }
}