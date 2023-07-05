using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Level
{
    public int Id { get; set; }

    public string? LevelName { get; set; }
    [JsonIgnore]

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
