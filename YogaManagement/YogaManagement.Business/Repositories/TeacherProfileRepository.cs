using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class TeacherProfileRepository : RepositoryBase<TeacherProfile>
{
    public TeacherProfileRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
