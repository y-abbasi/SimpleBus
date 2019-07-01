using SimpleBus.EndPoint;

namespace SimpleBus.Settings
{
    internal class RabbitMqPublishSubscribeServiceProvider : IPublishSubscribeServiceProvider
    {
        private string server;
        private string userName;
        private string password;

        public IPublishSubscribeService Provide()
        {
            return new RabbitMqPublishSubscribeService(server, userName, password);
        }

        public RabbitMqPublishSubscribeServiceProvider WithServer(string server)
        {
            this.server = server;
            return this;
        }

        public RabbitMqPublishSubscribeServiceProvider LogOnWith(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            return this;
        }
    }
}