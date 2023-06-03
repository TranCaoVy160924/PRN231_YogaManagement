using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Authority.Request;
public class LoginRequest
{
    [Required(ErrorMessage = "Please enter username")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
