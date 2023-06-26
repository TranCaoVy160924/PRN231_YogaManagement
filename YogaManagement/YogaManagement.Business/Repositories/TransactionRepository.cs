using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class TransactionRepository : RepositoryBase<Transaction>
{
    public TransactionRepository(YogaManagementDbContext context) : base(context) { }
}
