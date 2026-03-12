using src.Modules.AcademicDomain.Entities.SemesterAggregate;
using src.SharedKernel.Domain.Common;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Errors.EntityErrors;
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

    public static Error SemesterWithIdNotFound(Guid semesterId)
    {
        return new Error(
            "SemesterErrors.SemesterWithIdNotFound",
            $"Semester dengan id: {semesterId} tidak ditemukan.",
            _domain
        );
    }
}