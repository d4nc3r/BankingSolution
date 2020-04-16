using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class OverdraftNotAllowed
    {
        //[Fact]
        //public void SystemCurrentlyAllowsOverdraftButShouldnt()
        //{
        //    var bankAccount = new BankAccount(null);
        //    var openingBalance = bankAccount.GetBalance();

        //    bankAccount.Withdraw(openingBalance + 1M);

        //    Assert.Equal(-1, bankAccount.GetBalance());
        //}

        [Fact]
        public void OverdraftDoesNotRemoveMoneyFromAccount()
        {
            var bankAccount = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            var openingBalance = bankAccount.GetBalance();

            try
            {
                bankAccount.Withdraw(openingBalance + 1M);
            }
            catch (OverdraftException)
            {
                // swallow exception so we can verify the balance
            }

            Assert.Equal(openingBalance, bankAccount.GetBalance());
        }

        [Fact]
        public void OverdraftThrows()
        {
            var bankAccount = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            var openingBalance = bankAccount.GetBalance();

            Assert.Throws<OverdraftException>(() => bankAccount.Withdraw(openingBalance + 1M));

        }

        [Fact]
        public void CanTakeAllMoney()
        {
            var bankAccount = new BankAccount(null, new Mock<INotifyTheFeds>().Object);

            bankAccount.Withdraw(bankAccount.GetBalance());

            Assert.Equal(0, bankAccount.GetBalance());
        }
    }
}
