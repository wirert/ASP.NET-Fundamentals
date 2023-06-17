using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Contacts.Constants.DataConstants.Contact;

namespace Contacts.Data.Models
{
    [Comment("Contact for users to use")]
    public class Contact
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("First name of the contact")]
        [Required]
        [MaxLength(MaxFirstName)]
        public string FirstName { get; set; } = null!;

        [Comment("Last name of the contact")]
        [Required]
        [MaxLength(MaxLastName)]
        public string LastName { get; set; } = null!;

        [Comment("Email of the contact")]
        [Required]
        [MaxLength(MaxEmail)]
        public string Email { get; set; } = null!;

        [Comment("Phone number of the contact")]
        [Required]
        [MaxLength(MaxPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } =
            new HashSet<ApplicationUserContact>();
    }
}

//•	Has Id – a unique integer, Primary Key
//•	Has FirstName – a string with min length 2 and max length 50 (required)
//•	Has LastName – a string with min length 5 and max length 50 (required)
//•	Has Email – a string with min length 10 and max length 60 (required)
//•	Has PhoneNumber – a string with min length 10 and max length 13 (required). The phone number must start with "+359" or '0' (zero), followed by four sets of digits, separated by a space, '-' (dash) or nothing between the sets. The first group must have exactly three digits and the others exactly two digits. Valid examples: 0 875 23 45 15, +359 - 883 - 15 - 12 - 10, 0889552217.
//•	Has Address – a string 
//•	Has Website – a string. First four characters are "www.", followed by letters, digits or '-' and last three characters are ".bg" (required)
//•	Has ApplicationUsersContacts – a collection of type ApplicationUserContact
