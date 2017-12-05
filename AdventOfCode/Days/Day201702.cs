/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    using System;
    using System.Linq;

    public class Day201702 : IDay
    {
        public int Year => 2017;
        public int Day => 2;

        public DayResult GetResult(string input)
        {
            var rows = input
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries); // Get all rows

            var sumOne = 0;
            var sumTwo = 0;

            foreach (var row in rows)
            {
                var largest = 0;
                var smallest = 9999;

                var numbers = row
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);

                foreach (var num in numbers)
                {
                    foreach (var denum in numbers.Where(n => n < num))
                    {
                        if (num % denum != 0)
                            continue;

                        sumTwo += num / denum;

                        break;
                    }

                    if (num > largest)
                        largest = num;

                    if (num < smallest)
                        smallest = num;
                }

                sumOne += (largest - smallest);
            }

            return new DayResult(sumOne.ToString(), sumTwo.ToString());
        }
    }
}