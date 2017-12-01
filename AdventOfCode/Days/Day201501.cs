// -------------------------------------------------------------------------------------------------
//  <copyright file="Day201501.cs">
//      © Johan Boström 2017
//  </copyright>
// -------------------------------------------------------------------------------------------------

namespace AdventOfCode.Days
{
    public class Day201501 : IDay
    {
        public int Year => 2015;
        public int Day => 1;

        public DayResult GetResult(string input)
        {
            var count = 0;
            var basement = 0;
            for (var i = 0; i < input.Length; i++)
            {
                count += input[i] == '(' ? 1 : -1;
                if (basement == 0 && count == -1)
                {
                    basement = i + 1;
                }
            }

            return new DayResult(count.ToString(), basement.ToString());
        }
    }
}