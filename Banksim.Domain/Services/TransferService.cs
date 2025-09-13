public class TransferService : ITransferService
{
    public void Transfer(IAccount from, IAccount to, Money amount, string description = "")
    {
        from.Withdraw(amount, TransactionType.TransferOut, description);
        to.Deposit(amount, TransactionType.TransferIn, description);
    }
}