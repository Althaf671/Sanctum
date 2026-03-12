using src.SharedKernel.Domain.ValueObjects;
using TugasEntity = src.Modules.AcademicDomain.Entities.MataKuliahAggregate.Tugas;

namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasDetail;

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