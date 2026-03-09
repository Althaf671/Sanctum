using src.Domain.ValueObjects;
using SemesterEntity = src.Domain.Entities.SemesterAggregate.Semester;

namespace src.App.Features.ModuleKuliah.Semester.Queries.GetDetailSemester;

public record SemesterDetailDto(
    Guid Id,
    MasaKuliah MasaKuliah,
    string TahunAjaran,
    DateTime CreatedAt
)
{
    public static SemesterDetailDto FromDomain(SemesterEntity semester)
        => new (
            semester.Id,
            semester.MasaKuliah,
            semester.TahunAjaran,
            semester.CreatedAt
        );
}
   