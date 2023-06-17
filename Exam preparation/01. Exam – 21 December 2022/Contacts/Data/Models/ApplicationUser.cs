using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static Contacts.Constants.DataConstants.User;

namespace Contacts.Data.Models
{
    [Comment("User of the contact app (extention of IdentityUser")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("User's username")]
        [Required]
        [MaxLength(MaxUserName)]
        public override string UserName
        {
            get => base.UserName;
            set => base.UserName = value;
        }

        [Comment("User's e-mail")]
        [Required]
        [StringLength(MaxEmail)]
        public override string Email 
        {  
            get => base.Email;
            set => base.Email = value; 
        }

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = 
            new HashSet<ApplicationUserContact>();
    }
}


//•	Has an Id – a string, Primary Key
//•	Has a UserName – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)
//•	Has ApplicationUsersContacts – a collection of type ApplicationUserContact
