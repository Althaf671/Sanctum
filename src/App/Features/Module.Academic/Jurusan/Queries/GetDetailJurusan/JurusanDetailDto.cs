using src.Domain.Enums;
using JurusanEntity = src.Domain.Entities.Jurusan;

namespace src.App.Features.ModuleKuliah.Jurusan.Queries.GetDetailJurusan;

public record JurusanDetailDto(
    Guid JurusanId,
    string KodeJurusan,
    string NamaJurusan,
    string NamaFakultas,
    Jenjang Jenjang,
    Akreditasi Akreditasi,
    DateTime? UpdatedAt,
    DateTime CreatedAt
)
{
    public static JurusanDetailDto FromDomain(JurusanEntity jurusan)
        => new (
            jurusan.Id,
            jurusan.KodeJurusan,
            jurusan.NamaJurusan,
            jurusan.NamaFakultas,
            jurusan.Jenjang,
            jurusan.Akreditasi,
            jurusan.UpdatedAt,
            jurusan.CreatedAt
        );
}
