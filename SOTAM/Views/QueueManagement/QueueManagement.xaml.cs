using System;
using System.Windows;
using System.Windows.Controls;
using SOTAM.Services;

namespace SOTAM.Views.QueueManagement
{
    public partial class QueueManagement : Window
    {
        private readonly QueueService _queueService;

        public QueueManagement(QueueService queueService)
        {
            InitializeComponent();
            _queueService = queueService;
        }

        private void AddToQueueButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;

            int hours = 0;
            if (HoursComboBox.SelectedItem != null)
            {
              
                int.TryParse(((ComboBoxItem)HoursComboBox.SelectedItem).Content.ToString(), out hours);
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter the customer's name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (hours <= 0)
            {
                MessageBox.Show("Please select a valid time duration.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var queue = _queueService.AddToQueue(name, hours);

            MessageBox.Show($"Added {name} to the queue for {hours} hour(s).", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            NameTextBox.Clear();
            HoursComboBox.SelectedIndex = 0; 
        }

        private void HoursComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
