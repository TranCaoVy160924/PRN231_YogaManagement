using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Authority.Request;
public class ChangePasswordRequest
{
    [Required(ErrorMessage = "Please enter current password")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; }

    [Required(ErrorMessage = "Please enter new password")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "Please enter confirmation password")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Password confirmation does not match password!")]
    public string ConfirmPassword { get; set; }
}
