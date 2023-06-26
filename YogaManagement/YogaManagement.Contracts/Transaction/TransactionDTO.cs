namespace YogaManagement.Contracts.Transaction;
public class TransactionDTO
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string TransactionType { get; set; }

    public int WalletId { get; set; }
}
