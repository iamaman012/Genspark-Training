namespace ProductApiSqlServerAzure.Model
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
