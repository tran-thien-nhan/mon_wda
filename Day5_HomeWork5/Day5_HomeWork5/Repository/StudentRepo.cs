
using Day5_HomeWork5.Data;
using Day5_HomeWork5.IRepository;
using Day5_HomeWork5.Models;
using Microsoft.EntityFrameworkCore;

namespace Day5_HomeWork5.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentDbContext db;

        public StudentRepo(StudentDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Student student)
        {
            db.Students.Add(student);
            try
            {
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> Delete(int id)
        {
            var stu = await db.Students.SingleOrDefaultAsync(student => student.Id == id);
            if (stu != null)
            {
                db.Remove(stu);
                return await db.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> Edit(Student student)
        {
            var stu = await db.Students.SingleOrDefaultAsync(s => s.Id == student.Id);
            if (stu != null)
            {
                stu.Name = student.Name;
                stu.Birthday = student.Birthday;
                stu.Gender = student.Gender;
                stu.Email = student.Email;
                return await db.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<Student> Get(int id)
        {
            var stu = await db.Students.SingleOrDefaultAsync(st => st.Id == id);
            return stu;
        }

        public async Task<IEnumerable<Student>> getAll()
        {
            var stuList = await db.Students.ToListAsync();  
            return stuList;
        }
    }
}
