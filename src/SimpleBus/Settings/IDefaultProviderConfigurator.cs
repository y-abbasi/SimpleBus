using SimpleBus.Config;

namespace SimpleBus.Settings.PubSub
{
    public interface IDefaultProviderConfigurator<T>
    {
        void Config(ServiceProviderConfigurator<T> configurator);
    }
}