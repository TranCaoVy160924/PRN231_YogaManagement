using System;
using System.Collections.Generic;

namespace YogaCenterLibrary.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string? SettingName { get; set; }

    public double? ActiveValue { get; set; }

    public DateTime? ActiveDate { get; set; }

    public double? PreactiveValue { get; set; }
}
