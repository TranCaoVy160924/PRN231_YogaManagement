using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Course;
public class CourseDTO
{
    // Core
    public int Id { get; set; } = 0;

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "The value must be greater than zero.")]
    public double Price { get; set; }

    [Required]
   // [Range(typeof(DateTime), "1/1/2000", "12/31/2100", ErrorMessage = "The value must be a valid date.")]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime StartDate { get ; set; }

    [Required]
    //[Range(typeof(DateTime), "1/1/2000", "12/31/2100", ErrorMessage = "The value must be a valid date.")]
    //[Compare(nameof(StartDate), ErrorMessage = "End Day must be after Start Day.")]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EnddDate { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public int CategoryId { get; set; }

    // Display
    public string CategoryName { get; set; } = "";
}
