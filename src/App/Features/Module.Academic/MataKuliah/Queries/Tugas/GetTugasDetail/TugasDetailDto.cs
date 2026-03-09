using src.Domain.ValueObjects;
using TugasEntity = src.Domain.Entities.MataKuliahAggregate.Tugas;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Tugas.GetTugasDetail;

public record TugasDetailDto(
    Guid TugasId,
    string JudulTugas,
    Url LinkPengerjaanTugas,
    Url LinkPnegumpulanTugas,
    bool IsTugasDikumpul,
    bool IsDeleted,
    DateTime? UpdatedAt,
    DateTime CreatedAt
)
{
    public static TugasDetailDto FromDomain(TugasEntity tugas)
        => new(
            tugas.Id,
            tugas.JudulTugas,
            tugas.LinkPengerjaanTugas,
            tugas.LinkPengumpulanTugas,
            tugas.IsTugasDikumpul,
            tugas.IsDeleted,
            tugas.UpdatedAt,
            tugas.CreatedAt
        );
}