using System.ComponentModel.DataAnnotations;

using static BusStation.Constants.DataConstants.User;

namespace BusStation.Models
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
        [StringLength(MaxUsernameLenght, MinimumLength = MinUsernameLenght,
            ErrorMessage = "Wrong user name")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght,
            ErrorMessage = "Wrong password")]
        public string Password { get; set; } = null!;
    }
}
