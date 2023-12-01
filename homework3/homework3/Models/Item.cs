using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace homework3.Models;

public partial class Item
{
    public string ItemCode { get; set; } = null!;

    public string? ItemName { get; set; }
    public int? Price { get; set; }
    public string? Image { get; set; }

    [NotMapped]
    public IFormFile? UploadImage { get; set; }
}
