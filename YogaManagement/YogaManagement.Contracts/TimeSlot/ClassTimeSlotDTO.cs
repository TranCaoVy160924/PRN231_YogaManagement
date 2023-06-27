using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Domain.Models;

namespace YogaManagement.Contracts.TimeSlot;
public class ClassTimeSlotDTO
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public string ClassName { get; set; }
    public string CourseName { get; set; }
}
