using System;
using System.Collections.Generic;

namespace Day12.Models;

public partial class CustomerAudit
{
    public int AuditId { get; set; }

    public int? CustomerId { get; set; }

    public string? ChangedField { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime? ChangedDate { get; set; }
}
