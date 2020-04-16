using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now; // only place in the app allowed to touch this untestable thing
        }
    }
}
