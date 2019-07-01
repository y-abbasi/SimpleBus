using SimpleBus.EndPoint;
using SimpleBus.Settings;
using SimpleBus.Settings.PubSub;

namespace SimpleBus.Routing
{
    class MessageRouter : IMessageRouter
    {
        private readonly IPublishSubscribeService pubSubService;
        private readonly IRouteTable routeTable;
        private const string EndPointStartedEventName = "endpoint.started.event";
        private const string EndPointStoppedEventName = "endpoint.stoped.event";
        public MessageRouter(IPublishSubscribeServiceBuilder pubSubServiceFactory, IRouteTable routeTable)
        {
            this.pubSubService = pubSubServiceFactory.Build();
            this.routeTable = routeTable;
            pubSubService.Subscribe<RouteEvent>(EndPointStartedEventName, EndPointStarted);
            pubSubService.Subscribe<RouteEvent>(EndPointStoppedEventName, EndPointStopped);
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