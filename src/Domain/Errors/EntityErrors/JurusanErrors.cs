using src.Domain.Common;
using src.Domain.Entities;
using static src.Domain.Common.StringHelper.StringHelper;

namespace src.Domain.Errors.EntityErrors;
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

}