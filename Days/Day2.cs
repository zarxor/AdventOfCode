using AdventOfCode;
using AdventOfCode.Models;

public class Day2 : IDay
{
    public int Year => 2021;

    public int Day => 2;

    public string[] GetResult(string inputData)
    {
        var steps = inputData.GetRows().Select(r => r.Split(' ')).Select(x => new { direction = x[0], count = int.Parse(x[1]) });
        int pos = 0, depth = 0, aim = 0;
        foreach (var step in steps)
        {
            switch (step.direction)
            {
                case "forward":
                    pos += step.count;
                    break;
                case "up":
                    depth -= step.count;
                    break;
                case "down":
                    depth += step.count;
                    break;
            }
        }

        var part1 = (pos * depth).ToString();
        pos = 0; depth = 0; aim = 0;

        foreach (var step in steps)
        {
            switch (step.direction)
            {
                case "forward":
                    pos += step.count;
                    depth += (aim * step.count);
                    break;
                case "up":
                    aim -= step.count;
                    break;
                case "down":
                    aim += step.count;
                    break;
            }
        }

        return new string[] {
            part1,
            (pos * depth).ToString()
        };
    }
}