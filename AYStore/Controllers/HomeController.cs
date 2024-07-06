using AYStore.Models;
using AYStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AYStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel(_productRepository.AllProducts);
            return View(homeViewModel);
        }
    }
}
