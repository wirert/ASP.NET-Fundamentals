using System.ComponentModel.DataAnnotations;
using static Watchlist.Constants.DataConstants.User;

namespace Watchlist.Models.User
{
    /// <summary>
    /// Log in view model
    /// </summary>
    public class LogInViewModel
    {
        /// <summary>
        /// User user name for login
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLenght, MinimumLength = MinUserNameLenght,
            ErrorMessage = "Wrong user name")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordlLenght,
            ErrorMessage = "Wrong password")]
        public string Password { get; set; } = null!;
    }
}
