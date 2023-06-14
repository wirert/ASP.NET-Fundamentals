using System.ComponentModel.DataAnnotations;
using static BusStation.Constants.DataConstants.Ticket;

namespace BusStation.Models
{
    public class CreateTicketsViewModel
    {
        [Required]
        [Range(MinPrice, MaxPrice, ErrorMessage = "The {0} must be between {1} and {2}")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DestinationId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "The {0} must be between {1} and {2}")]
        public int TicketsCount { get; set; }
    }
}
