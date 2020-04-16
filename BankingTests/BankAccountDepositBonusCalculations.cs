using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountDepositBonusCalculations
    {
        [Theory]
        [InlineData(100, 42)]
        [InlineData(150, 12)]
        public void DepositUsesBonusCalculator(decimal amountToDeposit, decimal bonus)
        {
            // make sure the bonus calculator
            // 1. is given the right arguments (balance, amountOfDeposit)
            // 2. and the amount returns from it is added to the deposit
            
            // Given
            var stubbedBonusCalculator = new Mock<ICalculateAccountBonuses>();
            var account = new BankAccount(stubbedBonusCalculator.Object, null);
            var openingBalance = account.GetBalance();
            stubbedBonusCalculator.Setup(b => b.GetDepositBonusFor(openingBalance, amountToDeposit)).Returns(bonus);
            
            // When
            account.Deposit(amountToDeposit);

            // Then
            Assert.Equal(openingBalance + amountToDeposit + bonus, account.GetBalance());
        }
    }
}
