using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using static SMS.Data.DataConstants.User;

namespace SMS.Models.Users
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(MaxUserNameLenght, MinimumLength = MinUserNameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght,
          ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Password { get; set; } = null!;
    }
}
