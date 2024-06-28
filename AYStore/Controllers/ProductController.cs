using AYStore.Models;
using AYStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AYStore.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
			_productRepository = productRepository;   
        }

        public IActionResult Index()
		{
			ProductListViewModel productListViewModel = new ProductListViewModel(_productRepository.AllProducts, "Electronics");
			return View(productListViewModel);
		}
	}
}
