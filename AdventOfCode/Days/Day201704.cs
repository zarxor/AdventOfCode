/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

using System;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day201704 : IDay
    {
        public int Year => 2017;
        public int Day => 4;

        public DayResult GetResult(string input)
        {
            var rows = input
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries); // Get all rows

            var validRows = rows.Count(IsValid);
            var validRows2 = rows.Count(IsValid2);

            return new DayResult(validRows.ToString(), validRows2.ToString());
        }

        private bool IsValid(string passphrase)
        {
            return passphrase.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).GroupBy(s => s).All(g => g.Count() == 1);
        }

        private bool IsValid2(string passphrase)
        {
            return passphrase
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new String(s.OrderBy(c => c).ToArray()))
                .GroupBy(s => s).All(g => g.Count() == 1);
        }
    }
}