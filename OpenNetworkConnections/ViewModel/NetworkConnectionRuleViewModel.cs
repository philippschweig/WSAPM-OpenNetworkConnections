using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class NetworkConnectionRuleViewModel : INetworkConnection
    {
        private NetworkConnectionRule Rule;

        public string LocalAddress
        {
            get
            {
                return Rule.LocalAddress;
            }
            set
            {
                Rule.LocalAddress = value;
            }
        }

        public string LocalPort => throw new NotImplementedException();

        public string RemoteAddress => throw new NotImplementedException();

        public string RemotePort => throw new NotImplementedException();

        public TcpState? State => throw new NotImplementedException();
    }
}
