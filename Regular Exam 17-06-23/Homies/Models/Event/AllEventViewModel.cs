using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models.Event
{
    public class AllEventViewModel
    {
        public int Id { get; set; }
                
        [Required]       
        public string Name { get; set; } = null!;       

        [Required]
        public string Start { get; set; } = null!;        

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Organiser { get; set;} = null!;
    }
}
