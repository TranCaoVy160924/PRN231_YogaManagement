namespace YogaManagement.Domain.Models;
public class YogaClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public bool Status { get; set; }

    public int CourseId { get; set; }
    public virtual Course Course { get; set; }
    public virtual ICollection<TeacherEnrollment>? TeacherEnrollments { get; set; }
    public virtual ICollection<Enrollment>? Enrollments { get; set; }
    public virtual ICollection<TimeSlot> TimeSlots { get; set; }
}
