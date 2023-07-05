using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Class
{
    public int Id { get; set; }

    public string? ClassName { get; set; }

    public int? TrainerId { get; set; }

    public int? CourseId { get; set; }

    public string? Room { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Status { get; set; }

    public bool? Finished { get; set; }
    [JsonIgnore]

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    [JsonIgnore]

    public virtual ICollection<ClassDetail> ClassDetails { get; set; } = new List<ClassDetail>();
    [JsonIgnore]

    public virtual Course? Course { get; set; }
    [JsonIgnore]

    public virtual Timetable? Timetable { get; set; }
    [JsonIgnore]

    public virtual Account? Trainer { get; set; }
}
