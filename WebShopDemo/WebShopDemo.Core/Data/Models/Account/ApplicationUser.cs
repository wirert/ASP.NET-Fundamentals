using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Core.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [Comment("User first name")]
        [MaxLength(20)]
        public string? FirstName { get; set; }

        [Comment("User last name")]
        [MaxLength(20)]
        public string? LastName { get; set; }
    }
}
