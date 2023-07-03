namespace YogaManagement.Domain.Models;
public class Wallet
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public double TotalDeposit { get; set; }
    public bool IsAdminWallet { get; set; }

    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }
}
