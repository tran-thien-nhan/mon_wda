using System.ComponentModel.DataAnnotations;

namespace wda1.Models
{
    public class AccountTb
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = " maximum characters is 30")]
        public string Username { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = " maximum characters is 30")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"Admin|User", ErrorMessage = "only accept Admin or User")]
        public string Role { get; set; }
    }
}
