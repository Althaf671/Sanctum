using src.Domain.Common;
using src.Domain.Errors.ValueObjectErrors;

namespace src.Domain.ValueObjects;

public sealed class Url : ValueObject
{
    private const int MinUrlLength = 8;
    private const int MaxUrlLength = 2048;

    public string Value { get; } 

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Value;
    }

    // Factory
    public static Result<Url> Create(string url)
    {
        // pre-validate
        if (string.IsNullOrWhiteSpace(url))
            return Result<Url>.Failure(UrlErrors.ValueRequired());

        var trimmedUrl = url.Trim();

        // validate invariant
        var validation = ValidateInvariant(trimmedUrl);
        if (validation.IsFailure)
            return Result<Url>.Failure(validation.Error);

        return Result<Url>.Success(new Url(trimmedUrl));
    }

    // Private constructor
    private Url(string cleanUrlValue)
    {
        if (string.IsNullOrWhiteSpace(cleanUrlValue))
            throw new InvalidValueObjectState("IMPOSSIBLE_STATE: value url harus mustahil kosong!");
            
        Value = cleanUrlValue;
    }

    // Validate invariant
    public static Result ValidateInvariant(string trimmedUrl)
    {
        if (trimmedUrl.Length < MinUrlLength)
            return Result.Failure(UrlErrors.InvalidLength()); 

        if (!Uri.TryCreate(trimmedUrl, UriKind.Absolute, out var uri))
            return Result.Failure(UrlErrors.InvalidFormat()); 

        // Hanya terima HTTPS
        if (uri!.Scheme != Uri.UriSchemeHttps)
            return Result.Failure(UrlErrors.OnlyHttpsAllowed()); 

        // Host tidak boleh kosong
        if (string.IsNullOrWhiteSpace(uri.Host))
            return Result.Failure(UrlErrors.UriHostRequired()); 

        // max length 2048 characters
        if (trimmedUrl.Length > MaxUrlLength)
            return Result.Failure(UrlErrors.InvalidLength()); 

        return Result.Success;
    }
}