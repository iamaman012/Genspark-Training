using ProductApiSqlServerAzure.Model;

namespace ProductApiSqlServerAzure.Interfaces
{
    public interface IProductService
    {
        public Task<Product> AddProduct(ProductDTO productDto);
        public Task<IEnumerable<Product>> GetAllProducts();

        
    }
}
