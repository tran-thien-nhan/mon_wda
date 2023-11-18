using Day3_HomeWork.Models;
using Microsoft.EntityFrameworkCore;

namespace Day3_HomeWork.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        // DbSet là một phần của Entity Framework và đại diện cho một tập hợp các đối tượng từ bảng cơ sở dữ liệu.
        // Trong trường hợp này, Customers là một tập hợp các đối tượng Customer.
        public DbSet<Customer> Customers { get; set; }
    }
}
