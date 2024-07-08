using AYStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AYStore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public SearchController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.AllProducts;
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            if(!_productRepository.AllProducts.Any(f => f.ProductId == id))
            {
                return NotFound();
            }

            return Ok(_productRepository.GetProductById(id)); //AllProducts.Where(f=> f.ProductId == id));
        }

        [HttpPost]
        public IActionResult SearchProduct([FromBody] string query)
        {
            IEnumerable<Product> products = new List<Product>();

            if (!string.IsNullOrEmpty(query))
            {
                 products = _productRepository.SearchProducts(query);
            }
            return new JsonResult(products);
        }
    }
}
