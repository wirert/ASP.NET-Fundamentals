using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static BusStation.Constants.DataConstants.Destination;

namespace BusStation.Data.Entities
{
    [Comment("Destination entity table")]
    public class Destination
    {
        [Comment("Destination primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Destination name")]
        [Required]
        [MaxLength(MaxNameLenght)]
        public string DestinationName { get; set; } = null!;

        [Comment("Destination origin")]
        [Required]
        [MaxLength(MaxOriginLenght)]
        public string Origin { get; set;} = null!;

        [Comment("Destination date")]
        [Required]
        [MaxLength(MaxDateLength)]
        public string Date { get; set; } = null!;

        [Comment("Destination time")]
        [Required]
        [MaxLength(MaxTimeLength)]
        public string Time { get; set; } = null!;

        [Comment("Image URL")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Tickets for the destination")]
        public ICollection<Ticket> Tickets { get; set; } =
            new HashSet<Ticket>();
    }
}
