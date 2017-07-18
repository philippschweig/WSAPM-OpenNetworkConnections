using de.efsdev.wsapm.OpenNetworkConnections.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Serialization;

namespace de.efsdev.wsapm.OpenNetworkConnections.Model
{
    [Serializable]
    public class NetworkConnectionRule : ObservableObject, INetworkConnection
    {
        private string _localAddress;
        public string LocalAddress
        {
            get { return _localAddress; }
            set { SetProperty(ref _localAddress, value, nameof(LocalAddress)); }
        }

        private string _localPort;
        public string LocalPort
        {
            get { return _localPort; }
            set { SetProperty(ref _localPort, value, nameof(LocalPort)); }
        }

        private string _remoteAddress;
        public string RemoteAddress
        {
            get { return _remoteAddress; }
            set { SetProperty(ref _remoteAddress, value, nameof(RemoteAddress)); }
        }

        private string _remotePort;
        public string RemotePort
        {
            get { return _remotePort; }
            set { SetProperty(ref _remotePort, value, nameof(RemotePort)); }
        }

        private TcpState? _state;
        public TcpState? State
        {
            get { return _state; }
            set { SetProperty(ref _state, value, nameof(State)); }
        }

        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value, nameof(Enabled)); }
        }

        public bool Matches(INetworkConnection obj)
        {
            var matches = new List<bool>();

            if (!string.IsNullOrEmpty(this.LocalAddress))
            {
                matches.Add(this.LocalAddress.Equals(obj.LocalAddress));
            }

            if (!string.IsNullOrEmpty(this.LocalPort))
            {
                matches.Add(this.LocalPort.Equals(obj.LocalPort));
            }

            if (!string.IsNullOrEmpty(this.RemoteAddress))
            {
                matches.Add(this.RemoteAddress.Equals(obj.RemoteAddress));
            }

            if (!string.IsNullOrEmpty(this.RemotePort))
            {
                matches.Add(this.RemotePort.Equals(obj.RemotePort));
            }

            if (this.State != null)
            {
                matches.Add(this.State.Equals(obj.State));
            }

            foreach (var match in matches)
            {
                if (!match)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
