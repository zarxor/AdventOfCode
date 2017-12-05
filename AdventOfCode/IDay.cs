/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode
{
    public interface IDay
    {
        int Year { get; }
        int Day { get; }

        DayResult GetResult(string input);
    }
}