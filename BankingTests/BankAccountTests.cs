using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        BankAccount Account;
        decimal OpeningBalance;

        public BankAccountTests()
        {
            Account = new BankAccount(new Mock<ICalculateAccountBonuses>().Object,
                new Mock<INotifyTheFeds>().Object);
            OpeningBalance = Account.GetBalance();
        }

        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {
            // write the code you WISH you had (WTCYWYH) - Corey Haines
            Assert.Equal(1200M, OpeningBalance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            /// (Arrange) Given - I have a new account and I have the balance of that acocunt
            /// (Act) When - I deposit $100
            var amountToDeposit = 100M;
            Account.Deposit(amountToDeposit);

            /// (Assert) Then - the account balance should be the opening balance plus 100
            Assert.Equal(OpeningBalance + amountToDeposit, Account.GetBalance());
        }

        [Fact]
        public void WithdrawalsDecreaseBalance()
        {
            var amountToWithdraw = 42M;
            Account.Withdraw(amountToWithdraw);

            Assert.Equal(OpeningBalance - amountToWithdraw, Account.GetBalance());
        }
    }
}
