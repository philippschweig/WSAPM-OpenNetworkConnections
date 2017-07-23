using de.efsdev.wsapm.OpenNetworkConnections.AOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Library
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InvokePropertyChangedForAllProperties()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in properties)
            {
                InvokePropertyChanged(item.Name);
            }
        }

        protected bool SetProperty<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            InvokePropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
