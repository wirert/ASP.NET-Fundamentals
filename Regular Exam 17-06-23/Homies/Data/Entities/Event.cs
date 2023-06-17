using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static Homies.Constants.DataConstants.Event;

namespace Homies.Data.Entities
{
	[Comment("Event table")]
	public class Event
	{
		[Comment("Primary key")]
		[Key]
		public int Id { get; set; }

		[Comment("Event name")]
		[Required]
		[MaxLength(MaxNameLenght)]
		public string Name { get; set; } = null!;

		[Comment("Event description")]
		[Required]
		[MaxLength(MaxDescriptionLenght)]
		public string Description { get; set; } = null!;

        [Comment("Date and time of creation of the event")]
        [Required]
        public DateTime CreatedOn { get; set; }

		[Comment("Event start date and time")]
		[Required]
		public DateTime Start { get; set; }

		[Comment("Event end date and time")]
		[Required]
		public DateTime End { get; set; }

		[Required]
		public string OrganiserId { get; set; } = null!;

		[ForeignKey(nameof(OrganiserId))]
		public virtual IdentityUser Organiser { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

		[ForeignKey(nameof(TypeId))]
		public virtual Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; } = 
			new HashSet<EventParticipant>();
    }
}
