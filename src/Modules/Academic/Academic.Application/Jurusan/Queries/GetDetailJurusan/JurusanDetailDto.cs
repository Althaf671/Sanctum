using src.Modules.AcademicDomain.Enums;
using JurusanEntity = src.Modules.AcademicDomain.Entities.Jurusan;

namespace src.Modules.Academic.App.Jurusan.Queries.GetDetailJurusan;

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
