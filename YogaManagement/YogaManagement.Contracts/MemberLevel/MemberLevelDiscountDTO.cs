using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.MemberLevel;
public class MemberLevelDiscountDTO
{
    public int Id { get; set; }
    public double Silver { get; set; }
    public double Gold { get; set; }
    public double Platinum { get; set; }
}
