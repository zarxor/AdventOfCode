using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day3 : IDay
    {
        public int GetDayNumber()
        {
            return 3;
        }

        public DayResult GetResult(string input)
        {
            //int count = 0;
            int x = 0, y = 0;
            Dictionary<string, int> pos = new Dictionary<string, int>();

            foreach (char c in input)
            {
                switch (c)
                {
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '<':
                        x--;
                        break;
                }

                string strPos = x + "," + y;
                if (!pos.ContainsKey(strPos))
                    pos.Add(strPos, 0);

                pos[strPos]++;
            }

            return new DayResult(pos.Count.ToString());
        }
    }
}
