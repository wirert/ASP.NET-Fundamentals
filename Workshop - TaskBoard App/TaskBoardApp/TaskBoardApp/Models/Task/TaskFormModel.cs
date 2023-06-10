using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(MaxTitle, MinimumLength = MinTitle,
            ErrorMessage = "{0} should be between {2} and {1} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDescription, MinimumLength = MinDescription,
        ErrorMessage = "{0} should be between {2} and {1} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();

    }
}
