using Microsoft.EntityFrameworkCore;

namespace AYStore.Models
{
    public class AYStoreDbContext : DbContext
    {

        public AYStoreDbContext(DbContextOptions<AYStoreDbContext> options): base(options)
        {
           
        }

       public DbSet<Product> Products { get; set; }
       public DbSet<Category> Categories { get; set; }
    }
}
