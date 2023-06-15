using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Data.Entities;
using SMS.Models.Products;
using SMS.Services.Contracts;

namespace SMS.Services
{
    public class ProductsService : IProductsService
    {
        private readonly SmsDbContext context;

        public ProductsService(SmsDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewProductAsync(CreateProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Id = Guid.NewGuid().ToString()
            };

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllProductsViewModel>> GetAllAsync()
        {
            return await context.Products
                    .Where(p => p.CartId == null)
                    .Select(p => new AllProductsViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToListAsync();
        }
    }
}
