using System.ComponentModel.DataAnnotations;

namespace Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password"), Compare("Password")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LName { get; set; }

        [MaxLength(200)]
        public string? AboutMe { get; set; }

        [Required(ErrorMessage = "Phone Number is required"), MaxLength(11)]
        [RegularExpression("01[0-9]+")]
        public string? Phone { get; set; }
    }
}
