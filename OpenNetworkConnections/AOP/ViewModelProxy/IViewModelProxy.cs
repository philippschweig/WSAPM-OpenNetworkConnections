using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.AOP.ViewModelProxy
{
    public interface IViewModelProxy<T>
    {
        T ProxyModel { get; }
    }
}
