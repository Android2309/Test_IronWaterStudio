using Microsoft.EntityFrameworkCore;
using PublicApi.Models;

namespace PublicApi.ContextFolder
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
