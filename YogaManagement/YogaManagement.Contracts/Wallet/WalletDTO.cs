using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Domain.Models;

namespace YogaManagement.Contracts.Wallet;
public class WalletDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public bool IsAdminWallet { get; set; }

    public int AppUserId { get; set; }
}
