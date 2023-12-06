using System.ComponentModel.DataAnnotations;

namespace wda2.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(5, ErrorMessage = "maximum 5 characters")]
        [RegularExpression(@"E\d{3}-\d{1}")]
        public string Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = " maximum 20 characters")]
        public string Name { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }
    }
}
