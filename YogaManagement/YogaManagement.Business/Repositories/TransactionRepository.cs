using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Database.EF;

namespace YogaManagement.Business.Repositories;
public class TransactionRepository : RepositoryBase<TransactionRepository>
{
    public TransactionRepository(YogaManagementDbContext context) : base(context) { }
}
