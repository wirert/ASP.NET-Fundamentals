namespace Homies.Data.Entities
{
    using static Constants.DataConstants.Type;
    using System.ComponentModel.DataAnnotations;

    public class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
