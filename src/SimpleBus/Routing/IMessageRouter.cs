namespace SimpleBus.Routing
{
    public interface IMessageRouter
    {
        EndPointInfo Route(object message);
    }
}