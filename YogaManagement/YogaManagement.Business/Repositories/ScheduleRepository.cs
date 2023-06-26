using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class ScheduleRepository : RepositoryBase<Schedule>
{
    public ScheduleRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
    public IQueryable<Schedule> GetScheduleOfAClass(int yogaClassId)
    {
        return Data.Where(x => x.YogaClassId == yogaClassId).ToList().AsQueryable();
    }
    public Schedule GetSchedule(int timeSlotId, int yoaClassId)
    {
        return Data.Where(x => x.TimeSlotId == timeSlotId && x.YogaClassId == yoaClassId).FirstOrDefault();
    }

}
