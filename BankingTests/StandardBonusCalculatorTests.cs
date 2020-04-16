using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorTests
    {
        [Fact]
        public void AboveCutoffAndBeforeClose()
        {
            var stubbedSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(stubbedSystemTime.Object);
            stubbedSystemTime.Setup(t => t.GetCurrent()).Returns(new DateTime(2020, 4, 20, 16, 59, 00));
            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(10M, bonus);
        }

        [Fact]
        public void AboveCutoffAndAfterClose()
        {
            var stubbedSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(stubbedSystemTime.Object);
            stubbedSystemTime.Setup(t => t.GetCurrent()).Returns(new DateTime(2020, 4, 20, 17, 00, 00));
            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(5M, bonus);
        }

        [Fact]
        public void BelowCutoffAndAfterClose()
        {
            var bonusCalculator = new StandardBonusCalculator();
            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(9999, 100);

            Assert.Equal(0M, bonus);
        }
    }

    //public class TestingBonusCalculator : StandardBonusCalculator
    //{
    //    private bool IsBeforeCutoff;

    //    public TestingBonusCalculator(bool isBeforeCutoff)
    //    {
    //        IsBeforeCutoff = isBeforeCutoff;
    //    }

    //    protected override bool BeforeCutoff()
    //    {
    //        return IsBeforeCutoff;
    //    }
    //}
}
