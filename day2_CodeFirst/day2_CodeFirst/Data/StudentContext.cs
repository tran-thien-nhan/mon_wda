using day2_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace day2_CodeFirst.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        //trường hợp muốn đổi tên table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            base.OnModelCreating(modelBuilder);
        }
    }
}
