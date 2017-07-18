using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Model
{
    public interface INetworkConnection
    {
        string LocalAddress { get; }
        string LocalPort { get; }
        string RemoteAddress { get; }
        string RemotePort { get; }
        TcpState? State { get; }
    }

    public static class INetworkConnectionExtensions
    {
        
    }
}
