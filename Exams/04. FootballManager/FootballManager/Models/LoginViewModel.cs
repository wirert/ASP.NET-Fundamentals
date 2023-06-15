using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants.User;

namespace FootballManager.Models
{
    /// <summary>
    /// Login user view model with validation attributes
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// User user name for login
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        [StringLength(MaxUsernameLenght, MinimumLength = MinUsernameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string UserName { get; set; } = null!;              

        /// <summary>
        /// User login password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Password { get; set; } = null!;
    }
}
