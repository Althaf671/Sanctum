using src.Domain.Common;
using src.Domain.Entities.SemesterAggregate;
using static src.Domain.Common.StringHelper.StringHelper;

namespace src.Domain.Errors.EntityErrors;
public static class SemesterErrors
{
    private static readonly string _domain = nameof(Semester);

    public static Error ValueRequired(string input)
    {
        return new Error(
            $"SemesterErrors.{RemoveWhiteSpace(input)}.Required",
            $"{input} tidak boleh kosong atau whitespace",
            _domain
        );
    }

    public static Error InvalidTahunAjaranLength()
    {
        return new Error(
            "SemesterErrors.InvalidTahunAjaranLength",
            "Min atau max tahun ajaran adalah 10 atau 20 karakter",
            _domain
        );
    }
}