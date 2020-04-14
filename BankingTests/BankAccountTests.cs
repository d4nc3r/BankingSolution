using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {
            // write the code you WISH you had (WTCYWYH) - Corey Haines
            BankAccount account = new BankAccount();
            decimal balance = account.GetBalance();

            Assert.Equal(1200M, balance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            /// (Arrange) Given - I have a new account and I have the balance of that acocunt
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            /// (Act) When - I deposit $100
            var amountToDeposit = 100M;
            account.Deposit(amountToDeposit);

            /// (Assert) Then - the account balance should be the opening balance plus 100
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }

        [Fact]
        public void WithdrawalsDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 42M;
            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
    }
}
