using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }
    [JsonIgnore]

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
