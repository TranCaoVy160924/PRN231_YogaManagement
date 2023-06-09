namespace YogaManagement.Contracts.YogaClass.Request;
public class YogaClassCreateRequest
{
    [Required(ErrorMessage ="The class's name can not be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please define the class's size")]
    public int Size { get; set; }
    public bool Status { get; set; }
    [Required]
    public int CourseId { get; set; }
}
