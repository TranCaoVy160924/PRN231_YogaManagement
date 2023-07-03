namespace YogaManagement.Contracts.Wallet;
public class WalletDTO
{
    public int Id { get; set; }
    public double Balance { get; set; }
    public double TotalDeposit { get; set; }
    public bool IsAdminWallet { get; set; }

    public int AppUserId { get; set; }
}
