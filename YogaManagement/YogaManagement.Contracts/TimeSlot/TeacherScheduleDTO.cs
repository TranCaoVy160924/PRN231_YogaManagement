using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.TimeSlot;
public class TeacherScheduleDTO
{
    public bool IsTaken { get; set; }
    public int TimeSlotId { get; set; }
    public int TeacherProfileId { get; set; }
}
