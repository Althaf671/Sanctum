namespace src.SharedKernel.Domain.Common.StringHelper;

public static class StringHelper
{
    /// <summary>
    /// This method is a wrapper for isNullOrWhitespace() method.
    /// It's purpose is just to follow ubiqitous language.
    /// </summary>
    /// <returns>true or false</returns>
    public static bool IsBlank(string input) =>
        string.IsNullOrWhiteSpace(input);

    /// <summary>
    /// This method is a wrapper for trim() method.
    /// </summary>
    /// <returns>string without whitespace in the edges of it</returns>
    public static string TrimEdges(string input) =>
        input.Trim();

    /// <summary>
    /// It will compare is input bigger or smaller than respective limit.
    /// </summary>
    /// <returns>true or false</returns>
    public static bool IsStringInputLengthOutOfRange(string input, int min, int max)
    {
        if (min > max)
            throw new InvalidDataException("Min value limit can't be bigger than max value limit");

        return input.Length < min || input.Length > max;
    }

    /// <summary>
    /// It wrap replace method 
    /// </summary>
    /// <returns>it will remove any white space inside a string</returns>
    public static string RemoveWhiteSpace(string input) =>
        input.Replace(" ", "");

    public static string StringfyInput(string input) =>
        input.ToString();
}

