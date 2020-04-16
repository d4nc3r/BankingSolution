using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class StandardBonusCalculator
    {
        // Poor-person's dependency injection
        ISystemTime _systemTime;

        public StandardBonusCalculator(ISystemTime systemTime) // constructor for Testing only
        {
            _systemTime = systemTime;
        }

        public StandardBonusCalculator() // constructor for Prod
        {
            _systemTime = new SystemTime();
        }

        public decimal CalculateBonusUsingStandardAlgorithm(decimal balance, decimal amount)
        {
            // if the balance is above a certain cutoff & the time is before the close of day
            // they get a 10% bonus on deposits, if it's above the cutoff and after close of day
            // they get 5%
            if (HasBonusWorthyBalance(balance) && BeforeCutoff())
            {
                return amount * .10M;
            }
            if (HasBonusWorthyBalance(balance))
            {
                return amount * .05M;
            }
            return 0;
        }

        private static bool HasBonusWorthyBalance(decimal balance)
        {
            return balance > 10000; // JFHCI
        }

        protected virtual bool BeforeCutoff()
        {
            return _systemTime.GetCurrent().Hour <= 16;
        }
    }
}
