using Microsoft.EntityFrameworkCore;
using demo_DTO.Models;

namespace demo_DTO.Models
{
    public class productContext : DbContext
    {
        public productContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<demo_DTO.Models.productDTO>? productDTO { get; set; }
    }
}
