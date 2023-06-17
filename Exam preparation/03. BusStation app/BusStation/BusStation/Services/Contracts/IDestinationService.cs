using BusStation.Models;

namespace BusStation.Services.Contracts
{
    public interface IDestinationService
    {
        Task AddAsync(AddDestinationViewModel model);

        Task<IEnumerable<AllDestinationsViewModel>> GetAllDestinationsAsync();
    }
}
