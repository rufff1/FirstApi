using Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.DataBaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog>  Blogs { get; set; }
    }
}
