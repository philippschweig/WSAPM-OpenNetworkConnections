using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.AOP.ViewModelProxy
{
    public class ViewModelProxyList<TViewModel, TProxyModel> : List<TViewModel>
        where TViewModel : IViewModelProxy<TProxyModel>
    {
        private IList<TProxyModel> ProxyModelList;

        public ViewModelProxyList(IList<TProxyModel> proxyModelList)
        {
            ProxyModelList = proxyModelList;
        }

        public new void Add(TViewModel item)
        {
            ProxyModelList.Add(item.ProxyModel);
            base.Add(item);
        }
    }
}
