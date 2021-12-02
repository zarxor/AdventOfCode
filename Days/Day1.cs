using AdventOfCode;
using AdventOfCode.Models;

public class Day1 : IDay
{
    public int Year => 2021;

    public int Day => 1;

    public string[] GetResult(string inputData)
    {
        var inputs = inputData.GetRows()
            .Select(s => int.Parse(s))
            .ToList();

        int increased = 0, previous = -1;

        foreach (var input in inputs)
        {
            if (previous >= 0 && input > previous)
            {
                increased++;
            }
            previous = input;
        }

        var part1 = increased.ToString();

        var inputGrouped = new List<int>();
        for (var i = 0; i < (inputs.Count - 2); i++)
        {
            inputGrouped.Add(inputs[i] + inputs[i + 1] + inputs[i + 2]);
        }
        
        increased = 0; previous = -1;
        foreach (var input in inputGrouped)
        {
            if (previous >= 0 && input > previous)
            {
                increased++;
            }
            previous = input;
        }

        var part2 = increased.ToString();

        return new string[] { part1, part2 };
    }
}