using src.Domain.Common;
using src.Domain.Entities;
using src.Domain.Entities.MataKuliahAggregate;
using static src.Domain.Common.StringHelper.StringHelper;

namespace src.Domain.Errors.EntityErrors;
public static class MataKuliahErrors
{
    private static readonly string _domain = nameof(MataKuliah);

    public static Error ValueRequired(string input)
    {
        return new Error(
            $"MataKuliahErrors.{RemoveWhiteSpace(input)}Required",
            $"{input} tidak boleh null atau string empty!",
            _domain
        );
    }

    public static Error InvalidInputLength(string input)
    {
        return new Error(
            $"MataKuliahErrors.Invalid{RemoveWhiteSpace(input)}Length",
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

    public static Error MataKuliahWithIdNotFound(Guid mataKuliahId)
    {
        return new Error(
            "MataKuliahErrors.MataKuliahWithIdNotFound",
            $"MataKuliah dengan id: {mataKuliahId} tidak ditemukan.",
            _domain
        );
    }
}