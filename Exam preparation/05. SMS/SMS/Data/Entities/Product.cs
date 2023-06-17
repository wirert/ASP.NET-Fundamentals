using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static SMS.Data.DataConstants.Product;

namespace SMS.Data.Entities
{
    [Comment("Shop's product")]
    public class Product
    {
        [Comment("Product primary key")]
        [Key]
        public string Id { get; init; } = null!;

        [Comment("Product name")]
        [Required]
        [MaxLength(MaxNameLenght)]
        public string Name { get; set; } = null!;

        [Comment("Product price")]
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Comment("User shopping cart Id")]
        public string? CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart? Cart { get; set; }
    }
}
