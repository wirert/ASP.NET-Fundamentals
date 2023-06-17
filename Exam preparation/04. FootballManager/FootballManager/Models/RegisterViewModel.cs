using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants.User;

namespace FootballManager.Models
{
    /// <summary>
    /// Register new user view model with validation attributes
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User user name
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        [StringLength(MaxUsernameLenght, MinimumLength = MinUsernameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User e-mail
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(MaxEmailLenght, MinimumLength = MinEmailLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols!")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Confirm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!; 
    }
}
