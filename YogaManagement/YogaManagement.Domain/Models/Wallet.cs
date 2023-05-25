using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class Wallet
{
    public int Id { get; set; }
    public double Balance { get; set; }

    public int MemberShipId { get; set; }
    public virtual Membership Membership { get; set; }
}
