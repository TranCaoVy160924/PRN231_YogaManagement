using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Timetable
{
    public int Id { get; set; }

    public int? ClassId { get; set; }
    [JsonIgnore]

    public virtual Class? Class { get; set; }
    [JsonIgnore]

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
