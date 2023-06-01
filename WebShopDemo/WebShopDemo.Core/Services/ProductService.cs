using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Product>(p => p.IsActive)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .ToListAsync();                
        }

        public async Task UpdateProductAsync(Guid id, int count)
        {
            var product = await repo.GetByIdAsync<Product>(id);

            if (product == null || 
                count > product.Quantity) return;
            
            product.Quantity -= count;
                        
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Add new or update product
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        public async Task AddProductAsync(ProductViewModel productViewModel)
        {
            var product = await repo
                .All<Product>(p => p.Name == productViewModel.Name)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                product = new Product();

                product.Id = Guid.NewGuid();
                product.Name = productViewModel.Name;

                await repo.AddAsync(product);
            }
            
            product.Price = productViewModel.Price;
            product.Quantity += productViewModel.Quantity;
            product.IsActive = true;
            
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Get product and add quantity
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="count">Quantity</param>
        /// <returns></returns>
        public async Task AddQuantityAsync(Guid id, int count)
        {
            var product = await repo.GetByIdAsync<Product>(id);

            if (product == null ||
                count <= 0) return;

            product.Quantity += count;

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Set status IsActive to false
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(Guid id)
        {
            var product = await repo.GetByIdAsync<Product>(id);

            if (product == null) return;

            product.IsActive = false;

            await repo.SaveChangesAsync();
        }
    }
}
