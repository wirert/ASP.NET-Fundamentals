using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using FootballManager.Models;
using FootballManager.Services.Contracts;

namespace FootballManager.Controllers
{
    /// <summary>
    /// Players controller
    /// </summary>
    public class PlayersController : BaseController
    {
        private readonly IPlayersService playersService;

        public PlayersController(IPlayersService _playersService)
        {
            playersService = _playersService;
        }


        /// <summary>
        /// Show all players
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var models = await playersService.GetAllAsync();

            return View(models);
        }

        /// <summary>
        /// Add new player get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPlayerViewModel();

            return View(model);
        }

        /// <summary>
        /// Add new player post method
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddPlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await playersService.AddAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        /// <summary>
        /// Add player to user collection of players
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddToCollection(int playerId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await playersService.AddToCollectionAsync(userId, playerId);
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError("", ae.Message);                
            }

            return RedirectToAction("All", "Players");
        }

        /// <summary>
        /// Show all user's players
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Collection()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var models = await playersService.GetCollectionAsync(userId);

            return View(models);
        }

        /// <summary>
        /// Remove player from user's collection of players
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveFromCollection(int playerId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await playersService.RemoveFromCollectionAsync(userId, playerId);
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError("", ae.Message);
            }

            return RedirectToAction("Collection", "Players");
        }
    }
}
