namespace Watchlist.Models.Movies
{
    /// <summary>
    /// Movie view model
    /// </summary>
    public class MoviesViewModel
    {
        /// <summary>
        /// Movie Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Movie title
        /// </summary>
        public string Title { get; set; } = null!;
           
        /// <summary>
        /// Movie director
        /// </summary>
        public string Director { get; set; } = null!;

        /// <summary>
        /// Movie cover URL
        /// </summary>
        public string ImageUrl { get; set; } = null!;
                
        /// <summary>
        /// Movie rating
        /// </summary>
        public decimal Rating { get; set; }

        /// <summary>
        /// Movie genre
        /// </summary>
        public string Genre { get; set; } = null!;
    }
}
