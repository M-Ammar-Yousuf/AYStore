
namespace AYStore.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AYStoreDbContext _context;
        public CategoryRepository(AYStoreDbContext dbContext) { 
            _context = dbContext;
        }

        public IEnumerable<Category> AllCategories {
            get
            {
                return _context.Categories;
            }
        }
    }
}
