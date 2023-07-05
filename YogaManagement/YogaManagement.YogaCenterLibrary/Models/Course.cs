using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? CourseName { get; set; }

    public double? Price { get; set; }

    public double? Discount { get; set; }

    public int? LevelId { get; set; }

    public string? Description { get; set; }

    public string? Img { get; set; }

    public bool? Deleted { get; set; }
    [JsonIgnore]

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    [JsonIgnore]

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    [JsonIgnore]

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    [JsonIgnore]

    public virtual Level? Level { get; set; }
}
