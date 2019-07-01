namespace SimpleBus.EndPoint
{
    public interface IPublishSubscribeServiceBuilder
    {
        IPublishSubscribeService<T> Build<T>();
    }
}