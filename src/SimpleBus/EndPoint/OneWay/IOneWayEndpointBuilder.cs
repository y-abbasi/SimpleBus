using System;

namespace SimpleBus.EndPoint.OneWay
{
    public interface IOneWayEndpointBuilder
    {
        void Configure(Action<IOneWayEndPointConfigurator> configurator);
    }
}