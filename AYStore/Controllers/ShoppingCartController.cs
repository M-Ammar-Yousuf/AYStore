using AYStore.Models;
using AYStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AYStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCart shoppingCart, IProductRepository productRepository)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(Product product)
        {
            var selectedProduct = _productRepository.AllProducts.Where(p => p.ProductId == product.ProductId).FirstOrDefault();

            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct);
            }

         return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(Product product)
        {
            var selectedProduct = _productRepository.AllProducts.Where(p => p.ProductId == product.ProductId).FirstOrDefault();

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }

           return RedirectToAction("Index");
        }

    }
}
