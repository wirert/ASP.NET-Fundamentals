using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static FootballManager.Constants.DataConstants.Player;

namespace FootballManager.Data.Entities
{
    [Comment("Football player db model")]
    public class Player
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Player full name")]
        [Required]
        [MaxLength(MaxNameLenght)]
        public string FullName { get; set; } = null!;

        [Comment("Player image URL")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Player position")]
        [Required]
        [MaxLength(MaxPositionLenght)]
        public string Position { get; set; } = null!;

        [Comment("Player speed")]
        [Required]
        public byte Speed { get; set; }

        [Comment("Player endurance")]
        [Required]
        public byte Endurance { get; set; }

        [Comment("Player description")]
        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; } = null!;

        public ICollection<UserPlayer> UserPlayers { get; set; } =
            new HashSet<UserPlayer>();
    }
}
