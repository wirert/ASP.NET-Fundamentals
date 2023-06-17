using Contacts.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Contacts.Constants.DataConstants.Contact;

namespace Contacts.Models.Contacts
{
    public class AddContactViewModel
    {
        [Required]
        [StringLength(MaxFirstName, MinimumLength = MinFirstName,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string FirstName { get; set; } = null!;
                
        [Required]
        [StringLength(MaxLastName, MinimumLength = MinLastName, 
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string LastName { get; set; } = null!;

        
        [Required]
        [EmailAddress]
        [StringLength(MaxEmail, MinimumLength = MinEmail, 
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Email { get; set; } = null!;

        
        [Required]
        [RegularExpression(@"^(\+359|0)[- ]?\d{3}([- ]?\d{2}){3}$", 
            ErrorMessage = "Type a valid phone number")]
        [StringLength(MaxPhoneNumber, MinimumLength = MinPhoneNumber, 
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string PhoneNumber { get; set; } = null!;
                
        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^www.[A-Za-z\d-]+.bg$",
            ErrorMessage = "Type a valid website")]
        public string Website { get; set; } = null!;
    }
}