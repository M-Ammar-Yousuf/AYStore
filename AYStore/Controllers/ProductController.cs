using AYStore.Models;
using AYStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AYStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(string category)
        {
            IEnumerable<Product> products;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.AllProducts.OrderBy(p=> p.ProductId);
                currentCategory = "All Products";
            }
            else
            {
                products = _productRepository.AllProducts.Where(f=> f.Category.Name == category).OrderBy(p => p.ProductId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(f => f.Name == category)?.Name;
            }

            ProductListViewModel productListViewModel = new ProductListViewModel(products, currentCategory);
            return View(productListViewModel);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
