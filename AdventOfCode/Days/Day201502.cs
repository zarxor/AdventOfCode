/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    using System.IO;
    using System.Linq;

    public class Day201502 : IDay
    {
        public int Year => 2015;
        public int Day => 2;

        public DayResult GetResult(string input)
        {
            var result = 0;
            var result2 = 0;

            using (var reader = new StringReader(input))
            {
                string line;
                do
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }

                    var rowResult = 0;
                    var rowResult2 = 0;
                    var c = line.Trim().Split('x').Select(i => int.Parse(i)).OrderBy(i => i).ToList();
                    int w = c[0] * c[1],
                        h = c[1] * c[2],
                        l = c[0] * c[2];

                    rowResult += 2 * w + 2 * h + 2 * l;

                    var sideList = new[] { w, h, l }.OrderBy(i => i).ToList();
                    rowResult += sideList.First();
                    result += rowResult;

                    //c = c.OrderBy(i => i).ToList();
                    rowResult2 += c[0] * c[1] * c[2] + c[0] + c[0] + c[1] + c[1];
                    result2 += rowResult2;
                } while (line != null);
            }

            return new DayResult(result.ToString(), result2.ToString());
        }
    }
}