using AYStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYStore.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        [BindProperty]
        public Order Order { get; set; }

        public CheckoutPageModel(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some products first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage");
            }

            return Page();

        }
    }
}
