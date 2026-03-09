using src.Domain.Enums;
using src.Domain.ValueObjects;
using MateriEntity = src.Domain.Entities.MataKuliahAggregate.Materi;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriDetail;

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