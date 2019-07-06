#region

using System;
using System.Configuration;
using SimpleBus.Config;

#endregion

namespace SimpleBus.Settings.PubSub
{
    public sealed class PublishSubscribeServiceDefaultProvider : IDefaultProviderConfigurator<IPublishSubscribeService>
    {
        public void Config(ServiceProviderConfigurator<IPublishSubscribeService> providerConfigurator)
        {
            var config = ConfigurationFactory.Create();
            providerConfigurator.As<RabbitMqPublishSubscribeServiceProvider>(provider => provider
                    .WithServer(config.RabbitMq.Server)
                    .LogOnWith(config.RabbitMq.UserName, config.RabbitMq.Password))
                .WithLifeStyle(LifeStyle.Singleton);
        }
    }
}