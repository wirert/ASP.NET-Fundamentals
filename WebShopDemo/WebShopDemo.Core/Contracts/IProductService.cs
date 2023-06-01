using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Contracts
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductViewModel>> GetAllAsync();

        /// <summary>
        /// Get product and update quantity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task UpdateProductAsync(Guid id, int count);

        /// <summary>
        /// Add new or update product
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        Task AddProductAsync(ProductViewModel productViewModel);

        /// <summary>
        /// Get product and add quantity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task AddQuantityAsync(Guid id, int count);

        /// <summary>
        /// Set status IsActive to false
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProductAsync(Guid id);
    }
}
