using Watchlist.Models.Movies;

namespace Watchlist.Services.Contracts
{
    /// <summary>
    /// Movies service interface
    /// </summary>
    public interface IMoviesService
    {
        Task<ICollection<MoviesViewModel>> GetAllAsync();
    }
}
