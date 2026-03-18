using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Errors.EntityErrors;

public static class PertemuanErrors
{
    private static readonly string _domain = nameof(Pertemuan);

    public static Error TanggalPertemuanInvalid()
    {
        return new Error(
            "PertemuanErrors.TanggalPertemuanInvalid",
            "Tanggal pertemuan tidak valid.",
            _domain
        );
    }

    public static Error InvalidPertemuanKe()
    {
        return new Error(
            "PertemuanErrors.InvalidPertemuanKe",
            "Pertemuan ke tidak boleh di bawah 1 atau di atas 16",
            _domain
        );
    }
}