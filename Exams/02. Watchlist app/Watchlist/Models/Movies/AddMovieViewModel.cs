using System.ComponentModel.DataAnnotations;

using Watchlist.Models.Genre;
using static Watchlist.Constants.DataConstants.Movie;

namespace Watchlist.Models.Movies
{
    /// <summary>
    /// Add new movie view model
    /// </summary>
    public class AddMovieViewModel
    {
        /// <summary>
        /// Movie title
        /// </summary>
        [Required]
        [StringLength(MaxTitleLenght, MinimumLength = MinTitleLenght, 
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Title { get; set; } = null!;
              
        /// <summary>
        /// Movie director
        /// </summary>
        [Required]
        [StringLength(MaxDirectorLenght, MinimumLength = MinDirectorLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Director { get; set; } = null!;

        /// <summary>
        /// Movie cover URL
        /// </summary>
        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Movie rating
        /// </summary>
        [Required]
        [Range(MinRating, MaxRating, ErrorMessage = "Rating must be between {1} and {2}")]
        public decimal Rating { get; set; }

        /// <summary>
        /// Movie genre id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        /// <summary>
        /// Collection of all genres for the view
        /// </summary>
        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
