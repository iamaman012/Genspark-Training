using Microsoft.AspNetCore.Mvc;
using ProductApiSqlServerAzure.Interfaces;
using ProductApiSqlServerAzure.Model;

namespace ProductApiSqlServerAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {   private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var result= await _productService.GetAllProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<IEnumerable<Product>>> AddProducts([FromForm]ProductDTO productDto)
        {
            try
            {
                var result = await _productService.AddProduct(productDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
