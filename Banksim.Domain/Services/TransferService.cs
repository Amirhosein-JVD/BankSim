public class TransferService : ITransferService
{
    public void Transfer(IAccount from, IAccount to, Money amount, string description = "")
    {
        if (from == null || to == null) throw new ArgumentException();
        if (ReferenceEquals(from, to)) throw new DomainException("Can nt transfer to same account!");
        from.Withdraw(amount, TransactionType.TransferOut, description);
        to.Deposit(amount, TransactionType.TransferIn, description);
    }
}