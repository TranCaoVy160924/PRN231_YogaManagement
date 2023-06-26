using YogaManagement.Client.OdataClient.YogaManagement.Contracts.TimeSlot;

namespace YogaManagement.Client.Models;

public class ScheduleViewModel
{
    public int Id { get; set; }
    public List<TimeSlotDTO> TimeSlots { get; set; }

    public ScheduleViewModel()
    {
        TimeSlots = new List<TimeSlotDTO>();
    }
}
