using System;
using System.Windows.Input;

namespace SOTAM.Helpers // Adjust the namespace to match your project structure
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        // Constructor
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // CanExecute with nullable parameter
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        // Execute with nullable parameter
        public void Execute(object? parameter) => _execute(parameter);

        // CanExecuteChanged event with nullable EventHandler
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
