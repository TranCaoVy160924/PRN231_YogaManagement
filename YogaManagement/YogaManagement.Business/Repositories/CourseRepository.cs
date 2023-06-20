using Microsoft.EntityFrameworkCore;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class CourseRepository : RepositoryBase<Course>
{
    public CourseRepository(YogaManagementDbContext dbContext) : base(dbContext) { }

    public override async Task<Course> Get(int id) => await Data
        .Include(c => c.YogaClasses)
        .ThenInclude(c => c.Enrollments)
        .SingleOrDefaultAsync(c => c.Id == id);

}
