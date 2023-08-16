namespace SoftUniBazar.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants.Ad;

    public class AdFormModel
    {
        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategorySelectModel> Categories { get; set; } = new List<CategorySelectModel>();
    }
}
