using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.ValueObjects;
using MateriEntity = src.Modules.AcademicDomain.Entities.MataKuliahAggregate.Materi;

namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriDetail;

public record MateriDetailDto(
    Guid MataKuliahId,
    Guid MateriId,
    int PertemuanKe,
    IsiMateri IsiMateri,
    TipeMateri TipeMateri,
    bool IsSudahDibaca,
    DateTime? DibacaAt,
    DateTime? UpdatedAt,
    DateTime CreatedAt,
    int TotalTugas
)
{
    public static MateriDetailDto FromDomain(MateriEntity materi)
        => new(
            materi.MataKuliahId,
            materi.Id,
            materi.PertemuanKe,
            materi.IsiMateri,
            materi.TipeMateri,
            materi.IsSudahDibaca,
            materi.DibacaAt,
            materi.UpdatedAt,
            materi.CreatedAt,
            materi.Tugas.Count
        );
}