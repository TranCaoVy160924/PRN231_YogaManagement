using Microsoft.EntityFrameworkCore;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class ScheduleRepository : RepositoryBase<Schedule>
{
    public ScheduleRepository(YogaManagementDbContext dbContext) : base(dbContext) { }

    public IQueryable<Schedule> GetAllInclude() =>
         Data
        .Include(x => x.TimeSlot)
        .Include(x => x.YogaClass)
        .Include(x => x.YogaClass)
        .ThenInclude(x => x.Course)
        .AsQueryable();

    public IQueryable<Schedule> GetScheduleOfAClass(int yogaClassId)
    {
        return Data.Where(x => x.YogaClassId == yogaClassId).ToList().AsQueryable();
    }
    public Schedule GetSchedule(int timeSlotId, int yoaClassId)
    {
        return Data.Where(x => x.TimeSlotId == timeSlotId && x.YogaClassId == yoaClassId).FirstOrDefault();
    }

}
