using de.efsdev.wsapm.OpenNetworkConnections;
using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenNetworkConnectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new PluginSettings();
            settings.NetworkConnectionRules = new List<NetworkConnectionRule>() {
                new NetworkConnectionRule() { LocalPort = "443" },
                new NetworkConnectionRule() { RemotePort = "443" }
            };

            XmlSerializer xmlSerializer = new XmlSerializer(settings.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, settings);
                var serialized = textWriter.ToString();
                Debugger.Break();
            }

            var activeConnections = NetworkConnectionsHelper.GetActiveTCPConnections();

            var matchedConnections = new List<NetworkConnectionRule>();

            foreach (var activeConnection in activeConnections)
            {
                foreach (var rule in settings.NetworkConnectionRules)
                {
                    if (rule.Matches(activeConnection))
                    {
                        Debugger.Break();
                    }
                }
            }

            Debugger.Break();
        }
    }
}
