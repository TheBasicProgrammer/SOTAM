using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SOTAM.ViewModels
{
    public class QueueManagementViewModel : INotifyPropertyChanged
    {
        private string? _name;
        private int _hours;
        private ObservableCollection<QueueItem> _queueItems;
        private bool _isAddToQueueButtonEnabled;

        public event PropertyChangedEventHandler? PropertyChanged;

        // Properties
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    UpdateButtonState(); // Update button enabled state
                }
            }
        }

        public int Hours
        {
            get => _hours;
            set
            {
                if (_hours != value)
                {
                    _hours = value;
                    OnPropertyChanged(nameof(Hours));
                    UpdateButtonState(); // Update button enabled state
                }
            }
        }

        public ObservableCollection<QueueItem> QueueItems
        {
            get => _queueItems;
            set
            {
                if (_queueItems != value)
                {
                    _queueItems = value;
                    OnPropertyChanged(nameof(QueueItems));
                }
            }
        }

        public bool IsAddToQueueButtonEnabled
        {
            get => _isAddToQueueButtonEnabled;
            private set
            {
                if (_isAddToQueueButtonEnabled != value)
                {
                    _isAddToQueueButtonEnabled = value;
                    OnPropertyChanged(nameof(IsAddToQueueButtonEnabled));
                }
            }
        }

        public ICommand AddToQueueCommand { get; }

        // Constructor
        public QueueManagementViewModel()
        {
            _queueItems = new ObservableCollection<QueueItem>();
            AddToQueueCommand = new RelayCommand(AddToQueue, CanAddToQueue);
            Hours = 1; // Default value
        }

        // Methods
        private void AddToQueue()
        {
            if (Name != null)
            {
                QueueItems.Add(new QueueItem { Name = Name, Hours = Hours });

                // Reset fields after adding
                Name = string.Empty;
                Hours = 1;
            }
        }

        private bool CanAddToQueue() => IsAddToQueueButtonEnabled;

        private void UpdateButtonState()
        {
            // Button is enabled only when Name is not empty and Hours > 0
            IsAddToQueueButtonEnabled = !string.IsNullOrWhiteSpace(Name) && Hours > 0;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Queue Item Model
    public class QueueItem
    {
        public string? Name { get; set; }
        public int Hours { get; set; }
    }

    // RelayCommand Implementation
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object? parameter) => _canExecute();

        public void Execute(object? parameter) => _execute();

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
