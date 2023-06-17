using System.ComponentModel.DataAnnotations;

using static BusStation.Constants.DataConstants.User;

namespace BusStation.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(MaxUsernameLenght, MinimumLength = MinUsernameLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]  
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(MaxEmailLenght, MinimumLength = MinEmailLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght,
            ErrorMessage = "{0} must be between {2} and {1} symbols")]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
