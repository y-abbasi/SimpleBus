namespace SimpleBus.Settings.PubSub
{
    public interface IPublishSubscribeServiceProvider
    {
        IPublishSubscribeService Provide();
    }
}