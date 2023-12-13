namespace WDA3.Models
{
    public class OrderDetail
    {
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Order? Order { get; set; }
    }
}
