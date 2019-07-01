using System;
using System.Collections.Generic;
using SimpleBus.EndPoint.OneWay;

namespace SimpleBus.EndPoint
{
    public interface IEndPointScannerBuilder
    {
        IOneWayEndpointBuilder With(IEnumerable<Type> types);
    }
}