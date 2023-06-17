using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class YogaClassRepository : RepositoryBase<YogaClass>
{
    public YogaClassRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
