using Day5_HomeWork5.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Day5_HomeWork5.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
