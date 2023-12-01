using System.ComponentModel.DataAnnotations;

namespace hw1.Models
{
    public class tbNews
    {
        [Key]
        public int NewsId { get; set; }
        public string NewsName { get; set; }
        public string ContentOfNews { get; set;}
    }
}
