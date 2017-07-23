using de.efsdev.wsapm.OpenNetworkConnections.AOP;
using de.efsdev.wsapm.OpenNetworkConnections.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Serialization;

namespace de.efsdev.wsapm.OpenNetworkConnections.Model
{
    public interface INetworkConnectionRule : INetworkConnection
    {
        bool Enabled { get; }
    }

    [Serializable]
    [ObservableObject]
    public class NetworkConnectionRule : ObservableObject, INetworkConnectionRule
    {
        #region INetworkConnection
        public string LocalAddress { get; set; }

        public string LocalPort { get; set; }

        public string RemoteAddress { get; set; }

        public string RemotePort { get; set; }

        public TcpState? State { get; set; }

        public bool Enabled { get; set; }
        #endregion

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

            if (matches.Count == 0)
            {
                return false;
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
