using System;
using System.Collections.Generic;

namespace SOTAM.Models;

public partial class Table
{
    public int TableId { get; set; }

    public string TableName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Customer { get; set; }

    public int? Hours { get; set; }

    public DateTime? TimeEnd { get; set; }

    public string? TimeLeft { get; set; }

    public virtual ICollection<QueueList> QueueLists { get; set; } = new List<QueueList>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
