namespace SoftUniBazar.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants.Category;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; } = new HashSet<Ad>();
    }
}
