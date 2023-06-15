using Microsoft.EntityFrameworkCore;

using FootballManager.Data;
using FootballManager.Models;
using FootballManager.Services.Contracts;
using FootballManager.Data.Entities;

namespace FootballManager.Services
{
    /// <summary>
    /// Player service
    /// </summary>
    public class PlayersService : IPlayersService
    {
        private readonly FootballManagerDbContext context;

        public PlayersService(FootballManagerDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Add new player to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddAsync(AddPlayerViewModel model)
        {
            await context.Players.AddAsync(new Player()
            {
                FullName = model.FullName,
                Description = model.Description,
                Speed = model.Speed,
                Endurance = model.Endurance,
                ImageUrl = model.ImageUrl,
                Position = model.Position
            });

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Add player to user collection of players in database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public async Task AddToCollectionAsync(string userId, int playerId)
        {
            var player = await context.Players.FirstOrDefaultAsync(p => p.Id == playerId);

            if (player == null)
            {
                throw new ArgumentException("Invalid player Id");
            }

            if (await context.UsersPlayers.AnyAsync(up => up.UserId == userId && up.PlayerId == playerId))
            {
                throw new ArgumentException("This player is already in user's collection.");
            }

            await context.UsersPlayers.AddAsync(new UserPlayer()
            {
                PlayerId = playerId,
                UserId = userId
            });

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all players from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllPlayersViewModel>> GetAllAsync()
        {
            return await context.Players
                .Select(p => new AllPlayersViewModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Description = p.Description,
                    Endurance = p.Endurance,
                    Speed = p.Speed,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position
                })
                .ToListAsync();
        }

        /// <summary>
        /// Return collection of user's players
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AllPlayersViewModel>> GetCollectionAsync(string userId)
        {
            return await context.UsersPlayers
                .Where(up => up.UserId == userId)
                .Select(up => new AllPlayersViewModel()
                {
                    Id = up.Player.Id,
                    FullName = up.Player.FullName,
                    Description = up.Player.Description,
                    Endurance = up.Player.Endurance,
                    Speed = up.Player.Speed,
                    ImageUrl = up.Player.ImageUrl,
                    Position = up.Player.Position
                })
                .ToListAsync();
        }

        /// <summary>
        /// Remove player from user collection of players in DB
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public async Task RemoveFromCollectionAsync(string userId, int playerId)
        {
            var userPlayer = await context.UsersPlayers
                .FirstOrDefaultAsync(up => up.UserId == userId && up.PlayerId == playerId);

            if (userPlayer == null) 
            {
                throw new ArgumentException("Wrong user Id or player Id!");
            }

            context.UsersPlayers.Remove(userPlayer);

            await context.SaveChangesAsync();
        }
    }
}
