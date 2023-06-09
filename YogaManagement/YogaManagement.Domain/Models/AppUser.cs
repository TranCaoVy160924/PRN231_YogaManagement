using Microsoft.AspNetCore.Identity;

namespace YogaManagement.Domain.Models;
public class AppUser : IdentityUser<int>
{
    public bool Status { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public virtual Member? Member { get; set; }
    public virtual TeacherProfile? TeacherProfile { get; set; }
}
