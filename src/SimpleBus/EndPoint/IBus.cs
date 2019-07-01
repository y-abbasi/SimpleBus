namespace SimpleBus.EndPoint
{
    public interface IBus
    {
        T2 Query<T1, T2>(T1 message);
        void Execute<T>(T message);
        void Publish<T>(T message);
    }
}