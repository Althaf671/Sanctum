using src.Domain.Common;
using src.Domain.Errors.ValueObjectErrors;
using static src.Domain.Common.StringHelper.StringHelper;

namespace src.Domain.ValueObjects;

public sealed class Url : ValueObject
{
    private const int MinUrlLength = 8;
    private const int MaxUrlLength = 2048;

    public string Value { get; } = null!;

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Value;
    }

    // Factory
    public static Result<Url> Create(string url)
    {
        // pre-validate
        if (IsBlank(url))
            return Result<Url>.Failure(UrlErrors.ValueRequired());

        var trimmedUrl = TrimEdges(url);

        // validate invariant
        var validation = ValidateInvariant(trimmedUrl);
        if (validation.IsFailure)
            return Result<Url>.Failure(validation.Error);

        return Result<Url>.Success(new Url(trimmedUrl));
    }

     private Url() { }

    // Private constructor
    private Url(string cleanUrlValue)
    {
        if (IsBlank(cleanUrlValue))
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
        if (IsBlank(uri.Host))
            return Result.Failure(UrlErrors.UriHostRequired()); 

        // max length 2048 characters
        if (trimmedUrl.Length > MaxUrlLength)
            return Result.Failure(UrlErrors.InvalidLength()); 

        return Result.Success;
    }
}