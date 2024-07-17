using ProductApiSqlServerAzure.Interfaces;
using ProductApiSqlServerAzure.Model;

namespace ProductApiSqlServerAzure.Services
{
    public class ProductService : IProductService
    { private readonly IRepository<int,Product> _productRepo;
        public ProductService(IRepository<int, Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                product = await _productRepo.Add(product);
                return product;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {

            var products = await _productRepo.GetAll();
            return products;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
