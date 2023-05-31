using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Data.Entities
{
    [Comment("Published posts")]
    public class Post
    {
        [Comment("Post Identity Key")]
        [Key]
        public int Id { get; set; }

        [Comment("Post title")]
        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Comment("Post content")]
        [Required]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; } = null!;

        [Comment("Mark record as deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
