using System;
using System.Collections;

namespace SimpleBus.EndPoint
{
    public class OneWayEndPointConfig
    {
        public TimeSpan Timeout { get; set; }
        public bool IncludeException { get; set; }
    }
}