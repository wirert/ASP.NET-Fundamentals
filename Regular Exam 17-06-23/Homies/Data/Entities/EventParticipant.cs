using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data.Entities
{
	[Comment("Connecting table for relation many to many")]
	public class EventParticipant
	{
		[Required]
		public string HelperId { get; set; } = null!;

		[ForeignKey(nameof(HelperId))]
		public IdentityUser Helper { get; set; } = null!;

        [Required]
        public int EventId { get; set; }

		[ForeignKey(nameof(EventId))]
		public Event Event { get; set; } = null!;
    }
}
