using ForumApp.Data.Configure;
using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext 
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            :base(options) { }
        

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            modelBuilder.Entity<Post>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
