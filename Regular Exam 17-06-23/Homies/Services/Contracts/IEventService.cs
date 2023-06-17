using Homies.Models.Event;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId);

        Task<ICollection<TypeViewModel>> GetTypesAsync();

        Task AddEventAsync(string userId, AddEventViewModel model);

        Task<AddEventViewModel?>  FindEventByIdAsync (int id);

        Task EditEventAsync(AddEventViewModel model);

        Task JoinAsync(string userId, int eventId);
    }
}
