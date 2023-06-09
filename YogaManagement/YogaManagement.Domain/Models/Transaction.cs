using YogaManagement.Domain.Enums;

namespace YogaManagement.Domain.Models;
public class Transaction
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    public TransactionType TransactionType { get; set; }

    public int WalletId { get; set; }
    public virtual Wallet Wallet { get; set; }
}
