using Microsoft.EntityFrameworkCore;
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
    public  Enrollment GetEnrollment(int memberId, int yogaClassId)
    {
        return  Data.Where(x => x.YogaClassId == yogaClassId && x.MemberId == memberId).SingleOrDefault();
    }
}
