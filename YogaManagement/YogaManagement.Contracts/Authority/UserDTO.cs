namespace YogaManagement.Contracts.Authority;
public class UserDTO
{
    // Display
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Status { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    // Edit
    public string Password { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";
}
