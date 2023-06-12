using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Models
{
    [Comment("Connecting table")]
    public class ApplicationUserContact
    {        
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public int ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public Contact Contact { get; set; } = null!;
    }
}
