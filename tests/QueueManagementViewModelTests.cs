using System.Collections.ObjectModel;
using Xunit;
using SOTAM.ViewModels;

namespace SOTAM.Tests
{
    public class QueueManagementViewModelTests
    {
        // Test: Ensure the AddToQueueCommand works when valid data is provided.
        [Fact]
        public void AddToQueueCommand_ExecutesCorrectly_WhenValidDataProvided()
        {
            var viewModel = new QueueManagementViewModel
            {
                Name = "Test Customer",
                Hours = 2
            };

            viewModel.AddToQueueCommand.Execute(null);

            Assert.Single(viewModel.QueueItems);
            Assert.Equal("Test Customer", viewModel.QueueItems[0].Name);
            Assert.Equal(2, viewModel.QueueItems[0].Hours);
        }

        // Test: Ensure the AddToQueueCommand doesn't work when invalid data is provided.
        [Fact]
        public void AddToQueueCommand_DoesNotExecute_WhenInvalidDataProvided()
        {
            var viewModel = new QueueManagementViewModel
            {
                Name = "",
                Hours = 0
            };

            // Command should not execute because of invalid input.
            Assert.False(viewModel.AddToQueueCommand.CanExecute(null));
        }

        // Test: Ensure the Name property changes correctly.
        [Fact]
        public void NameProperty_ChangesAreTrackedCorrectly()
        {
            var viewModel = new QueueManagementViewModel();
            viewModel.Name = "New Customer";

            Assert.Equal("New Customer", viewModel.Name);
        }
    }
}
