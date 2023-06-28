using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Domain.Models;
public class TeacherSchedule
{
    public bool IsTaken { get; set; }
    [Key]
    public int TimeSlotId { get; set; }
    public virtual TimeSlot TimeSlot { get; set; }

    [Key]
    public int TeacherProfileId { get; set; }
    public virtual TeacherProfile TeacherProfile { get; set; }
}
