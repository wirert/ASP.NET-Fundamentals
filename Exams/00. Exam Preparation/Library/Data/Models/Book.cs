﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("Book for the library")]
    public class Book
    {
        [Comment("Primary key")]
        [Key] 
        public int Id { get; set; }

        [Comment("Title of the book")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Comment("Author of the book")]
        [Required]
        [StringLength(50)]
        public string Author { get; set; } = null!;

        [Comment("Description of the book")]
        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        [Comment("Image URL of the book")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Rating of the book")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("Category ID of the book")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Category of the book")]
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new HashSet<IdentityUserBook>();
    }
}
