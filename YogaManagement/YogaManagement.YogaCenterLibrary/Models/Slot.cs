using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Slot
{
    public int Id { get; set; }

    public int? TimetableId { get; set; }

    public string? DayOfWeek { get; set; }

    public int? TimeFrameId { get; set; }
    [JsonIgnore]

    public virtual TimeFrame? TimeFrame { get; set; }
    [JsonIgnore]

    public virtual Timetable? Timetable { get; set; }
}
