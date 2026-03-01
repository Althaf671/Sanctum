using System.Text.RegularExpressions;
using src.Domain.Common;
using src.Domain.Errors.ValueObjectErrors;

namespace src.Domain.ValueObjects;

public sealed class IsiMateri : ValueObject
{
    private const int MaxRingkasanLength = 500;
    private const int MinRingkasanLength = 10;

    public Url OriginalFileURL { get; }

    public string Ringkasan { get; }

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return OriginalFileURL;
        yield return Ringkasan;
    }

    // Factory
    public static Result<IsiMateri> Create(string originalFileURL, string ringkasan)
    {   
        // pre-validation for ringkasan
        if (string.IsNullOrWhiteSpace(ringkasan))
            return Result<IsiMateri>.Failure(IsiMateriErrors.RingkasanRequired());

        // validasi url
        var validUrl = Url.Create(originalFileURL);
        if (validUrl.IsFailure)
            return Result<IsiMateri>.Failure(validUrl.Error);

        // validasi invariant - url sudah divalidasi oleh Url 
        var validation = ValidateInvariant(ringkasan);
        if (validation.IsFailure)
            return Result<IsiMateri>.Failure(validation.Error);

        return Result<IsiMateri>.Success(new IsiMateri(validUrl.Value!, ringkasan));
    }

    // Private constructor
    private IsiMateri(Url validUrl, string ringkasan)
    {
        var checkValidUrl = validUrl.Value;
        if (string.IsNullOrWhiteSpace(ringkasan) || string.IsNullOrWhiteSpace(checkValidUrl))
            throw new InvalidValueObjectState(
                "IMPOSSIBLE_STATE: Isi materi ringkasan dan valid url harus mustahil kosong!");

        OriginalFileURL = validUrl;
        Ringkasan = ringkasan;
    }

    // Validate invariant
    public static Result ValidateInvariant(string ringkasan)
    {
        // min 10 karakter dan maks 1000 karakter
        if (IsRingkasanLengthOutOfRange(ringkasan))
            return Result.Failure(IsiMateriErrors.InvalidRingkasanCharacterLength());

        return Result.Success;
    }

    private static bool IsRingkasanLengthOutOfRange(string ringkasan) =>
        ringkasan.Length < MinRingkasanLength || ringkasan.Length > MaxRingkasanLength;

}