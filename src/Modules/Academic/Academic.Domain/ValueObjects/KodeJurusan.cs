using System.Text.RegularExpressions;
using src.Modules.AcademicDomain.Errors.ValueObjectErrors;
using src.SharedKernel.Domain.Common;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.ValueObjects;

public sealed partial class KodeJurusan : ValueObject
{
    private const int _minKodeJurusanLength = 5;

    private const int _maxDigitJurusanLength = 6;

    public string Value { get; } = null!;

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Value;
    }

    private KodeJurusan() { }

    private KodeJurusan(string value)
    {
        Value = value;
    }

    public static Result<KodeJurusan> Create(string value)
    {
        var validation = ValidateInvariant(value);
        if (validation.IsFailure)
            return Result<KodeJurusan>.Failure(validation.Error);

        return Result<KodeJurusan>.Success(new KodeJurusan(value));
    }

    public static Result ValidateInvariant(string value)
    {
        if (IsStringInputLengthOutOfRange(value, _minKodeJurusanLength, _maxDigitJurusanLength))
            return Result.Failure(
                KodeJurusanErrors.ValueLengthOutOfRange(_minKodeJurusanLength, _maxDigitJurusanLength));

        if (!NumericOnlyRegex().IsMatch(value))
            return Result.Failure(KodeJurusanErrors.InvalidFormat());

        return Result.Success;
    }
    
    [GeneratedRegex(@"^\d{3,6}$")]
    private static partial Regex NumericOnlyRegex();
}


