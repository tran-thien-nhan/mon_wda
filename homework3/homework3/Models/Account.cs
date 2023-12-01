using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace homework3.Models;

public partial class Account
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, ErrorMessage = "Username must be less than 50 characters")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(50, ErrorMessage = "Password must be less than 50 characters")]
    public string? Password { get; set; }
}
