namespace WDA3.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public string Phone { get; set; }
        public string Address { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; } 
    }
}
