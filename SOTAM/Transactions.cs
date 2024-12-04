using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOTAM
{
    public class Transactions
    {
        [Key]  // Marks TransactionID as the primary key
        public int TransactionID { get; set; }

        [Required]  // Ensures SessionID cannot be null
        [MaxLength(20)]
        public string SessionID { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;  // Defaults to current time

        [ForeignKey("TableID")]  // Foreign key linking to the Tables table
        public int TableID { get; set; }

        [Range(0, double.MaxValue)]  // Ensures AmountPaid is a positive value
        public decimal AmountPaid { get; set; }
    }
}
