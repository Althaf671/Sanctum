using src.Domain.Common;
using src.Domain.Entities.MataKuliahAggregate;

namespace src.Domain.Errors.EntityErrors;
public static class MateriErrors
{
    private static readonly string _domain = nameof(Materi);

    public static Error JudulMateriRequired()
    {
        return new Error(
            "MateriErrors.JudulMateriRequired",
            "Judul materi harus di isi atau tidak boleh string kosong!",
            _domain  
        );  
    }

    public static Error PertemuanOutOfRange()
    {
        return new Error(
            "MateriErrors.PertemuanOutOfRange",
            "Pertemuan tidak boleh kurang dari 1 atau tidak boleh lebih dari 14",
            _domain
        );
    }

    public static Error MateriWithIdNotFound(Guid materiId)
    {
        return new Error(
            "MateriErrors.MateriWithIdNotFound",
            $"Materi dengan id: {materiId} tidak ditemukan.",
            _domain
        );
    }
}