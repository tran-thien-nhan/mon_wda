using System.ComponentModel.DataAnnotations.Schema;

namespace Day4_Upload.Models.DTO
{
    public class productDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Price { get; set; }

        public string? Image { get; set; }
    }
}
