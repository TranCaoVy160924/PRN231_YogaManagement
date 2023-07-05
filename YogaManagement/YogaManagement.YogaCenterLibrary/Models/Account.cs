using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Account
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public bool? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public string? ValidationCode { get; set; }

    public bool? Deleted { get; set; }

    public string? Img { get; set; }
    [JsonIgnore]
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    [JsonIgnore]

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    [JsonIgnore]

    public virtual ICollection<ClassDetail> ClassDetails { get; set; } = new List<ClassDetail>();
    [JsonIgnore]

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    [JsonIgnore]

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    [JsonIgnore]

    public virtual Role? Role { get; set; }
}
