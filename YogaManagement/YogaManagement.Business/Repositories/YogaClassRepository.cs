using Microsoft.EntityFrameworkCore;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class YogaClassRepository : RepositoryBase<YogaClass>
{
    public YogaClassRepository(YogaManagementDbContext dbContext) : base(dbContext) { }

    public override async Task<YogaClass> Get(int id) => await Data
        .Include(yc => yc.Enrollments)
        .Include(yc => yc.TeacherEnrollments)
        .Include(yc => yc.Course)
        .SingleOrDefaultAsync(yc => yc.Id == id);
}
