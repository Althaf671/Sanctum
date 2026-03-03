using src.Domain.Common;
using src.Domain.Entities;

namespace src.Domain.Errors.EntityErrors;
public static class MataKuliahErrors
{
    private static readonly string _domain = nameof(MataKuliah);

    public static Error ValueRequired(string input)
    {
        return new Error(
            "MataKuliahErrors.ValueRequired",
            $"{input} tidak boleh null atau string empty!",
            _domain
        );
    }

    public static Error InvalidInputLength(string input)
    {
        return new Error(
            "MataKuliahErrors.InvalidInputLength",
            $"{input} tidak boleh kurang dari 10 atau lebih dari 40 karakter!",
            _domain
        );
    }

    public static Error InvalidSksLength()
    {
        return new Error(
            "MataKuliahErrors.InvalidSksLength",
            "Input SKS tidak boleh kurang dari 1 atau lebih dari 3!",
            _domain       
        );
    }
}