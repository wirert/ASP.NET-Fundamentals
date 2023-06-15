using SMS.Models.Products;

namespace SMS.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<AllProductsViewModel>> GetAllAsync();

        Task AddNewProductAsync(CreateProductViewModel model);
    }
}
