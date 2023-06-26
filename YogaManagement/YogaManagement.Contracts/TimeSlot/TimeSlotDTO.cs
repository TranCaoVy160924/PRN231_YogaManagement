using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.TimeSlot;
public class TimeSlotDTO
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    // Time only
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Status { get; set; }
}
