using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Library
{
    public class GenericEventArgs<TData> : EventArgs
    {
        public TData EventData { get; set; }

        public GenericEventArgs() { }

        public GenericEventArgs(TData eventData)
        {
            EventData = eventData;
        }
    }
}
