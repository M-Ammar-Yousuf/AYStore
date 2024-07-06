using Microsoft.EntityFrameworkCore;

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
                dbContext.SaveChanges();
            }

            if (!dbContext.Products.Any())
            {
                var categories = dbContext.Categories.ToList();
                dbContext.Products.AddRange(
                    GetProducts(categories)
                 );
                dbContext.SaveChanges();
            }
        }

        private static IEnumerable<Product> GetProducts(List<Category> categories)
        {
            Product[] productList = {  new Product { Name = "Smartphone", Description = "High-end smartphone", Price = 999.99m, Category = categories[0] },
                    new Product { Name = "Laptop", Description = "Powerful laptop for professionals", Price = 1499.99m, Category = categories[0] },
                    new Product { Name = "T-shirt", Description = "Cotton t-shirt", Price = 19.99m, Category = categories[1] },
                    new Product { Name = "Jeans", Description = "Slim fit jeans", Price = 49.99m, Category = categories[1] },
                    new Product { Name = "Programming C#", Description = "Book about C# programming", Price = 39.99m, Category = categories[2] },
                    new Product { Name = "Harry Potter and the Philosopher's Stone", Description = "Fantasy novel", Price = 29.99m, Category = categories[2] }
                };
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
