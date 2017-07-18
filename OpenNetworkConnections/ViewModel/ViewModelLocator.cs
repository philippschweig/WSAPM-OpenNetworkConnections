using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class ViewModelLocator
    {
        private static PluginViewModel _pluginvm;
        public static PluginViewModel PluginViewModel
        {
            get
            {
                if (_pluginvm == null)
                {
                    _pluginvm = new PluginViewModel();
                }

                return _pluginvm;
            }
        }
    }
}
