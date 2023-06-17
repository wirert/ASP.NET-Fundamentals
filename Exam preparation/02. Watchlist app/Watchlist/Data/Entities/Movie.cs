using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Constants.DataConstants.Movie;

namespace Watchlist.Data.Entities
{
    [Comment("Movie class")]
    public class Movie
    {
        [Comment("Movie primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Movie title")]
        [Required]
        [MaxLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Comment("Movie director")]
        [Required]
        [MaxLength(MaxDirectorLenght)]
        public string Director { get; set; } = null!;

        [Comment("Movie cover URL")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Movie rating")]
        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Rating { get; set; }

        [Comment("Movie genre Id")]
        [Required]
        public int GenreId { get; set; }

        [Comment("Movie genre")]
        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<UserMovie> UsersMovies { get; set; } =
            new HashSet<UserMovie>();
    }
}
