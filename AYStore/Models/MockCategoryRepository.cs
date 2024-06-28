
namespace AYStore.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category>() {
        new Category { CategoryId = 1, Name = "Electronics", Description = "Category for electronic products" },
            new Category { CategoryId = 2, Name = "Clothing", Description = "Category for clothing items" },
            new Category { CategoryId = 3, Name = "Books", Description = "Category for books" }

        };
    }
}
