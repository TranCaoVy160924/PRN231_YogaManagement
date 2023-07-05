using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? TraineeId { get; set; }

    public int? CourseId { get; set; }

    public int? Rating { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }
    [JsonIgnore]

    public virtual Course? Course { get; set; }
    [JsonIgnore]

    public virtual Account? Trainee { get; set; }
}
