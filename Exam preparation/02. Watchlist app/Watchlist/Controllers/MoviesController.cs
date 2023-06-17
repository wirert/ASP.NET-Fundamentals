using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Models.Movies;
using Watchlist.Services.Contracts;

namespace Watchlist.Controllers
{
    /// <summary>
    /// Movies controller
    /// </summary>
    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService _moviesService)
        {
            moviesService = _moviesService;
        }

        /// <summary>
        /// Show all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await moviesService.GetAllAsync();

            return View(movies);
        }

        /// <summary>
        /// Add new movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel()
            {
                Genres = await moviesService.GetGenresAsync()
            };

            return View(model);
        }

        /// <summary>
        /// Add new movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await moviesService.AddMovieAsync(model);

                return RedirectToAction("All", "Movies");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        /// <summary>
        /// Show user's watch list
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Watched()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await moviesService.GetWatchedAsync(userId);

            return View(model);
        }

        /// <summary>
        /// Add movie to user's watch list
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {     
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await moviesService.AddMovieToCollectionAsync(userId, movieId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("All", "Movies");
        }

        /// <summary>
        /// Removes movie from user's watch list
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await moviesService.RemoveMovieFromCollectionAsync(userId, movieId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Watched", "Movies");
        }
    }
}
