using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Domain.Enums;
public enum UserRoles
{
    [Display(Name = "Member")]
    Member = 1,
    [Display(Name = "Teacher")]
    Teacher = 2,
    [Display(Name = "Staff")]
    Staff = 3
}
