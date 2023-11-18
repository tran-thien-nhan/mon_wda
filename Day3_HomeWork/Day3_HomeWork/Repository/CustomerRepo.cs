using Day3_HomeWork.Data;
using Day3_HomeWork.IRepository;
using Day3_HomeWork.Models;
using Microsoft.EntityFrameworkCore;

namespace Day3_HomeWork.Repository
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly CustomerContext db;

        public CustomerRepo(CustomerContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Customer customer)
        {
            db.Customers.Add(customer);
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
           var cus = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (cus != null)
            {
                db.Customers.Remove(cus);
                return await db.SaveChangesAsync(); 
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> Edit(Customer customer)
        {
            var cus = await db.Customers.SingleOrDefaultAsync(c => c.Id == customer.Id);
            if (cus != null)
            {
                cus.Email = customer.Email; 
                cus.Birthday = customer.Birthday;
                cus.Gender = customer.Gender;
                cus.Name = customer.Name;   
                return await db.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<Customer> Get(int id)
        {
            var cus = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            return cus;
        }

        public async Task<IEnumerable<Customer>> getAll()
        {
            var cusList = await db.Customers.ToListAsync();
            return cusList;
        }

        public async Task<IEnumerable<Customer>> SearchByName(string name)
        {
            var searchlist = await db.Customers.Where(c => c.Name.Contains(name)).ToListAsync();
            return searchlist;
        }
    }
}
