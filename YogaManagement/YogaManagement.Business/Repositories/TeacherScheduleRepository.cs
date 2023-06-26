using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class TeacherScheduleRepository : RepositoryBase<TeacherSchedule>
{
    public TeacherScheduleRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
    public IQueryable<TeacherSchedule> GetScheduleOfATeacher(int id)
    {
        return Data.Where(x => x.TeacherProfileId == id).ToList().AsQueryable();
    }
    public TeacherSchedule GetSchedule(int timeSlotId, int teacherId)
    {
        return Data.Where(x => x.TimeSlotId == timeSlotId && x.TeacherProfileId == teacherId).FirstOrDefault();
    }
}
