namespace AYStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product? GetProductById(int id);
        IEnumerable<Product> SearchProducts(string searchQuery);
    }
}
