using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Errors.ValueObjectErrors;

public static class KodeJurusanErrors
{
    private static readonly string _domain = nameof(KodeJurusan);

    public static Error ValueLengthOutOfRange(int min, int max)
    {
        return new Error(
            "KodeJurusanErrors.ValueLengthOutOfRange",
            $"Input tidak boleh lebih dari {min} atau kurang dari {max}",
            _domain
        );
    }

    public static Error InvalidFormat()
    {
        return new Error(
            "KodeJurusanErrors.NonNumericStringInput",
            "Input hanya boleh dalam bentuk numeric",
            _domain
        );
    }
}