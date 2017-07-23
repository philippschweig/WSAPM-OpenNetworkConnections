using de.efsdev.wsapm.OpenNetworkConnections.Library;
using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class PluginViewModel : ObservableObject
    {
        private PluginSettings _settings;
        public PluginSettings Settings
        {
            get { return _settings; }
            set { SetProperty(ref _settings, value, nameof(Settings)); }
        }

        public IList<ActiveNetworkConnection> ActiveConnections => NetworkConnectionsHelper.GetActiveTCPConnections();

        public void SetSettingsFromObject(object settings)
        {
            Settings = (PluginSettings)settings;
        }

        public event EventHandler OnActiveConnectionsRefreshed;

        public ICommand DeleteRuleCommand => new RelayCommand<NetworkConnectionRule>(new Action<NetworkConnectionRule>(DeleteRuleAction));
        public ICommand AddActiveRuleCommand { get; set; }
        public ICommand RefreshActiveConnectionsCommand => new RelayCommand<object>(new Action<object>(RefreshActiveConnectionsAction));

        private void DeleteRuleAction(NetworkConnectionRule connection)
        {
            this.Settings.NetworkConnectionRules.Remove(connection);
        }

        private void RefreshActiveConnectionsAction(object data)
        {
            this.OnActiveConnectionsRefreshed(this, null);
        }
    }
}
