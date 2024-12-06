using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using SOTAM.Interfaces;
using SOTAM.Helpers;

namespace SOTAM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authenticationService;

        // Constructor
        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new RelayCommand(Login);

            // Initialize fields (non-nullable)
            _username = string.Empty;  // Initialize to empty string or null if needed
            _password = string.Empty;  // Initialize to empty string or null if needed
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        // Command property
        public ICommand LoginCommand { get; }

        // Login method
        private void Login(object parameter)
        {
            bool isSuccess = _authenticationService.Login(Username, Password);
            if (isSuccess)
            {
                // Navigate to the next view or display success
                System.Windows.MessageBox.Show("Login successful!");
            }
            else
            {
                // Display error message
                System.Windows.MessageBox.Show("Invalid username or password.");
            }
        }

        // PropertyChanged event implementation
        public event PropertyChangedEventHandler? PropertyChanged;  // Nullable event

        // OnPropertyChanged method
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
