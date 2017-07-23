using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using de.efsdev.wsapm.OpenNetworkConnections.AOP.ViewModelProxy;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class NetworkConnectionRuleViewModel : INetworkConnectionRule, IViewModelProxy<NetworkConnectionRule>
    {
        public NetworkConnectionRule ProxyModel { get; private set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string LocalAddress { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string LocalPort { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string RemoteAddress { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string RemotePort { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public TcpState? State { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public bool Enabled { get; set; }

        public IList<INetworkConnection> ApplicableConnections { get; set; }

        private int _applicableConnectionsCount = 0;
        private DateTime _lastApplicableConnectionsCountCalculation;
        public int ApplicableConnectionsCount => CalculateApplicableConnectionsCount();

        public NetworkConnectionRuleViewModel() : this(new NetworkConnectionRule()) { }

        public NetworkConnectionRuleViewModel(NetworkConnectionRule rule)
        {
            ProxyModel = rule;
        }

        private int CalculateApplicableConnectionsCount()
        {
            //if (DateTime.Now.Subtract(_lastAppliedConnectionsCountCalculation).TotalMinutes < 1)
            //{
            //    return _appliedConnectionsCount;
            //}

            _lastApplicableConnectionsCountCalculation = DateTime.Now;

            return _applicableConnectionsCount = PluginHelper.CalculateMatchedConnections(ProxyModel);
        }
    }
}
