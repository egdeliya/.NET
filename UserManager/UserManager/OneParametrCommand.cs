using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserManager
{
    public class OneParametrCommand<T>: ICommand where T: class
    {
        private readonly Action<T> _executeAction;
        public event EventHandler CanExecuteChanged;

        public OneParametrCommand(Action<T> ExecuteAction)
        {
            _executeAction = ExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction.Invoke(parameter as T);
        }
    }
}
