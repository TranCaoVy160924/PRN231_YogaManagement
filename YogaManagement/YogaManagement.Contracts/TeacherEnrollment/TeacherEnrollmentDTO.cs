namespace YogaManagement.Contracts.TeacherEnrollment;
public class TeacherEnrollmentDTO
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TeacherProfileId { get; set; }
    public int YogaClassId { get; set; }

    // Display
    public string? TeacherName { get; set; }
    public string? ClassName { get; set; }
}
