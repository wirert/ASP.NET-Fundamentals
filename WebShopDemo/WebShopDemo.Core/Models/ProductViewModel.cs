using System.ComponentModel.DataAnnotations;
using WebShopDemo.Core.Constants;

namespace WebShopDemo.Core.Models
{
    /// <summary>
    /// Product view model
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Required]        
        [StringLength(DataConstants.Product.NameMaxLenght, 
            MinimumLength = DataConstants.Product.NameMinLenght, 
            ErrorMessage = "The {0} must be between {2} and {1} symbols")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Product price
        /// </summary>
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }

        /// <summary>
        /// Products in stock
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
