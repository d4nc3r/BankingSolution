﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
}
