using Watchlist.Models.Genre;
using Watchlist.Models.Movies;

namespace Watchlist.Services.Contracts
{
    /// <summary>
    /// Movies service interface
    /// </summary>
    public interface IMoviesService
    {
        /// <summary>
        /// Take all movies from database and transform them to view model list
        /// </summary>
        /// <returns>list of movie view model</returns>
        Task<ICollection<MoviesViewModel>> GetAllAsync();

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>list of genre view model</returns>
        Task<IEnumerable<GenreViewModel>> GetGenresAsync();

        /// <summary>
        /// Add movie to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddMovieAsync(AddMovieViewModel model);

        /// <summary>
        /// Get all movies from user watch list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of movie view model</returns>
        Task<IEnumerable<MoviesViewModel>> GetWatchedAsync(string id);

        /// <summary>
        /// Add movie to user's watch list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task AddMovieToCollectionAsync(string userId, int movieId);

        /// <summary>
        /// Remove movie from user watch list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task RemoveMovieFromCollectionAsync(string userId, int movieId);
    }
}
