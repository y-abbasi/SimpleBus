using System;

namespace SimpleBus.EndPoint.OneWay
{
    public interface IOneWayEndPointConfigurator
    {
        IOneWayEndPointConfigurator WithTimeout(TimeSpan timeout);
        IOneWayEndPointConfigurator Include(bool includeException = true);
        OneWayEndPointConfig Build();
    }
}