using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Model
{
    public class ActiveNetworkConnection : INetworkConnection
    {
        private TcpConnectionInformation Connection { get; set; }

        public string LocalAddress => Connection.LocalEndPoint.Address.ToString();

        public string LocalPort => Connection.LocalEndPoint.Port.ToString();

        public string RemoteAddress => Connection.RemoteEndPoint.Address.ToString();

        public string RemotePort => Connection.RemoteEndPoint.Port.ToString();

        public TcpState? State => Connection.State;

        public ActiveNetworkConnection(TcpConnectionInformation connection)
        {
            this.Connection = connection;
        }
    }
}
