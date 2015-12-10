using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day1 : IDay
    {
        public int GetDayNumber()
        {
            return 1;
        }

        public DayResult GetResult(string input)
        {
            int count = 0;
            int _basement = 0;
            for (int i = 0; i < input.Length; i++)
            {
                count += input[i] == '(' ? 1 : -1;
                if (_basement == 0 && count == -1)
                    _basement = i + 1;
            }

            return new DayResult(count.ToString(), _basement.ToString());
        }
    }
}
