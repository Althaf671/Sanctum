using src.Domain.Common;
using src.Domain.Errors.ValueObjectErrors;

namespace src.Domain.ValueObjects;

public sealed class Url : ValueObject
{
    public string Value { get; } 

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Value;
    }

    // Factory
    public static Result<Url> Create(string urlValue)
    {
        // pre-validate
        if (string.IsNullOrWhiteSpace(urlValue))
            return Result<Url>.Failure(UrlErrors.ValueRequired());

        var cleanUrlValue = urlValue.Trim();

        // validate invariant
        var validation = ValidateInvariant(cleanUrlValue);
        if (validation.IsFailure)
            return Result<Url>.Failure(validation.Error);

        return Result<Url>.Success(new Url(cleanUrlValue));
    }

    // Private constructor
    private Url(string cleanUrlValue)
    {
        if (string.IsNullOrWhiteSpace(cleanUrlValue))
            throw new InvalidValueObjectState("IMPOSSIBLE_STATE: value url harus mustahil kosong!");
            
        Value = cleanUrlValue;
    }

    // Validate invariant
    public static Result ValidateInvariant(string cleanUrlValue)
    {
        if (!Uri.TryCreate(cleanUrlValue, UriKind.Absolute, out var uri))
            return Result.Failure(UrlErrors.InvalidFormat()); 

        // Hanya terima HTTPS
        if (uri!.Scheme != Uri.UriSchemeHttps)
            return Result.Failure(UrlErrors.OnlyHttpsAllowed()); 

        // Host tidak boleh kosong
        if (string.IsNullOrWhiteSpace(uri.Host))
            return Result.Failure(UrlErrors.UriHostRequired()); 

        // min length 8 max length 2048 characters
        if (cleanUrlValue.Length < 8 || cleanUrlValue.Length > 2048)
            return Result.Failure(UrlErrors.InvalidLength()); 

        return Result.Success;
    }
}