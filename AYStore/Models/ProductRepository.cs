
using Microsoft.EntityFrameworkCore;

namespace AYStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AYStoreDbContext _dbContext;
        public ProductRepository(AYStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get { return _dbContext.Products.Include(c => c.Category); }
        }

        public Product? GetProductById(int id)
        {
           return _dbContext.Products.Include(c => c.Category).FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
