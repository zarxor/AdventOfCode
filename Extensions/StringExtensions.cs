public static class StringExtensions
{
    public static List<string> GetRows(this string str)
    {
        return str.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
    }
}