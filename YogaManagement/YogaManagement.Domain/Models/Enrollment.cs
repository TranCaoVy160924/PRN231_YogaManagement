namespace YogaManagement.Domain.Models;
public class Enrollment
{
    public DateTime EnrollDate { get; set; }
    public double Discount { get; set; }
    public double Amount { get; set; }

    public int MemberId { get; set; }
    public virtual Member Member { get; set; }

    public int YogaClassId { get; set; }
    public virtual YogaClass YogaClass { get; set; }
}
