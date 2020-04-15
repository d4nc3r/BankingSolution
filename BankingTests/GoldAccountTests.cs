using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {
        [Fact]
        public void GoldAccoutnsGetABonusOnDeposits()
        {
            var account = new GoldAccount();
            var originalBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(originalBalance + (amountToDeposit * 1.10M), account.GetBalance());
        }
    }
}
