using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Errors.ValueObjectErrors;
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