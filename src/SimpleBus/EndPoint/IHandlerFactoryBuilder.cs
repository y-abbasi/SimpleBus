namespace SimpleBus.EndPoint
{
    public interface IHandlerFactoryBuilder
    {
        void WithMessageHandlerFactory(IMessageHandlerFactory messageHandlerFactory);
    }
}