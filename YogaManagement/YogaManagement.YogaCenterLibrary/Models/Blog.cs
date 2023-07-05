using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Blog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? Date { get; set; }

    public string? Header { get; set; }

    public string? Content { get; set; }

    public string? Img { get; set; }
    [JsonIgnore]

    public virtual Account? User { get; set; }
}
