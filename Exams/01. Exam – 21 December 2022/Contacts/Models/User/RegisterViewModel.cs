using System.ComponentModel.DataAnnotations;

using static Contacts.Constants.DataConstants.User;

namespace Contacts.Models.User
{
    /// <summary>
    /// Register view model
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User username
        /// </summary>
        [Required]
        [StringLength(MaxUserName, MinimumLength = MinUserName, ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// User e-mail
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(MaxEmail, MinimumLength = MinEmail, ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Email { get; set;} = null!;

        /// <summary>
        /// user's login password
        /// </summary>
        [Required]
        [StringLength(MaxPassword, MinimumLength = MinPassword, ErrorMessage = "{0} must be between {2} and {1} symbols")]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; } = null!;

        /// <summary>
        /// User confurm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
