using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShopDemo.Core.Data.Models;

namespace WebShopDemo.Core.Data.Configure
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            List<Product> products = GetProducts();

            builder.HasData(products);
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bread",
                    Price = 2m,
                    Quantity = 100,
                    IsActive = true
                },
                 new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer",
                    Price = 1.5m,
                    Quantity = 200,
                    IsActive = true
                },
                  new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham",
                    Price = 10.45m,
                    Quantity = 40,
                    IsActive = true
                },
                   new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Eggs",
                    Price = 3.5m,
                    Quantity = 60,
                    IsActive = true
                },
                    new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Milk",
                    Price = 2.35m,
                    Quantity = 35,
                    IsActive = true
                }
            };
        }
    }
}
