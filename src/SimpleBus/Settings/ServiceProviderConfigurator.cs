using System;

namespace SimpleBus.Config
{
    public class ServiceProviderConfigurator<T>
    {
        private readonly Module module;
        private IServiceProviderDecorator<T> decorateWith;

        internal ServiceProviderConfigurator(Module module)
        {
            this.module = module;
        }
        public ServiceProviderConfigurator<T> As<T1>(Action<T1> configurator) where T1 : IServiceProvider<T>, new()
        {
            var provider = new T1();
            Register(provider);
            configurator(provider);
            return this;
        }

        private void Register<T1>(T1 provider) where T1 : IServiceProvider<T>, new()
        {
            if (decorateWith != null)
            {
                decorateWith.SeDecoratee(provider);
                module.Register(decorateWith);
            }
            else
                module.Register(provider);
        }

        public ServiceProviderConfigurator<T> WithLifeStyle(LifeStyle lifeStyle)
        {
            decorateWith = LifeStyleDecoratorFactory.Create<T>(lifeStyle);
            return this;
        }
    }
}