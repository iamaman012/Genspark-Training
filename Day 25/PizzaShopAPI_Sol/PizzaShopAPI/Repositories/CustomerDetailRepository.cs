using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class CustomerDetailRepository : IRepository<int, CustomerDetail>
    {
        private readonly PizzaShopContext _context;

        public CustomerDetailRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<CustomerDetail> Add(CustomerDetail entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerDetail> DeleteById(int id)
        {
            var cd = await GetById(id);
            if (cd != null)
            {

                _context.Remove(cd);
                await _context.SaveChangesAsync();


            }
            return cd;
        }

        public async Task<IEnumerable<CustomerDetail>> GetAll()
        {
            var Cds = await _context.CustomerDetails.ToListAsync();
            return Cds;
        }

        public  async Task<CustomerDetail> GetById(int id)
        {
            var cd = await _context.CustomerDetails.FirstOrDefaultAsync(p => p.CustomerID == id);
            return cd;
        }

        public Task<CustomerDetail> Update(CustomerDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
