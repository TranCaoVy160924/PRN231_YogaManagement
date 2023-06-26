namespace YogaManagement.Contracts.TimeSlot;
public class TimeSlotDTO
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    // Time only
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public bool Status { get; set; }
}
