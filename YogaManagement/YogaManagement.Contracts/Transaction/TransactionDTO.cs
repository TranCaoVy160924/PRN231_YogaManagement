using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaManagement.Domain.Enums;

namespace YogaManagement.Contracts.Transaction;
public class TransactionDTO
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    public string TransactionType { get; set; }

    public int WalletId { get; set; }
}
