using System;
using System.Collections.Generic;

namespace SOTAM.Models;

public partial class QueueList
{
    public int QueueId { get; set; }

    public string Customer { get; set; } = null!;

    public int Hours { get; set; }

    public int? TableId { get; set; }

    public virtual Table? Table { get; set; }

    public bool IsConfirmed { get; set; }
}
