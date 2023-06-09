using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Configuration
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
            => new HashSet<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = "2bd4cb6d-b8bd-440f-a8f0-f84b8ec225ef",
                    BoardId = 1
                },
                new Task()
                {
                    Id= 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn= DateTime.Now.AddDays(-5),
                    BoardId = 1,
                    OwnerId = "2bd4cb6d-b8bd-440f-a8f0-f84b8ec225ef"
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "b5731c65-0597-45ab-a4ff-55b8eac87aac",
                    BoardId = 2
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = "b5731c65-0597-45ab-a4ff-55b8eac87aac",
                    BoardId = 3
                }
            };
    }
}
