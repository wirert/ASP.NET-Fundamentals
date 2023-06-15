using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Data.Entities
{
    public class UserPlayer
    {
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; } = null!;
    }
}