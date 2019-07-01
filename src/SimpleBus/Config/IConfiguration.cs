namespace SimpleBus.Config
{
    public interface IConfiguration
    {
        RabbitMqConfig RabbitMq { get; }
    }
}