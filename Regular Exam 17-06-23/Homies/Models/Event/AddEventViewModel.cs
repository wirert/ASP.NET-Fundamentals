using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


using static Homies.Constants.DataConstants.Event;

namespace Homies.Models.Event
{
    public class AddEventViewModel
    {
        public int? Id { get; set; }

        [Comment("Event name")]
        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLenght, MinimumLength = MinDescriptionLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Description { get; set; } = null!;

        [Required]        
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }        

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
