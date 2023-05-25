using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class Enrollment
{
    public DateTime EnrollDate { get; set; }
    public double Discount { get; set; }
    public double Amount { get; set; }

    public int MembershipId { get; set; }
    public virtual Membership Membership { get; set; }

    public int CourseId { get; set; }
    public virtual Course Course { get; set; }
}
