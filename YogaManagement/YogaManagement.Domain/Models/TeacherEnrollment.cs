using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class TeacherEnrollment
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int TeacherProfileId { get; set; }
    public virtual TeacherProfile TeacherProfile { get; set; }

    public int YogaClassId { get; set; }
    public virtual YogaClass YogaClass { get; set; }
}
