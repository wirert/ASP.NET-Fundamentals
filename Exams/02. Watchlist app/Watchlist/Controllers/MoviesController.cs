using Microsoft.AspNetCore.Mvc;
using Watchlist.Services.Contracts;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;
               
        public MoviesController(IMoviesService _moviesService)
        {
            moviesService = _moviesService;
        }

        public async Task<IActionResult> All()
        {
            var movies = await moviesService.GetAllAsync();

            return View(movies);
        }
    }
}
