using System.ComponentModel.DataAnnotations;

namespace homework1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
