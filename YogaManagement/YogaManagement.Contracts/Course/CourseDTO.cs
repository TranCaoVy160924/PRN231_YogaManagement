using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Course;
public class CourseDTO
{
    // Core
    public int Id { get; set; } = 0;

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EnddDate { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public int CategoryId { get; set; }

    // Display
    public string CategoryName { get; set; } = "";
}
