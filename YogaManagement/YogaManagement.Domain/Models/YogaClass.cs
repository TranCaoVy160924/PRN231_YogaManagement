using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class YogaClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public bool Status { get; set; }

    public virtual Course Course { get; set; }
    public virtual TeacherProfile? TeacherProfile { get; set; }
    public virtual ICollection<TimeSlot> TimeSlots { get; set; } 
}
