using System.ComponentModel.DataAnnotations;

namespace Library.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;
    }
}
