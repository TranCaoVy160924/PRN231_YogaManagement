using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class MemberRepository : RepositoryBase<Member>
{
    public MemberRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
