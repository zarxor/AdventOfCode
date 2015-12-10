using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day2 : IDay
    {
        public int GetDayNumber()
        {
            return 2;
        }

        public DayResult GetResult(string input)
        {
            int result = 0;
            int result2 = 0;

            using (StringReader reader = new StringReader(input))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        int rowResult = 0;
                        int rowResult2 = 0;
                        var c = line.Trim().Split('x').Select(i => Int32.Parse(i)).OrderBy(i => i).ToList();
                        int w = c[0] * c[1],
                            h = c[1] * c[2],
                            l = c[0] * c[2];

                        rowResult += ((2 * w) + (2 * h) + (2 * l));

                        List<int> sideList = new[] { w, h, l }.OrderBy(i => i).ToList();
                        rowResult += sideList.First();
                        result += rowResult;

                        //c = c.OrderBy(i => i).ToList();
                        rowResult2 += (c[0] * c[1] * c[2]) + (c[0] + c[0] + c[1] + c[1]);
                        result2 += rowResult2;
                    }

                } while (line != null);
            }

            return new DayResult(result.ToString(), result2.ToString());
        }
    }
}
