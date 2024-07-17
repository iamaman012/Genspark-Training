using ProductApiSqlServerAzure.Model;

namespace ProductApiSqlServerAzure.Interfaces
{
    public interface IProductService
    {
        public Task<Product> AddProduct(Product product);
        public Task<IEnumerable<Product>> GetAllProducts();
    }
}
