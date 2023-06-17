using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static BusStation.Constants.DataConstants.Destination;

namespace BusStation.Models
{
    public class AddDestinationViewModel
    {
        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string DestinationName { get; set; } = null!;

        [Required]
        [StringLength(MaxOriginLenght, MinimumLength = MinOriginLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string Origin { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
                

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;
    }
}
