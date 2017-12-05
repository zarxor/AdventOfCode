/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    using System.Collections.Generic;
    using System.Windows;

    public class Day201503 : IDay
    {
        public int Year => 2015;
        public int Day => 3;

        public DayResult GetResult(string input)
        {
            var currentPos = new List<Point>();
            int x = 0, y = 0;

            var housesA = new Dictionary<string, int>();
            var housesB = new Dictionary<string, int> { { "0,0", 1 } };

            for (var i = 0; i < input.Length; i++)
            {
                var id = i % 2;
                if (currentPos.Count <= id)
                {
                    currentPos.Add(new Point());
                }

                var activePos = currentPos[id];

                switch (input[i])
                {
                    case '^':
                        currentPos[id] = new Point(activePos.X, ++activePos.Y);
                        y++;
                        break;

                    case 'v':
                        currentPos[id] = new Point(activePos.X, --activePos.Y);
                        y--;
                        break;

                    case '>':
                        currentPos[id] = new Point(++activePos.X, activePos.Y);
                        x++;
                        break;

                    case '<':
                        currentPos[id] = new Point(--activePos.X, activePos.Y);
                        x--;
                        break;
                }

                var strPos = x + "," + y;
                if (!housesA.ContainsKey(strPos))
                {
                    housesA.Add(strPos, 0);
                }

                housesA[strPos]++;

                var strPosB = activePos.X + "," + activePos.Y;
                if (!housesB.ContainsKey(strPosB))
                {
                    housesB.Add(strPosB, 0);
                }

                housesB[strPosB]++;
            }

            return new DayResult(housesA.Count.ToString(), housesB.Count.ToString());
        }
    }
}