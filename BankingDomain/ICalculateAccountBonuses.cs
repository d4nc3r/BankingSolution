using System;

namespace BankingDomain
{
    public interface ICalculateAccountBonuses
    {
        decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit);
    }
}