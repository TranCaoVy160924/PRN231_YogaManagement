using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.Course.Request;
public class CourseUpdateRequest
{
    [Required]
    public int Id { get; set; }   
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
}
