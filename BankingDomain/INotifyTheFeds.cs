namespace BankingDomain
{
    public interface INotifyTheFeds
    {
        void Notify(BankAccount bankAccount, decimal amountToWithdraw);
    }
}