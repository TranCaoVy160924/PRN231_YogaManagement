using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class WalletRepository : RepositoryBase<Wallet>
{
    public WalletRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
