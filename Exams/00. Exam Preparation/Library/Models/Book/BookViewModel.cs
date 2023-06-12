using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Book
{
    public class BookViewModel
    {   
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, 
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Title { get; set; } = null!;

        [Comment("Author of the book")]
        [Required]
        [StringLength(50, MinimumLength = 5,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5,
             ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(0.0, 10.00, ErrorMessage = "{0} must be between {1} and {2}")]
        public decimal Rating { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

    }
}
