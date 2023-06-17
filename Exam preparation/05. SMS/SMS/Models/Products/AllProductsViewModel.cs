using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.Products
{
    public class AllProductsViewModel
    {
        public string? Id { get; init; }

        [Required]
        public string Name { get; set; } = null!;
                
        [Required]
        public decimal Price { get; set; }

        public string? CartId { get; set; }
    }
}
