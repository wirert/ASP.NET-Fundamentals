using SMS.Models.Products;

namespace SMS.Services.Contracts
{
    public interface ICartsService
    {
        Task AddToCartAsync(string userId, string productId);

        Task<IEnumerable<AllProductsViewModel>> GetCartDetailsAsync(string userId);

        Task BuyAsync(string userId);
    }
}
