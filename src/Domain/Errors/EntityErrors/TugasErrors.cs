using src.Domain.Common;
using src.Domain.Entities.MataKuliahAggregate;

namespace src.Domain.Errors.EntityErrors;
public static class TugasErrors
{
    private static readonly string _domain = nameof(Tugas);

    public static Error JudulTugasRequired()
    {
        return new Error(
            "TugasErrors.JudulTugasRequired",
            "Judul tugas tidak boleh kosong!",
            _domain
        );
    }

    public static Error JudulTugasLengthOutOfRange()
    {
        return new Error(
            "TugasErrors.JudulTugasRequired",
            "Judul tugas tidak boleh kosong!",
            _domain
        );
    }

    public static Error TugasWithIdNotFound(Guid tugasId)
    {
        return new Error(
            "TugasErrors.TugasWithIdNotFound",
            $"Tugas dengan id: {tugasId} tidak ditemukan",
            _domain
        );
    }
}