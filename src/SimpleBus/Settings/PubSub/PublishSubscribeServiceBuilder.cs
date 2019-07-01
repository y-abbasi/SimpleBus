#region

using System;
using System.Configuration;
using SimpleBus.Config;

#endregion

namespace SimpleBus.Settings.PubSub
{
    public sealed class PublishSubscribeServiceBuilder
    {
        private Action<object> configurator;
        private Func<IPublishSubscribeServiceProvider> providerCreator;
        private Func<IPublishSubscribeService> builder;

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
            var config = ConfigurationFactory.Create();
            Instance = new PublishSubscribeServiceBuilder();
            Instance.WithProvider<RabbitMqPublishSubscribeServiceProvider>(
                provider => provider.WithServer(config.RabbitMq.Server)
                                    .LogOnWith(config.RabbitMq.UserName, config.RabbitMq.Password));
        }

        public static PublishSubscribeServiceBuilder Instance { get; }

        public PublishSubscribeServiceBuilder WithProvider<T>(Action<T> configurator)
            where T : class, IPublishSubscribeServiceProvider, new()
        {
            this.configurator = o => configurator((T)o);
            this.providerCreator = () => new T();
            return this;
        }


        public IPublishSubscribeService Build()
        {
            var service = builder();
            builder = () => service;
            return service;
        }
    }
}