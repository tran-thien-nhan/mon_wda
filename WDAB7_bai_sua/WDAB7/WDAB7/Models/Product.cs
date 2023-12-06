using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WDAB7.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }

        [Range(100,1000,ErrorMessage ="Quantity must be between 100 and 1000$")]
        public int Quantity { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
