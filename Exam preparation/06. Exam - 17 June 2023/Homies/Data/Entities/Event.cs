namespace Homies.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static Constants.DataConstants.Event;

    public class Event
    {
        public Event()
        {
            CreatedOn = DateTime.UtcNow;
            EventsParticipants = new HashSet<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [ForeignKey(nameof(OrganiserId))]
        public virtual IdentityUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public virtual Type Type { get; set; } = null!;

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
