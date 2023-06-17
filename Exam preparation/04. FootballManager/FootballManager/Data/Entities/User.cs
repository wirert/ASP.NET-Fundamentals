using Microsoft.AspNetCore.Identity;

namespace FootballManager.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserPlayer> UserPlayers { get; set; } = 
            new HashSet<UserPlayer>();
    }
}
