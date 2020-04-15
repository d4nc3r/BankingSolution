namespace BankingDomain
{
    public class GoldAccount : BankAccount
    {
        public override void Deposit(decimal amountToDeposit)
        {
            decimal bonus = amountToDeposit * .10M;
            base.Deposit(amountToDeposit + bonus);
        }
    }
}