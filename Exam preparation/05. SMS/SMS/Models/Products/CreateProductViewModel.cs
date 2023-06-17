using System.ComponentModel.DataAnnotations;

using static SMS.Data.DataConstants.Product;

namespace SMS.Models.Products
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(MinPrice, MaxPrice, ErrorMessage = "{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
    }
}
