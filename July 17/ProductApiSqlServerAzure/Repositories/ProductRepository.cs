using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ProductApiSqlServerAzure.Context;
using ProductApiSqlServerAzure.Interfaces;
using ProductApiSqlServerAzure.Model;

namespace ProductApiSqlServerAzure.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly AzureContext _context;
        public ProductRepository(AzureContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product item)
        {
             _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task<Product> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public Task<Product> GetById(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
