/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    public class Day201703 : IDay
    {
        public int Year => 2017;
        public int Day => 3;

        public enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }

        public DayResult GetResult(string input)
        {
            var gridPartOne = new List<Point>();
            var gridPartTwo = new Dictionary<Point, int>();
            var inputNumber = int.Parse(input);
            //var sideSize = 1;
            //while (sideSize * sideSize < inputNumber)
            //    sideSize += 2;

            var direction = Direction.Right;
            var currentPos = new Point(0, 0);

            var add = false;
            var steps = 1;

            for (var i = 0; i <= inputNumber; i++)
            {
                for (var i2 = 0; i2 < steps; i2++)
                {
                    gridPartOne.Add(currentPos);

                    Step(direction, ref currentPos);

                    i++;
                }
                i--;

                direction = GetNewDirection(direction);

                if (add)
                    steps++;

                add = !add;
            }

            var result1 = Math.Abs(gridPartOne[inputNumber - 1].X) + Math.Abs(gridPartOne[inputNumber - 1].Y);

            #region Part 2

            add = false;
            steps = 1;
            currentPos = new Point(0, 0);

            var currentSum = 0;

            for (var i = 0; currentSum <= inputNumber; i++)
            {
                for (var i2 = 0; i2 < steps; i2++)
                {
                    currentSum = gridPartTwo
                        .Where(kvp =>
                            kvp.Key.X <= (currentPos.X + 1)
                            && kvp.Key.X >= (currentPos.X - 1)
                            && kvp.Key.Y <= (currentPos.Y + 1)
                            && kvp.Key.Y >= (currentPos.Y - 1))
                        .Sum(kvp => kvp.Value);

                    if (currentSum < 1)
                        currentSum = 1;

                    gridPartTwo.Add(currentPos, currentSum);

                    if (currentSum > inputNumber)
                        break;

                    Step(direction, ref currentPos);

                    i++;
                }

                if (currentSum > inputNumber)
                    break;

                i--;

                direction = GetNewDirection(direction);

                if (add)
                    steps++;

                add = !add;
            }

            #endregion Part 2

            return new DayResult(result1.ToString(), currentSum.ToString());
        }

        public Direction GetNewDirection(Direction currentDirection)
        {
            if (currentDirection == Direction.Up)
                return Direction.Left;
            else if (currentDirection == Direction.Down)
                return Direction.Right;
            else if (currentDirection == Direction.Right)
                return Direction.Up;
            else
                return Direction.Down;
        }

        public void Step(Direction direction, ref Point point)
        {
            switch (direction)
            {
                case Direction.Up:
                    point.Y++;
                    break;

                case Direction.Down:
                    point.Y--;
                    break;

                case Direction.Right:
                    point.X++;
                    break;

                case Direction.Left:
                    point.X--;
                    break;
            };
        }
    }
}