using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace de.efsdev.wsapm.OpenNetworkConnections
{
    public class NetworkConnectionsHelper
    {
        public static IList<ActiveNetworkConnection> GetActiveTCPConnections()
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var connections = properties.GetActiveTcpConnections();
            var wrappedActiveConnections = new List<ActiveNetworkConnection>();

            foreach (var connection in connections)
            {
                wrappedActiveConnections.Add(new ActiveNetworkConnection(connection));
            }

            return wrappedActiveConnections;
        }


    }
}
