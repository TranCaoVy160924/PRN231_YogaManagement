using YogaManagement.Domain.Enums;

namespace YogaManagement.Domain.Models;
public class Member
{
    public int Id { get; set; }

    public MemberLevel MemberLevel { get; set; }

    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}
