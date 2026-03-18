using src.SharedKernel.Domain.Common;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Errors.EntityErrors;

public static class UniversitasErrors
{
    private static readonly string _domain = "Mahasiswa.Universitas";

    public static Error ValueRequired(string input)
    {
        return new Error(
            $"UniversitasErrors.{RemoveWhiteSpace(input)}.Required",
            $"{input} tidak boleh kosong atau whitespace",
            _domain
        );
    }

    public static Error InvalidInputLength(string input, int min, int max)
    {
        return new Error(
            $"UniversitasErrors.Invalid{RemoveWhiteSpace(input)}Length",
            $"{input} tidak boleh kurang dari {min} atau lebih dari {max} karakter!",
            _domain
        );
    }
}