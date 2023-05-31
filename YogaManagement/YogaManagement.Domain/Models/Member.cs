using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class Member
{
    public int Id { get; set; }

    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

    public virtual Wallet? Wallet { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}
