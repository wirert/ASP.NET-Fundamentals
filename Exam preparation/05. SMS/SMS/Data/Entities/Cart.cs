using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace SMS.Data.Entities
{
    [Comment("Shopping cart")]
    public class Cart
    {
        [Comment("Cart primary key")]
        [Key]
        public string Id { get; set; } = null!;

        [Comment("Cart owner Id")]
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public User User { get; set; } = null!;

        public ICollection<Product> Products { get; set; } =
            new HashSet<Product>();
    }
}