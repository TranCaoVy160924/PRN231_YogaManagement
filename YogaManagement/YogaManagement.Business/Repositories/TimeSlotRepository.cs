using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class TimeSlotRepository : RepositoryBase<TimeSlot>
{
    public TimeSlotRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
