using Microsoft.AspNetCore.Identity;

namespace YogaManagement.Domain.Models;
public class AppRole : IdentityRole<int>
{
    public string Description { get; set; }
}
