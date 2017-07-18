using de.efsdev.wsapm.OpenNetworkConnections.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wsapm.Extensions;

namespace de.efsdev.wsapm.OpenNetworkConnections.View
{
    // This is the UI class of your plugin (in this case, it is a WPF UserControl).
    // It only has to implement the interface IWsapmPluginSettingsControl.

    /// <summary>
    /// Interaktionslogik für PluginView.xaml
    /// </summary>
    public partial class PluginView : UserControl, IWsapmPluginSettingsControl
    {
        public PluginView()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.PluginViewModel;
        }

        public object GetSettingsBeforeSave()
        {
            // Build up a new instance of your settings class here 
            // and fill it with the elements from your UI.
            return ViewModelLocator.PluginViewModel.Settings;
        }

        public void SetSettings(object settings)
        {
            // In this method, the current settings of your plugin gets injected.
            // Use this method to initialize the UI, i.e. filling the UI elements from the current settings.
            ViewModelLocator.PluginViewModel.SetSettingsFromObject(settings);
        }
    }
}
