using FootballManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data
{
    public class FootballManagerDbContext : IdentityDbContext<User>
    {
        public FootballManagerDbContext(DbContextOptions<FootballManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = null!;

        public DbSet<UserPlayer> UsersPlayers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(u => u.UserName).IsRequired(true);
            builder.Entity<User>().Property(u => u.Email).IsRequired(true);

            builder.Entity<UserPlayer>().HasKey(k => new { k.UserId, k.PlayerId });

            base.OnModelCreating(builder);
        }
    }
}