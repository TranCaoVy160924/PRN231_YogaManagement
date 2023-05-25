using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class TeacherProfile
{
    public int Id { get; set; }

    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

    public virtual ICollection<YogaClass>? YogaClasses { get; set; }
    public virtual ICollection<TimeSlot>? AvailableSlot { get; set; }
}
