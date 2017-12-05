/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

using System;
using System.Linq;

namespace AdventOfCode
{
    public static class Utils
    {
        public static string[] GetRows(string input) => input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        public static int[] GetValues(string input) => GetRows(input)
                .Select(s => int.Parse(s.Trim()))
                .ToArray();

        public static T Clone<T>(T obj) where T : ICloneable => (T)obj.Clone();
    }
}