using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configure
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPosts();

            builder.HasData(posts);
        }

        private List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post
                {
                    Id = 10,
                    Title = "My first post",
                    Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
                },
                new Post
                {
                    Id = 11,
                    Title = "My second post",
                    Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
                },
                new Post
                {
                    Id = 12,
                    Title = "My third post",
                    Content = "Hello there! I'm getting better and better with CRUD operations in MVC. Stay tuned!"
                }
            };
        }
    }
}
