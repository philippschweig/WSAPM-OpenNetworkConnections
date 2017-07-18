using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    [Serializable]
    public class RelayCommand<TObject> : ICommand
    {
        #region Fields
        private readonly Action<TObject> execute;
        private readonly Predicate<TObject> canExecute;
        #endregion Fields

        #region Constructors
        public RelayCommand(Action<TObject> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<TObject> execute, Predicate<TObject> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion Constructors

        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            return canExecute((TObject)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute((TObject)parameter);
        }
        #endregion ICommand Members
    }
}
