using System.ComponentModel.DataAnnotations;

namespace bt_order.Models
{
    public class Order
    {
        //[RegularExpression(@"^O[0-9]{3}$", ErrorMessage = "wrong formar id")]
        //[MaxLength(5, ErrorMessage = "maximum length 4 characters")]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "maximum length 30 characters")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "maximum length 30 characters")]
        public string Phone { get; set; }

        [MaxLength(30, ErrorMessage = "maximum length 30 characters")]
        public string Address { get; set; }

        public List<OrderDetail> Details { get; set; }
    }
}
