using System;
using System.Collections.Generic;

namespace Day12.Models;

public partial class Segment
{
    public int SegmentId { get; set; }

    public string? SegmentName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
