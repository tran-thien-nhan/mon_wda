using System;
using System.Collections.Generic;

namespace HW4_5.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Birthday { get; set; }

    public bool? Gender { get; set; }

    public string? Email { get; set; }
}
