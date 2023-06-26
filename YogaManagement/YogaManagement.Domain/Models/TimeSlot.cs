namespace YogaManagement.Domain.Models;
public class TimeSlot
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    // Time only
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Room { get; set; }
    public bool Status { get; set; }

    public virtual ICollection<Schedule>? Schedule { get; set; }
    public virtual ICollection<TeacherProfile>? AvailableTeacher { get; set; }
}
