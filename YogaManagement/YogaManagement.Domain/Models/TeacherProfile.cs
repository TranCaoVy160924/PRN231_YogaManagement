﻿namespace YogaManagement.Domain.Models;
public class TeacherProfile
{
    public int Id { get; set; }

    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

    public virtual ICollection<TeacherEnrollment>? TeacherEnrollments { get; set; }
    public virtual ICollection<TimeSlot>? AvailableSlot { get; set; }
}
