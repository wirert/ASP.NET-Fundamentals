using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Homies.Constants.DataConstants.Type;

namespace Homies.Data.Entities
{
	[Comment("Event type table")]
	public class Type
	{
		[Comment("Type primary key")]
		[Key]
		public int Id { get; set; }

		[Comment("Event type name")]
		[Required]
		[MaxLength(MaxNameLenght)]
		public string Name { get; set; } = null!;

		public virtual ICollection<Event> Events { get; set; } = 
			new HashSet<Event>();
    }
}
