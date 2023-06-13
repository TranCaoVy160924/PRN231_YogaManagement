using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Authority;
public class UserDTO
{
    // Core
    public int Id { get; set; } = 0;

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public bool Status { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Email { get; set; }

    // Display
    public string Role { get; set; } = "";

    // Edit
    [Required]
    public string Password { get; set; } = "";

    [Required]
    public string ConfirmPassword { get; set; } = "";
}
