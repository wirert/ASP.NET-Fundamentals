using BusStation.Models;

namespace BusStation.Services.Contracts
{
    public interface ITicketService
    {
        Task CreateAsync(CreateTicketsViewModel model);

        Task BookAsync(string userId, int destId);

        Task<IEnumerable<MyTicketViewModel>> GetMyTicketsAsync(string userId);
    }
}
