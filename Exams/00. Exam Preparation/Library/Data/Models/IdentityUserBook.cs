using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("User books")]
    public class IdentityUserBook
    {
        [Comment("Book collector Id")]
        public string CollectorId { get; set; } = null!;

        [Comment("Book collector")]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Comment("Collector's book Id")]
        public int BookId { get; set; }

        [Comment("Collector's book")]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}