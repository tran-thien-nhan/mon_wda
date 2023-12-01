using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace homework_2.Models;

public partial class TbPerson
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public bool? Roles { get; set; }

    public double? Balance { get; set; }
}
