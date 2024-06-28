namespace AYStore.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            AYStoreDbContext dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AYStoreDbContext>();

            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(
                    GetCategories()
                    );
            }

            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(
                    GetProducts()
                 );
            }

            dbContext.SaveChanges();
        }

        private static IEnumerable<Product> GetProducts()
        {
            Product[] productList = { new Product { Name = "Smartphone", Description = "High-end smartphone", Price = 999.99m, CategoryId = 1, Category = GetCategories().ToList()[0] },
            new Product { Name = "Laptop", Description = "Powerful laptop for professionals", Price = 1499.99m, CategoryId = 1, Category = GetCategories().ToList()[0] },
            new Product { Name = "T-shirt", Description = "Cotton t-shirt", Price = 19.99m, CategoryId = 2, Category = GetCategories().ToList()[1] },
            new Product { Name = "Jeans", Description = "Slim fit jeans", Price = 49.99m, CategoryId = 2, Category = GetCategories().ToList()[1] },
            new Product { Name = "Programming C#", Description = "Book about C# programming", Price = 39.99m, CategoryId = 3, Category = GetCategories().ToList()[2] },
            new Product { Name = "Harry Potter and the Philosopher's Stone", Description = "Fantasy novel", Price = 29.99m, CategoryId = 3, Category = GetCategories().ToList()[2] } };
            return productList;
        }

        private static IEnumerable<Category> GetCategories()
        {
            Category[] categories = { new Category { Name = "Electronics", Description = "Category for electronic products" },
            new Category { Name = "Clothing", Description = "Category for clothing items" },
            new Category {  Name = "Books", Description = "Category for books" }
            };

            return categories;
        }
    }
}
