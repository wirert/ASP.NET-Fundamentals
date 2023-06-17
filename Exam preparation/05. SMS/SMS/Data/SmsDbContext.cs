using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMS.Data.Entities;

namespace SMS.Data
{
    public class SmsDbContext : IdentityDbContext<User>
    {
        public SmsDbContext(DbContextOptions<SmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(u => u.UserName).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();

            builder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .IsRequired(true);

            base.OnModelCreating(builder);
        }
    }
}