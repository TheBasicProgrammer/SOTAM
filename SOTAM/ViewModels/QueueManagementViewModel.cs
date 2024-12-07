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
                    UpdateButtonState();
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
                    UpdateButtonState();
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

        public ICommand AddToQueueCommand { get; }

        // Constructor
        public QueueManagementViewModel()
        {
            _queueItems = new ObservableCollection<QueueItem>();
            AddToQueueCommand = new RelayCommand(AddToQueue);
            Hours = 1; // Default value
        }

        private void AddToQueue()
        {
            if (!string.IsNullOrEmpty(Name) && Hours > 0)
            {
                var newQueueItem = new QueueItem
                {
                    Name = Name,
                    Hours = Hours // Assign the selected Hours value
                };

                QueueItems.Add(newQueueItem); // Add the new queue item to the list
                Name = string.Empty;  // Clear the Name field after adding
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateButtonState()
        {
            OnPropertyChanged(nameof(AddToQueueCommand));
        }
    }

    public class QueueItem
    {
        public string? Name { get; set; }
        public int Hours { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute) => _execute = execute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => _execute();
    }
}
