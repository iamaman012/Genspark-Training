using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaShopContext _context;

        public CustomerRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
           return entity;
        }

        public async Task<Customer> DeleteById(int id)
        {
            var customer = await GetById(id);
            if(customer!= null  )
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;

        }

        public async Task<Customer> GetById(int id)
        {
            var customer =   _context.Customers.FirstOrDefault(c => c.CId == id);
            return customer;
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
