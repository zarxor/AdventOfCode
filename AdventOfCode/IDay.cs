// -------------------------------------------------------------------------------------------------
//  <copyright file="IDay.cs">
//      © Johan Boström 2017
//  </copyright>
// -------------------------------------------------------------------------------------------------

namespace AdventOfCode
{
    public interface IDay
    {
        int Year { get; }
        int Day { get; }
        DayResult GetResult(string input);
    }
}