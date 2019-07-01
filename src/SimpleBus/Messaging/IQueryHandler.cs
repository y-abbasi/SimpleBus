namespace SimpleBus.Messaging
{
    public interface IQueryHandler<in T1, out T2>
    {
        T2 Handle(T1 message, MessageContext context);
    }
}