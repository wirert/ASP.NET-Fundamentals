using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static FootballManager.Constants.DataConstants.Player;

namespace FootballManager.Models
{
    /// <summary>
    /// Add new player view model with validation attributes
    /// </summary>
    public class AddPlayerViewModel
    {
        /// <summary>
        /// Player full name
        /// </summary>
        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Player picture URL
        /// </summary>
        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Player game position
        /// </summary>
        [Required]
        [StringLength(MaxPositionLenght, MinimumLength = MinPositionLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Position { get; set; } = null!;

        /// <summary>
        /// Player speed
        /// </summary>
        [Required]
        [Range(MinSpeed, MaxSpeed, 
            ErrorMessage = "{0} must be between {1} and {2}")]
        public byte Speed { get; set; }

        /// <summary>
        /// Player endurance
        /// </summary>
        [Required]
        [Range(MinEndurace, MaxEndurace,
            ErrorMessage = "{0} must be between {1} and {2}")]
        public byte Endurance { get; set; }

        /// <summary>
        /// Player description
        /// </summary>
        [Required]
        [StringLength(MaxDescriptionLenght, ErrorMessage ="{0} can't be more than {1} symbols")]
        public string Description { get; set; } = null!;
    }
}
