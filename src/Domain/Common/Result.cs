namespace src.Domain.Common;
public sealed record Error(
    string Code, 
    string? Description = null, 
    string? Domain = null)
{
    public static readonly Error None = new(string.Empty); 
}

public class Result
{
    // Constructor
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    
    public bool IsFailure => !IsSuccess; 

    public Error Error { get; }

    public static Result Success => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(T? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static new Result<T> Success(T value) =>
        new (value, true, Error.None);

    public static new Result<T> Failure(Error error) =>
        new (default, false, error);

}

