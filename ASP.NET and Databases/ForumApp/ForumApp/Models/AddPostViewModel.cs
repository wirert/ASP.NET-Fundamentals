using System.ComponentModel.DataAnnotations;
using static ForumApp.Constants.DataConstants.Post;
using System.Xml.Linq;

namespace ForumApp.Models
{
    public class AddPostViewModel
    {
        /// <summary>
        /// Post Title
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Title")]
        [StringLength(TitleMaxLenght,
                    MinimumLength = TitleMinLenght,
                    ErrorMessage = "The field {0} must between {2} and {1} symbols")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Post content
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(ContentMaxLenght,
                    MinimumLength = ContentMinLenght,
                    ErrorMessage = "The field {0} must between {2} and {1} symbols")]
        public string Content { get; set; } = null!;
    }
}
