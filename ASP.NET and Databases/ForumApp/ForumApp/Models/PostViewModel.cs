using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Models
{
    public class PostViewModel : AddPostViewModel
    {
        /// <summary>
        /// Post ID
        /// </summary>
        public int Id { get; set; }
    }
}
