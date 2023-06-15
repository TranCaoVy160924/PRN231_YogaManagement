using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Domain.Enums;
public enum UserRoles
{
    [Display(Name = "Member")]
    Member,
    [Display(Name = "Teacher")]
    Teacher,
    [Display(Name = "Staff")]
    Staff
}
