using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Models
{
    /// <summary>
    /// Register view model
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User Email for registration
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [Compare(nameof(PasswordRepeat))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// User confurm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; } = null!;

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The field {0} must be between {2} and {1} symbols")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} symbols")]
        public string LastName { get; set; } = null!;
    }
}
