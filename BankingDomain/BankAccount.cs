using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1200;
        private ICalculateAccountBonuses _bonusCalculator;
        private INotifyTheFeds _feds;

        public BankAccount(ICalculateAccountBonuses bonusCalculator, INotifyTheFeds feds)
        {
            _bonusCalculator = bonusCalculator;
            _feds = feds;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdraw;
            _feds.Notify(this, amountToWithdraw);
        }
    }
}