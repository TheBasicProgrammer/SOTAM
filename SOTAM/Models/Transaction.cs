using System;
using System.Collections.Generic;

namespace SOTAM.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string SessionId { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public int? TableId { get; set; }

    public decimal AmountPaid { get; set; }

    public virtual Table? Table { get; set; }
}
