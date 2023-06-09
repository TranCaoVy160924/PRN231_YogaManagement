namespace YogaManagement.Contracts.YogaClass.Response;
public class YogaClassResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public bool Status { get; set; }

    public int CourseId { get; set; }
    public string CourseName { get; set; }
}
