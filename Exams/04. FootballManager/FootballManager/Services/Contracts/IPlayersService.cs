using FootballManager.Models;

namespace FootballManager.Services.Contracts
{
    /// <summary>
    /// Player service interface
    /// </summary>
    public interface IPlayersService
    {
        /// <summary>
        /// Get all players from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllPlayersViewModel>> GetAllAsync();

        /// <summary>
        /// Add new player to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(AddPlayerViewModel model);

        /// <summary>
        /// Add player to user collection of players in database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        Task AddToCollectionAsync(string userId, int playerId);

        /// <summary>
        /// Return collection of user's players
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<AllPlayersViewModel>> GetCollectionAsync(string userId);

        /// <summary>
        /// Remove player from user collection of players in DB
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        Task RemoveFromCollectionAsync(string userId, int playerId);
    }
}
