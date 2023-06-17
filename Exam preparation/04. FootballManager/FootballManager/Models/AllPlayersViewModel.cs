using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Models
{
    /// <summary>
    /// Player view model for showing data
    /// </summary>
    public class AllPlayersViewModel
    {
        public int Id { get; set; }
                
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Position { get; set; } = null!;

        [Required]
        public byte Speed { get; set; }

        [Required]
        public byte Endurance { get; set; }

        [Required]
        public string Description { get; set; } = null!;
    }
}
