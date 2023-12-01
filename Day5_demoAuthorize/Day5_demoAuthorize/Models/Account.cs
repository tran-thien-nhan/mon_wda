using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day5_demoAuthorize.Models;

public partial class Account
{
    public int Id { get; set; }

    [Display(Name = "Tài Khoản")]
    public string? Usename { get; set; }

    [Display(Name = "Mật Khẩu")]
    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
}
