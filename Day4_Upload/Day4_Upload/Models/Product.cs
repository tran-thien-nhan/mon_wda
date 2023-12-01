using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day4_Upload.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    //[BindRequired] : yêu cầu khớp dữ liệu
    //[BindNever] : ko yêu cầu khớp dữ liệu
    public int? Price { get; set; }

    public string? Image { get; set; }

    [NotMapped]
    public IFormFile? UploadImage { get; set; }
}
