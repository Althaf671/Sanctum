using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Errors.ValueObjectErrors;
public static class MasaKuliahErrors
{
    private static readonly string _domain = nameof(MasaKuliah);

    public static Error InvalidSemesterPeriod()
    {
        return new Error(
            "MasaKuliahErrors.InvalidSemesterPeriod",
            "Hanya boleh memilih semester Ganjil atau Genap!",
            _domain
        );
    }

    public static Error CantStartAfterEnd()
    {
        return new Error(
            "MasaKuliahErrors.CantStartAfterEnd",
            "Periode awal harus tidak sesudah periode akhir!",
            _domain
        );
    }
}