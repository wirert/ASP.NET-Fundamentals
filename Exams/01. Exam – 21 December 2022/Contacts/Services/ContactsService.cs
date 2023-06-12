using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models.Contacts;
using Contacts.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ContactsDbContext context;

        public ContactsService(ContactsDbContext _context)
        {
            context = _context;
        }

        public async Task AddContactAsync(AddContactViewModel model)
        {
            var contact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();
        }

        public async Task AddContactToTeamAsync(string userId, int contactId)
        {
            await context.UsersContacts.AddAsync(new ApplicationUserContact()
            {
                ApplicationUserId = userId,
                ContactId = contactId
            });

            await context.SaveChangesAsync();
        }

        public async Task EditContactAsync(AddContactViewModel model, int contactId)
        {
            var contact = await context.Contacts.FindAsync(contactId);

            if (contact != null)
            {
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
                contact.Email = model.Email;
                contact.PhoneNumber = model.PhoneNumber;
                contact.Address = model.Address;
                contact.Website = model.Website;

                await context.SaveChangesAsync();
            }
        }

        public async Task<AddContactViewModel?> FindContactByIdAsync(int id)
        {
            return await context.Contacts
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new AddContactViewModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<ContactsViewModel>> GetAllContactsAsync()
        {
            return await context.Contacts
                .AsNoTracking()
                .Select(c => new ContactsViewModel
                {
                    ContactId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                    Website = c.Website
                })
                .ToListAsync();
        }

        public async Task<ICollection<ContactsViewModel>> GetTeamContactsAsync(string userId)
        {
            return await context.UsersContacts
                .AsNoTracking()
                .Where(uc => uc.ApplicationUserId == userId)
                .Select(uc => new ContactsViewModel
                {
                    ContactId = uc.Contact.Id,
                    FirstName = uc.Contact.FirstName,
                    LastName = uc.Contact.LastName,
                    Email = uc.Contact.Email,
                    Address = uc.Contact.Address,
                    PhoneNumber = uc.Contact.PhoneNumber,
                    Website = uc.Contact.Website
                })
                .ToListAsync();
        }

        public async Task<bool> HasContactAsync(string userId, int contactId)
                => await context.UsersContacts
                          .AnyAsync(uc => uc.ContactId == contactId && uc.ApplicationUserId == userId);

        public async Task RemoveContactFromTeamAsync(string userId, int contactId)
        {
            var userContact = await context.UsersContacts
                .FirstOrDefaultAsync(uc => uc.ApplicationUserId == userId && uc.ContactId == contactId);

            if (userContact != null)
            {
                context.UsersContacts.Remove(userContact);

                await context.SaveChangesAsync();
            }           
        }
    }
}
