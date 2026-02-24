using System;
using System.Collections.Generic;

namespace Day12.Models;

public partial class CustomerInteraction
{
    public int InteractionId { get; set; }

    public int? CustomerId { get; set; }

    public string? InteractionType { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public DateTime? InteractionDate { get; set; }

    public virtual Customer? Customer { get; set; }
}
