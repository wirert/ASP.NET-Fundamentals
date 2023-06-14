using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Models.Genre;
using Watchlist.Models.Movies;
using Watchlist.Services.Contracts;

namespace Watchlist.Services
{
    /// <summary>
    /// Movies service
    /// </summary>
    public class MoviesService : IMoviesService
    {
        private readonly WatchlistDbContext context;

        public MoviesService(WatchlistDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Add movie to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                Rating = model.Rating,
                ImageUrl = model.ImageUrl,
                GenreId = model.GenreId
            };

            await context.Movies.AddAsync(movie);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Take all movies from database and transform them to view model list
        /// </summary>
        /// <returns>list of movie view model</returns>
        public async Task<ICollection<MoviesViewModel>> GetAllAsync()
        {
            return await context.Movies               
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

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>list of genre view model</returns>
        public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
        {
            return await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// Get all movies from user watch list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of movie view model</returns>
        public async Task<IEnumerable<MoviesViewModel>> GetWatchedAsync(string id)
        {
            return await context.UsersMovies
                .Where(um => um.UserId == id)
                .Select(um => new MoviesViewModel()
                {
                    Id = um.Movie.Id,
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    Rating = um.Movie.Rating,
                    ImageUrl = um.Movie.ImageUrl,
                    Genre = um.Movie.Genre.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// Add movie to user's watch list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throw exception if movie id is invalid</exception>
        public async Task AddMovieToCollectionAsync(string userId, int movieId)
        {
            bool isAlreadyAdded = await context.UsersMovies
                .AnyAsync(um => um.UserId == userId && um.MovieId == movieId);

            if (isAlreadyAdded)
            {
                return;
            }

            var movie = await context.Movies.FindAsync(movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid movie Id");
            }

            var userMovie = new UserMovie()
            {
                UserId = userId,
                MovieId = movieId,
                Movie = movie
            };

            await context.UsersMovies.AddAsync(userMovie);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove movie from user watch list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throw exception if movie id is invalid</exception>
        public async Task RemoveMovieFromCollectionAsync(string userId, int movieId)
        {
            var movie = await context.Movies.FindAsync(movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid movie Id");
            }

            var userMovie = await context.UsersMovies
                    .FirstOrDefaultAsync(um => um.UserId == userId && um.MovieId == movieId);

            if (userMovie != null)
            {
                context.UsersMovies.Remove(userMovie);

                await context.SaveChangesAsync();
            }
        }
    }
}
