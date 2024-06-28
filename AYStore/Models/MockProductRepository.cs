
namespace AYStore.Models
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Product> AllProducts => new List<Product>()
        {
            new Product { ProductId = 1, Name = "Smartphone", Description = "High-end smartphone", Price = 999.99m, CategoryId = 1, Category = _categoryRepository.AllCategories.ToList()[0] },
            new Product { ProductId = 2, Name = "Laptop", Description = "Powerful laptop for professionals", Price = 1499.99m, CategoryId = 1, Category = _categoryRepository.AllCategories.ToList()[0]  },
            new Product { ProductId = 3, Name = "T-shirt", Description = "Cotton t-shirt", Price = 19.99m, CategoryId = 2, Category = _categoryRepository.AllCategories.ToList()[1]  },
            new Product { ProductId = 4, Name = "Jeans", Description = "Slim fit jeans", Price = 49.99m, CategoryId = 2, Category = _categoryRepository.AllCategories.ToList()[1]  },
            new Product { ProductId = 5, Name = "Programming C#", Description = "Book about C# programming", Price = 39.99m, CategoryId = 3 , Category = _categoryRepository.AllCategories.ToList()[2] },
            new Product { ProductId = 6, Name = "Harry Potter and the Philosopher's Stone", Description = "Fantasy novel", Price = 29.99m, CategoryId = 3 , Category = _categoryRepository.AllCategories.ToList()[2]}
        };

        public Product? GetProductById(int id)
        {
            return AllProducts.FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
