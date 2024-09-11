using Microsoft.EntityFrameworkCore;

namespace StorageLogistic.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }

    }
}