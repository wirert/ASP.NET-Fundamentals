using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Entities
{
    public class User : IdentityUser
    {  
        public ICollection<Ticket> Tickets { get; set; } = 
            new HashSet<Ticket>();
    }
}
