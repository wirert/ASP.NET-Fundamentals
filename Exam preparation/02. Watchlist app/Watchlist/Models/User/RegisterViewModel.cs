using System.ComponentModel.DataAnnotations;

using static Watchlist.Constants.DataConstants.User;

namespace Watchlist.Models.User
{
    /// <summary>
    /// Register new user view model
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User user name
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLenght, MinimumLength = MinUserNameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User e-mail
        /// </summary>
        [Required]
        [StringLength(MaxEmailLenght, MinimumLength = MinEmailLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordlLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Confirm user password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
