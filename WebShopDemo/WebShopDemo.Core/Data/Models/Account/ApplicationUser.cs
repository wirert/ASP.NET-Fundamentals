using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebShopDemo.Core.Constants;

namespace WebShopDemo.Core.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [Comment("User first name")]
        [MaxLength(DataConstants.User.FirstNameMaxLenght)]
        public string? FirstName { get; set; }

        [Comment("User last name")]
        [MaxLength(DataConstants.User.LastNameMaxLenght)]
        public string? LastName { get; set; }
    }
}
