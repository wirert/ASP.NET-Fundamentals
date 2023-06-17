using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SMS.Data.Entities
{
    [Comment("Application user")]
    public class User : IdentityUser
    {
        [Comment("User shopping cart id")]
        [Required]
        public string CartId { get; set; } = null!;

        [Required]
        public Cart Cart { get; set; } = null!;
    }
}
