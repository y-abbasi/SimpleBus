namespace SimpleBus.EndPoint
{
    public interface IBusBuilder
    {
        IBusBuilder WithRedisServer(string connectionString);
        IBus Build();
    }
}