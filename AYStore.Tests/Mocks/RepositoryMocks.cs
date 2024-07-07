using AYStore.Models;
using Moq;

namespace AYStore.Tests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            List<Product> products = new List<Product>()
            {
                new Product { Name = "Smartphone", Description = "High-end smartphone", Price = 999.99m, Category = GetCategories[0] },
                    new Product { Name = "Laptop", Description = "Powerful laptop for professionals", Price = 1499.99m, Category = GetCategories[0] },
                    new Product { Name = "T-shirt", Description = "Cotton t-shirt", Price = 19.99m, Category = GetCategories[1] },
                    new Product { Name = "Jeans", Description = "Slim fit jeans", Price = 49.99m, Category = GetCategories[1] },
                    new Product { Name = "Programming C#", Description = "Book about C# programming", Price = 39.99m, Category = GetCategories[2] },
                    new Product { Name = "Harry Potter and the Philosopher's Stone", Description = "Fantasy novel", Price = 29.99m, Category = GetCategories[2] }
            };

            Mock<IProductRepository> mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(repo => repo.AllProducts).Returns(products);
            mockRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(products[0]);

            return mockRepository;
        }

        private static List<Category> GetCategories
        {
            get
            {
                var categories = new List<Category>
            {
                        new Category { Name = "Electronics", Description = "Category for electronic products" },
                        new Category { Name = "Clothing", Description = "Category for clothing items" },
                        new Category {  Name = "Books", Description = "Category for books" }
            };

                return categories;
            }
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                        new Category { Name = "Electronics", Description = "Category for electronic products" },
                        new Category { Name = "Clothing", Description = "Category for clothing items" },
                        new Category {  Name = "Books", Description = "Category for books" }
            };

            Mock<ICategoryRepository> mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.AllCategories).Returns(categories);
            return mockRepository;
        }
    }
}