﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    interface IDay
    {
        int GetDayNumber();
        DayResult GetResult(string input);
    }
}
