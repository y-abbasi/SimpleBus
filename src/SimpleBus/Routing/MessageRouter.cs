using SimpleBus.EndPoint;

namespace SimpleBus.Routing
{
    class MessageRouter : IMessageRouter
    {
        private readonly IPublishSubscribeService<RouteEvent> pubSubService;
        private readonly IRouteTable routeTable;
        private const string EndPointStartedEventName = "endpoint.started.event";
        private const string EndPointStoppedEventName = "endpoint.stoped.event";
        public MessageRouter(IPublishSubscribeServiceBuilder pubSubServiceFactory, IRouteTable routeTable)
        {
            this.pubSubService = pubSubServiceFactory.Build<RouteEvent>();
            this.routeTable = routeTable;
            pubSubService.Subscribe(EndPointStartedEventName, EndPointStarted);
            pubSubService.Subscribe(EndPointStoppedEventName, EndPointStopped);
        }

        private void EndPointStarted(RouteEvent obj)
        {
            routeTable.Register(obj.Subjects, obj.EndPointInfo);
        }

        private void EndPointStopped(RouteEvent obj)
        {
            routeTable.UnRegister(obj.Subjects, obj.EndPointInfo);
        }

        public EndPointInfo Route(object message)
        {
            return routeTable.Map(message.GetType().FullName);
        }

    }
}