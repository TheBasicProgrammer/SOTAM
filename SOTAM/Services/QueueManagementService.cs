using SOTAM.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SOTAM.Services
{
    public class QueueManagementService
    {
        private readonly ObservableCollection<QueueList> _queueList;

        public QueueManagementService()
        {
            _queueList = new ObservableCollection<QueueList>();
        }

        // Gets the queue list
        public ObservableCollection<QueueList> GetQueueList()
        {
            return _queueList;
        }

        // Adds a customer to the queue
        public void AddToQueue(string customerName, int hours)
        {
            var newQueueItem = new QueueList
            {
                QueueId = _queueList.Count + 1,
                Customer = customerName,
                Hours = hours,
                TableId = null,  // Table is empty initially
                IsConfirmed = false // Initially, the queue item is not confirmed
            };

            _queueList.Add(newQueueItem);
        }

        // Confirms a customer from the queue and moves them to the table management system
        public void ConfirmQueueItem(int queueId)
        {
            var queueItem = _queueList.FirstOrDefault(q => q.QueueId == queueId);
            if (queueItem != null)
            {
                // Mark the item as confirmed
                queueItem.IsConfirmed = true;

                // You would pass the data to the Table Management system here
                // For now, we just remove the item from the queue
                _queueList.Remove(queueItem);
            }
        }

        // Cancels a customer from the queue
        public void CancelQueueItem(int queueId)
        {
            var queueItem = _queueList.FirstOrDefault(q => q.QueueId == queueId);
            if (queueItem != null)
            {
                // Remove the customer from the queue
                _queueList.Remove(queueItem);
            }
        }
    }
}
