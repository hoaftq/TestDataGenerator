using System;
using System.Windows.Input;

namespace TestDataGenerator.Common
{
    class DelegateCommand : ICommand
    {
        private Action<object> eventHandler;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            eventHandler?.Invoke(parameter);
        }
    }
}
