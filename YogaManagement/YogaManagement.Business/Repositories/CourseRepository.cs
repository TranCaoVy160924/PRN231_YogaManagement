using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class CourseRepository : RepositoryBase<Course>
{
    public CourseRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
