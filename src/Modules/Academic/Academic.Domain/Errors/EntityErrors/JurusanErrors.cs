using src.Modules.AcademicDomain.Entities;
using src.SharedKernel.Domain.Common;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Errors.EntityErrors;
public static class JurusanErrors
{
    private static readonly string _domain = nameof(Jurusan);

    public static Error ValueRequired(string input)
    {
        return new Error(
            $"JurusanErrors.{RemoveWhiteSpace(input)}Required",
            $"{input} tidak boleh null atau string empty!",
            _domain
        );
    }

    public static Error InvalidInputLength(string input)
    {
        return new Error(
            $"JurusanErrors.Invalid{RemoveWhiteSpace(input)}Length",
            $"{input} tidak boleh kurang dari 10 atau lebih dari 40 karakter!",
            _domain
        );
    }

    public static Error JurusanWithIdNotFound(Guid jurusanId)
    {
        return new Error(
            "JurusanErrors.JurusanWithIdNotFound",
            $"Jurusan dengan id: {jurusanId} tidak ditemukan.",
            _domain
        );
    }
}