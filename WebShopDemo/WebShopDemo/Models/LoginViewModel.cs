using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Models
{
    /// <summary>
    /// Login view model
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// User login e-mail 
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User login password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Return URL, when there is redirection to login page from another page which requre login
        /// </summary>
        [UIHint("hidden")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Check box value on page
        /// </summary>
        [Required]
        [Display(Name = "RememberMe")]
        public bool IsPersistent { get; set; }
    }
}
