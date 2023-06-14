using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Models
{
    public class AllDestinationsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string DestinationName { get; set; } = null!;

        [Required]
        public string Origin { get; set; } = null!;

        [Required]
        public string Date { get; set; } = null!;

        [Required]
        public string Time { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public int Tickets { get; set; }
    }
}
