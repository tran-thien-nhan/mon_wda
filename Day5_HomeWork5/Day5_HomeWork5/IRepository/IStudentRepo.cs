using Day5_HomeWork5.Models;

namespace Day5_HomeWork5.IRepository
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> getAll();

        Task<Student> Get(int id);

        Task<int> Edit(Student student);

        Task<int> Delete(int id);

        Task<int> Create(Student student);
    }
}
