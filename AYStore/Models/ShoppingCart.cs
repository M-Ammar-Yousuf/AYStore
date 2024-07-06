
using Microsoft.EntityFrameworkCore;

namespace AYStore.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly AYStoreDbContext _dbContext;

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public string? ShoppingCartId { get; set; }

        public ShoppingCart(AYStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            AYStoreDbContext dbContext = services.GetRequiredService<AYStoreDbContext>() ?? throw new Exception("Error initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(dbContext) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = _dbContext.ShoppingCartItems
                .SingleOrDefault(f => f.ShoppingCartId == ShoppingCartId && f.Product.ProductId == product.ProductId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    Amount = 1,
                    Product = product,
                    ShoppingCartId = ShoppingCartId
                };
                _dbContext.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _dbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = _dbContext.ShoppingCartItems.Where(f => f.ShoppingCartId == ShoppingCartId);
            _dbContext.RemoveRange(cartItems);
            _dbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
                .Include(p => p.Product)
                .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            decimal total = _dbContext.ShoppingCartItems.Where(f => f.ShoppingCartId == ShoppingCartId)
                .Select(s => s.Product.Price * s.Amount).Sum();
            return total;

        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _dbContext.ShoppingCartItems
                .SingleOrDefault(f => f.ShoppingCartId == ShoppingCartId && f.Product.ProductId == product.ProductId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _dbContext.SaveChanges();
            return localAmount;
        }
    }
}
