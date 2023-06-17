using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.Contacts
{
    public class ContactsViewModel
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;
       
        public string Email { get; set; } = null!;
       
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }
        
        public string Website { get; set; } = null!;
    }
}
