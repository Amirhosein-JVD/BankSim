public interface ITransferService
{
    void Transfer(IAccount from, IAccount to, Money amount, string description= "" );
}