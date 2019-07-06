using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBus.Settings.PubSub;

namespace SimpleBus.Config
{
    public class Module
    {
        Dictionary<Type, object> map = new Dictionary<Type, object>();
        public Module Config<T>(Action<ServiceProviderConfigurator<T>> configurator) //where T : class, new()
        {

            configurator(new ServiceProviderConfigurator<T>(this));
            return this;
        }
        public Module Config<T>(Action<ServiceProviderConfigurator<T>> configurator, Func<T> creator)
        {
            return this;
        }

        internal void Register<T>(IServiceProvider<T> provider)
        {
            map[typeof(T)] = provider;
        }

        private IServiceProvider<T> GetProvider<T>()
        {
            if (map.ContainsKey(typeof(T)))
                return map[typeof(T)] as IServiceProvider<T>;
            var defaultProviderType = GetType().Assembly.GetExportedTypes()
                .SingleOrDefault(type => typeof(IDefaultProviderConfigurator<T>).IsAssignableFrom(type));
            if (defaultProviderType == null)
                throw new NotImplementedException($"no custom or default provider defined for {typeof(T)}");
            var configurator = (IDefaultProviderConfigurator<T>)Activator.CreateInstance(defaultProviderType);
            this.Config<T>(configurator.Config);
            return map[typeof(T)] as IServiceProvider<T>;
        }
        public T GetInstance<T>()
        {
            return GetProvider<T>().Provide();
        }
        public static void Test()
        {
            new Module().Config<IPublishSubscribeService>(configurator =>
                configurator.As<RabbitMqPublishSubscribeServiceProvider>()
                    .WithServer("")
                    .LogOnWith("", ""));
        }
    }
}