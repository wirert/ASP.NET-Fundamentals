using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Models.Products;
using SMS.Services.Contracts;

namespace SMS.Services
{
	public class CartsService : ICartsService
    {
        private readonly SmsDbContext context;

        public CartsService(SmsDbContext _context)
        {
            context = _context;
        }

        public async Task AddToCartAsync(string userId, string productId)
        {
            var user = await context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("Wrong user");
            }

            var product = await context.Products.FindAsync(productId);

            if (product == null) 
            {
                throw new ArgumentException("Wrong product Id");
            }

            if (product.CartId != null)
            {
                throw new ArgumentException("This product is in anothor users shopping cart");
            }

            product.CartId = user.CartId;

            await context.SaveChangesAsync();
        }

		public async Task BuyAsync(string userId)
		{
			var cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

			if (cart == null)
			{
				throw new ArgumentException("Wrong user id");
			}

			var products = await context.Products
				.Where(p => p.CartId == cart.Id)
                .ToListAsync();

            context.Products.RemoveRange(products);

            await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<AllProductsViewModel>> GetCartDetailsAsync(string userId)
		{
			var cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                throw new ArgumentException("Wrong user id");
            }

			return await context.Products
                .Where(p => p.CartId == cart.Id)
                .Select(p => new AllProductsViewModel
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToListAsync();
		}
	}
}
