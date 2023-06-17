using System.ComponentModel.DataAnnotations;
using static Contacts.Constants.DataConstants.User;

namespace Contacts.Models.User
{
    /// <summary>
    /// Login view model
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// user login username
        /// </summary>
        [Required]
        [StringLength(MaxUserName, MinimumLength = MinUserName, ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// user's login password
        /// </summary>
        [Required]
        [StringLength(MaxPassword, MinimumLength = MinPassword, ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Return URL, when there is redirection to login page from another page which requre login
        /// </summary>
        [UIHint("hidden")]
        public string? ReturnUrl { get; set; }
    }
}
