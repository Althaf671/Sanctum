using src.Modules.AcademicDomain.Entities.MahasiswaAggregate;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Errors.EntityErrors;
public static class MahasiswaErrors
{
    private static readonly string _domain = nameof(Mahasiswa);

    public static Error UserNotFound()
    {
        return new Error(
            "MahasiswaErrors.UserNotFound",
            "User dengan ID ini tidak ditemukan",
            _domain
        );
    }
}