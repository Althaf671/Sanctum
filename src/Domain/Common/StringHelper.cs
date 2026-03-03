namespace src.Domain.Common.StringHelper;

public static class StringHelper
{
    /// <summary>
    /// This method is a wrapper for isNullOrWhitespace() method.
    /// It's purpose is just to follow ubiqitous language.
    /// </summary>
    /// <param name="input">it required a string input</param>
    /// <returns>true or false</returns>
    public static bool IsBlank(string input) =>
        string.IsNullOrWhiteSpace(input);

    /// <summary>
    /// This method is a wrapper for trim() method.
    /// </summary>
    /// <param name="input">it required a string input</param>
    /// <returns>string without whitespace in the edges of it</returns>
    public static string TrimEdges(string input) =>
        input.Trim();

    /// <summary>
    /// It will compare is input bigger or smaller than respective limit.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns>true or false</returns>
    public static bool IsStringInputLengthOutOfRange(string input, int min, int max)
    {
        if (min > max)
            throw new InvalidDataException("Min value limit can't be bigger than max value limit");

        return input.Length < min || input.Length > max;
    }
    
}
