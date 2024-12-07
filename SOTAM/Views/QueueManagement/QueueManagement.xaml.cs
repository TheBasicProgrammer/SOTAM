using System.Windows;
using SOTAM.ViewModels;

namespace SOTAM.Views.QueueManagement
{
    public partial class QueueManagement : Window
    {
        public QueueManagement()
        {
            InitializeComponent();

            // Initialize the ViewModel and set it as the DataContext
            DataContext = new QueueManagementViewModel();
        }

        // Event handler for the "Add to Queue" button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Assuming AddToQueueCommand is already implemented in your ViewModel
            var viewModel = DataContext as QueueManagementViewModel;

            if (viewModel != null && viewModel.AddToQueueCommand.CanExecute(null))
            {
                viewModel.AddToQueueCommand.Execute(null);
            }
        }

        // Event handler for the NameTextBox TextChanged event
        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Optional: Add custom logic if required for NameTextBox input changes
        }

        // Event handler for the HoursComboBox SelectionChanged event
        private void HoursComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Optional: Add custom logic if required for HoursComboBox selection changes
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
