namespace SimpleBus.Routing
{
    public class EndPointInfo
    {
        public string AppName { get; set; }
        public string Server { get; set; }
        public string Address { get; set; }
        public bool IsMaster { get; set; }
        public EndPointType EndPointType { get; set; }
        public string Protocol { get; set; }
        public string ProtocolSetting { get; set; }
    }
}