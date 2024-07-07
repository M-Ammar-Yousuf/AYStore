namespace AYStore.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AYStoreDbContext _dbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(AYStoreDbContext dbContext, IShoppingCart shoppingCart)
        {
            _dbContext = dbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetails = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Product.Price,
                    ProductId = shoppingCartItem.Product.ProductId
                };

                order.OrderDetails.Add(orderDetails);
            }

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}
