using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Models.Movies;
using Watchlist.Services.Contracts;

namespace Watchlist.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly WatchlistDbContext context;

        public MoviesService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task<ICollection<MoviesViewModel>> GetAllAsync()
        {
            return await context.Movies
                .AsNoTracking()
                .Select(m => new MoviesViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    Rating = m.Rating,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name
                })
                .ToListAsync();
        }
    }
}
