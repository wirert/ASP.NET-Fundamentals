using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    [Comment("Category for books in library")]
    public class Category
    {
        [Comment("Primary key of the Category")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the category")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}