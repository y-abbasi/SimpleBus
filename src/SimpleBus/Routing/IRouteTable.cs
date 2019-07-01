using System.Collections.Generic;

namespace SimpleBus.Routing
{
    public interface IRouteTable
    {
        void Register(List<string> subjects, EndPointInfo entry);
        void UnRegister(List<string> subjects, EndPointInfo entry);
        EndPointInfo Map(string subject);
    }
}