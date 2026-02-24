using System;
using System.Collections.Generic;

namespace Day12.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? SegmentId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ContactPerson> ContactPeople { get; set; } = new List<ContactPerson>();

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<CustomerInteraction> CustomerInteractions { get; set; } = new List<CustomerInteraction>();

    public virtual Segment? Segment { get; set; }
}
