using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStation.Data.Entities
{
    [Comment("Bus ticket table")]
    public class Ticket
    {
        [Comment("Ticket primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Ticket price")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }

        [Comment("Ticket's owner Id")]        
        public string? UserId { get; set; }

        [Comment("Ticket's owner")]
        [ForeignKey(nameof(UserId))]        
        public User? User { get; set; }

        [Comment("Travel destination Id for the ticket")]
        [Required]
        public int DestinationId { get; set; }

        [Comment("Travel destination for the ticket")]
        [Required]
        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; } = null!;
    }
}
