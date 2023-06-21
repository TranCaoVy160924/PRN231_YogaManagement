using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Business.Repositories;
public class EnrollmentRepository : RepositoryBase<Enrollment>
{
    public EnrollmentRepository(YogaManagementDbContext dbContext) : base(dbContext) { }
}
