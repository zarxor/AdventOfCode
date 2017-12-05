/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    public class Day201701 : IDay
    {
        public int Year => 2017;
        public int Day => 1;

        public DayResult GetResult(string input)
        {
            if (input.Length < 2 || input.Length % 2 > 0)
                return new DayResult("ERROR", "ERROR");

            var sumOne = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var i2 = (i + 2) > input.Length ? 0 : i + 1;
                var a = int.Parse(input[i].ToString());
                var b = int.Parse(input[i2].ToString());

                if (a == b)
                {
                    sumOne += a;
                }
            }

            var sumTwo = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var i2 = i + (input.Length / 2);
                if (i2 >= input.Length)
                    i2 -= input.Length;

                var a = int.Parse(input[i].ToString());
                var b = int.Parse(input[i2].ToString());

                if (a == b)
                {
                    sumTwo += a;
                }
            }

            return new DayResult(sumOne.ToString(), sumTwo.ToString());
        }
    }
}