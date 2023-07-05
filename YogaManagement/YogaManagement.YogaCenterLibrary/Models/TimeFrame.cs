using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class TimeFrame
{
    public int Id { get; set; }

    public string? TimeFrame1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
