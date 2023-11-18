using Day3_HomeWork.Models;

namespace Day3_HomeWork.IRepository
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> getAll();

        Task<Customer> Get(int id);

        Task<int> Edit(Customer customer);

        Task<int> Delete(int id);

        Task<int> Create(Customer customer);

        Task<IEnumerable<Customer>> SearchByName(string name);
    }
}
