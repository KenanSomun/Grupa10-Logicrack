using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoFly.Helper
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteMethod;
        private readonly Action<T> _executeMethod;

        public RelayCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }


        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            try
            {
                return CanExecute((T)parameter);
            }
            catch { return false; }
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }
        public bool CanExecute(T parameter)
        {
            return ((_canExecuteMethod == null) || _canExecuteMethod(parameter));
        }

        public void Execute(T parameter)
        {
            _executeMethod?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }
    }
}
