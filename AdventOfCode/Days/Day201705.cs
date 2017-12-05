/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    public class Day201705 : IDay
    {
        public int Year => 2017;
        public int Day => 5;

        public DayResult GetResult(string input)
        {
            var values = Utils.GetValues(input);
            var valuesClone = Utils.Clone(values);

            return new DayResult(PartOne(values), PartTwo(valuesClone));
        }

        private string PartOne(int[] values)
        {
            var curPos = 0;
            var itterations = 0;

            while (curPos < values.Length)
            {
                var curVal = values[curPos];
                values[curPos]++;
                curPos += curVal;
                itterations++;
            }

            return itterations.ToString();
        }

        private string PartTwo(int[] values)
        {
            var curPos = 0;
            var itterations = 0;

            while (curPos < values.Length)
            {
                var curVal = values[curPos];
                values[curPos] += curVal >= 3 ? -1 : 1;
                curPos += curVal;
                itterations++;
            }

            return itterations.ToString();
        }
    }
}