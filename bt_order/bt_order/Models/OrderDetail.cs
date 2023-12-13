using System.ComponentModel.DataAnnotations;

namespace bt_order.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "maximum length must be 30 characters")]
        public string ProductName { get; set; }

        public int Quantity { get; set; }   

        public int Price {  get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
