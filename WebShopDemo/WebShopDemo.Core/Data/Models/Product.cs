using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebShopDemo.Core.Constants;

namespace WebShopDemo.Core.Data.Models
{
    [Comment("Products for sale")]
    public class Product
    {
        [Comment("Primary key")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Product name")]
        [Required]
        [MaxLength(DataConstants.Product.NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Comment("Product price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Products in stock")]
        [Required]
        public int Quantity { get; set; }

        [Comment("Product is active")]
        public bool IsActive { get; set; } = true;
    }
}
