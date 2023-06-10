using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.YogaClass.Request;
public class YogaClassUpdateRequest
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The class's name can not be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please define the class's size")]
    public int Size { get; set; }
    public bool Status { get; set; }
    [Required]
    public int CourseId { get; set; }
}
