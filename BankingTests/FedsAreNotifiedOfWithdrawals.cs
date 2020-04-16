using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class FedsAreNotifiedOfWithdrawals
    {
        [Fact]
        public void FedsAreNotified()
        {
            var fedMock = new Mock<INotifyTheFeds>();
            var account = new BankAccount(null, fedMock.Object);

            account.Withdraw(5);

            // what would we assert on here?
            fedMock.Verify(m => m.Notify(account, 5));
        }
    }
}
