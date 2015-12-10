using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            List<Point> currentPos = new List<Point>();
            int x = 0, y = 0;

            Dictionary<string, int> housesA = new Dictionary<string, int>();
            Dictionary<string, int> housesB = new Dictionary<string, int>();
            housesB.Add("0,0", 1);

            for (int i = 0; i < input.Length; i++)
            {
                var _id = i % 2;
                if (currentPos.Count <= _id)
                    currentPos.Add(new Point());

                var _activePos = currentPos[_id];

                switch (input[i])
                {
                    case '^':
                        currentPos[_id] = new Point(_activePos.X, ++_activePos.Y);
                        y++;
                        break;

                    case 'v':
                        currentPos[_id] = new Point(_activePos.X, --_activePos.Y);
                        y--;
                        break;

                    case '>':
                        currentPos[_id] = new Point(++_activePos.X, _activePos.Y);
                        x++;
                        break;

                    case '<':
                        currentPos[_id] = new Point(--_activePos.X, _activePos.Y);
                        x--;
                        break;
                }

                string strPos = x + "," + y;
                if (!housesA.ContainsKey(strPos))
                    housesA.Add(strPos, 0);

                housesA[strPos]++;

                string strPosB = _activePos.X + "," + _activePos.Y;
                if (!housesB.ContainsKey(strPosB))
                    housesB.Add(strPosB, 0);

                housesB[strPosB]++;
            }

            return new DayResult(housesA.Count.ToString(), housesB.Count.ToString());
        }
    }
}
