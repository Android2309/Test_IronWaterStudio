using Microsoft.EntityFrameworkCore;
using ProductManager.Models.Entities;

namespace ProductManager.ContextFolder
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
    }

}
