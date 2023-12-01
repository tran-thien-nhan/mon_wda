using System;
using System.Collections.Generic;

namespace hw2.Models;

public partial class TbPerson
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public bool? Roles { get; set; }

    public double? Balance { get; set; }
}
