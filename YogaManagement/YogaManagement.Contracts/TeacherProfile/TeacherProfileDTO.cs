using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Domain.Models;

namespace YogaManagement.Contracts.TeacherProfile;
public class TeacherProfileDTO
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public string Name { get; set; }
}
