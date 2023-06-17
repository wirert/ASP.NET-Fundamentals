using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Watchlist.Constants.DataConstants.Genre;

namespace Watchlist.Data.Entities
{
    [Comment("Movie genre")]
    public class Genre
    {
        [Comment("Genre primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Genre name")]
        [Required]
        [MaxLength(MaxNameLenght)]
        public string Name { get; set; } = null!;

        [Comment("Genre's collection of movies")]
        public ICollection<Movie> Movies { get; set; } = new 
            HashSet<Movie>();
    }
}
