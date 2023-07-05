using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class ClassDetail
{
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public int? TraineeId { get; set; }
    [JsonIgnore]

    public virtual Class? Class { get; set; }
    [JsonIgnore]

    public virtual Account? Trainee { get; set; }
}
