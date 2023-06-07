namespace YogaManagement.Domain.Models;
public class Wallet
{
    public int Id { get; set; }
    public double Balance { get; set; }

    public int MemberId { get; set; }
    public virtual Member Member { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }
}
