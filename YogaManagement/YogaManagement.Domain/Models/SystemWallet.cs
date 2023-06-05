using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Domain.Models;
public class SystemWallet
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public DateTime LastUpdated { get; set; }
}
