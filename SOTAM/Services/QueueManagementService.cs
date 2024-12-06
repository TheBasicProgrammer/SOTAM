using SOTAM.Models;

namespace SOTAM.Services
{
    public class QueueManagementService
    {
        private readonly SotamContext _context;

        public QueueManagementService(SotamContext context)
        {
            _context = context;
        }

        // To add a customer to the queue
        public QueueList AddToQueue(string customer, int hours)
        {
            var queue = new QueueList
            {
                Customer = customer,
                Hours = hours
            };

            _context.QueueLists.Add(queue);
            _context.SaveChanges();

            return queue;
        }

        // To assign a table to a customer in the queue
        public QueueList? AssignTable(int queueId, int tableId)
        {
            var queue = _context.QueueLists.FirstOrDefault(q => q.QueueId == queueId);
            var table = _context.Tables.FirstOrDefault(t => t.TableId == tableId);

            if (queue != null && table != null && table.Status == "Available")
            {
                queue.TableId = tableId;
                table.Status = "Occupied";
                _context.SaveChanges();
                return queue;
            }

            return null; // Either queue or table not found, or table is unavailable
        }

        // Confirm the session and remove the queue entry
        public void ConfirmSession(int queueId)
        {
            var queue = _context.QueueLists.FirstOrDefault(q => q.QueueId == queueId);

            if (queue != null)
            {
                _context.QueueLists.Remove(queue);
                _context.SaveChanges();
            }
        }

        // Cancel a queue entry
        public void CancelQueueEntry(int queueId)
        {
            var queue = _context.QueueLists.FirstOrDefault(q => q.QueueId == queueId);

            if (queue != null)
            {
                _context.QueueLists.Remove(queue);
                _context.SaveChanges();
            }
        }
    }
}
