using System;
using System.Windows.Input;

namespace Watermarker.GUI.Commands
{
    internal class Command<T> : ICommand
    {
        private readonly Action<object> executeDelegate;
        private readonly Predicate<object> whenDelegate;

        public Command(Action execute, Func<bool> when = null)
        {
            if (execute is null) throw new ArgumentNullException(nameof(execute));

            executeDelegate = obj => execute();

            if (when != null)
                whenDelegate = obj => when();
            else
                whenDelegate = obj => true;
        }

        private EventHandler canExecuteChangedHandler;
        event EventHandler ICommand.CanExecuteChanged
        {
            add => canExecuteChangedHandler += value;
            remove => canExecuteChangedHandler -= value;
        }

        bool ICommand.CanExecute(object parameter) => whenDelegate(parameter);

        void ICommand.Execute(object parameter) => executeDelegate(parameter);
    }
}
