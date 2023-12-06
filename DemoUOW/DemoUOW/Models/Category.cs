namespace DemoUOW.Models
{
    // Category.cs
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } // Mối quan hệ 1-n với Product
    }

}
