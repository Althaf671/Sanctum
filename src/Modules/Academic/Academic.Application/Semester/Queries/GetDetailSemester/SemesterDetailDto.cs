using src.Modules.AcademicDomain.ValueObjects;
using SemesterEntity = src.Modules.AcademicDomain.Entities.SemesterAggregate.Semester;

namespace src.Modules.Academic.App.Semester.Queries.GetDetailSemester;

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
   