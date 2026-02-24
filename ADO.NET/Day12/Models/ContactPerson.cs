using System;
using System.Collections.Generic;

namespace Day12.Models;

public partial class ContactPerson
{
    public int ContactPersonId { get; set; }

    public int? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Title { get; set; }

    public bool? IsPrimary { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Customer? Customer { get; set; }
}
