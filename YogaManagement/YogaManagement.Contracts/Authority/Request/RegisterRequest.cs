using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Authority.Request
{
    public class RegisterRequest
    {
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters!")]
        [Required(ErrorMessage = "Please enter first name:")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters!")]
        [Required(ErrorMessage = "Please enter last name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
