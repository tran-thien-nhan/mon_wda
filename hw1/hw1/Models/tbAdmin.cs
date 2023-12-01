using System.ComponentModel.DataAnnotations;

namespace hw1.Models
{
    public class tbAdmin
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
