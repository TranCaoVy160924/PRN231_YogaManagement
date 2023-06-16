using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class CategoryRepository : RepositoryBase<Category>
{
    public CategoryRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
