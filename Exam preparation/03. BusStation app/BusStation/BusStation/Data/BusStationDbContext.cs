using BusStation.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusStation.Data
{
    public class BusStationDbContext : IdentityDbContext<User>
    {
        public BusStationDbContext(DbContextOptions<BusStationDbContext> options)
            : base(options)
        {
        }
               
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public DbSet<Destination> Destinations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {           
            builder.Entity<User>().Property(u => u.UserName).IsRequired(true);
            builder.Entity<User>().Property(u => u.Email).IsRequired(true);

            base.OnModelCreating(builder);
        }
    }
}