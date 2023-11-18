using System.ComponentModel.DataAnnotations;

namespace day2_CodeFirst.Models
{
    public class Student
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "min is 2 characters")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "phone is 10 numbers")]
        [MinLength(10, ErrorMessage = "phone is 10 numbers")]
        public string Phone { get; set; }
    }
}
