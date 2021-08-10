using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recorder.ViewModels
{
    class ButtonCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        private Action _execute;
        private bool _CanExecute;

        public ButtonCommand(Action execute, bool CanExecute)
        {
            _execute = execute;
            _CanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
