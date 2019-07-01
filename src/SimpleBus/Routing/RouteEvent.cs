using System.Collections.Generic;

namespace SimpleBus.Routing
{
    public class RouteEvent
    {
        public EndPointInfo EndPointInfo { get; set; }
        public List<string> Subjects { get; set; }
        public RouteEventAction Action { get; set; }
    }
}