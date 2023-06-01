using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Data.Configure;
using WebShopDemo.Core.Data.Models;

namespace WebShopDemo.Core.Data
{
    /// <summary>
    /// WebShop database context 
    /// </summary>
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }
    }
}
