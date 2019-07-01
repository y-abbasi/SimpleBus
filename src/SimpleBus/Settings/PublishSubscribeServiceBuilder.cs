#region

using System;

#endregion

namespace SimpleBus.Settings
{
    public class PublishSubscribeServiceBuilder
    {
        private Action<object> configurator;
        private Func<IPublishSubscribeServiceProvider> providerCreator;

        private PublishSubscribeServiceBuilder()
        {
            builder = () =>
            {
                var provider = providerCreator();
                configurator(provider);
                return provider.Provide();
            };
        }

        static PublishSubscribeServiceBuilder()
        {
            Instance = new PublishSubscribeServiceBuilder();
            Instance.WithProvider<RabbitMqPublishSubscribeServiceProvider>(
                provider => provider.WithServer("server")
                                    .LogOnWith("user", "pass"));
        }

        public static PublishSubscribeServiceBuilder Instance { get; }

        public PublishSubscribeServiceBuilder WithProvider<T>(Action<T> configurator)
            where T : class, IPublishSubscribeServiceProvider, new()
        {
            this.configurator = o => configurator((T) o);
            this.providerCreator = () => new T();
            return this;
        }

        private Func<IPublishSubscribeService> builder;

        public IPublishSubscribeService Build()
        {
            var service = builder();
            builder = () => service;
            return service;
        }
    }
}