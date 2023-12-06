using System.ComponentModel.DataAnnotations;

namespace WDA1.Models
{
    public class AccountTb
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Password { get; set; }

        [RegularExpression(@"Admin|User", ErrorMessage = "Only accept Admin or User")]
        public string Role { get; set; }
    }
}
