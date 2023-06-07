using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.Member.Response;
public class MemberResponse
{
    public int Id { get; set; }

    public int AppUserId { get; set; }

    public List<int> Enrollments { get; set; }
    //public string AppUserName { get; set; }
}
