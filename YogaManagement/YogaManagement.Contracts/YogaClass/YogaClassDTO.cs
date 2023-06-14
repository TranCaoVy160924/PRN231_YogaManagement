using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.YogaClass;
public class YogaClassDTO
{
    // Core
    public int Id { get; set; } = 0;

    [Required]
    public string Name { get; set; }

    [Required]
    public int Size { get; set; }

    [Required]
    public bool Status { get; set; }

    [Required]
    public int CourseId { get; set; }

    // Display
    public string CourseName { get; set; } = "";
}
