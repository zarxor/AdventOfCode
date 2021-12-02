namespace AdventOfCode.Models
{
    public interface IDay
    {
        int Year { get; }
        int Day { get; }

        string[] GetResult(string inputData);
    }
}