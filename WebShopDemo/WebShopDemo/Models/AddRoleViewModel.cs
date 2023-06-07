using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Models
{
    public class AddRoleViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string RoleName { get; set; }
    }
}
