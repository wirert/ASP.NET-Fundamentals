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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(u => u.UserName).IsRequired(true);
            builder.Entity<User>().Property(u => u.Email).IsRequired(true);

            base.OnModelCreating(builder);
        }
    }
}