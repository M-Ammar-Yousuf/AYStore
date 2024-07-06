using AYStore.Models;

namespace AYStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
           ShoppingCartTotal= shoppingCartTotal;
        }

        public decimal ShoppingCartTotal { get;}

        public IShoppingCart ShoppingCart { get;}
    }
}
