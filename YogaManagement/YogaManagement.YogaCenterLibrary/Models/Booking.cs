using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YogaCenterLibrary.Models;

public partial class Booking
{
    public int Id { get; set; }

    public string? PaymentTransactionId { get; set; }

    public double? Amount { get; set; }

    public int? Status { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? PayDate { get; set; }

    public DateTime? RefundDate { get; set; }

    public int? AccountId { get; set; }

    public int? ClassId { get; set; }

    public int? CourseId { get; set; }
    [JsonIgnore]

    public virtual Account? Account { get; set; }
    [JsonIgnore]

    public virtual Class? Class { get; set; }
    [JsonIgnore]

    public virtual Course? Course { get; set; }
}
