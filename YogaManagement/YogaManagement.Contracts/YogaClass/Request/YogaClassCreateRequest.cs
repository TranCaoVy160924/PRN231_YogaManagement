namespace YogaManagement.Contracts.YogaClass.Request;
public class YogaClassCreateRequest
{
    public string Name { get; set; }
    public int Size { get; set; }
    public bool Status { get; set; }

    public int CourseId { get; set; }
}
