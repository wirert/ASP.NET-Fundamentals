using Contacts.Models.Contacts;

namespace Contacts.Services.Contracts
{
    public interface IContactsService
    {
        Task<ICollection<ContactsViewModel>> GetAllContactsAsync();

        Task<ICollection<ContactsViewModel>> GetTeamContactsAsync(string userId);

        Task AddContactAsync(AddContactViewModel model);

        Task<AddContactViewModel> FindContactByIdAsync(int id);

        Task<bool> HasContactAsync(string userId, int contactId);

        Task AddContactToTeamAsync(string userId, int contactId);
        Task RemoveContactFromTeamAsync(string userId, int contactId);

        Task EditContactAsync(AddContactViewModel model, int contactId);
    }
}
