using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class Schedule
{
    [Key]
    public int TimeSlotId { get; set; }
    public virtual TimeSlot TimeSlot { get; set; }
    [Key]
    public int YogaClassId { get; set; }
    public virtual YogaClass YogaClass { get; set; }
}
