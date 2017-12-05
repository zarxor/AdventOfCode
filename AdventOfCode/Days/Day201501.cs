/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

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