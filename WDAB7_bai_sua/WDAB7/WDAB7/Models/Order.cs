namespace WDAB7.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
