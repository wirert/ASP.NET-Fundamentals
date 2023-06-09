using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Configuration;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<Board> Boards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BoardEntityConfiguration());
            builder.ApplyConfiguration(new TaskEntityConfiguration());

            base.OnModelCreating(builder);
        }

    }
}