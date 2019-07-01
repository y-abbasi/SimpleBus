namespace SimpleBus.Settings
{
    public interface IPublishSubscribeServiceProvider
    {
        IPublishSubscribeService Provide();
    }
}