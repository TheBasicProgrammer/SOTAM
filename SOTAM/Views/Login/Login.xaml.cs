using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using SOTAM.ViewModels;
using SOTAM.Services; // Update with the actual namespace of AuthenticationService
using SOTAM.Models;   // Update with the actual namespace of SotamContext

namespace SOTAM.Views.Login
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            // Create SotamContext and AuthenticationService
            var context = new SotamContext();
            var authService = new AuthenticationService(context);

            // Set DataContext to LoginViewModel
            var loginViewModel = new LoginViewModel(authService);
            DataContext = loginViewModel;

            // Attach PasswordBox.PasswordChanged event
            PasswordBox.PasswordChanged += (s, e) =>
            {
                loginViewModel.Password = PasswordBox.Password;
            };
        }
    }
}
