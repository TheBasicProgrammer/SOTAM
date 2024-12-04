using Microsoft.EntityFrameworkCore;
namespace SOTAM  
{
    public class SOTAMContext : DbContext  
    {
        
        public SOTAMContext(DbContextOptions<SOTAMContext> options) : base(options)
        {
        }

        
        public DbSet<Table> Tables { get; set; }
        public DbSet<QueueList> QueueLists { get; set; }
        public DbSet<Transactions> TransactionHistories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
