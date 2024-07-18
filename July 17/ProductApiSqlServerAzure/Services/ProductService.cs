using ProductApiSqlServerAzure.Interfaces;
using ProductApiSqlServerAzure.Model;
using Azure.Storage.Blobs;

namespace ProductApiSqlServerAzure.Services
{
    public class ProductService : IProductService
    {   private readonly IRepository<int,Product> _productRepo;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "product-images";
        public ProductService(IRepository<int, Product> productRepo,BlobServiceClient blobServiceClient)
        {
            _productRepo = productRepo;
            _blobServiceClient = blobServiceClient;
        }
        public async Task<Product> AddProduct(ProductDTO productDto)
        {
            try
            {
                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                await blobContainerClient.CreateIfNotExistsAsync();

                var blobClient = blobContainerClient.GetBlobClient(productDto.ProductImage.FileName);
                await blobClient.UploadAsync(productDto.ProductImage.OpenReadStream(), true);
                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductPrice = productDto.ProductPrice,
                };
                product.ProductImage = blobClient.Uri.ToString();
                return await _productRepo.Add(product);
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
