using System.ComponentModel.DataAnnotations;

namespace wda4.Models
{
    public class User
    {
        [Key]
        [MaxLength(30, ErrorMessage = "maximum 30 characters")]
        public string Username { get; set; }

        [MaxLength(30, ErrorMessage = "maximum 30 characters")]
        public string Password { get; set; }
    }
}
